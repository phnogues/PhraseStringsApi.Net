using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Responses;

public class SearchKeyResult : AuditableEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("name_hash")]
    public string NameHash { get; set; }

    [JsonPropertyName("plural")]
    public bool? Plural { get; set; }

    [JsonPropertyName("max_characters_allowed")]
    public int? MaxCharactersAllowed { get; set; }

    [JsonPropertyName("tags")]
    public object? Tags { get; set; }
}
