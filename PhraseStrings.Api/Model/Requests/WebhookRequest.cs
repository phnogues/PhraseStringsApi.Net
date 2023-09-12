using PhraseStrings.Api.Enums;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Requests;

public class WebhookRequest
{
    [JsonPropertyName("callback_url")]
    public string CallbackUrl { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("events")]
    public List<WebhookEvents> Events { get; set; }

    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [JsonPropertyName("include_branches")]
    public bool? IncludeBranches { get; set; }

    [JsonPropertyName("secret")]
    public string Secret { get; set; }
}
