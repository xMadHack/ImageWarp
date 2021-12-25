using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpLib
{
    public class PatchTex
    {
        public static System.Drawing.Bitmap CreatePatch(string sourceFile, string maskFile, string outFile)
        {
            var sourceImage = ImageFileHelper.LoadFromFile<Bgra,byte>(sourceFile);
            var maskImage = ImageFileHelper.LoadFromFile<Gray, byte>(maskFile);
            maskImage = maskImage.Resize(sourceImage.Width, sourceImage.Height, Emgu.CV.CvEnum.Inter.Cubic);
            var outImage = ImageOps.MaskToAlpha(sourceImage, maskImage);

            outImage.Save(outFile);
            return outImage.ToBitmap();
        }

        private static bool IsDds(string file)
        {
            return file.EndsWith(".dds", StringComparison.CurrentCultureIgnoreCase);
        }

        public static System.Drawing.Bitmap ApplyPatch(string sourceFile, string patchFile, string outFile, bool compressDds = true)
        {
            using (var tempFolder = TempsHelper.DisposableFolder("patch_op_"))
            {
                Image<Bgra, byte> sourceImage = null;
                if (IsDds(sourceFile))
                {
                    var tempSourcePngFile = tempFolder.GetTempFile(".png");
                    DdsTools.ConvertToPng(sourceFile, tempSourcePngFile);
                    sourceImage = ImageFileHelper.LoadFromFile<Bgra, byte>(tempSourcePngFile);
                }
                else
                {
                    sourceImage = ImageFileHelper.LoadFromFile<Bgra, byte>(sourceFile);
                }


                var patchImage = ImageFileHelper.LoadFromFile<Bgra, byte>(patchFile);
                patchImage = patchImage.Resize(sourceImage.Width, sourceImage.Height, Emgu.CV.CvEnum.Inter.Cubic);
                Image<Bgra, byte> outImage = ImageOps.BlendOver(sourceImage, patchImage);

                if (IsDds(outFile))
                {
                    var tempSourcePngFile =  tempFolder.GetTempFile(".png");
                    outImage.Save(tempSourcePngFile);
                    DdsTools.SaveDdsAsCmd(tempSourcePngFile, outFile, true, compressDds);
                    return outImage.ToBitmap();
                }
                else
                {
                    outImage.Save(outFile);
                    return outImage.ToBitmap();
                }
            }
           
        }

    }
}
