**Since Google Code no longer allows new downloads, the latest release can be downloaded via [NuGet](https://www.nuget.org/packages/AssimpNet/)**


---


A .NET wrapper for the [Open Asset Import Library](http://assimp.sourceforge.net/) (Assimp). The wrapper uses P/Invoke to communicate with Assimp's C-API and is divided into two parts:

  1. Low-level
    * The native methods are exposed via the AssimpLibrary singleton.
    * "Unmanaged" structures prefixed with the name 'Ai' that contain IntPtrs to the unmanaged data.
    * The unmanaged library is loaded/unloaded dynamically, 32 and 64 bit is supported. The managed DLL is 'AnyCPU'
    * Located in the 'Assimp.Unmanaged' namespace.
  1. High-level
    * A more C# like interface that is more familiar to .NET programmers and allows you to work with the data in managed memory.
    * Completely handles data marshaling for both import and export, the user left only concerned with the data itself.
    * Located in the default 'Assimp' namespace.

Commonalities between these two levels are certain structures like Vector3D, Color4D, etc. The High level layer is very similar to Assimp's C++ API and the low level part is public to allow users do whatever they want (e.g. maybe load the unmanaged data directly into their own structures).

For a brief overview and code sample, check out the [Getting Started](GettingStarted.md) wiki page.

The binaries were built in Visual Studio 2012 as AnyCpu and target .NET 4.5 and .NET 2.0. They are deployed with the **Assimp 3.1.1** release (you can download the latest Assimp releases [here](http://assimp.sourceforge.net/main_downloads.html)).

It is fairly easy to build AssimpNet yourself as it does not rely on many external dependencies that you have to download/install prior. The only special instruction is that you need to ensure that the interop generator patches the AssimpNet.dll in a post-build process, otherwise the library won't function correctly. This is part of the standard build process when running out of a msbuild environment. Look at that build process if you are using something else.

Enjoy!


---


In addition, check out these other projects from the same author:

  * [Tesla Graphics Engine](http://code.google.com/p/tesla-engine/) - a 3D rendering platform written in C# and the primary motivation for developing AssimpNet.
  * [DevIL.NET](http://code.google.com/p/devil-net/) - a sister C# wrapper for the [Developer Image Library](http://openil.sourceforge.net/) (DevIL). (Mostly a relic at this point)

Follow project updates and more on [Twitter](https://twitter.com/Tesla3D/)

A support forum is located [here](http://www.tesla-engine.net/forums/). Feel free to post questions or comments on the direction of the library.