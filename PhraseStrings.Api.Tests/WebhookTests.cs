using PhraseStrings.Api.Enums;
using PhraseStrings.Api.Model;
using PhraseStrings.Api.Model.Requests;

namespace PhraseStrings.Api.Tests;

[TestClass]
public class WebhookTests : BaseTest
{
    [TestMethod]
    public async Task GetAll_ShouldReturnResults()
    {
        var result = await localizationClient.Webhooks.GetAll(ProjectTestId);

        Assert.IsTrue(result.Count > 1);
    }

    [TestMethod]
    public async Task Add_ShouldReturnResults()
    {
        Webhook webhookToAdd = new Webhook()
        {
            Active = true,
            CallbackUrl = "https://www.google.com",
            Description = "Unit Test Webhook",
            Events = new List<WebhookEvents>() { WebhookEvents.JobsLocale_Complete, WebhookEvents.Translations_Create },
            Secret = Guid.NewGuid().ToString(),
        };

        var result = await localizationClient.Webhooks.Add(ProjectTestId, webhookToAdd);

        Assert.IsTrue(result.Description == webhookToAdd.Description);
    }

    [TestMethod]
    public async Task Update_ShouldReturnResults()
    {
        Webhook webhookToUpdate = (await localizationClient.Webhooks.GetAll(ProjectTestId)).FirstOrDefault(w => w.Description.Contains("test"));

        WebhookRequest webhookRequest = new WebhookRequest()
        {
            Description = "Unit Test Webhook Updated",
        };

        var result = await localizationClient.Webhooks.Update(ProjectTestId, webhookToUpdate.Id, webhookRequest);

        Assert.IsTrue(result.Description == webhookRequest.Description);
    }
}