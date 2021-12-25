using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace XmhShellExtensions
{
    /// <summary>
    /// The CountLinesExtensions is an example shell context menu extension,
    /// implemented with SharpShell. It adds the command 'Count Lines' to text
    /// files.
    /// </summary>
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class PngFilesExtension : SharpContextMenu
    {
        /// <summary>
        /// Determines whether this instance can a shell
        /// context show menu, given the specified selected file list
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance should show a shell context
        /// menu for the specified file list; otherwise, <c>false</c>
        /// </returns>
        protected override bool CanShowMenu()
        {
            if (!RegHelper.IsContextMenuEnabled())
            {
                return false;
            }
            return SelectedItemPaths.Any((s) => s.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith(".dds", StringComparison.CurrentCultureIgnoreCase));

        }

        /// <summary>
        /// Creates the context menu. This can be a single menu item or a tree of them.
        /// </summary>
        /// <returns>
        /// The context menu for the shell context menu.
        /// </returns>
        protected override ContextMenuStrip CreateMenu()
        {
            //  Return the menu
            return XmhShellExtensions.XmhTextureMenuBuilder.CreateMenu(SelectedItemPaths);
        }
    }
}