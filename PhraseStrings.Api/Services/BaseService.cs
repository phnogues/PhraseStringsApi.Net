using System.Text.Json;

namespace PhraseStrings.Api.Services;

internal abstract class BaseService
{
    protected HttpClient HttpClient;
    protected JsonSerializerOptions JsonSerializerOptions;

    internal BaseService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        HttpClient = httpClient;
        JsonSerializerOptions = jsonSerializerOptions;
    }

    protected async Task<TResult?> GetAsync<TResult>(string requestUri)
    {
        var result = await HttpClient.GetAsync(requestUri);

        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return default;

        HandleError(result);

        var json = await result.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResult?>(json);
    }

    protected async Task<TResult?> GetListAsync<TResult>(string requestUri)
    {
        var result = await HttpClient.GetAsync(requestUri);

        HandleError(result);

        var json = await result.Content.ReadAsStringAsync();

        var model = JsonSerializer.Deserialize<TResult>(json);

        return model;
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

            default:
                throw new Exception($"An error occured: {responseMessage.StatusCode}");
        }
    }
}
