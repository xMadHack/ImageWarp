# Xmh Tools
A tools suite for image processing.  
Project hosted at: https://github.com/xMadHack/ImageWarp  

Included features: 
- Enables generation of **DDS files thumbnails** in window explorer (including compressed formats)
- **Context Menu** with shortcuts for DDS and PNG files functionalities.
- **TexPatcher**: a Tool to quickly apply patches to texture files. (Mosly useful to patch body seams in textures like Skyrim, when having unmatching body and head textures.)
- **LiteView**: A light-weight image viewer supporting DDS file formats.

**Only Windows x64 operative systems are supported**  
**Requires .Net 6.0 and .NetFramework 4.7.2**  

**Tested in:**  
- Windows 10 x64

***Textures not included.***  
They have to be downloaded externally. For Skyrim, check https://www.nexusmods.com/

## Contribute!

With a pull request: https://github.com/xMadHack/ImageWarp  
Be a Patreon: https://www.patreon.com/xMadHack  
Donate to the effort: https://paypal.me/xMadHack  

## Instructions For Users

### Legitimate Download Sites

Do no accept binaries from sites that are not listed here.   
Legitimate:  
- Official Mod in NexusMods. 
- Releases of  https://github.com/xMadHack/ImageWarp/releases

### Installation
Normally, the installation instruction are listed in the site that hosted the link to the binaries.  
Here is listed the general usage.  

First, install the required runtimes (both of them):

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.1-windows-x64-installer

https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer

1. The binaries of Xmh Tools should come packaged in a zip file. 
1. Extract the files to the target application path (Where you want the application to be installed).
1. To enable Shell Extensions (DDS thumbnails in windows explorer, and image context menu), execute the file
"XmhShellExtensionsInstaller.exe" and follow instructions.

## For Developers
The solution is currently tested only with Visual Studio 2022 Comunity Edition.

### Building Instrutions
1. Get the source code.
2. Open it in VisualStudio 2022.
3. Build Debug x64 or Release x64.

All the required libraries should be downloaded automatically by NuGet.

### Creating outputs

Use the Publish feature (right click a project, and select Publish...) to create the outputs for each exe project.

## License

### ImageWarp
The solution (as in Visual Studio Solution, including all its projects) license is: GNU GPL license v3. 

## External Libraries.
## Emgu CV
Installed through NuGet when building.  
https://www.emgu.com/ 
Licence (GNU GPL license v3) copied in the Licenses folder.  

## Other NuGet Libraries Used
DirectxTexNet (MIT license)  
SharpShell (MIT license)
