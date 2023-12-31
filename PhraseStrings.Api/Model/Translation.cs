﻿using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

public class Translation : AuditableEntity
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("unverified")]
    public bool? Unverified { get; set; }

    [JsonPropertyName("excluded")]
    public bool? Excluded { get; set; }

    [JsonPropertyName("plural_suffix")]
    public string PluralSuffix { get; set; }

    [JsonPropertyName("key")]
    public Key Key { get; set; }

    [JsonPropertyName("placeholders")]
    public List<string>? Placeholders { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("locale")]
    public LocaleLight Locale { get; set; }
}
