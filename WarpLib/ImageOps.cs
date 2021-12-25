using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpLib
{
    internal class ImageOps
    {
        public static Image<Bgra, byte> MaskToAlpha(Image<Bgra, byte> img1, Image<Gray, byte> mask)
        {
            var outputImage = img1.Clone();
            var img1Data = img1.Data;
            var maskData = mask.Data;
            var outputData = outputImage.Data;

            var w = img1.Cols;
            var h = img1.Rows;

            for (int j = 0; j < img1.Rows; j++)
            {
                for (int i = 0; i < img1.Cols; i++)
                {
                    double factor = Math.Min(1.0, Math.Max(0.0, (double)maskData[j, i, 0] / 255.0));

                    outputData[j, i, 3] = (byte)Math.Max(0, Math.Min(255, (img1Data[j, i, 3] * factor)));
                }
            }
            return outputImage;
        }

        public static Image<Bgra, byte> BlendOver(Image<Bgra, byte> imgBase, Image<Bgra, byte> imgOver)
        {
            var outputImage = new Image<Bgra, byte>(imgBase.Size);
            var baseImgData = imgBase.Data;
            var imgOverData = imgOver.Data;
            var outputData = outputImage.Data;

            var w = imgBase.Width;
            var h = imgBase.Height;

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    double factor = 1.0 - Math.Min(1.0, Math.Max(0.0, (double)imgOverData[j, i, 3] / 255.0));

                    for (int k = 0; k < 4; k++)
                    {
                        outputData[j, i, k] = (byte)Math.Max(0, Math.Min(255, (baseImgData[j, i, k] * factor + imgOverData[j, i, k] * (1.0 - factor))));
                    }
                    outputData[j, i, 3] = baseImgData[j, i, 3];//Keep the alpha value
                }
            }
            return outputImage;
        }

    }
}
