using PhraseStrings.Api.Interfaces;
using PhraseStrings.Api.Model;
using System.Text.Json;

namespace PhraseStrings.Api.Services;

internal class TranslationService : BaseService, ITranslationService
{
    internal TranslationService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions) : base(httpClient, jsonSerializerOptions)
    {
    }

    public async Task<List<Translation>?> GetAll(string projectId)
    {
        var result = await GetListAsync<List<Translation>>($"projects/{projectId}/translations");

        return result;
    }

    public async Task<List<Translation>?> GetByLocale(string projectId, string localeId)
    {
        var result = await GetListAsync<List<Translation>>($"projects/{projectId}/locales/{localeId}/translations");

        return result;
    }
}
