using PhraseStrings.Api.Utilities;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PhraseStrings.Api.Services;

internal abstract class BaseService
{
    private const string XRateLimitLimitHeader = "X-Rate-Limit-Limit";
    private const string XRateLimitRemainingHeader = "X-Rate-Limit-Remaining";
    private const string XRateLimitResetHeader = "X-Rate-Limit-Reset";

    protected HttpClient HttpClient;
    protected JsonSerializerOptions JsonSerializerOptions;

    internal BaseService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumMemberConverter() }
        };
    }

    protected async Task<TResult?> Get<TResult>(string requestUri)
    {
        var result = await HttpClient.GetAsync(requestUri);

        ReadLimitVariables(result);

        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return default;

        HandleError(result);

        return await HandleResult<TResult>(result);
    }

    protected async Task<TResult?> GetList<TResult>(string requestUri)
    {
        var result = await HttpClient.GetAsync(requestUri);

        ReadLimitVariables(result);
        HandleError(result);

        return await HandleResult<TResult>(result);
    }

    protected async Task<TResult?> Post<TRequest, TResult>(string requestUri, TRequest request, bool contentAsFormData = false)
    {
        HttpResponseMessage result;

        if (contentAsFormData)
        {
            var data = request.ToPhraseDatasKeyValue();
            result = await HttpClient.PostAsync(requestUri, new FormUrlEncodedContent(data));
        }
        else
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(request, JsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            result = await HttpClient.SendAsync(requestMessage);
        }

        ReadLimitVariables(result);
        HandleError(result);

        return await HandleResult<TResult>(result);
    }

    protected async Task<TResult?> Patch<TRequest, TResult>(string requestUri, TRequest request)
    {
        var data = request.ToPhraseDatasKeyValue();
        var result = await HttpClient.PatchAsync(requestUri, new FormUrlEncodedContent(data));

        ReadLimitVariables(result);
        HandleError(result);

        return await HandleResult<TResult>(result);
    }

    protected async Task<bool?> Delete(string requestUri)
    {
        var result = await HttpClient.DeleteAsync(requestUri);

        ReadLimitVariables(result);
        HandleError(result);

        return result.IsSuccessStatusCode;
    }

    protected bool MatchesWildcard(string data, string wildcard)
    {
        var pattern = $"^{wildcard.Replace("*", ".*?")}$";
        return Regex.IsMatch(data, pattern, RegexOptions.IgnoreCase);
    }

    private async Task<TResult?> HandleResult<TResult>(HttpResponseMessage result)
    {
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResult?>(json);
    }

    private void HandleError(HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
            return;

        switch (responseMessage.StatusCode)
        {
            case System.Net.HttpStatusCode.Unauthorized:
                throw new Exception("Unauthorized, please check your Api Token");

            case System.Net.HttpStatusCode.NotFound:
                throw new Exception("NotFound, Please check your parameters (ProjectId)");

            case System.Net.HttpStatusCode.UnprocessableEntity:
                throw new Exception("UnprocessableEntity, Please check your content object, the item may already be used");

            default:
                throw new Exception($"An error occured: {responseMessage.StatusCode}");
        }
    }

    private void ReadLimitVariables(HttpResponseMessage response)
    {
        if (response is null)
            return;

        var headers = response.Headers;

        if (headers.Contains(XRateLimitLimitHeader) && headers.TryGetValues(XRateLimitLimitHeader, out IEnumerable<string>? xRateLimitLimitHeaderValues))
        {
            if (int.TryParse(xRateLimitLimitHeaderValues?.FirstOrDefault(), out int result))
            {
                lock (LimitVariables.NumberOfAllowedRequestsLock)
                {
                    LimitVariables.NumberOfAllowedRequests = result;
                }
            }
        }

        if (headers.Contains(XRateLimitRemainingHeader) && headers.TryGetValues(XRateLimitRemainingHeader, out IEnumerable<string>? xRateLimitRemainingHeaderValues))
        {
            if (int.TryParse(xRateLimitRemainingHeaderValues?.FirstOrDefault(), out int result))
            {
                lock (LimitVariables.NumberOfRemainingRequestsLock)
                {
                    LimitVariables.NumberOfRemainingRequests = result;
                }
            }
        }

        if (headers.Contains(XRateLimitResetHeader) && headers.TryGetValues(XRateLimitResetHeader, out IEnumerable<string>? values))
        {
            if (long.TryParse(values?.FirstOrDefault(), out long result))
            {
                lock (LimitVariables.DateTimeOfLimitResetingLock)
                {
                    LimitVariables.DateTimeOfLimitReseting = DateTimeOffset.FromUnixTimeSeconds(result);
                }
            }
        }
    }
}
