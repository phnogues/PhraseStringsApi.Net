namespace PhraseStrings.Api.Interfaces;

public interface IProjectService
{
    Task<List<Project>?> GetAll(string? q = null, int perPage = 100, int? page = null);

    Task<Project?> GetByName(string projectName);

    Task<Project?> Add(ProjectRequest project);

    Task<List<Locale>?> GetLocales(string projectId);

    Task<Locale?> AddLocale(string projectId, LocaleRequest locale);
}
