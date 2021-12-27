using SharpShell.Attributes;
using SharpShell.SharpThumbnailHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XmhShellExtensions
{
    /// <summary>
    /// The DdsThumbnailHandler is a ThumbnailHandler for dds files
    /// </summary>
    [ComVisible(true)]
#pragma warning disable CS0618 // Type or member is obsolete
    [COMServerAssociation(AssociationType.FileExtension, ".dds")]
#pragma warning restore CS0618 // Type or member is obsolete
    public class DdsThumbnailHandler : SharpThumbnailHandler
    {
        private const int GenerationTimeout = 30000;
        private Random rand = new Random(System.Environment.TickCount);
        private bool LogStuff = false; //change this for debugging purposes
        private string ImgConvertCmdPath="";
        private string LogFilepath()
        {
            return Path.Combine(Path.GetDirectoryName(ImgConvertCmdPath), "Thumbnails", "log.txt");
        }
        /// <summary>
        /// All these methods are called from a windows service host linked somehow to the shell.
        /// Crashing the runtime sounds risky. This is why we use this instead of just trusting that the
        /// log file will be correctly written.
        /// </summary>
        /// <param name="text"></param>
        private void TryLoggingLine(string logfile, string text)
        {
            try
            {
                File.AppendAllText(logfile, $"{DateTime.Now:HH:mm:ss:fff} - {text}\n" );
            }
            catch { }
        }

        private void LogSomethingReceived(int size)
        {
            if (!LogStuff) { return; }

            var imgConvertCmdDesc = new XMadHackRegistry.ImgConvertCmdDescription();
            var imgConverterPath = imgConvertCmdDesc.ReadRegisteredPath();

            var id = rand.Next().ToString();
            var logfile = LogFilepath();
            TryLoggingLine(logfile, $"Received ID:{id} Begin");
            TryLoggingLine(logfile, $"Received ID:{id} Width:{size}");
            TryLoggingLine(logfile, $"Received ID:{id} Name:{SelectedItemStream.Name}");
            TryLoggingLine(logfile, $"Received ID:{id} Length:{SelectedItemStream.Length}");
        }


        /// <summary>
        /// Gets the thumbnail image
        /// </summary>
        /// <param name="width">The width of the image that should be returned.</param>
        /// <returns>
        /// The image for the thumbnail
        /// </returns>
        /// 
        protected override Bitmap GetThumbnailImage(uint width)
        {
            
            if (!RegHelper.IsDdsThumbnailsEnabled())
            {
                return null;
            }
            ImgConvertCmdPath = RegHelper.ImgConverCmdPath();

            LogSomethingReceived((int)width);
            var file = SelectedItemStream.Name; // What if the stream doesnt include the filename?? :S

            //  Attempt to open the stream with a reader
            try
            {
                var filenameonly = Path.GetFileName(file);
                var infile = Path.Combine(Path.GetDirectoryName(ImgConvertCmdPath), "Thumbnails", filenameonly + "_" + rand.Next().ToString() + "_t.dds");
                var outfile = Path.Combine(Path.GetDirectoryName(ImgConvertCmdPath), "Thumbnails", filenameonly + "_" + rand.Next().ToString() + "_t.png");
                using (var ms = new MemoryStream())
                {
                    SelectedItemStream.CopyTo(ms);
                    File.WriteAllBytes(infile, ms.ToArray());
                }

                var p = new Process();
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = ImgConvertCmdPath;
                p.StartInfo.Arguments = $"-thumbnail {width} \"{infile}\" \"{outfile}\"";
                p.Start();
                p.WaitForExit(GenerationTimeout);
                try
                {
                    var bytes = File.ReadAllBytes(outfile);//We do this so the file can be deleted
                    using (var outms = new MemoryStream(bytes))
                    {
                        var bmp = new Bitmap(outms);
                        return bmp;
                    }
                }
                finally
                {
                    if (File.Exists(infile)) File.Delete(infile);
                    if (File.Exists(outfile)) File.Delete(outfile);
                }
            }
            catch (Exception ex)
            {
                //  Log the exception and return null for failure
                TryLoggingLine(LogFilepath(), "An exception occurred during thumbnail generation. Name: {} \n" + ex.ToString());
                return null;
            }
        }
    }
}
