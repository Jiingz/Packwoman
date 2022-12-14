

<h1 align="center">
  <br>
  <a href="http://www.amitmerchant.com/electron-markdownify"><img src="https://cdn1.iconfinder.com/data/icons/logos-brands-in-colors/231/among-us-player-pink-512.png" alt="Markdownify" width="200"></a>
  <br>
  Packwoman
  <br>
</h1>

<h4 align="center">A simple and very basic usermode anticheat library</h4>
<h5 align="center">This repository and everything related to it are not and never will be associated with Riot Games in any way.</h5>

<p align="center">
  <a href="#key-features">Key Features</a> •
  <a href="#how-to-use">How To Use</a> •
  <a href="#download">Download</a> •
  <a href="#credits">Credits</a> •
  <a href="#related">Related</a> •
  <a href="#license">License</a>
</p>

![screenshot](https://i.imgur.com/coWFdM5.png)

## Key Features

* Blocking of known, blacklisted modules
* Detection of attached and open debuggers
* Check of newly created threads
* Easy to implement
* Eventsystem to trigger bans with your own subscribed ban handle function
* Shows in system tray

## How To Use

```bash
# Clone this repository
$ git clone https://github.com/Jiingz/Packwoman.git
```
* Open the Project

* build packwoman

* Add the library to your project.

### How to create your own Modules
```bash
class YourModule : IAnticheatModule

//Implemented from the IAnticheatModule
public void Execute()
{
  //Execute your module logic here
}
```

### Setup your own Ban Handle function
```bash
void HandleBans()
{
    //Ban Logic
    Console.WriteLine("You have been banned!");
}

BanHandler.GetBanHandler().SubscribeBanHandler(HandleBans);
```
### Add modules
```bash
AntiCheatProvider.GetAntiCheatProvider().AddModule(new YourModule());
```
### Execute Anticheat Modules
```bash
AntiCheatProvider.GetAntiCheatProvider().ExecuteModules();
```

> **Note**
> .NET 6 and Visual Studio 2022 with latest build tools were used for development.

# Should I use this for my game?
No. This was never meant to be used in production and lacks alot of features. The functionality is very basic.
However, if you want to block basic attack vectors and want some sort of anticheat system, this might be useful to you.
If you decide to do so please let me know! :)

# Can I use this code?
Sure! 

## Download

You can [download](https://github.com/Jiingz/Packwoman/releases) the latest version of Packwoman.

## License

Unlicensed

---

> GitHub [@Jiingz](https://github.com/Jiingz/) &nbsp;&middot;&nbsp;

