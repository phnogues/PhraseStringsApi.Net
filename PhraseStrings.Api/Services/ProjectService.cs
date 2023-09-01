using PhraseStrings.Api.Interfaces;
using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Services;

internal class ProjectService : BaseService, IProjectService
{
    internal ProjectService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Project>?> GetAll()
    {
        var result = await GetList<List<Project>>($"projects");

        return result;
    }

    public async Task<List<Locale>?> GetLocales(string projectId)
    {
        var result = await GetList<List<Locale>>($"projects/{projectId}/locales");

        return result;
    }
}