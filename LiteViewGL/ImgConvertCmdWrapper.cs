using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteViewGL
{
    public class ImgConvertCmdWrapper
    {

        private static string baseFilePath()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImgConvertCmd.DUCKYDUCK.png");
        }
        private static string ImgConvertCmdFilePath { get { 
                // This is shameful :C
                // Don't refactor this.  It fixes an error with the Internetz. See readme
                return baseFilePath().Replace("DUCKYDUCK.png", "") + "executive.png".Substring(0, 3); } }

        private static void DoCmdWithArgs(string filename, string args)
        {
            var p = new Process();
            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit(10000);
        }

        public static void ConvertToPng(string srcImage, string dstImage)
        {
            DoCmdWithArgs(ImgConvertCmdFilePath, $"-png \"{srcImage}\" \"{dstImage}\"");
        }

        public static byte[] ConvertToPngBytes(string srcImage)
        {
            using (var tempFolder = WarpLib.TempsHelper.DisposableFolder("lv_"))
            {
                var tempFile = tempFolder.GetTempFile(".png");
                ConvertToPng(srcImage, tempFile);
                return System.IO.File.ReadAllBytes(tempFile);
            }
        }

        public static Bitmap LoadBitmap(string srcImage)
        {
            return new Bitmap(new System.IO.MemoryStream(ConvertToPngBytes(srcImage)));
        }

        public static void ConvertToDds(string srcImage, string dstImage, bool compressed)
        {
            if (compressed)
            {
                DoCmdWithArgs(ImgConvertCmdFilePath, $"-ddsBC7 \"{srcImage}\" \"{dstImage}\"");
            }
            else
            {
                DoCmdWithArgs(ImgConvertCmdFilePath, $"-dds \"{srcImage}\" \"{dstImage}\"");
            }
        }
    }
}
