using DirectXTexNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WarpLib
{
    public class DdsTools
    {


        public static System.Drawing.Bitmap LoadDdsAsBitmap(string ddsFile)
        {
            using var dds = LoadDDS(ddsFile);
            Guid guid = TexHelper.Instance.GetWICCodec(WICCodecs.PNG);
            using (UnmanagedMemoryStream memStream = dds.SaveToWICMemory(0, WIC_FLAGS.FORCE_SRGB, guid))
            {
                return (Bitmap)System.Drawing.Image.FromStream(memStream);
            }
        }

        public static System.Drawing.Bitmap LoadDdsAsBitmapThumbnail(string ddsFile, int width)
        {
            var tempFolder = TempsHelper.AppTempFolder();
            var tempPng = Path.Combine(tempFolder, TempsHelper.GetTemporalFilename(".png"));
            ConvertToPng(ddsFile, tempPng);
            Bitmap resized;
            using (var bmp = new Bitmap(tempPng))
            {
                //var meta = dds.GetMetadata();
                var aspectRatio = (double)bmp.Height / (double)bmp.Width;
                resized = new Bitmap(width, (int)(aspectRatio * width));
                using (var g = Graphics.FromImage(resized))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.DrawImage(bmp, 0, 0, resized.Width, resized.Height);
                }
            }
            System.IO.File.Delete(tempPng);


            return resized;
        }

        public static System.Drawing.Bitmap LoadDdsFromMemoryAsBitmap(MemoryStream ms)
        {
            using ScratchImage fromMem = TexHelper.Instance.LoadFromWICMemory(
                            new IntPtr(ms.Position),
                            ms.Length,
                            WIC_FLAGS.FORCE_RGB);
            Guid guid = TexHelper.Instance.GetWICCodec(WICCodecs.PNG);
            using (UnmanagedMemoryStream memStream = fromMem.SaveToWICMemory(0, WIC_FLAGS.FORCE_SRGB, guid))
            {
                return (Bitmap)System.Drawing.Image.FromStream(memStream);
            }
        }


        public static void ConvertToDds(string aFile, string ddsfile, bool mipmaps = true, bool compress = true)
        {
            SaveDdsAsCmd(aFile, ddsfile, mipmaps, compress);
        }



        public static void ConvertToPng(string ddsSourceFile, string pngOutput)
        {

            using (var folder = TempsHelper.DisposableFolder("conv_"))
            {
                var tempOutputFolder = folder.DirectoryPath;
                Console.WriteLine("Convert to Png: Calling cmd util with...");
                Console.WriteLine("Input: " + ddsSourceFile.ToString());
                Console.WriteLine("Output: " + pngOutput.ToString());
                var tempOutputFilename = Path.Combine(tempOutputFolder, Path.GetFileNameWithoutExtension(ddsSourceFile) + ".png");
                if (File.Exists(tempOutputFilename)) { File.Delete(tempOutputFilename); }

                // Compresses and creates mipmaps
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "Utils\\texconv.exe",
                        Arguments = $"-f B8G8R8A8_UNORM_SRGB -srgb -nologo -ft png -o \"{tempOutputFolder}\" -y \"{ddsSourceFile}\"",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };
                process.Start();
                process.WaitForExit();
                File.Move(tempOutputFilename, pngOutput, true);
                if (Directory.Exists(tempOutputFolder))
                {
                    try
                    {
                        Directory.Delete(tempOutputFolder, true);
                    }
                    catch { }
                }
            }

        }

        public static void SaveDdsAsCmd(string sourceFile, string ddsOutputfile, bool mipmaps = true, bool compress = true)
        {
            using (var tmpFolder = TempsHelper.DisposableFolder("dds_conv_"))
            {
                var tempOutputFolder = tmpFolder.DirectoryPath;

                Console.WriteLine("Calling cmd util with...");
                Console.WriteLine("Input: " + sourceFile.ToString());
                Console.WriteLine("Output: " + ddsOutputfile.ToString());
                var tempOutputFilename = Path.Combine(tempOutputFolder, Path.GetFileNameWithoutExtension(sourceFile) + ".dds");
                if (File.Exists(tempOutputFilename)) { File.Delete(tempOutputFilename); }
                var mipMapArg = "";
                if (mipmaps) mipMapArg = " -m 1";
                var formatArg = "";
                if (compress)
                {
                    formatArg = "BC7_UNORM";
                }
                else
                {
                    formatArg = "BGRA";

                }
                // Compresses and creates mipmaps
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "Utils\\texconv.exe",
                        Arguments = $"-f {formatArg} -nologo{mipMapArg} -o \"{tempOutputFolder}\" -y \"{sourceFile}\"",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };
                process.Start();
                process.WaitForExit();
                File.Move(tempOutputFilename, ddsOutputfile, true);
            }

        }

        private static bool IsDdsCompressed(TexMetadata meta)
        {
            //There might be other compression formats. 
            // Also, there might be a flag in the meta data telling about this.
            // Additionally, I{m not sure if this will be needed once the project
            // migrates to full texconv.exe as dds backend.
            switch (meta.Format)
            {
                case DXGI_FORMAT.BC1_TYPELESS:
                case DXGI_FORMAT.BC1_UNORM:
                case DXGI_FORMAT.BC1_UNORM_SRGB:
                case DXGI_FORMAT.BC2_TYPELESS:
                case DXGI_FORMAT.BC2_UNORM:
                case DXGI_FORMAT.BC2_UNORM_SRGB:
                case DXGI_FORMAT.BC3_TYPELESS:
                case DXGI_FORMAT.BC3_UNORM:
                case DXGI_FORMAT.BC3_UNORM_SRGB:
                case DXGI_FORMAT.BC4_SNORM:
                case DXGI_FORMAT.BC4_TYPELESS:
                case DXGI_FORMAT.BC4_UNORM:
                case DXGI_FORMAT.BC5_SNORM:
                case DXGI_FORMAT.BC5_TYPELESS:
                case DXGI_FORMAT.BC5_UNORM:
                case DXGI_FORMAT.BC6H_SF16:
                case DXGI_FORMAT.BC6H_TYPELESS:
                case DXGI_FORMAT.BC6H_UF16:
                case DXGI_FORMAT.BC7_TYPELESS:
                case DXGI_FORMAT.BC7_UNORM:
                case DXGI_FORMAT.BC7_UNORM_SRGB:
                    return true;
                default:
                    return false;
            }
        }

        private static ScratchImage LoadDDS(string filename, TexMetadata meta = null)
        {
            if (meta == null)
            {
                meta = TexHelper.Instance.GetMetadataFromDDSFile(filename, DirectXTexNet.DDS_FLAGS.NONE);
            }
            //var dds = DirectXTexNet.TexHelper.Instance.LoadFromDDSFile(filename, DirectXTexNet.DDS_FLAGS.NONE);
            var dds = DirectXTexNet.TexHelper.Instance.LoadFromDDSFile(filename, DirectXTexNet.DDS_FLAGS.FORCE_RGB);
            ScratchImage uncompressed = null;
            var wasCompressed = IsDdsCompressed(meta);

            if (wasCompressed)
            {
                uncompressed = dds.Decompress(0, DXGI_FORMAT.R8G8B8A8_UNORM);
                dds.Dispose();
            }
            else
            {
                if (meta.Format != DXGI_FORMAT.R8G8B8A8_UNORM)
                {
                    uncompressed = dds.Convert(DXGI_FORMAT.R8G8B8A8_UNORM, TEX_FILTER_FLAGS.DEFAULT, 0.5f);
                    dds.Dispose();
                }

            }
            return uncompressed;
        }

        private static void ConvertToDds(DirectXTexNet.ScratchImage image, string ddsFile, bool mipmaps, bool compress)
        {

            DirectXTexNet.ScratchImage mipMapStage = null;
            DirectXTexNet.ScratchImage compressionStage = null;
            try
            {
                if (mipmaps)
                {
                    mipMapStage = image.GenerateMipMaps(DirectXTexNet.TEX_FILTER_FLAGS.CUBIC | TEX_FILTER_FLAGS.DITHER, 0);
                }
                else
                {
                    mipMapStage = image;
                }
                if (compress)
                {
                    compressionStage = mipMapStage.Compress(DirectXTexNet.DXGI_FORMAT.BC7_UNORM, DirectXTexNet.TEX_COMPRESS_FLAGS.PARALLEL, 0.5f);
                }
                else
                {
                    compressionStage = mipMapStage;
                }

                compressionStage.SaveToDDSFile(DirectXTexNet.DDS_FLAGS.NONE, ddsFile);
            }
            finally
            {
                if (mipmaps)
                {
                    mipMapStage?.Dispose();
                }
                if (compress)
                {
                    compressionStage?.Dispose();
                }
            }


        }


    }
}
