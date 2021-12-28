using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteViewGL
{
    internal class ImagePositioner
    {
        private bool IsMouseDown = false;
        private PointF ImageCenter = new PointF(0F, 0F);
        private double ZoomFactor = 1.0;
        private double MinZoomFactorForImage = 0.1;
        private int MinDisplayImageSize = 100;

        public string Filename = "";

        public PointF ImageOrigin
        {
            get
            {
                if (ViewedImage != null)
                {
                    var ic = ImageCenter;
                    var s = ImageZoomedSize;
                    return new PointF((float)(ic.X - s.Width / 2.0), (float)(ic.Y - s.Height / 2.0));
                }
                else
                    return ImageCenter;
            }
        }

        private bool IsInitialized
        {
            get
            {
                return ViewedImage != null;
            }
        }

        public SizeF ImageZoomedSize
        {
            get
            {
                if (ViewedImage != null)
                    return new SizeF((float)(ViewedImage.Width * ZoomFactor), (float)(ViewedImage.Height * ZoomFactor));
                else
                    return new SizeF(1, 1);
            }
        }
        private Control ownerControl;
        private PointF CenterOfView
        {
            get
            {
                var cs = ownerControl.ClientSize;
                return new PointF((float)(cs.Width / 2.0), (float)(cs.Height / 2.0));
            }
        }
        public void pView_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            IsMouseDown = true;
            MouseOldPos = e.Location;
        }

        public void pView_MouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            IsMouseDown = false;
        }
        private Point MouseOldPos = new Point();
        public bool pView_MouseMove(MouseEventArgs e)
        {
            var newX = e.Location.X;
            var newy = e.Location.Y;
            var dx = newX - MouseOldPos.X;
            var dy = newy - MouseOldPos.Y;
            var needRedraw = false;
            if (IsInitialized && IsMouseDown)
            {
                ImageCenter = new PointF(ImageCenter.X + dx, ImageCenter.Y + dy);
                needRedraw = true;
            }
            MouseOldPos = e.Location;
            return needRedraw;
        }

        private Bitmap ViewedImage;

        public void LoadImage(Control owner, Bitmap bmp)
        {
            ownerControl = owner;
            ViewedImage = bmp;
            var min= Math.Min(ViewedImage.Width, ViewedImage.Height);  
            if (min < MinDisplayImageSize)
            {
                MinDisplayImageSize = min;
            };
            MinZoomFactorForImage = MinDisplayImageSize / min;
            ResetImage();
        }


        private double GetFitZoomFactor()
        {
            if (!IsInitialized)
                return 1.0;
            var viewAspect = System.Convert.ToDouble(ownerControl.ClientSize.Height) / System.Convert.ToDouble(ownerControl.ClientSize.Width);
            var imageAspect = System.Convert.ToDouble(ViewedImage.Height) / System.Convert.ToDouble(ViewedImage.Width);
            if (viewAspect > imageAspect)
                // fit by image width
                return System.Convert.ToDouble(ownerControl.ClientSize.Width) / System.Convert.ToDouble(ViewedImage.Width);
            else
                // fit by image height
                return System.Convert.ToDouble(ownerControl.ClientSize.Height) / System.Convert.ToDouble(ViewedImage.Height);
        }
        public void ResetImage()
        {
            ZoomFactor = GetFitZoomFactor();
            ImageCenter = CenterOfView;

        }
        public void ImgView_DoubleClick(EventArgs e)
        {

            if (ZoomFactor > 0.99 && ZoomFactor < 1.01)
                ResetImage();
            else
            {
                ZoomFactor = 1.0;
                ImageCenter = CenterOfView;

            }
        }

        public Image DisplayedImage
        {
            get
            {
                return ViewedImage;
            }
        }

        public bool ImgView_MouseWheel(MouseEventArgs e)
        {
            bool shouldRedraw = false;
            double zoomSpeed = 0.001;
            if (e.Delta != 0)
            {
                var DX = e.Location.X - ImageCenter.X;
                var DY = e.Location.Y - ImageCenter.Y;
                var presize = ImageZoomedSize;

                if (e.Delta > 0)
                    ZoomFactor *= (1.0 + (e.Delta * zoomSpeed));
                else
                    ZoomFactor /= (1.0 + (-e.Delta * zoomSpeed));
                ZoomFactor = Math.Min(20.0, Math.Max(MinZoomFactorForImage, ZoomFactor));

                var displacementRatio = (ImageZoomedSize.Width - presize.Width) / (double)presize.Width;
                ImageCenter = new PointF((float)(ImageCenter.X - (DX * displacementRatio)), (float)(ImageCenter.Y - (DY * displacementRatio)));
                shouldRedraw = true;
            }
            return shouldRedraw;
        }
    }

}

