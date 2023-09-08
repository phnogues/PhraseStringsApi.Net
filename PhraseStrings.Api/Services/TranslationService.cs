namespace PhraseStrings.Api.Services;

internal class TranslationService : BaseService, ITranslationService
{
    internal TranslationService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Translation>?> GetAll(string projectId, int perPage = 100, int? page = null)
    {
        string url = $"projects/{projectId}/translations?per_page={perPage}";

        List<Translation> results = new List<Translation>();
        int maxPages = 10000;

        if (page.HasValue)
        {
            return await GetList<List<Translation>>($"{url}&page={page}");
        }
        else
        {
            // Phrase doesn't return the total number of pages, so we have to guess
            page = 1;

            while (page < maxPages)
            {
                var pageResults = await GetList<List<Translation>>($"{url}&page={page}");
                if (pageResults is not null && pageResults.Any())
                {
                    results.AddRange(pageResults);
                    page++;
                }
                else
                {
                    break;
                }
            }
        }

        return results;
    }

    public async Task<List<Translation>?> GetByLocale(string projectId, string localeId)
    {
        return await GetList<List<Translation>>($"projects/{projectId}/locales/{localeId}/translations");
    }

    public async Task<List<Translation>?> GetByKey(string projectId, string keyId)
    {
        return await GetList<List<Translation>>($"projects/{projectId}/keys/{keyId}/translations");
    }

    public async Task<Translation?> Add(string projectId, TranslationRequest translation)
    {
        return await Post<TranslationRequest, Translation>($"projects/{projectId}/translations", translation);
    }

    public async Task<Translation?> Update(string projectId, string translationId, TranslationRequest translation)
    {
        return await Patch<TranslationRequest, Translation>($"projects/{projectId}/translations/{translationId}", translation);
    }
}
