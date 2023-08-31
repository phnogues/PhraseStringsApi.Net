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
}
