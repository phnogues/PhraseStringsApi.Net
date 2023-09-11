using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

public class User : AuditableEntity
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("position")]
    public string? Position { get; set; }
}
