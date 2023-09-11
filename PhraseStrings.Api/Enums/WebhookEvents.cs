using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Enums;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[DefaultValue(NotDefined)]
public enum WebhookEvents
{
    [EnumMember(Value = "locales:create")]
    Locales_Create,
    [EnumMember(Value = "locales:update")]
    Locales_Update,
    [EnumMember(Value = "locales:delete")]
    Locales_Delete,

    [EnumMember(Value = "uploads:create")]
    Uploads_Create,
    [EnumMember(Value = "uploads:processing")]
    Uploads_Processing,

    [EnumMember(Value = "keys:create")]
    Keys_Create,
    [EnumMember(Value = "keys:update")]
    Keys_Update,
    [EnumMember(Value = "keys:delete")]
    Keys_Delete,
    [EnumMember(Value = "keys:batch_delete")]
    Keys_Batch_Delete,

    [EnumMember(Value = "translations:create")]
    Translations_Create,
    [EnumMember(Value = "translations:update")]
    Translation_Update,
    [EnumMember(Value = "translations:delete")]
    Translation_Delete,
    [EnumMember(Value = "translations:deliver")]
    Translations_Deliver,
    [EnumMember(Value = "translations:review")]
    Translations_Review,
    [EnumMember(Value = "translations:unreview")]
    Translations_Unreview,

    [EnumMember(Value = "comments:create")]
    Comments_Create,

    [EnumMember(Value = "jobs:create")]
    Jobs_Create,
    [EnumMember(Value = "jobs:complete")]
    Jobs_Complete,
    [EnumMember(Value = "jobs:start")]
    Jobs_Start,
    [EnumMember(Value = "jobs:reopened")]
    Jobs_Reopened,
    [EnumMember(Value = "jobs:update")]
    Jobs_Update,

    [EnumMember(Value = "jobs:locale:complete")]
    JobsLocale_Complete,
    [EnumMember(Value = "jobs:locale:reopened")]
    JobsLocale_Reopened,
    [EnumMember(Value = "jobs:locale:review:complete")]
    JobsLocale_Review_Complete,
    [EnumMember(Value = "jobs:locale:review:reopen")]
    JobsLocale_Review_Reopen,

    [EnumMember(Value = "screenshots:create")]
    Screenshots_Create,
    [EnumMember(Value = "screenshots:update")]
    Screenshots_Update,
    [EnumMember(Value = "screenshots:delete")]
    Screenshots_Delete,

    [EnumMember(Value = "branches:create")]
    Branches_Create,
    [EnumMember(Value = "branches:merge")]
    Branches_Merge,

    [EnumMember(Value = "releases:create")]
    Releases_Create,
    [EnumMember(Value = "releases:delete")]
    Releases_Delete,

    [EnumMember(Value = "test:event")]
    Test,

    NotDefined
}
