using PhraseStrings.Api.Enums;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

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
