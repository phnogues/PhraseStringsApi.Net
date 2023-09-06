namespace PhraseStrings.Api.Services;

internal class ProjectService : BaseService, IProjectService
{
    internal ProjectService(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get all projects with optional search query
    /// </summary>
    /// <param name="q">Search query, can contains wildcards (ex: projectOne*)</param>
    /// <returns></returns>
    public async Task<List<Project>?> GetAll(string? q = null)
    {
        var result = await GetList<List<Project>>($"projects");

        if (!string.IsNullOrEmpty(q) && result is not null)
        {
            result = result.Where(x => MatchesWildcard(x.Name, q)).ToList();
        }

        return result;
    }

    public async Task<Project?> GetByName(string projectName)
    {
        var result = await GetAll();

        return result?.FirstOrDefault(p => p.Name.Equals(projectName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Project?> Add(ProjectRequest project)
    {
        var result = await Post<ProjectRequest, Project>($"projects", project);

        return result;
    }

    public async Task<List<Locale>?> GetLocales(string projectId)
    {
        var result = await GetList<List<Locale>>($"projects/{projectId}/locales");

        return result;
    }

    public async Task<Locale?> AddLocale(string projectId, LocaleRequest locale)
    {
        var result = await Post<LocaleRequest, Locale>($"projects/{projectId}/locales", locale);

        return result;
    }
}