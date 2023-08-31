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
    public async Task GetLocales_ShouldReturnResults()
    {
        var result = await localizationClient.Projects.GetLocales(ProjectTestId);

        Assert.IsTrue(result.Count > 1);
    }
}
