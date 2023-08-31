using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Interfaces;

public interface IProjectService
{
    public Task<List<Project>?> GetAll();

    public Task<List<Locale>?> GetLocales(string projectId);
}
