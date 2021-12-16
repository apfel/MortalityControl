# Mortality Control
Allows controlling your mortality on the fly.  
Requires [MelonLoader](https://github.com/LavaGang/MelonLoader) 0.4 and [ModThatIsNotMod](https://boneworks.thunderstore.io/package/gnonme/ModThatIsNotMod/).

## Settings
You can change whether the mod turns you mortal (`ToggleMortality`) and whether you'd prefer to die instantly (`PreferInstantDeath`) in your `MelonPreferences.cfg`.  
ModThatIsNotMod's BoneMenu is also supported.

## Compiling
Requires:
- .NET Framework 4.7.2 SDK
- CMake 3.10 or newer
- A copy of BONEWORKS with MelonLoader and ModThatIsNotMod installed

```ps1
cmake -B build                          # Creates a build folder, use -DBONEWORKS_DIR=<path> if you installed BONEWORKS somewhere outside of C:\Program Files (x86)\Steam\steamapps\common
cmake --build build --config Release    # Builds the Release configuration.
```

## ChangeLog
2.0.0:
- Renamed settings values to more accurately convey their meaning
- Added a preference toggle for instant or timed death
- Fixed the hot-reload code
- Cleaned up some of the in-place code

1.1.0:
- Added an attempt to allow hot-reloading the mortality setting

1.0.0:
Initial release.
