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
    public async Task<List<Project>?> GetAll(string? q = null, int perPage = 100, int? page = null)
    {
        string url = $"projects?per_page={perPage}";

        List<Project> results = new List<Project>();
        int maxPages = 100;

        if (page.HasValue)
        {
            return await GetList<List<Project>>($"{url}&page={page}");
        }
        else
        {
            // Phrase doesn't return the total number of pages, so we have to guess
            page = 1;

            while (page < maxPages)
            {
                var pageResults = await GetList<List<Project>>($"{url}&page={page}");
                if (pageResults is not null && pageResults.Any())
                {
                    results.AddRange(pageResults);
                    page++;
                }
                else
                {
                    break;
                }
            }
        }

        if (!string.IsNullOrEmpty(q) && results is not null)
        {
            results = results.Where(x => MatchesWildcard(x.Name, q)).ToList();
        }

        return results;
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