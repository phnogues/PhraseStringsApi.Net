using PhraseStrings.Api.Enums;
using PhraseStrings.Api.Model;

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
}