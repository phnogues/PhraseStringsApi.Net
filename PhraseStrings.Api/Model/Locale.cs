using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

public class Locale : AuditableEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("main")]
    public bool Main { get; set; }

    [JsonPropertyName("rtl")]
    public bool rtl { get; set; }

    [JsonPropertyName("plural_forms")]
    public List<string> PluralForms { get; set; }

    [JsonPropertyName("source_locale")]
    public object SourceLocale { get; set; }

    [JsonPropertyName("fallback_locale")]
    public object FallbackLocale { get; set; }
}

public class LocaleLight
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }
}
