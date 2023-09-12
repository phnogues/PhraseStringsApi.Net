namespace PhraseStrings.Api.Interfaces;

public interface ILocalizationClient
{
    IProjectService Projects { get; }

    ITranslationService Translations { get; }

    IKeyService Keys { get; }

    IWebhookService Webhooks { get; }
}

