using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Cryptography;
using System.Text;

namespace PhraseStrings.Api.ActionFilters;

public class PhraseApiHmacAuthenticationAttribute : ActionFilterAttribute
{
    public string AuthenticationHeaderName { get; set; } = "X-PhraseApp-Signature";

    public required string Secret { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
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

