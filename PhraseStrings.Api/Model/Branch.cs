using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

public class Branch
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
