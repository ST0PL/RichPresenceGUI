<div align="center">
  <img src="/assets/logo.png"/>
  <h1>Rich Presence GUI</h1>
  Rich Presence GUI is an application that makes Discord Rich Presence management easier.
</div>

---

# Features
+ ✨ Friendly UI
  
  You can easily set any aspect of your rich presence such as:
  - State/Details/Images/Party/Buttons/Timestamps
  - Activity type:
    - Playing
    - Watching
    - Listening
    - Competing
  - Status display type:
    - Name
    - State
    - Details
  
- 📑 Templates
  
  The templates system allows you to save and reuse your rich presence preset in one click. Templates visual style can also be used to preview your rich presence.
  
- 🌙 Dark and Light themes
  
  Support for dark and light themes via the XAML resource dictionaries.
  
- 🖥️ Always on 

  Application can be collapsed into a tray and work in background.

- 🔨 Debugging

  You can see Discord RPC logs in debug view.

- ⚡ Auto Updates

  Application will automatically check for newest version on startup.
  
- 🌍 Multi-language system
  
  Application already support several languages.
  You can simply create a localization dictionary using the template of existing ones and your translation will be automatically added to the list of available application languages, see [**Supported Languages**](#supported-languages).

# Getting Started

Following this steps you can easily setup your Discord Rich Presence

1. Get the [**latest release**](https://github.com/ST0PL/RichPresenceGUI/releases/latest)
2. Go to [**My Applications**](https://discord.com/developers/applications)
3. Select an exist application or press **New application** to create a new one
4. Go to **General Information** and copy *Application ID*
5. Launch **Rich Presence GUI**, paste your _Application ID_ into the **Application ID** field and press **Connect**
6. Setup your Rich Presence and press **Update presence** button
7. See your new Rich Presence in the **Discord App**

> [!NOTE]
> You can't see your own Rich Presence buttons in profile.

# Supported Languages

|**Language**|**Status**|
|---|:---:|
|English|Completed|
|Russian|Completed|

> [!NOTE]
> You can help with translation in other languages!

### How to add a new translation
1. Fork this repository
2. Copy one of the existing xaml dictionary located in `/Resources/Themes/Locale/`
3. Change `locale_name` and other dictionary entries
4. Make a pull-request
5. ✅ Congrats! ✅ 


# Preview


|<kbd><img alt="Fields" src="/assets/fields.png" width=400 /></kbd>|<kbd><img alt="Fields light" src="/assets/fields_light.png" width=400 /></kbd>|<kbd><img alt="Templates" src="/assets/templates.png" width=400 /></kbd>|
|:---:|:---:|:---:|
|`Fields`|`Fields light`|`Templates`|
|<kbd><img alt="More templates" src="/assets/templates2.png" width=400 /></kbd>|<kbd><img alt="Debug" src="/assets/debug.png" width=400 /></kbd>|<kbd><img alt="Balloon" src="/assets/balloon.png" width=300 /></kbd>|
|`More templates`|`Debug`|`Balloon`|

|<kbd><img alt="Result" src="/assets/discord.gif" width=200 /></kbd>|
|:---:|
|`Result`|


# Why
Initially, I made it for personal usage and C# practice. I decided to publish it for someone who is looking for simple WPF/MVVM application example with dependency injection, not such bad UI and other cool things.

# Credits
*This application uses following open-source libraries:*
- [**Hardcodet NotifyIcon for WPF**](https://github.com/hardcodet/wpf-notifyicon) - Task bar tray functionality
- [**Discord Rich Presence**](https://github.com/Lachee/discord-rpc-csharp) - C# Discord Rich Presence implementation