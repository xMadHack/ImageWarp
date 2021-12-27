using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmhShellExtensions
{
    internal class RegHelper
    {
    

    public static bool IsContextMenuEnabled()
        {
            var shellExtDescr = new XMadHackRegistry.XmhShellExtensionsDescription();
            return shellExtDescr.ReadEnableContextMenu();
        }

        public static bool IsDdsThumbnailsEnabled()
        {
            var shellExtDescr = new XMadHackRegistry.XmhShellExtensionsDescription();
            return shellExtDescr.ReadEnableDdsThumbnails();
        }

        public static string ImgConverCmdPath()
        {
            var appDesc = new XMadHackRegistry.ImgConvertCmdDescription();
            return appDesc.ReadRegisteredPath();
        }
        public static string TexPatcherPath()
        {
            var appDesc = new XMadHackRegistry.TexPatcherDescription();
            return appDesc.ReadRegisteredPath();
        }

        public static string LiteViewPath()
        {
            var appDesc = new XMadHackRegistry.LiteViewDescription();
            return appDesc.ReadRegisteredPath();
        }
    }
}
