using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgConvertCmd
{
    enum ProcessFlags { Dds, DdsNoMipmap, DdsCompressed, DdsCompressedNoMipmap, Png, Backup, Restore, Thumbnail }
    public class Converter
    {
        private static string BackupExtension = ".backup";

        public static void Convert(string[] args)
        {
            if (args.Length < 2 && args.Length > 4)
            {
                ShowUsage();
                return;
            }

            var flag = ParseFlag(args[0]);
            if (flag == null)
            {
                Console.WriteLine("Invalid flag");
                return;
            }

            if (args.Length == 2)
            {
                var inFile = args[1];
                if (Directory.Exists(inFile))
                {
                    Console.WriteLine("Error: Only individual files are supported as input.");
                    //Thread.Sleep(500);
                    return;
                }
                switch (flag)
                {
                    case ProcessFlags.Dds: WarpLib.DdsTools.ConvertToDds(inFile, ReplaceFileExtension(inFile, ".dds"), true, false); break;
                    case ProcessFlags.DdsNoMipmap: WarpLib.DdsTools.ConvertToDds(inFile, ReplaceFileExtension(inFile, ".dds"), false, false); break;
                    case ProcessFlags.DdsCompressed: WarpLib.DdsTools.ConvertToDds(inFile, ReplaceFileExtension(inFile, ".dds"), true, true); break;
                    case ProcessFlags.DdsCompressedNoMipmap: WarpLib.DdsTools.ConvertToDds(inFile, ReplaceFileExtension(inFile, ".dds"), false, true); break;
                    case ProcessFlags.Png: WarpLib.DdsTools.ConvertToPng(inFile, ReplaceFileExtension(inFile, ".png")); break;
                    case ProcessFlags.Backup: BackupFile(inFile); break;
                    case ProcessFlags.Restore: Restore(inFile); break;
                }
            }
            else if (args.Length == 3)
            {
                var inFile = args[1];
                var outFile = args[2];
                if (Directory.Exists(inFile))
                {
                    Console.WriteLine("Error: Only individual files are supported as input.");
                    //Thread.Sleep(500);
                    return;
                }
                if (Directory.Exists(outFile))
                {
                    Console.WriteLine("Error: Only individual files are supported as input.");
                    // Thread.Sleep(500);
                    return;
                }
                switch (flag)
                {
                    case ProcessFlags.Dds: WarpLib.DdsTools.ConvertToDds(inFile, outFile, true, false); break;
                    case ProcessFlags.DdsNoMipmap: WarpLib.DdsTools.ConvertToDds(inFile, outFile, false, false); break;
                    case ProcessFlags.DdsCompressed: WarpLib.DdsTools.ConvertToDds(inFile, outFile, true, true); break;
                    case ProcessFlags.DdsCompressedNoMipmap: WarpLib.DdsTools.ConvertToDds(inFile, outFile, false, true); break;
                    case ProcessFlags.Png: WarpLib.DdsTools.ConvertToPng(inFile, outFile); break;
                }
            }
            else if (args.Length == 4)
            {
                switch (flag)
                {
                    case ProcessFlags.Thumbnail:
                        {
                            // usage: app.exe -thumbnail 256 myinputfile myoutputfile
                            var size = Int32.Parse(args[1]);
                            var inputFile = args[2];
                            var outfile = args[3];
                            using (var bmp = WarpLib.DdsTools.LoadDdsAsBitmapThumbnail(inputFile, size))
                            {
                                bmp.Save(outfile);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine("Done");
        }

        private static void BackupFile(string filename)
        {
            if (filename.EndsWith(BackupExtension, StringComparison.CurrentCultureIgnoreCase)) return;
            File.Copy(filename, filename + BackupExtension, true);
        }

        private static void Restore(string filename)
        {
            string fileToRestore = filename;
            string backupFile = filename;

            if (filename.EndsWith(BackupExtension, StringComparison.CurrentCultureIgnoreCase))
            {
                fileToRestore = filename.Substring(0, filename.Length - BackupExtension.Length);
                backupFile = filename;
            }
            else
            {
                fileToRestore = filename;
                backupFile = filename + BackupExtension;
            }
            if (File.Exists(backupFile) && File.Exists(fileToRestore))
            {
                File.Copy(backupFile, fileToRestore, true);
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            Thread.Sleep(500);
        }

        private static string ReplaceFileExtension(string filename, string newExtWithDot)
        {
            var fileNoExtension = System.IO.Path.GetFileNameWithoutExtension(filename);
            return System.IO.Path.Combine(Path.GetDirectoryName(filename), fileNoExtension + newExtWithDot);
        }

        private static ProcessFlags? ParseFlag(string a)
        {
            switch (a)
            {
                case "-dds": return ProcessFlags.Dds;
                case "-ddsNoMipmap": return ProcessFlags.DdsNoMipmap;
                case "-ddsBC7": return ProcessFlags.DdsCompressed;
                case "-ddsBC7NoMipmap": return ProcessFlags.DdsCompressedNoMipmap;
                case "-png": return ProcessFlags.Png;
                case "-backup": return ProcessFlags.Backup;
                case "-restore": return ProcessFlags.Restore;
                case "-thumbnail": return ProcessFlags.Thumbnail;
            }
            return null;
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage Inforamtion.");
            Console.WriteLine("Call this executable specifying a flag and the input filename");
            Console.WriteLine("Flags:");
            Console.WriteLine("-dds: outputs to uncompressed dds file with mipmaps");
            Console.WriteLine("-ddsNoMipmap: outputs to uncompressed dds file without mipmaps");
            Console.WriteLine("-ddsBC7: outputs to compressed dds file with mipmaps");
            Console.WriteLine("-ddsBC7NoMipmap: outputs to compressed dds file without mipmaps");
            Console.WriteLine("-png: outputs to compressed dds file with mipmaps");
            Console.WriteLine("Example1:");
            Console.WriteLine("ImgConvertCmd.exe -dds \"MySourceImage.png\"");
            Console.WriteLine("Will create a new image file in DDS format(uncompressed and with mipmaps) called \"MySourceImage.dds\"");
        }
    }
}
