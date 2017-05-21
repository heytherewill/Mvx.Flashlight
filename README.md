# Mvx.Flashlight [![Build Status](https://www.bitrise.io/app/7d7c5d481be083cf/status.svg?token=NQFc0gqIxZGc20c9OqAIEA&branch=master)](https://www.bitrise.io/app/7d7c5d481be083cf)
:flashlight: MvvmCross Flashlight Plugin

This plugin allows you to use the device's flash in any [MvvmCross](https://github.com/MvvmCross/MvvmCross) project.

# Installation

Install via [NuGet](https://www.nuget.org/packages/Mvx.Flashlight/) using:

``PM> Install-Package Mvx.Flashlight``

# Usage

Resolve it:

``var flashlightService = Mvx.Resolve<IFlashlightService>();``

Use it at will:

```
//Checks whether the user is using a phone or a toaster 
flashlightService.DeviceHasFlashlight;

//Indicates if the flashlight is currently on or not
flashlightService.IsFlashlightOn

// Those two are self explanatory
flashlightService.EnsureFlashlightOn();
flashlightService.EnsureFlashlightOff();
```

Check the Sample projects for a working example.

# :warning: Attention

You need to add the camera permission to your Android manifest in order to make this puglin work:

```
<uses-permission android:name="android.permission.CAMERA" />
<uses-permission android:name="android.permission.FLASHLIGHT" />
```
