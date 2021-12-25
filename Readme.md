# ImageWarp
A tools suite for image processing. 

Included features: 
- Enables generation of DDS files in window explorer (including compressed formats)
- Context Menu with shortcuts for DDS and PNG files functionalities.
- TexPatcher: a Tool to quickly apply patches to texture files. (Mosly useful to patch body seams in textures like Skyrim, when having unmatching body and head textures.)

**Only Windows x64 operative systems are supported** 
**Requires .Net 6.0 and .NetFramework 4.8** 
*Tested in:*
- Windows 10 x64

***Textures not included.*** 
They have to be downloaded externally. For Skyrim, check https://www.nexusmods.com/

## For users

### Legitimate download sites

Do no accept binaries from site that are not listed here (unless you really trust them).
TODO: Add links

### Installation
Normally, the installation instruction are listed in the site that hosted the link to the binaries. 
Here is listed the general usage.

1. The binaries should come packaged in a zip file. 
1. Extract the files to the target application path (Where you want the application to be installed).
1. To enable Shell Extensions (DDS thumbnails in windows explorer, and image context menu), execute the file
"XmhShellExtensionsInstaller.exe" and follow instructions.

## For developers
The solution is currently tested only with Visual Studio 2022 Comunity Edition.

### Building instrutions
1. Get the source code.
2. Open it in VisualStudio 2022.
3. Build Debug x64 or Release x64.

All the required libraries should 

### Creating outputs

Use the Publish feature (right click a project, and select Publish...) to create the outputs for each exe project.

## License

### ImageWarp
The solution (as in Visual Studio Solution, including all its projects) license is: GNU GPL license v3. 

## External libraries.
## Emgu CV
Installed through NuGet when building.
https://www.emgu.com/ 
Licence (GNU GPL license v3) copied in the Licenses folder. 

## Other NuGet Libraries Used
DirectxTexNet (MIT license)
SharpShell (MIT license)