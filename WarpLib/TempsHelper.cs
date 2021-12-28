using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpLib
{
    public class TempsHelper
    {
        private static int TempCounter = 0;
        /// <summary>
        /// A temporal unique filename. Doesn't include the directory
        /// </summary>
        /// <param name="extensionWithDot"></param>
        /// <returns></returns>
        public static string GetTemporalFilename(string extensionWithDot)
        {
            TempCounter += 1;
            //var file = DateTime.Now.ToString("HH:mm:ss:fff").Replace(":", "_") + "_temp_" + TempCounter.ToString() + extensionWithDot;
            var file = "t"+TempCounter.ToString()+"_"+Guid.NewGuid().ToString("N") + extensionWithDot;
            return file;
        }

        public static string AppTempFolder(bool ensureExists = true)
        {
            string userTemp = Path.GetTempPath();
            var folder = Path.Combine(Path.GetFullPath(userTemp), "XmhDdsTool");
            if (ensureExists && !Directory.Exists(folder)) { Directory.CreateDirectory(folder); }
            return folder;
        }

        public static ScopedTempFolder DisposableFolder(string namePrefix="") { return new ScopedTempFolder(namePrefix); }
    }
}
