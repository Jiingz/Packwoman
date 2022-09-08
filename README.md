

<h1 align="center">
  <br>
  <a href="http://www.amitmerchant.com/electron-markdownify"><img src="https://cdn1.iconfinder.com/data/icons/logos-brands-in-colors/231/among-us-player-pink-512.png" alt="Markdownify" width="200"></a>
  <br>
  Packwoman
  <br>
</h1>

<h4 align="center">A simple and very basic usermode anticheat library</h4>

<p align="center">
  <a href="https://badge.fury.io/js/electron-markdownify">
    <img src="https://badge.fury.io/js/electron-markdownify.svg"
         alt="Gitter">
  </a>
  <a href="https://gitter.im/amitmerchant1990/electron-markdownify"><img src="https://badges.gitter.im/amitmerchant1990/electron-markdownify.svg"></a>
  <a href="https://saythanks.io/to/bullredeyes@gmail.com">
      <img src="https://img.shields.io/badge/SayThanks.io-%E2%98%BC-1EAEDB.svg">
  </a>
  <a href="https://www.paypal.me/AmitMerchant">
    <img src="https://img.shields.io/badge/$-donate-ff69b4.svg?maxAge=2592000&amp;style=flat">
  </a>
</p>

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

```bash
#Setup your own Ban Handle function
void HandleBans()
{
    //Ban Logic
    Console.WriteLine("You have been banned!");
}

BanHandler.GetBanHandler().SubscribeBanHandler(HandleBans);
```
```bash
#Execute Anticheat Modules
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

