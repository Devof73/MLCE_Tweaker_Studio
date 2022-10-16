using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FuiEditor.Forms
{
    public partial class PicViewer : Form
    {
        public PicViewer(Image Image)
        {
            InitializeComponent();
            MainImage = Image;
            pictureBox1.Image = Image;
            var x = MainImage.Width;
            var y = MainImage.Height;
            int xx = 0;
            int yy = 0;
            bool comp = false;
            if (y > 70 && x > 70)
            {
                this.Size = new Size(x, y);
            }
            if (x < 70)
            {
                xx = 100;
                comp = true;
            }
            else if (y < 70)
            {
                yy = 100;
                comp = true;
            }
            if (comp == true)
            {
                this.Size = new Size(190, 190);
            }

        }
        Image MainImage;

        private void PicViewer_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Size.Height < 90 || this.Size.Width < 90)
            {
                this.Size = new Size(150, 150);
                throw new Exception("Cant resize windows below 90x90. Minimum size fetched.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
              "", false);

            ImageFormat[] imageFormats =
            {
                ImageFormat.Png,
                ImageFormat.Jpeg
            };

            CommonSaveFileDialog fileDialog = new CommonSaveFileDialog("")
            {
                Filters =
                {
                    new CommonFileDialogFilter("PNG", "*.png"),
                    new CommonFileDialogFilter("JPEG", "*.jpg;*.jpeg")
                },
                Controls =
                {
                    correctColorCb
                },
                RestoreDirectory = true
            };
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (correctColorCb.IsChecked)
                {
                    ImageUtils.ReverseColorRB((Bitmap)MainImage);
                }
                ImageFormat saveFormat = imageFormats[fileDialog.SelectedFileTypeIndex - 1];
                MainImage.Save(fileDialog.FileName, saveFormat);
                //File.WriteAllBytes();
            }

            fileDialog.Dispose();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImageUtils.ReverseColorRB((Bitmap)MainImage);
            pictureBox1.Image = MainImage;
        }
    }
}
