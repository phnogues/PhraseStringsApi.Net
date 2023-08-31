namespace PhraseStrings.Api.Tests;

[TestClass]
public class TranslationTests : BaseTest
{
    [TestMethod]
    public async Task GetAll_ShouldReturnResults()
    {
        var result = await localizationClient.Translations.GetAll(ProjectTestId);

        Assert.IsTrue(result.Count > 1);
    }
}

