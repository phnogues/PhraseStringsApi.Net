# PhraseStringsApi.Net

[![NuGet latest version](https://badgen.net/nuget/v/PhraseStrings.Api/latest)](https://nuget.org/packages/PhraseStrings.Api)

Api for Phrase Strings solution

<img src="/Phrase.png" width="100" height="100" />

.Net Library for interfacing with [Phrase Strings](https://phrase.com/) api

Supported functions for now :
- Projects
   - GetAll
   - GetAll(wildcard query)
   - GetByName
   - Add
   - GetLocales
   - AddLocale
- Translations
   - GetAll(projectId, perPage = 100, page) 
   - GetByLocale
   - GetByKey
   - Add
   - Update
- Keys
   - GetAll 
   - GetById
   - GetByName
   - Search
   - Add 
   - Delete
- Webhooks
   - GetAll
   - Add
   - Update
   - ActionFilterAttribute to manage Phrase webhook request integrity

## Get startred
Get an API key (Token) from your Phrase account

Open your statup.cs, and use that code :
#####  services.AddPhraseStrings("Your Token");

For test project you have to change settings from appsettings.json file
``` {
  "Phrase": {
    "TokenAPI": "[Your Token]",
    "TestProjectId": "[A Project Id]"
  }
}
```

## Enjoy !
<a href="https://www.buymeacoffee.com/phnogues" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>

