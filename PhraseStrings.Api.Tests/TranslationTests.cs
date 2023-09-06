using PhraseStrings.Api.Model.Requests;

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

    [TestMethod]
    public async Task Add_Should_Insert_Record()
    {
        var locales = await localizationClient.Projects.GetLocales(ProjectTestId);
        TranslationRequest translationToAdd = new TranslationRequest()
        {
            KeyId = "test",
            LocaleId = "en",
            Content = "test"
        };

        var result = await localizationClient.Translations.Add("", translationToAdd);

        Assert.IsTrue(result.Content == translationToAdd.Content);
    }
}

