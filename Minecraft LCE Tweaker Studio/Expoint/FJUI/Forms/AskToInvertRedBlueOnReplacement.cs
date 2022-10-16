using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms
{
    public partial class AskToInvertRedBlueOnReplacement : Form
    {
        private string ImageFileName = null;
        private string Message = "Are you sure?";
        private bool SkipAll = false;
        public bool IsSkiping
        {
            get { return SkipAll; }
        }
        public AskToInvertRedBlueOnReplacement(string filename, string message = null)
        {
            InitializeComponent();
            if (message != null)
            {
                Message = message;
            }
            var check = new FileInfo(filename);
            {
                if (check.Exists)
                {
                    if (check.Extension.ToLower() == ".png" || check.Extension.ToLower() is ".jpg")
                    {
                        ImageFileName = filename;
                        TargetDesign((Bitmap)Bitmap.FromFile(ImageFileName), Bitmap.FromHicon(System.Drawing.SystemIcons.Warning.Handle), Message);
                    }
                }
                else
                {
                    throw new FileNotFoundException("File doesnt exist!");
                }
            }

        }
        private void TargetDesign(Bitmap bmp, Bitmap msgIco, string msg)
        {
            PICBX_msgIco.Image = msgIco;
            PICBX_TargetImage.Image = bmp;
            LABEL_MESSAGE.Text = msg;
        }

        public new DialogResult ShowDialog()
        {
            ((this) as Form).ShowDialog();
            return this.DialogResult;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SkipAll = true;
        }
    }
}
