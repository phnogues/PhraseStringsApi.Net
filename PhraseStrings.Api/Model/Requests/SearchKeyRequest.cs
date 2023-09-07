using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Requests;

public class SearchKeyRequest
{
    [JsonPropertyName("branch")]
    public string Branch { get; set; }

    [JsonPropertyName("sort")]
    public string Sort { get; set; }

    [JsonPropertyName("order")]
    public string order { get; set; }

    [JsonPropertyName("q")]
    public string Query { get; set; }

    [JsonPropertyName("locale_id")]
    public string LocaleId { get; set; }

}
