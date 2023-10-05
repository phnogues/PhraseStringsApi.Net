namespace PhraseStrings.Api.Interfaces;

public interface ILocalizationClient
{
    IProjectService Projects { get; }

    ITranslationService Translations { get; }

    IKeyService Keys { get; }

    IWebhookService Webhooks { get; }

    int? NumberOfAllowedRequests { get; }

    int? NumberOfRemainingRequests { get; }

    DateTimeOffset? DateTimeOfLimitReseting { get; }
}