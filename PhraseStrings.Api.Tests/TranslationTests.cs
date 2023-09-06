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
    public async Task GetByKey_ShouldReturnResults()
    {
        var key = (await localizationClient.Keys.GetAll(ProjectTestId))[0];

        var result = await localizationClient.Translations.GetByKey(ProjectTestId, key.Id);

        Assert.IsTrue(key.Name == result[0].Key.Name);
    }

    [TestMethod]
    public async Task Add_Should_Insert_Record()
    {
        var locales = await localizationClient.Projects.GetLocales(ProjectTestId);
        TranslationRequest translationToAdd = new TranslationRequest()
        {
            KeyId = "A key here",
            LocaleId = locales.Where(l => l.Default).First().Id,
            Content = "test"
        };

        var result = await localizationClient.Translations.Add(ProjectTestId, translationToAdd);

        Assert.IsTrue(result.Content == translationToAdd.Content);
    }

    [TestMethod]
    public async Task Update_Should_Return_UpdatedRecord()
    {
        var locales = await localizationClient.Projects.GetLocales(ProjectTestId);
        var translationToUpdate = (await localizationClient.Translations.GetAll(ProjectTestId)).First();
        TranslationRequest translationRequest = new TranslationRequest()
        {
            KeyId = translationToUpdate.Key.Id,
            LocaleId = locales.Where(l => l.Default).First().Id,
            Content = "test updated 3"
        };

        var result = await localizationClient.Translations.Update(ProjectTestId, translationToUpdate.Id, translationRequest);

        Assert.IsTrue(result.Content == translationRequest.Content);
    }
}

