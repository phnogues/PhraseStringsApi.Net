using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Interfaces;

public interface IKeyService
{
    Task<List<Key>?> GetAll(string projectId);

    Task<Key?> GetById(string projectId, string keyId);

    Task<Key?> Add(string projectId, Key key);
}
