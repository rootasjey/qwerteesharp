# qwerteesharp
C# Qwertee data extractor into a library targeting .NET Standard 1.4..

:warning: This library is unstable because it parses the [Qwertee website](https://www.qwertee.com/) and any unavailability of Qwertee website will make this API unavailable. And any DOM changes of the Qwertee website will probably make this lib outdated.

This lib is compatible with .NET Core, .NET Framework 4.6.1, Xamarin (iOS, Android), Universal Windows Platform.

# Purpose
I wanted to group all the algorithms used in my Wearme app into a library for more clarity.

# Installation
Install the library from Nuget

# Usage

```JavaScript
using Qwerteesharp;

var client = new QwerteesharpClient();
client.GetTodayTees();
```

# API documentation

* [Instantiate a new client](https://github.com/rootasjey/qwerteesharp#instantiate-a-new-client)
* [Designs](https://github.com/rootasjey/qwerteesharp#designs)
* [Prints](https://github.com/rootasjey/qwerteesharp#prints)

## Instantiate a new client

```JavaScript
var client = new QwerteesharpClient();
```

## Designs

### Get all current designs

```JavaScript
var currentDesigns = await client.GetAllCurrentDesigns();
```

### Get today designs

```JavaScript
var todayDesigns = await client.GetTodayDesigns();
```

### Get last chance designs

```JavaScript
var lastChanceDesigns = await client.GetLastChanceDesigns();
```

## Prints
