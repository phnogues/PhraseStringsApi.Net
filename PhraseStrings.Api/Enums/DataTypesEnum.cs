using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Enums;


[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[DefaultValue(NotDefined)]

public enum DataTypesEnum
{
    [EnumMember(Value = "string")]
    String,

    [EnumMember(Value = "currency")]
    Currency,

    [EnumMember(Value = "datetime")]
    Datetime,

    NotDefined
}

