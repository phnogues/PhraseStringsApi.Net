namespace PhraseStrings.Api.Interfaces;

public interface IKeyService
{
    Task<List<Key>?> GetAll(string projectId);

    Task<Key?> GetById(string projectId, string keyId);

    Task<SearchKeyResult?> GetByName(string projectId, string keyName);

    Task<List<SearchKeyResult>?> Search(string projectId, SearchKeyRequest keyRequest);

    Task<Key?> Add(string projectId, Key key);
}
