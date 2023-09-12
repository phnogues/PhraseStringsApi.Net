namespace PhraseStrings.Api.Interfaces;

public interface ITranslationService
{
    Task<List<Translation>?> GetAll(string projectId, int perPage = 100, int? page = null);

    Task<List<Translation>?> GetByLocale(string projectId, string localeId);

    Task<List<Translation>?> GetByKey(string projectId, string keyId);

    Task<Translation?> Add(string projectId, TranslationRequest translation);

    Task<Translation?> Update(string projectId, string translationId, TranslationRequest translation);
}
