using PhraseStrings.Api.Interfaces;
using PhraseStrings.Api.Model;
using System.Text.Json;

namespace PhraseStrings.Api.Services;

internal class ProjectService : BaseService, IProjectService
{
    internal ProjectService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions) : base(httpClient, jsonSerializerOptions)
    {
    }

    public async Task<List<Project>?> GetAll()
    {
        var result = await GetListAsync<List<Project>>($"projects");

        return result;
    }

    public async Task<List<Locale>?> GetLocales(string projectId)
    {
        var result = await GetListAsync<List<Locale>>($"projects/{projectId}/locales");

        return result;
    }
}