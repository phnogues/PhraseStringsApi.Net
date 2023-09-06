namespace PhraseStrings.Api.Interfaces;

public interface ITranslationService
{
    public Task<List<Translation>?> GetAll(string projectId, int perPage = 100, int? page = null);

    public Task<List<Translation>?> GetByLocale(string projectId, string localeId);

    public Task<List<Translation>?> GetByKey(string projectId, string keyId);

    public Task<Translation?> Add(string projectId, TranslationRequest translation);

    public Task<Translation?> Update(string projectId, string translationId, TranslationRequest translation);
}
