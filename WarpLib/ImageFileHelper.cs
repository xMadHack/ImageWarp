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
    public class ImageFileHelper
    {

        /// <summary>
        /// Directly loading images using Image&lt;T1,T2&gt; constructors will result in the loss of the alpha Channel.
        /// Use this function instead, or open them using Mat yourself, as this code does.
        /// Loads an image from a file. The internal format will keep alpha if the image contains it.
        /// </summary>
        /// <typeparam name="TColor">The Emgu Color structure: Bgra, Gray, etc</typeparam>
        /// <typeparam name="TDepth">The depth: For example byte, short, etc </typeparam>
        /// <param name="filename"></param>
        /// <returns>An Image&lt;T1,T2&gt; object of the speficied format</returns>
        /// <exception cref="NullReferenceException"></exception>
        internal static Image<TColor, TDepth> LoadFromFile<TColor, TDepth>(string filename, bool converting=false) where TColor : struct, IColor where TDepth : new()
        {
            using (Mat mat = CvInvoke.Imread(filename, ImreadModes.Unchanged))
            {
                if (mat.IsEmpty)
                {
                    throw new NullReferenceException($"Unable to load image from file \"{filename}\".");
                }
                // the default ToImage has a depth "scale" problem.
                // For example, when transforming a value of 1000 from an ushort depth to byte, it just truncates it to 255.
                // The following block (when converting is true) ensures that the value is transformed to the new depth space. 
                // So, even if the default ToImage is called at the end, the values are already in the proper space
                if (converting)
                {
                    //Fixes a conversion problem when converting from different depths
                    using (Mat mat2 = new Mat())
                    {
                        mat.DepthAwareConvertTo(mat2, CvInvoke.GetDepthType(typeof(TDepth)));
                        return mat2.ToImage<TColor, TDepth>();
                    }
                }
                else
                {
                    return mat.ToImage<TColor, TDepth>();
                }
                
            }

        }
    }
}
