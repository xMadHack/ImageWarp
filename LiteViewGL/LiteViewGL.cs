using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LiteViewGL
{
    public partial class LiteViewGL : Form
    {
        private bool GlInitialized;
        private GLControl glc;
        private int ImageTexture = 0;
        private Bitmap DisplayedImage;
        private ImagePositioner ImgPositioner;
        private string ImgFilename;
        public LiteViewGL()
        {
            InitializeComponent();
            glc = new GLControl(OpenTK.Graphics.GraphicsMode.Default, 3, 0, OpenTK.Graphics.GraphicsContextFlags.Default);
            this.Controls.Add(glc);
            int margin = 10;
            menuStrip1.Visible = false;
            glc.Location = new Point(margin, margin);
            glc.Width = this.ClientSize.Width - margin * 2;
            glc.Height = this.ClientSize.Height - margin * 2;
            glc.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            glc.ContextMenuStrip = ImgContextMenu;
            GlInitialized = false;

            ImgPositioner = new ImagePositioner();
            AddHandlers();
        }

        private void AddHandlers()
        {
            this.Shown += this.FormShown;
            this.Load += this.FormLoad;
            glc.MouseDown += this.HandleMouseDown;
            glc.MouseUp += this.HandleMouseUp;
            glc.MouseMove += this.HandleMouseMove;
            glc.MouseWheel += this.HandleMouseWheel;
            glc.DoubleClick += this.HandleDoubleClick;
            glc.Paint += this.HandleGlcPaint;
            glc.Resize += this.HandleResize;
        }

        public void FormShown(object sender, EventArgs eventArgs)
        {
            if (DisplayedImage == null)
            {

                LoadImageFromArgsOrAsk();
            }
            HandleResize(this, EventArgs.Empty);
            glc.Invalidate();
        }


        private void LoadImageFromArgsOrAsk()
        {
            string requestedFilename = "";
            if (Program.Arguments.Length > 0)
            {
                requestedFilename = Program.Arguments[0];
            }
            else
            {
                //ask for it
                var ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.bmp;*.dds;*.gif;*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    requestedFilename = ofd.FileName;
                }
                else
                {
                    Close();
                }
            }
            if (String.IsNullOrWhiteSpace(requestedFilename)) return;
            DisplayedImage = ImgConvertCmdWrapper.LoadBitmap(requestedFilename);
            ImgFilename = requestedFilename;
            ImgPositioner.LoadImage(this, DisplayedImage);
            SetUpTexture();
            UpdateTitle();

        }


        public void FormLoad(object sender, EventArgs eventArgs)
        {
            InitializeGL();
        }

        public void HandleMouseDown(object sender, MouseEventArgs eventArgs)
        {
            ImgPositioner.pView_MouseDown(eventArgs);
        }

        public void HandleMouseUp(object sender, MouseEventArgs eventArgs)
        {
            ImgPositioner.pView_MouseUp(eventArgs);

        }
        public void HandleMouseMove(object sender, MouseEventArgs eventArgs)
        {
            if (ImgPositioner.pView_MouseMove(eventArgs))
            {
                glc.Invalidate();
            }

        }

        public void HandleMouseWheel(object sender, MouseEventArgs eventArgs)
        {
            if (ImgPositioner.ImgView_MouseWheel(eventArgs))
            {
                glc.Invalidate();
            }

        }

        public void HandleDoubleClick(object sender, EventArgs eventArgs)
        {
            ImgPositioner.ImgView_DoubleClick(eventArgs);
            glc.Invalidate();
        }

        //private Bitmap ConvertoToCompatibleFormat(Bitmap src)
        //{
        //    Bitmap dest = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    using (var g = Graphics.FromImage(dest))
        //    {
        //        g.DrawImage(src, 0, 0, dest.Width, dest.Height);
        //    }
        //    return dest;
        //}

        private void SetUpTexture()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1, out ImageTexture);
            GL.BindTexture(TextureTarget.Texture2D, ImageTexture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToBorder);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToBorder);
            Rectangle rect = new Rectangle(0, 0, DisplayedImage.Width, DisplayedImage.Height);
            BitmapData data = DisplayedImage.LockBits(rect,
                                              ImageLockMode.ReadOnly,
                                              System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(
                    OpenTK.Graphics.OpenGL.TextureTarget.Texture2D,   // texture_target,
                    0,                                                // level,
                    OpenTK.Graphics.OpenGL.PixelInternalFormat.Rgba,  // internal_format
                    data.Width, data.Height,                          // width, height, 
                    0,                                                // border,
                    OpenTK.Graphics.OpenGL.PixelFormat.Bgra,          // pixel_format
                    OpenTK.Graphics.OpenGL.PixelType.UnsignedByte,    // pixel_type
                    data.Scan0                                        // pixels
                    );

            GL.PixelStore(PixelStoreParameter.UnpackRowLength, data.Width * 4); // 4x for 32bpp
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            DisplayedImage.UnlockBits(data);
        }

        private void InitializeGL()
        {
            glc.MakeCurrent();
            //GL.DepthFunc(DepthFunction.Always);
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);
            GL.Disable(EnableCap.Lighting);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.ClearColor(BackColor);
            GL.Enable(EnableCap.Texture2D);
            GL.ActiveTexture(TextureUnit.Texture0);
            HandleResize(this, EventArgs.Empty);
            GL.Color3(Color.White);

            GlInitialized = true;
        }

        private void RenderImage()
        {
            var o = ImgPositioner.ImageOrigin;
            var s = ImgPositioner.ImageZoomedSize;
            var z = -0.5;
            GL.Begin(PrimitiveType.TriangleStrip);
            GL.TexCoord2(0, 0);
            GL.Vertex3(o.X, o.Y, z);
            GL.TexCoord2(1, 0);
            GL.Vertex3(o.X + s.Width, o.Y, z);
            GL.TexCoord2(0, 1);
            GL.Vertex3(o.X, o.Y + s.Height, z);
            GL.TexCoord2(1, 1);
            GL.Vertex3(o.X + s.Width, o.Y + s.Height, z);
            GL.End();
        }

        private void UpdateTitle()
        {
            if (string.IsNullOrWhiteSpace(ImgFilename) || DisplayedImage == null)
                return;
            this.Text = $"[XMH] LiteView >  {ImgFilename} > {DisplayedImage.Width}x{DisplayedImage.Height}";
        }

        private void HandleResize(object sender, EventArgs e)
        {
            if (!GlInitialized)
                return;
            glc.MakeCurrent();
            GL.Viewport(0, 0, glc.Width, glc.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glc.Width, glc.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

        }
        private void HandleGlcPaint(object sender, PaintEventArgs e)
        {
            if (!GlInitialized) // Play nice
                return;
            glc.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (DisplayedImage != null)
            {
                RenderImage();

            }
            glc.SwapBuffers();
        }



        private void saveAsPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Saving As PNG";
            sfd.Filter = "PNG Images| *.png";
            sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(ImgFilename) + ".png";
            if (sfd.ShowDialog() == DialogResult.OK)
                ImgConvertCmdWrapper.ConvertToPng(ImgFilename, sfd.FileName);
        }

        private void saveADDSUncompressedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Saving As Uncompressed DDS";
            sfd.Filter = "DDS Images| *.dds";
            sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(ImgFilename) + ".dds";
            if (sfd.ShowDialog() == DialogResult.OK)
                ImgConvertCmdWrapper.ConvertToDds(ImgFilename, sfd.FileName, false);
        }

        private void saveAsDDSCompressedBC7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Saving As Compressed (BC7) DDS";
            sfd.Filter = "DDS Images| *.dds";
            sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(ImgFilename) + ".dds";
            if (sfd.ShowDialog() == DialogResult.OK)
                ImgConvertCmdWrapper.ConvertToDds(ImgFilename, sfd.FileName, true);
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(DisplayedImage);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
