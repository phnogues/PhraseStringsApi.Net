# PhraseStringsApi.Net
Api for Phrase Strings solution

<img src="/Phrase.png" width="100" height="100" />

.Net Library for interfacing with [Phrase Strings](https://phrase.com/) api

Supported functions for now :
- Projects
   - GetAll
- Translations
   - GetAll 
- Keys
   - GetAll 
   - GetById
   - Add 

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
