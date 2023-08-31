using PhraseStrings.Api.Enums;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

public class Translation : AuditableEntity
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("unverified")]
    public bool Unverified { get; set; }

    [JsonPropertyName("excluded")]
    public bool Excluded { get; set; }

    [JsonPropertyName("plural_suffix")]
    public string PluralSuffix { get; set; }

    [JsonPropertyName("key")]
    public Key key { get; set; }

    [JsonPropertyName("placeholders")]
    public List<string> Placeholders { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("locale")]
    public LocaleLight Locale { get; set; }
}

public class Key
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("plural")]
    public bool Plural { get; set; }

    [JsonPropertyName("data_type")]
    public DataTypesEnum DataType { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
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
