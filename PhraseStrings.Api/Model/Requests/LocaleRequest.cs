using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Requests;

public class LocaleRequest
{
    [JsonPropertyName("branch")]
    public string Branch { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("main")]
    public bool Main { get; set; }

    [JsonPropertyName("rtl")]
    public bool Rtl { get; set; }

    [JsonPropertyName("source_locale_id")]
    public string SourceLocaleId { get; set; }

    [JsonPropertyName("fallback_locale_id")]
    public string FallbackLocaleId { get; set; }

    [JsonPropertyName("unverify_new_translations")]
    public bool UnverifyNewTranslations { get; set; }

    [JsonPropertyName("unverify_updated_translations")]
    public bool UnverifyUpdatedTranslations { get; set; }

    [JsonPropertyName("autotranslate")]
    public bool Autotranslate { get; set; }
}
