using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System.Drawing.Imaging;

namespace WarpLib
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public class WarpBitmap
    {
        public static Action<string> WriteToLogHandler = (string s) => { };
        private static void LogLine(string l)
        {
            WriteToLogHandler($"WarpLib : {l}");
        }

      
        public static void myOCVFunc()
        {
            String win1 = "Test Window"; //The name of the window
            CvInvoke.NamedWindow(win1); //Create the window using the specific name

            Mat img = new Mat(200, 400, DepthType.Cv8U, 3); //Create a 3 channel image of 400x200
            img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color

            //Draw "Hello, world." on the image using the specific font
            CvInvoke.PutText(
               img,
               "Hello, world",
               new System.Drawing.Point(10, 80),
               FontFace.HersheyComplex,
               1.0,
               new Bgr(0, 255, 0).MCvScalar);


            CvInvoke.Imshow(win1, img); //Show the image
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyWindow(win1); //Destroy the window if key is pressed
        }

        public static string ProcessingPipelineDebugFolder { get; set; } = System.IO.Path.GetFullPath(@".\PipelineDebugFolder");

        public static void ShowImage(Mat img, string filename)
        {
            ShowImage(img, filename, filename);
        }

        public static void ShowImage(Mat img, string label, string filename)
        {
            bool showWindow = false;
            if (!Directory.Exists(ProcessingPipelineDebugFolder))
            {
                System.IO.Directory.CreateDirectory(ProcessingPipelineDebugFolder);
            }
            var fullFilename = System.IO.Path.Combine(ProcessingPipelineDebugFolder, filename + ".png");
            img.Save(fullFilename);
            LogLine($"Pipeline step image {filename} written to: {fullFilename}");
            if (!showWindow) return;
            CvInvoke.NamedWindow(label); //Create the window using the specific name

            //Mat img = new Mat(200, 400, DepthType.Cv8U, 3); //Create a 3 channel image of 400x200
            //img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color

            CvInvoke.Imshow(label, img); //Show the image

            try
            {
                CvInvoke.WaitKey(0);  //Wait for the key pressing event
                CvInvoke.DestroyWindow(label); //Destroy the window if key is pressed
            }
            catch
            {
                System.Environment.Exit(0);
            }
        }

        public static Bitmap LoadBitmap(string filename)
        {
            Image<Bgra, Byte> My_Image = ImageFileHelper.LoadFromFile<Bgra, byte>(filename,true);
            return My_Image.ToBitmap();
        }

        /// <summary>
        /// Used for previews mostly.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Bitmap LoadBgrBitmap(string filename)
        {
            Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(filename);
            return My_Image.ToBitmap();
        }

        public static void GenerateIdentityGradient(int size, string filename)
        {
            int side = size;
            int maxValue = 256 * 256;
            int step = maxValue / side;
            Mat linesBlue = new Mat(side, side, DepthType.Cv16U, 3);
            for (int i = 0; i < side; i++)
            {
                int val = step * i;
                linesBlue.Row(i).SetTo(new Bgr(val, 0, 0).MCvScalar);
            }
            Mat linesRed = new Mat(side, side, DepthType.Cv16U, 3);
            for (int i = 0; i < side; i++)
            {
                int val = step * i;
                linesRed.Col(i).SetTo(new Bgr(0, 0, val).MCvScalar);
            }
            Image<Bgr, UInt16> img = (linesRed + linesBlue).ToImage<Bgr, UInt16>();
            img.Save(filename);
        }

        public static Bitmap GetWarppedBitmap(string sourceFilename, string warpMapFilename, string outputFilename, bool repairSeams)
        {
            if (!repairSeams)
            {
                var image = PerformImageWarp(sourceFilename, warpMapFilename, outputFilename);
                return image.ToBitmap();
            }
            else
            {
                var unpatchedFilename = System.IO.Path.GetDirectoryName(outputFilename);
                var fileOnly = "unpatched_" + System.IO.Path.GetFileName(outputFilename);
                unpatchedFilename = System.IO.Path.Combine(
                    unpatchedFilename,
                    fileOnly);
                var image = PerformImageWarp(sourceFilename, warpMapFilename, unpatchedFilename);

                return DoRepair(warpMapFilename, unpatchedFilename, outputFilename).ToBitmap();
            }
        }

        private static Image<Gray, byte> findEdges(Image<Bgr, UInt16> img)
        {

            var blur = img.SmoothGaussian(AdaptToRes(7));
            var sobel1 = new Image<Bgr, UInt16>(blur.Size);
            CvInvoke.Sobel(/*blurred*/blur, sobel1, DepthType.Cv16U, 1, 1, 7);
            var rotated = img.Rotate(180.0, new Bgr(0, 0, 0)).SmoothGaussian(7);
            var sobel2 = new Image<Bgr, UInt16>(blur.Size);
            CvInvoke.Sobel(/*blurred*/rotated, sobel2, DepthType.Cv16U, 1, 1, 7);

            var sobel3 = new Image<Bgr, UInt16>(blur.Size);
            CvInvoke.Sobel(/*blurred*/blur, sobel3, DepthType.Cv16U, 2, 2, 5);
            var sobel4 = new Image<Bgr, UInt16>(blur.Size);
            CvInvoke.Sobel(/*blurred*/rotated, sobel4, DepthType.Cv16U, 2, 2, 5);

            var sobellvl1 = (sobel1 + sobel2.Rotate(180.0, new Bgr(0, 0, 0))).DepthAwareConvert<Gray, byte>(); ;

            var sobellvl2 = (sobel3 + sobel4.Rotate(180.0, new Bgr(0, 0, 0))).DepthAwareConvert<Gray, byte>();

            sobellvl1 = sobellvl1.ThresholdBinary(new Gray(2), new Gray(255)).Dilate(ScaleToRes(2)).Erode(ScaleToRes(3)).Dilate(ScaleToRes(1));
            ShowImage(sobellvl1.Mat, "01_a_edges1", "01_a_edges1");
            sobellvl2 = sobellvl2.ThresholdBinary(new Gray(1), new Gray(255)).Dilate(ScaleToRes(10)).Erode(ScaleToRes(7));
            ShowImage(sobellvl2.Mat, "01_b_edges2", "01_a_edges2");

            return sobellvl1 + sobellvl2;
        }

        private static int AdaptToRes(double n)
        {
            return ScaleToRes(n).MakeItOdd();
        }

        private static int ScaleToRes(double n)
        {
            return (int)Math.Round(n * ThicknessScalingFactor);
        }

        private static Image<Gray, byte> findEdgesGaussiansDifference(Image<Bgr, UInt16> img)
        {
            var r1 = 1;
            var r2 = 9;
            var diff1_g1 = img.SmoothGaussian(AdaptToRes(r1));
            var diff1_g2 = img.SmoothGaussian(AdaptToRes(r2));

            //ShowImage(diff1_g1.Mat, "01_a_diff1_g1");
            //ShowImage(diff1_g2.Mat, "01_b_diff1_g2");
            var diff1 = diff1_g2 - diff1_g1;
            var diff2 = diff1_g1 - diff1_g2;
            diff1 = diff1 * 20;
            diff2 = diff2 * 20;
            ShowImage(diff1.Mat, "01_c_diff1");
            ShowImage(diff2.Mat, "01_d_diff2");

            var t1 = diff1.DepthAwareConvert<Gray, byte>().ThresholdBinary(new Gray(2), new Gray(255));
            var t2 = diff2.DepthAwareConvert<Gray, byte>().ThresholdBinary(new Gray(2), new Gray(255));

            ShowImage(t1.Mat, "01_e_diff1_thresh");
            ShowImage(t2.Mat, "01_f_diff2_thresh");
            var merged = t1 + t2;
            merged = merged.SmoothGaussian(3).ThresholdBinary(new Gray(40), new Gray(255));
            return merged.Dilate(ScaleToRes(1)).Erode(ScaleToRes(2)).Dilate(ScaleToRes(7)).Erode(ScaleToRes(3));
        }

        public static Image<Bgra, byte> RemoveAllDetails(Image<Bgra, byte> image)
        {
            var original_tex_size = image.Size;

            var blurred_texToRepair = image;//.Resize(1.0, Inter.Cubic);
            for (int i = 0; i < 1; i++)
            {
                blurred_texToRepair = blurred_texToRepair.SmoothMedian(AdaptToRes(25));//23 to 27 works
            }
            ShowImage(blurred_texToRepair.Mat, "07_blurred_median_tex", "07_blurred_median_tex");

            for (int i = 0; i < 0; i++)
            {
                blurred_texToRepair = blurred_texToRepair.SmoothGaussian(AdaptToRes(3));
            }
            ShowImage(blurred_texToRepair.Mat, "08_blurred_gaussian_tex", "08_blurred_gaussian_tex");


            return blurred_texToRepair.Resize(original_tex_size.Width, original_tex_size.Height, Inter.Cubic);
        }

        public static Image<Bgra, byte> DoRepair(string warpMapFilename, string texToRepairFilename, string outputFileName)
        {
            var image = ImageFileHelper.LoadFromFile<Bgr, UInt16>(warpMapFilename);
            var originalWarpMapSize = image.Size;

            image = image.Resize((double)WorkingResolution / (double)originalWarpMapSize.Width, Inter.Nearest);
            var blurred = image;//.SmoothGaussian(1);

            var edges_mask = findEdgesGaussiansDifference(image);
            ShowImage(edges_mask.Mat, "01_z_edges");
            var greyImage = image.DepthAwareConvert<Gray, byte>();
            var backgroundMask = greyImage.ThresholdBinary(new Gray(3), new Gray(255)).Erode(ScaleToRes(2));
            ShowImage(backgroundMask.Mat, "05_background_mask", "05_background_mask");

            var blurMask = backgroundMask & edges_mask;

            ShowImage(blurMask.Mat, "06_blur_mask", "06_blur_mask");

            var reversed = PerformReverseImageWarp(edges_mask, image).SmoothGaussian(AdaptToRes(7)).ThresholdBinary(new Gray(40), new Gray(255));
            ShowImage(reversed.Mat, "xx_reversed_mask", "xx_reversed_mask");

            var tex_to_repair = ImageFileHelper.LoadFromFile<Bgra, byte>(texToRepairFilename);
            var original_tex_size = tex_to_repair.Size;

            // Dilation here helps to have a bigger blend mask (to smooth a bigger are in the detected seams).
            // 3 is ok for normal usage. I tried 60, and the result doesn't seem to lose too much quality, but didn't solved the difficult seams
            // Difficult seams happen when the baked texture has patches from separated parts of the original texture
            // I might try a different approach to fix that:
            // First buil a mask (like the current one with big post dilation (60 or more). This mask should cover all the separated patches (not only the seams).
            // (I might find a different algorithm to find this mask too).
            // Secondly, smooth (median) the warp texture, (possibly several iterations, and in each iteration, I need to restore the unmasked parts). The
            // smoothed warpmap should contain in the masked parts an interpolation of the unmasked parts. Do the warp with this image instead.
            blurMask = blurMask.Dilate(ScaleToRes(5)).Resize((double)WorkingResolution / (double)blurMask.Width, Inter.Cubic).SmoothGaussian(AdaptToRes(35))/*.SmoothGaussian(AdaptToRes(25))*/;

            var blurred_texToRepair = RemoveAllDetails(tex_to_repair);
            // Put everything to the same size
            var resized_mask = blurMask.Resize(original_tex_size.Width, original_tex_size.Height, Inter.Cubic);

            //apply the blurring, but using the mask
            var bgr_mask = /*ImageUtils.ConvertImage<Gray, double>(resized_mask)*/ resized_mask.DepthAwareConvert<Bgra, byte>();

            ShowImage(bgr_mask.Mat, "09_bgr_mask", "09_bgr_mask");

            //tex_to_repair = tex_to_repair.Mul(inverted_mask);//AddWeighted(bgr_mask, 1,-1,0);
            //ShowImage(tex_to_repair.Mat, "10_tex_to_repair_no_seam_area", "10_tex_to_repair_no_seam_area");

            //var seam_patch = blurred_texToRepair.Mul(bgr_mask);//AddWeighted(inverted_mask, 1, -1, 0);
            //ShowImage(seam_patch.Mat, "11_seam_patch", "11_seam_patch");
            var patched_image = Blend(blurred_texToRepair, tex_to_repair, bgr_mask.DepthAwareConvert<Gray, byte>()/*ImageUtils.ConvertImage<Gray, double>(bgr_mask)*/); ;// + seam_patch;
            ShowImage(patched_image.Mat, "12_patched_image", "12_patched_image");
            patched_image.Save(outputFileName);
            return patched_image;
        }

        private static Image<Bgra, byte> Blend(Image<Bgra, byte> img1, Image<Bgra, byte> img2, Image<Gray, byte> mask)
        {
            var outputImage = new Image<Bgra, byte>(img1.Size);
            var img1Data = img1.Data;
            var img2Data = img2.Data;
            var maskData = mask.Data;
            var outputData = outputImage.Data;

            var w = img1.Width;
            var h = img1.Height;

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    //double factor = Math.Min(1.0, Math.Max(0.0, maskData[j, i, 0]));
                    double factor = Math.Min(1.0, Math.Max(0.0, (double)maskData[j, i, 0] / 255.0));
                    //if (factor>1.0 || factor < 0)
                    //{
                    //    int asd = 1;
                    //}
                    for (int k = 0; k < 4; k++)
                    {
                        outputData[j, i, k] = (byte)Math.Max(0, Math.Min(255, (img1Data[j, i, k] * factor) + (img2Data[j, i, k] * (1.0 - factor))));
                    }
                }
            }
            return outputImage;
        }
        private static double WorkingResolution = 4096;
        private static double TestsReferenceResolution = 4096;
        private static double ThicknessScalingFactor = (double)WorkingResolution / (double)TestsReferenceResolution;
        public static Image<Bgra, byte> PerformImageWarp(string sourceFilename, string warpMapFilename, string outputFilename)
        {
            var rawSourceImage = ImageFileHelper.LoadFromFile<Bgra, byte>(sourceFilename);

            var rawWarpImage = ImageFileHelper.LoadFromFile<Bgr, UInt16>(warpMapFilename);

            double targetWorkingResolution = WorkingResolution;
            var sourceWorkScaleFactor = (double)targetWorkingResolution / (double)rawSourceImage.Width;
            var warpMapWorkScaleFactor = (double)targetWorkingResolution / (double)rawWarpImage.Width;
            var sourceImage = rawSourceImage.Resize(sourceWorkScaleFactor, Inter.Cubic);
            var warpImage = rawWarpImage.Resize(warpMapWorkScaleFactor, Inter.Cubic);
            var outputImage = new Image<Bgra, byte>(sourceImage.Size);
            var sourceData = sourceImage.Data;
            var warpMapData = warpImage.Data;
            var outputData = outputImage.Data;
            var maxVal = ushort.MaxValue;

            var w = sourceImage.Cols;
            var h = sourceImage.Rows;

            for (int j = 0; j < sourceImage.Rows; j++)
            {
                for (int i = 0; i < sourceImage.Cols; i++)
                {
                    // Note that OpenCV pixel (0,0) origin is actually the center of the pixel (0.5, 0.5)
                    // This is the reason for adding 0.5. Otherwise, the obtained coordinates are not correct
                    ushort wR = warpMapData[j, i, 2];
                    ushort wB = warpMapData[j, i, 0];
                    double wx = 0.5 + ((double)wR / (double)(maxVal)) * (double)(w);
                    int x = (int)Math.Floor(Math.Min((double)w - 1, (double)Math.Max(wx, 0.0)));
                    double wy = 0.5 + ((double)wB / (double)(maxVal)) * (double)(h);
                    int y = (int)Math.Floor(Math.Min((double)h - 1, (double)Math.Max(wy, 0.0)));
                    outputData[j, i, 0] = sourceData[y, x, 0];
                    outputData[j, i, 1] = sourceData[y, x, 1];
                    outputData[j, i, 2] = sourceData[y, x, 2];
                    outputData[j, i, 3] = sourceData[y, x, 3];
                }
            }
            var downScaledOutputImage = outputImage.Resize(1.0 / sourceWorkScaleFactor, Inter.Cubic);
            downScaledOutputImage.Save(outputFilename);
            return downScaledOutputImage;
        }



        public static Image<T1, byte> PerformReverseImageWarp<T1>(Image<T1, byte> rawSourceImage, Image<Bgr, UInt16> rawWarpImage) where T1 : struct, IColor
        {
            double targetWorkingResolution = WorkingResolution;
            var sourceWorkScaleFactor = (double)targetWorkingResolution / (double)rawSourceImage.Width;
            var warpMapWorkScaleFactor = (double)targetWorkingResolution / (double)rawWarpImage.Width;
            var sourceImage = ((dynamic)rawSourceImage).Resize(sourceWorkScaleFactor, Inter.Cubic);
            var warpImage = rawWarpImage.Resize(warpMapWorkScaleFactor, Inter.Cubic);
            var outputImage = new Image<T1, byte>(sourceImage.Size);
            var sourceData = (byte[,,])sourceImage.Data;
            var warpMapData = warpImage.Data;
            var outputData = outputImage.Data;

            var w = sourceImage.Cols;
            var h = sourceImage.Rows;
            int channels;

            if (rawSourceImage is Image<Gray, byte>)
            {
                channels = 1;
            }
            else
            {
                channels = 4;
            }

            var maxVal = ushort.MaxValue;

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    // Note that OpenCV pixel (0,0) origin is actually the center of the pixel (0.5, 0.5)
                    // This is the reason for adding 0.5. Otherwise, the obtained coordinates are not correct
                    ushort wR = warpMapData[j, i, 2];
                    ushort wB = warpMapData[j, i, 0];
                    double wx = 0.5 + ((double)wR / (double)(maxVal)) * (double)(w);
                    int x = (int)Math.Floor(Math.Min((double)w - 1, (double)Math.Max(wx, 0.0)));
                    double wy = 0.5 + ((double)wB / (double)(maxVal)) * (double)(h);
                    int y = (int)Math.Floor(Math.Min((double)h - 1, (double)Math.Max(wy, 0.0)));
                    for (int k = 0; k < channels; k++)
                    {
                        outputData[y, x, k] = sourceData[j, i, k];
                    }
                }
            }

            var downScaledOutputImage = outputImage.Resize(1.0 / sourceWorkScaleFactor, Inter.Cubic);

            return downScaledOutputImage;
        }
    }
}