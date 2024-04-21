# SplotchLib
### The successor to Splotch
SplotchLib is the new version of Splotch that runs as a library mod for BepInEx instead of a standalone mod loader. 

## Features
### Implemented
1. Popups! (and more GUI shenanigans coming soon)
2. Basic utility functions
3. Built-in mod names
### Planned (not yet implemented)
1. Networking
2. Custom ability creation


## How to use in your mod
1. Add `SplotchLib.dll` as an assembly reference
2. Edit your mod to have this in the main class:
    ```c#
    using BepInEx;
    using SplotchLib;

    namespace MyMod
    {
        [BepInDependency("com.codemob.splotch")]
        [BepInSplotch(authors: new string[]{ "Yourname" })]
        [BepInPlugin("someGUID", "MyMod", "0.1.0")]
        public class MyMod : BaseUnityPlugin
        {
    ```
3. Thats it!
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
:3