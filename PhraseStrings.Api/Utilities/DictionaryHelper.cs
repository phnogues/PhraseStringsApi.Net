using System.Reflection;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Utilities;

public static class DictionaryHelper
{
    public static Dictionary<string, string> ToPhraseDatasKeyValue(this object objectToConvert)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();

        var properties = objectToConvert.GetType().GetProperties();

        foreach (var property in properties)
        {
            var key = property.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
            var value = property.GetValue(objectToConvert);
            if (value != null)
            {
                result.Add(key, value.ToString());
            }
        }

        return result;
    }
}