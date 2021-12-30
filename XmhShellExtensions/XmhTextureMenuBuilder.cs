using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace XmhShellExtensions
{
    internal class XmhTextureMenuBuilder
    {
        public static ContextMenuStrip CreateMenu(IEnumerable<string> filenames)
        {
            //  Create the menu strip
            var menu = new ContextMenuStrip();

            //  Create a 'count lines' item
            var menuItem = new ToolStripMenuItem
            {
                Text = $"xMa{"dHac"}k Tools"
            };
            menuItem.DropDownItems.AddRange(CreateToolsSubMenuItems(filenames));

            //  Add the item to the context menu
            menu.Items.Add(menuItem);

            //  Return the menu
            return menu;
        }

        private static ToolStripMenuItem[] CreateToolsSubMenuItems(IEnumerable<string> filenames)
        {
            var texPatcherPath = RegHelper.TexPatcherPath();

            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();

            var item = new ToolStripMenuItem();
            item.Text = "Show with LiteView";
            item.Click += (sender, args) =>
            {
                foreach (var f in filenames)
                {
                    Process.Start(Path.GetFullPath(RegHelper.LiteViewPath()), $"\"{f}\"");
                }
            };
            items.Add(item);


            item = new ToolStripMenuItem();
            item.Text = "Open with TexPatcher";
            item.Click += (sender, args) =>
            {
                foreach (var f in filenames)
                {
                    Process.Start(Path.GetFullPath(texPatcherPath), $"\"{f}\"");
                }
            };
            items.Add(item);


            var imgConverterPath = RegHelper.ImgConverCmdPath();

            item = new ToolStripMenuItem();
            item.Text = "Convert to PNG";

            item.Click += (sender, args) =>
                DoCmdWithArgsForAll(imgConverterPath, filenames, (string f) => $"-png \"{f}\"");

            items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Convert to DDS";
            item.Click += (sender, args) => { };
            item.DropDownItems.AddRange(CreateDDsSubMenuItems(filenames, imgConverterPath));
            items.Add(item);
            //  Return the menu
            return items.ToArray();
        }


        private static void DoCmdWithArgs(string exePath, string args)
        {
            var p = new Process();
            p.StartInfo.FileName = exePath;
            p.StartInfo.Arguments = args;
            p.Start();
            p.WaitForExit(30000);
        }

        private static void DoCmdWithArgsForAll(string exePath, IEnumerable<string> filenames, Func<string, string> argsGetter)
        {
            foreach (var f in filenames)
            {
                DoCmdWithArgs(exePath, argsGetter(f));
            }
        }
        private static ToolStripMenuItem[] CreateDDsSubMenuItems(IEnumerable<string> filenames, string imgConvertCmdPath)
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();

            var item = new ToolStripMenuItem();
            item.Text = "Uncompressed";
            item.Click += (sender, args) =>
                DoCmdWithArgsForAll(imgConvertCmdPath, filenames, (string f) => $"-ddsNoMipmap \"{f}\"");
            items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Uncompressed with Mipmaps";
            item.Click += (sender, args) =>
                DoCmdWithArgsForAll(imgConvertCmdPath, filenames, (string f) => $"-dds \"{f}\"");

            items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Compressed (BC7)";
            item.Click += (sender, args) =>
                DoCmdWithArgsForAll(imgConvertCmdPath, filenames, (string f) => $"-ddsBC7NoMipmap \"{f}\"");
            items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Compressed (BC7) with Mipmaps";
            item.Click += (sender, args) =>
                DoCmdWithArgsForAll(imgConvertCmdPath, filenames, (string f) => $"-ddsBC7 \"{f}\"");
            items.Add(item);
            //  Return the menu
            return items.ToArray();
        }

    }
}
