using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Requests;

public class TranslationRequest
{
    [JsonPropertyName("branch")]
    public string Branch { get; set; }

    [JsonPropertyName("locale_id")]
    public string LocaleId { get; set; }

    [JsonPropertyName("key_id")]
    public string KeyId { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("plural_suffix")]
    public string PluralSuffix { get; set; }

    [JsonPropertyName("unverified")]
    public bool Unverified { get; set; }

    [JsonPropertyName("excluded")]
    public bool Excluded { get; set; }

    [JsonPropertyName("autotranslate")]
    public bool Autotranslate { get; set; }
}
