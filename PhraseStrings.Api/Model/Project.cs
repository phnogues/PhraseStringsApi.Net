using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model;

public class Project : AuditableEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("main_format")]
    public string MainFormat { get; set; }

    [JsonPropertyName("project_image_url")]
    public object ProjectImageUrl { get; set; }

    [JsonPropertyName("account")]
    public Account Account { get; set; }

    [JsonPropertyName("space")]
    public Space Space { get; set; }

    [JsonPropertyName("point_of_contact")]
    public PointOfContact PointOfContact { get; set; }

    [JsonPropertyName("media")]
    public string Media { get; set; }
}

public class Account : AuditableEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("company_logo_url")]
    public object CompanyLogoUrl { get; set; }
}

public class PointOfContact
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("gravatar_uid")]
    public string GravatarUid { get; set; }
}

public class Space : AuditableEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("projects_count")]
    public int ProjectsCount { get; set; }
}


