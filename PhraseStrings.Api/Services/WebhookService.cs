namespace PhraseStrings.Api.Services
{
    internal class WebhookService : BaseService, IWebhookService
    {
        internal WebhookService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Webhook>?> GetAll(string projectId)
        {
            return await GetList<List<Webhook>>($"projects/{projectId}/webhooks");
        }

        public async Task<Webhook?> Add(string projectId, Webhook webhook)
        {
            return await Post<Webhook, Webhook>($"projects/{projectId}/webhooks", webhook);
        }
    }
}
