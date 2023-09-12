namespace PhraseStrings.Api.Interfaces;

public interface IWebhookService
{
    Task<List<Webhook>?> GetAll(string projectId);

    Task<Webhook?> Add(string projectId, Webhook webhook);

    Task<Webhook?> Update(string projectId, string webhookId, WebhookRequest webhook);
}
