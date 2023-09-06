namespace PhraseStrings.Api.Services;

internal class KeyService : BaseService, IKeyService
{
    internal KeyService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Key>?> GetAll(string projectId)
    {
        var result = await GetList<List<Key>>($"projects/{projectId}/keys");

        return result;
    }

    public async Task<Key?> GetById(string projectId, string keyId)
    {
        var result = await Get<Key>($"projects/{projectId}/keys/{keyId}");

        return result;
    }

    public async Task<Key?> Add(string projectId, Key key)
    {
        var result = await Post<Key, Key>($"projects/{projectId}/keys", key);

        return result;
    }
}