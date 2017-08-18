# VendingMachine
Vending Machine excercise for Pillar

# Setup
The easiest way to get this running is to just open the solution and build it. The NuGet dependencies will install themselves and you should be good to go.

# Projects
This solution is divided into to projects. The main Vending Machine project that runs it all, and the tests.

# Running the Application
When you run it, it's just a simple console application to interact with the vending machine with a bunch of .ReadKey()'s. So just press the number keys to interact with it. No enter key needed!

# NuGet Dependencies
MSTest.TestFramework (1.1.17)
MSTest.TestAdapter (1.1.17)
Microsoft.NET.Test.Sdk (15.3.0)

# .NET Core
In order to run this, you need .NET Core 1.1.

It should come with Visual Studio but in case it didn't I've got a couple of ways to get it (it's too big to upload the .zip!)

# "Unable to start the program 'dotnet.exe'"
If you're getting this message it means you don't have .Net Core. 

There are a couple ways to get .Net Core:

The Visual Studio Installer way:
	It can also be installed through the Visual Studio Installer. 
	Just open it, select your visual studio version, click modify, and find the .NET Core SDK option. 
	
The github way:
	It can be found at https://github.com/dotnet/core/blob/master/release-notes/download-archive.md
