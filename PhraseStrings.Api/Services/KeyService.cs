namespace PhraseStrings.Api.Services;

internal class KeyService : BaseService, IKeyService
{
    internal KeyService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Key>?> GetAll(string projectId, int perPage = 100, int? page = null)
    {
        string url = $"projects/{projectId}/keys?per_page={perPage}";

        List<Key> results = new();
        int maxPages = 10000;

        if (page.HasValue)
        {
            return await GetList<List<Key>>($"{url}&page={page}");
        }
        else
        {
            // Phrase doesn't return the total number of pages, so we have to guess
            page = 1;

            while (page < maxPages)
            {
                var pageResults = await GetList<List<Key>>($"{url}&page={page}");
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

    public async Task<Key?> GetById(string projectId, string keyId)
    {
        return await Get<Key>($"projects/{projectId}/keys/{keyId}");
    }

    public async Task<SearchKeyResult?> GetByName(string projectId, string keyName)
    {
        SearchKeyRequest searchKeyRequest = new SearchKeyRequest()
        {
            Query = keyName
        };

        var results = await Search(projectId, searchKeyRequest);
        return results?.Where(r => r.Name.Equals(keyName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
    }

    public async Task<List<SearchKeyResult>?> Search(string projectId, SearchKeyRequest searchKeyRequest)
    {
        return await Post<SearchKeyRequest, List<SearchKeyResult>>($"projects/{projectId}/keys/search", searchKeyRequest, contentAsFormData: true);
    }

    public async Task<Key?> Add(string projectId, Key key)
    {
        return await Post<Key, Key>($"projects/{projectId}/keys", key);
    }

    public async Task<bool?> Delete(string projectId, string keyId)
    {
        return await Delete($"projects/{projectId}/keys/{keyId}");
    }
}