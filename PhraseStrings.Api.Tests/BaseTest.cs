using Microsoft.Extensions.Configuration;
using PhraseStrings.Api.Interfaces;
using PhraseStrings.Api.Services;

namespace PhraseStrings.Api.Tests;

public class BaseTest
{
    protected string ProjectTestId { get; private set; }

    public ILocalizationClient localizationClient;

    public BaseTest()
    {
        var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        ProjectTestId = config["Phrase:TestProjectId"];
        localizationClient = new PhraseClient(config["Phrase:TokenAPI"]);
    }
}