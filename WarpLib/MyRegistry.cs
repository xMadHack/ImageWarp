using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WarpLib
{
    public class MyRegistry
    {
        public static string ReadRegistry()
        {
            Registry.GetValue("HKEY_CURRENT_USER\\Software\\xMadHack", "TexPatcherPath", null); //"ImgConvertCmdPath"
            return "";
        }

        public static void WriteBaseValues()
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\xMadHack", "TexPatcherPath", @"D:\Max\Projects\ImageWarp\TexPatcher\bin\x64\Release\net6.0-windows\TexPatcher.exe", RegistryValueKind.String);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\xMadHack", "ImgConvertCmdPath", @"D:\Max\Projects\ImageWarp\ImgConvertCmd\bin\x64\Release\net6.0-windows\ImgConvertCmd.exe", RegistryValueKind.String);
        }
    }
}
