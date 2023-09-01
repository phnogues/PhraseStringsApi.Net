using PhraseStrings.Api.Interfaces;
using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Services;

internal class TranslationService : BaseService, ITranslationService
{
    internal TranslationService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Translation>?> GetAll(string projectId)
    {
        var result = await GetList<List<Translation>>($"projects/{projectId}/translations");

        return result;
    }

    public async Task<List<Translation>?> GetByLocale(string projectId, string localeId)
    {
        var result = await GetList<List<Translation>>($"projects/{projectId}/locales/{localeId}/translations");

        return result;
    }
}
