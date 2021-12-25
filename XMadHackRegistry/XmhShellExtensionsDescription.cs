using System;
using System.Collections.Generic;
using System.Text;

namespace XMadHackRegistry
{
    public class XmhShellExtensionsDescription : AppDescription
    {
        public const string EnableDdsThumbnailsExtValueName = "EnableDdsThumbnails";
        public const string EnableContextMenuExtValueName = "EnableContextMenu";
        public override string AppFilenameWithoutExtension()
        {
            return "XmhShellExtensions";
        }

        public void WriteBaseRegistryValues(bool enableDdsThumbnails, bool enableContextMenu,bool appEnabled = true)
        {
            base.WriteBaseRegistryValues(appEnabled);
            WriteBoolValueToRegistry(EnableDdsThumbnailsExtValueName, enableDdsThumbnails);
            WriteBoolValueToRegistry(EnableContextMenuExtValueName, enableContextMenu);
        }

        public override void DeleteRegistryValues()
        {
            AppKey.DeleteValue(EnableContextMenuExtValueName);
            AppKey.DeleteValue(EnableDdsThumbnailsExtValueName);
            base.DeleteRegistryValues();
        }

        public bool ReadEnableDdsThumbnails()
        {
            return ReadBoolValueFromRegistry(EnableDdsThumbnailsExtValueName);
        }

        public bool ReadEnableContextMenu()
        {
            return ReadBoolValueFromRegistry(EnableContextMenuExtValueName);
        }
    }
}
