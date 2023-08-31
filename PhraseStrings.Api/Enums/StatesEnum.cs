using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Enums;


[JsonConverter(typeof(JsonStringEnumConverter))]
[DefaultValue(NotDefined)]
public enum StatesEnum
{
    [EnumMember(Value = "translated")]
    Translated,

    NotDefined
}
