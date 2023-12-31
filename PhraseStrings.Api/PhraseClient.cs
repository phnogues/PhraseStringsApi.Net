﻿using PhraseStrings.Api.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhraseStrings.Api;

public class PhraseClient : ILocalizationClient
{
    const string API_URL_EU = "https://api.phrase.com/v2/";
    const string API_URL_US = "https://api.us.app.phrase.com/v2/";

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    private IProjectService? _projects;
    private ITranslationService? _translations;
    private IKeyService? _keys;
    private IWebhookService? _webhooks;

    public PhraseClient(string apiToken, bool europeanDataCenter = true)
    {
        _httpClient = new HttpClient();

        if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            _httpClient.DefaultRequestHeaders.Remove("Authorization");

        _httpClient.DefaultRequestHeaders.Add("Authorization", "token " + apiToken);

        _httpClient.BaseAddress = new Uri(europeanDataCenter ? API_URL_EU : API_URL_US);
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    public IProjectService Projects => _projects ??= new ProjectService(_httpClient);

    public ITranslationService Translations => _translations ??= new TranslationService(_httpClient);

    public IKeyService Keys => _keys ??= new KeyService(_httpClient);

    public IWebhookService Webhooks => _webhooks ??= new WebhookService(_httpClient);

    public int? NumberOfAllowedRequests
    {
        get
        {
            lock (LimitVariables.NumberOfAllowedRequestsLock)
            {
                return LimitVariables.NumberOfAllowedRequests;
            }
        }
    }

    public int? NumberOfRemainingRequests
    {
        get
        {
            lock (LimitVariables.NumberOfRemainingRequestsLock)
            {
                return LimitVariables.NumberOfRemainingRequests;
            }
        }
    }

    public DateTimeOffset? DateTimeOfLimitReseting
    {
        get
        {
            lock (LimitVariables.DateTimeOfLimitResetingLock)
            {
                return LimitVariables.DateTimeOfLimitReseting;
            }
        }
    }
}
