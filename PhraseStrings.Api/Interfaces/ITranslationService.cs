using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Interfaces;

public interface ITranslationService
{
    public Task<List<Translation>?> GetAll(string projectId);

    public Task<List<Translation>?> GetByLocale(string projectId, string localeId);
}
