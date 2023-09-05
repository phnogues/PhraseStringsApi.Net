using PhraseStrings.Api.Model;

namespace PhraseStrings.Api.Interfaces;

public interface IProjectService
{
    public Task<List<Project>?> GetAll(string? q = null);

    public Task<Project?> GetByName(string projectName);

    public Task<List<Locale>?> GetLocales(string projectId);
}
