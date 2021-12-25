using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System.Drawing.Imaging;

static class Extensions
{
    public static System.Drawing.Rectangle ToRect(this System.Drawing.Size size)
    {
        return new System.Drawing.Rectangle(new System.Drawing.Point(), size);
    }

    /// <summary>
    /// Returns the closest odd number, adding one if needed
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int MakeItOdd(this int n)
    {
        if (n % 2 == 0) return n + 1;
        return n;
    }

    /// <summary>
    /// Returns the closest even number, adding one if needed
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int MakeItEven(this int n)
    {
        if (n % 2 == 0) return n;
        return n + 1;
    }

    private static double GetDepthSize(DepthType rtype)
    {
        switch (rtype)
        {
            case DepthType.Cv8U:
                return byte.MaxValue;
            case DepthType.Cv8S:
                return byte.MaxValue/2;//Is this even correct?
            case DepthType.Cv16U:
                return ushort.MaxValue;
            case DepthType.Cv16S:
                return short.MaxValue;
            case DepthType.Cv32S:
                return int.MaxValue;
            case DepthType.Cv32F:
                return 1.0; // They are always normalized I believe
                            //return float.MaxValue;
            case DepthType.Cv64F:
                return 1.0;
            default:
                throw new ArgumentException("Unrecognized DepthType");

        }
    }

    public static void DepthAwareConvertTo(this Mat mat, IOutputArray m, DepthType rtype)
    {
        double source_depth = GetDepthSize(mat.Depth);
        double dest_depth = GetDepthSize(rtype);
        double scale_factor = dest_depth / source_depth;
        mat.ConvertTo(m, rtype, scale_factor);
    }


    public static Image<TColor2, TDepth2> DepthAwareConvert<TColor2, TDepth2>(this IInputOutputArray image, bool useDefault = true) where TColor2 : struct, IColor where TDepth2 : new()
    {
        //The signature is somewhat a dirty trick, but simplifies coding
        if (useDefault)
        {
            dynamic img = image;
            return img.Convert<TColor2, TDepth2>();
        }
        else
        {
            dynamic img = image;
            var newImage = new Image<TColor2, TDepth2>(img.Size);
            ((Mat)(img.Mat)).DepthAwareConvertTo(newImage, CvInvoke.GetDepthType(typeof(TDepth2)));
            return newImage;
        }
       
    }
}

//public class ImageUtils
//{
//    public static Image<TColor2,TDepth2> ConvertImage<TColor2, TDepth2>(dynamic image) where TColor2 : struct, IColor where TDepth2 : new()
//    {
//        var newImage = new Image<TColor2, TDepth2>(image.Size);
//        image.Mat.DepthAwareConvertTo(newImage, CvInvoke.GetDepthType(typeof(TDepth2)));
//        return newImage;
//    }
//}