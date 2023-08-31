namespace PhraseStrings.Api.Tests;

[TestClass]
public class KeyTests : BaseTest
{
    [TestMethod]
    public async Task GetAll_ShouldReturnResults()
    {
        var result = await localizationClient.Keys.GetAll(ProjectTestId);

        Assert.IsTrue(result.Count > 1);
    }

    [TestMethod]
    public async Task GetById_ShouldReturnResult()
    {
        var randomKey = (await localizationClient.Keys.GetAll(ProjectTestId))[0];
        var result = await localizationClient.Keys.GetById(ProjectTestId, randomKey.Id);

        Assert.IsTrue(result.Id == randomKey.Id);
    }
}
