namespace PhraseStrings.Api.Services;

internal class KeyService : BaseService, IKeyService
{
    internal KeyService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Key>?> GetAll(string projectId)
    {
        return await GetList<List<Key>>($"projects/{projectId}/keys");
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
}