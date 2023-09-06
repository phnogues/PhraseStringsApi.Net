namespace PhraseStrings.Api.Interfaces;

public interface IProjectService
{
    public Task<List<Project>?> GetAll(string? q = null);

    public Task<Project?> GetByName(string projectName);

    public Task<Project?> Add(ProjectRequest project);

    public Task<List<Locale>?> GetLocales(string projectId);

    public Task<Locale?> AddLocale(string projectId, LocaleRequest locale);
}
