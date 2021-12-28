namespace LiteViewGL
{
    partial class LiteViewGL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLiteViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImgContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveADDSUncompressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsDDSCompressedBC7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.ImgContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1644, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageFileToolStripMenuItem
            // 
            this.openImageFileToolStripMenuItem.Name = "openImageFileToolStripMenuItem";
            this.openImageFileToolStripMenuItem.Size = new System.Drawing.Size(283, 40);
            this.openImageFileToolStripMenuItem.Text = "Open Image File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(283, 40);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(283, 40);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutLiteViewToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(74, 34);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutLiteViewToolStripMenuItem
            // 
            this.aboutLiteViewToolStripMenuItem.Name = "aboutLiteViewToolStripMenuItem";
            this.aboutLiteViewToolStripMenuItem.Size = new System.Drawing.Size(271, 40);
            this.aboutLiteViewToolStripMenuItem.Text = "About LiteView";
            // 
            // ImgContextMenu
            // 
            this.ImgContextMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ImgContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsPNGToolStripMenuItem,
            this.saveADDSUncompressedToolStripMenuItem,
            this.saveAsDDSCompressedBC7ToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.ImgContextMenu.Name = "contextMenuStrip1";
            this.ImgContextMenu.Size = new System.Drawing.Size(395, 184);
            // 
            // saveAsPNGToolStripMenuItem
            // 
            this.saveAsPNGToolStripMenuItem.Name = "saveAsPNGToolStripMenuItem";
            this.saveAsPNGToolStripMenuItem.Size = new System.Drawing.Size(394, 36);
            this.saveAsPNGToolStripMenuItem.Text = "Save As PNG...";
            this.saveAsPNGToolStripMenuItem.Click += new System.EventHandler(this.saveAsPNGToolStripMenuItem_Click);
            // 
            // saveADDSUncompressedToolStripMenuItem
            // 
            this.saveADDSUncompressedToolStripMenuItem.Name = "saveADDSUncompressedToolStripMenuItem";
            this.saveADDSUncompressedToolStripMenuItem.Size = new System.Drawing.Size(394, 36);
            this.saveADDSUncompressedToolStripMenuItem.Text = "Save As DDS (Uncompressed)...";
            this.saveADDSUncompressedToolStripMenuItem.Click += new System.EventHandler(this.saveADDSUncompressedToolStripMenuItem_Click);
            // 
            // saveAsDDSCompressedBC7ToolStripMenuItem
            // 
            this.saveAsDDSCompressedBC7ToolStripMenuItem.Name = "saveAsDDSCompressedBC7ToolStripMenuItem";
            this.saveAsDDSCompressedBC7ToolStripMenuItem.Size = new System.Drawing.Size(394, 36);
            this.saveAsDDSCompressedBC7ToolStripMenuItem.Text = "Save As DDS (Compressed BC7)...";
            this.saveAsDDSCompressedBC7ToolStripMenuItem.Click += new System.EventHandler(this.saveAsDDSCompressedBC7ToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(394, 36);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(394, 36);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // LiteViewGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1644, 849);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LiteViewGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[XMH] LiteView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ImgContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutLiteViewToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ImgContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveADDSUncompressedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsDDSCompressedBC7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

