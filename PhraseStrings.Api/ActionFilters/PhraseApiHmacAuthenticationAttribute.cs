using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using System.Text;

namespace PhraseStrings.Api.ActionFilters;

/// <summary>
/// If you do not choose a secret, it will be searched in the 
/// key vault or settings file with the key "Phrase:Secret". The setting key can be overridden
/// </summary>
public class PhraseApiHmacAuthenticationAttribute : ActionFilterAttribute
{
    public string AuthenticationHeaderName { get; set; } = "X-PhraseApp-Signature";

    public string? Secret { get; set; }

    public string SecretAppSettingKey { get; set; } = "Phrase:Secret";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // If no secret is defined, we can't authenticate
        if (string.IsNullOrEmpty(Secret) && string.IsNullOrEmpty(SecretAppSettingKey))
        {
            throw new ArgumentNullException("Please define a secret key");
        }

        // If no secret is defined, we try to get it from the KeyVault or app settings
        if (string.IsNullOrEmpty(Secret))
        {
            var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
            Secret = config[SecretAppSettingKey];
        }

        bool isAuthenticated = IsAuthenticated(context);

        if (!isAuthenticated)
        {
            context.Result = new UnauthorizedObjectResult("Not authorized");
        }

        base.OnActionExecuting(context);
    }

    private bool IsAuthenticated(ActionExecutingContext context)
    {
        var headers = context.HttpContext.Request.Headers;

        var signature = GetHttpRequestHeader(headers, AuthenticationHeaderName);
        if (string.IsNullOrEmpty(signature))
            return false;

        var bodyStream = new StreamReader(context.HttpContext.Request.Body);
        bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
        var baseString = bodyStream.ReadToEnd();

        return IsAuthenticated(Secret, baseString, signature);
    }

    private static bool IsAuthenticated(string hashedPassword, string message, string signature)
    {
        if (string.IsNullOrEmpty(hashedPassword))
            return false;

        var verifiedHash = ComputeHash(hashedPassword, message);
        if (signature != null && signature.Equals(verifiedHash))
            return true;

        return false;
    }

    private static string ComputeHash(string hashedPassword, string message)
    {
        var key = Encoding.UTF8.GetBytes(hashedPassword);
        string hashString;

        using (var hmac = new HMACSHA256(key))
        {
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            hashString = Convert.ToBase64String(hash);
        }

        return hashString;
    }

    private static string GetHttpRequestHeader(IHeaderDictionary headers, string headerName)
    {
        return headers.ContainsKey(headerName) ? headers[headerName].ToString() : string.Empty;
    }
}

