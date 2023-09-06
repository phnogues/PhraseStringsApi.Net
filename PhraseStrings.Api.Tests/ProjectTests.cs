using PhraseStrings.Api.Model.Requests;

namespace PhraseStrings.Api.Tests;

[TestClass]
public class ProjectTests : BaseTest
{
    [TestMethod]
    public async Task GetAll_ShouldReturnResults()
    {
        var result = await localizationClient.Projects.GetAll();

        Assert.IsTrue(result.Count > 1);
    }

    [TestMethod]
    public async Task GetAll_WithQuery_ShouldReturnResults()
    {
        var result = await localizationClient.Projects.GetAll("App.S*"); // change this to a project name you have

        Assert.IsTrue(result.First().Name.StartsWith("App.S"));
    }

    [TestMethod]
    public async Task GetByName_ShouldReturnResults()
    {
        var projects = await localizationClient.Projects.GetAll();
        var result = await localizationClient.Projects.GetByName(projects.First().Name);

        Assert.IsTrue(result.Name.Equals(projects.First().Name, StringComparison.InvariantCultureIgnoreCase));
    }

    [TestMethod]
    public async Task Add_ShouldReturnResults()
    {
        ProjectRequest newProject = new ProjectRequest()
        {
            Name = "test",
            MainFormat = "csv",
            Media = ".NET"
        };

        var result = await localizationClient.Projects.Add(newProject);

        Assert.IsTrue(result.Name == newProject.Name);
    }

    [TestMethod]
    public async Task GetLocales_ShouldReturnResults()
    {
        var result = await localizationClient.Projects.GetLocales(ProjectTestId);

        Assert.IsTrue(result.Count > 1);
    }

    [TestMethod]
    public async Task AddLocale_ShouldReturnResults()
    {
        LocaleRequest newLocale = new LocaleRequest()
        {
            Name = "fr",
            Code = "fr-FR",
            Default = true
        };

        var result = await localizationClient.Projects.AddLocale(ProjectTestId, newLocale);

        Assert.IsTrue(result.Code == newLocale.Code);
    }
}
