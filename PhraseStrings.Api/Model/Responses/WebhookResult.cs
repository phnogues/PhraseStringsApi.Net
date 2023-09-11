using PhraseStrings.Api.Enums;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Responses;

public class WebhookResult
{
    [JsonPropertyName("event")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public WebhookEvents Event { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("project")]
    public Project Project { get; set; }

    [JsonPropertyName("branch")]
    public Branch Branch { get; set; }

    [JsonPropertyName("translation")]
    public Translation Translation { get; set; }
}
