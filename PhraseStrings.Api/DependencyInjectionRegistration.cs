using Microsoft.Extensions.DependencyInjection;
using PhraseStrings.Api.Interfaces;
using PhraseStrings.Api.Services;

namespace PhraseStrings.Api;

public static class DependencyInjectionRegistration
{
    public static void AddPhraseStrings(this IServiceCollection services, string tokenApi)
    {
        services.AddScoped<ILocalizationClient>(s => new PhraseClient(tokenApi));
    }
}