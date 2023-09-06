using System.Text.Json.Serialization;

namespace PhraseStrings.Api.Model.Requests;

public class ProjectRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("main_format")]
    public string MainFormat { get; set; }

    [JsonPropertyName("media")]
    public string Media { get; set; }

    [JsonPropertyName("shares_translation_memory")]
    public bool SharesTranslationMemory { get; set; }

    [JsonPropertyName("project_image")]
    public string ProjectImage { get; set; }

    [JsonPropertyName("remove_project_image")]
    public object RemoveProjectImage { get; set; }

    [JsonPropertyName("account_id")]
    public string AccountId { get; set; }

    [JsonPropertyName("point_of_contact")]
    public string PointOfContact { get; set; }

    [JsonPropertyName("source_project_id")]
    public string SourceProjectId { get; set; }

    [JsonPropertyName("workflow")]
    public string Workflow { get; set; }

    [JsonPropertyName("machine_translation_enabled")]
    public bool MachineTranslationEnabled { get; set; }

    [JsonPropertyName("enable_branching")]
    public bool EnableBranching { get; set; }

    [JsonPropertyName("protect_master_branch")]
    public bool ProtectMasterBranch { get; set; }

    [JsonPropertyName("enable_all_data_type_translation_keys_for_translators")]
    public bool EnableAllDataTypeTranslationKeysForTranslators { get; set; }

    [JsonPropertyName("enable_icu_message_format")]
    public bool EnableIcuMessageFormat { get; set; }

    [JsonPropertyName("zero_plural_form_enabled")]
    public bool ZeroPluralFormEnabled { get; set; }

    [JsonPropertyName("autotranslate_enabled")]
    public bool AutotranslateEnabled { get; set; }

    [JsonPropertyName("autotranslate_check_new_translation_keys")]
    public bool AutotranslateCheckNewTranslationKeys { get; set; }

    [JsonPropertyName("autotranslate_check_new_uploads")]
    public bool AutotranslateCheckNewUploads { get; set; }

    [JsonPropertyName("autotranslate_check_new_locales")]
    public bool AutotranslateCheckNewLocales { get; set; }

    [JsonPropertyName("autotranslate_mark_as_unverified")]
    public bool AutotranslateMarkAsUnverified { get; set; }

    [JsonPropertyName("autotranslate_use_machine_translation")]
    public bool AutotranslateUseMachineTranslation { get; set; }

    [JsonPropertyName("autotranslate_use_translation_memory")]
    public bool AutotranslateUseTranslationMemory { get; set; }

    [JsonPropertyName("smart_suggest_enabled")]
    public bool SmartSuggestEnabled { get; set; }

    [JsonPropertyName("smart_suggest_use_glossary")]
    public bool SmartSuggestUseGlossary { get; set; }

    [JsonPropertyName("smart_suggest_use_machine_translation")]
    public bool SmartSuggestUseMachineTranslation { get; set; }
}
