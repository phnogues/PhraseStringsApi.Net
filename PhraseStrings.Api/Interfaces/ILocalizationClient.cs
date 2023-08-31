namespace PhraseStrings.Api.Interfaces;

public interface ILocalizationClient
{
    public IProjectService Projects { get; }

    public ITranslationService Translations { get; }

    public IKeyService Keys { get; }
}

