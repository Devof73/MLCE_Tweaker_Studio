using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.CMIX
{
    public partial class ColorGuiHelper : Form
    {
        internal Timer Refr = new Timer();
        internal string HexCurrent = "n/a";
        internal Bitmap[] ttdmBmps;
        internal Bitmap[] outputBitmaps;
        internal List<string> outputBmpsNames;
        internal List<string> outputBmpsDirs;
        internal List<string> outputBmpsFiPaths;
        internal const string _KeyOutputOrder = "approvedBmpClassicOutput";
        public ColorGuiHelper()
        {
            InitializeComponent();
            Initial();

        }
        void Initial()
        {
            Refr.Interval = 500;
            Refr.Start();
            Refr.Tick += Refr_Tick;
            DRPDWN_IMG_VIEW_MODE.Items.Add("normal");
            DRPDWN_IMG_VIEW_MODE.Items.Add("autosize");
            DRPDWN_IMG_VIEW_MODE.Items.Add("stretch");
            DRPDWN_IMG_VIEW_MODE.Items.Add("zoom");
            DRPDWN_IMG_VIEW_MODE.Items.Add("center");
            DRPDWN_IMG_VIEW_MODE.SelectedIndex = 2;
        }
        public ColorGuiHelper(string[] filenames, object sender)
        {
            InitializeComponent();
            Initial();

            Console.WriteLine("[!] Quick Ins called by " + (sender.ToString()));
            LBX_FILES.Items.Clear();
            BeginReadingImages(filenames);
            TCTRL_MainTC.TabPages[1].Select();
        }
        private void Refr_Tick(object sender, EventArgs e)
        {
            var cr = GN_TRACK_COLOR_R.Value;
            var cg = GN_TRACK_COLOR_G.Value;
            var cb = GN_TRACK_COLOR_B.Value;
            GN_TRACK_COLOR_R.Text = cr.ToString();
            GN_TRACK_COLOR_G.Text = cg.ToString();
            GN_TRACK_COLOR_B.Text = cb.ToString();
            var result = Color.FromArgb(cr, cg, cb);
            PNL_COL_RESULT.BackColor = result;
            HexCurrent = "#" + result.R.ToString("X2") + result.G.ToString("X2") + result.B.ToString("X2");
            LBL_VALUE_HEX.Text = HexCurrent;
            LBL_VALUE_RGB.Text = cr.ToString() + ", " + cg.ToString() + ", " + cb.ToString();
            if (ttdmBmps?.Length != 0 && LBX_FILES.Items.Count != 0 && LBX_FILES.SelectedIndex != -1)
            {
                PICB_RESULT.Image = AltImageValues(ttdmBmps[LBX_FILES.SelectedIndex], TRBR_OPACITY.Value, TB_DARK_LEVEL.Value);
            }
            TBX_VALUE_COLOR_R.Text = cr.ToString();
            TBX_VALUE_COLOR_G.Text = cg.ToString();
            TBX_VALUE_COLOR_B.Text = cb.ToString();
        }
        private void ColorGuiHelper_Load(object sender, EventArgs e)
        {

        }
        private void BTN_AddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Select Images To Edit.";
            ofd.AddExtension = true;
            ofd.Filter = "Portable Network Graphics | *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var rst = ofd.FileNames;
                if (rst?.Length != 0)
                {
                    BeginReadingImages(rst);
                }
            }

        }
        private void BeginReadingImages(string[] filenames)
        {

            ttdmBmps = new Bitmap[50];
            if (filenames.Length > 50)
            {
                MessageBox.Show("Limit Exceeded, only 50 images will be readed for improve perfomance!.");
            }
            for (int i = 0; i < filenames.Length; i++)
            {
                var fn = filenames[i];
                if (File.Exists(fn))
                {
                    Image img = Bitmap.FromFile(fn);
                    if (img.Size.Width > 500 || img.Size.Height > 500)
                    {
                        return;
                    }
                    ttdmBmps[i] = new Bitmap(img);
                    LBX_FILES.Items.Add(fn);
                    LBL_IMAGECOUNT.Text = LBX_FILES.Items.Count.ToString() + "/50";

                }
            }
        }
        private void BTN_UP_IMG_Click(object sender, EventArgs e)
        {
            var index = LBX_FILES.SelectedIndex;
            if (LBX_FILES.Items.Count == 0 || index < LBX_FILES.Items.Count)
                return;
            if (index <= LBX_FILES.Items.Count)
                index++;
            PICB_RESULT.Image = ttdmBmps[index];
            LBX_FILES.SelectedIndex = index;
        }
        private void BTN_DWN_Click(object sender, EventArgs e)
        {
            var index = LBX_FILES.SelectedIndex;
            if (LBX_FILES.Items.Count == 0)
                return;
            if (LBX_FILES.Items.Count != 0)
                index--;
            if (index < 0 == false)
            {
                PICB_RESULT.Image = ttdmBmps[index];
            }
            LBX_FILES.SelectedIndex = index;
        }
        private void LBX_FILES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBX_FILES.SelectedIndex != -1)
            {
                try
                {
                    var index = LBX_FILES.SelectedIndex;
                    PICB_RESULT.Image = ttdmBmps[index];
                    LBL_CURRENT_IMG_INDEX.Text = index + "/" + LBX_FILES.Items.Count;
                }
                catch { }
            }
        }
        private Bitmap AltImageValues(Bitmap initial, int transp, int darkRest)
        {
            if (transp == 100 && darkRest == 0)
            {
                return initial;
            }
            else
            {
                if (initial == null)
                {
                    return null;
                }
                var bmp = Bitmap.FromHbitmap(initial.GetHbitmap());
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        if (transp <= 0)
                        {
                            transp = 1;
                        }
                        var red = bmp.GetPixel(x, y).R - darkRest;
                        var green = bmp.GetPixel(x, y).G - darkRest;
                        var blue = bmp.GetPixel(x, y).B - darkRest;
                        if (red < 0) { red = 0; }
                        if (green < 0) { green = 0; }
                        if (blue < 0) { blue = 0; }
                        bmp.SetPixel(x, y, Color.FromArgb(transp, red, green, blue));
                        bmp.MakeTransparent(Color.Black);
                    }
                }
                return bmp;
            }
        }
        private void BTN_PREVIEW_IMAGE_Click(object sender, EventArgs e)
        {
            if (ttdmBmps?.Length != 0 && LBX_FILES.Items.Count != 0)
            {
                PICB_RESULT.Image = AltImageValues(ttdmBmps[LBX_FILES.SelectedIndex], TRBR_OPACITY.Value, TB_DARK_LEVEL.Value);
            }
        }
        private void BTN_DeleteAll_Click(object sender, EventArgs e)
        {
            ttdmBmps = null;
            LBX_FILES.Items.Clear();
        }
        private void ColorGuiHelper_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            Refr.Stop();
        }
        private void TRBR_OPACITY_Scroll(object sender, EventArgs e)
        {
            LBL_TR_VALUE.Text = TRBR_OPACITY.Value.ToString();
        }
        private void TB_DARK_LEVEL_Scroll(object sender, EventArgs e)
        {
            LBL_DARK_VALUE.Text = TB_DARK_LEVEL.Value.ToString();
        }
        private void BTN_setColAll_Click(object sender, EventArgs e)
        {
            ColorStartDumpSetting();
        }
        private void ColorStartDumpSetting()
        {
            if (LBX_FILES.Items.Count != 0)
            {
                Console.WriteLine("running prc1");
                outputBmpsDirs = new List<string>();
                outputBmpsNames = new List<string>();
                outputBmpsFiPaths = new List<string>();
                string[] values = LBX_FILES.Items.Cast<string>().ToArray();
                foreach (string str in values)
                {
                    if (File.Exists(str))
                    {
                        FileInfo fi = new FileInfo(str);
                        outputBmpsDirs.Add(fi.Directory.Name);
                        outputBmpsNames.Add(fi.Name);
                        outputBmpsFiPaths.Add(fi.FullName);
                        fi = null;
                    }
                    else
                    {
                        return;
                    }
                }
                if (outputBmpsFiPaths != null)
                {
                    if (outputBmpsFiPaths.Count != 0)
                    {
                        SetOutputBitmaps(_KeyOutputOrder, outputBmpsFiPaths);
                    }
                }


            }
        }
        private void SetOutputBitmaps(object sender, List<string> files)
        {
            Console.WriteLine("running prc2");
            if ((string)sender == _KeyOutputOrder)
            {
                outputBitmaps = new Bitmap[15];
                for (int index = 0; index < files.Count; index++)
                {
                    try
                    {
                        if (index > -1 && index < files.Count)
                        {
                            Console.WriteLine("drawing image indexed as value: " + index);
                            outputBitmaps[index] = (Bitmap)Bitmap.FromFile(files[index]);
                            outputBitmaps[index] = AltImageValues(outputBitmaps[index], TRBR_OPACITY.Value, TB_DARK_LEVEL.Value);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error " + e.ToString() + " - " + e.Message + " - " + e.GetBaseException().ToString());
                    }
                }
                RequestOutput();
            }
        }
        private void RequestOutput()
        {

            Console.WriteLine("Ejecutando prc3");
            Console.WriteLine("direccionesDeBmpsSonNulas? " + (outputBmpsDirs == null).ToString());
            Console.WriteLine("NombresDeBmpsSonNulas? " + (outputBmpsNames == null).ToString());
            Console.WriteLine("BmpsDeSalidaSonNulas? " + (outputBitmaps == null).ToString());

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select folder to save all these dumped images...";
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("OFD! es ok");
                for (int index = 0; index < outputBitmaps.Length; index++)
                {
                    Console.WriteLine(index);
                    string outpath = fbd.SelectedPath + @"\" + outputBmpsDirs[index] + " - " + outputBmpsNames[index];
                    if (outputBitmaps[index] == null)
                    {
                        Console.WriteLine("valor indexado como {0} devolvió null.");
                        return;
                    }
                    else
                    {
                        outputBitmaps[index].Save(outpath);
                        Console.WriteLine($"!Saved ({index}°) image = {outpath}");
                    }
                }
            }
        }
        private void BTN_SetCol_Click(object sender, EventArgs e)
        {
            if (LBX_FILES.SelectedIndex != -1 && ttdmBmps != null)
            {
                if (ttdmBmps[LBX_FILES.SelectedIndex] != null)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Portable Net Graphics | *.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        AltImageValues(ttdmBmps[LBX_FILES.SelectedIndex], TRBR_OPACITY.Value, TB_DARK_LEVEL.Value).Save(sfd.FileName);
                    }
                }
            }
        }
        private void GNBTN_COPY_COLOR_RGB_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(LBL_VALUE_RGB.Text);

        }
        private void GNBTN_COPY_COLOR_HEX_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(LBL_VALUE_HEX.Text);
        }
        internal Bitmap wbmp;
        internal string ubmp_path = "";
        internal string ubmp_savepath = "";
        private void BTN_GetPixelAtCoords_Click(object sender, EventArgs e)
        {
            if (wbmp != null)
            {
                Color gcl = wbmp.GetPixel((int)NUPD_X_BMP.Value, (int)NUPD_Y_BMP.Value);
                PICBX_WIMG.Image = wbmp;
                TBX_RC_REDCOL.Text = gcl.R.ToString();
                TBX_RC_GCOL.Text = gcl.G.ToString();
                TBX_RC_BCOL.Text = gcl.B.ToString();
            }
        }
        private void BTN_InputFilePathExamine_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select one image...";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                {
                    ubmp_path = ofd.FileName;
                    TBX_FileInputPath.Text = ubmp_path;
                    wbmp = (Bitmap)Bitmap.FromFile(ofd.FileName);
                    PICBX_WIMG.Image = wbmp;
                    NUPD_X_BMP.Maximum = wbmp.Width;
                    NUPD_Y_BMP.Maximum = wbmp.Height;
                    LBL_ImageW.Text = "/ " + wbmp.Width;
                    LBL_IMAGE_HEIGHT.Text = "/ " + wbmp.Height;
                }
            }
            ofd.Dispose();
        }
        private void TBX_FileInputPath_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TBX_FileInputPath.Text) == false && File.Exists(TBX_FileInputPath.Text) is true)
            {
                ubmp_path = TBX_FileInputPath.Text;
                wbmp = (Bitmap)Bitmap.FromFile(TBX_FileInputPath.Text);
                PICBX_WIMG.Image = wbmp;
                NUPD_X_BMP.Maximum = wbmp.Width;
                NUPD_Y_BMP.Maximum = wbmp.Height;
                LBL_ImageW.Text = "/ " + wbmp.Width;
                LBL_IMAGE_HEIGHT.Text = "/ " + wbmp.Height;
            }
        }
        private void RefreshDisplayingCol(Color col)
        {
            COL_RESULT_COLOR.BackColor = col;
            TBX_RC_REDCOL.Text = col.R.ToString();
            TBX_RC_GCOL.Text = col.G.ToString();
            TBX_RC_BCOL.Text = col.B.ToString();
            PICBX_WIMG.Image = wbmp;
        }

        private void DRPDWN_IMG_VIEW_MODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DRPDWN_IMG_VIEW_MODE.SelectedIndex)
            {
                case 0:
                    {
                        PICBX_WIMG.SizeMode = PictureBoxSizeMode.Normal;
                        break;
                    }
                case 1:
                    {
                        PICBX_WIMG.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;
                    }

                case 2:
                    {
                        PICBX_WIMG.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                    }
                case 3:
                    {
                        PICBX_WIMG.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    }

                case 4:
                    {
                        PICBX_WIMG.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;
                    }

            }
        }

        private void TBX_RC_REDCOL_TextChanged(object sender, EventArgs e) => TbxToCol();
        private void TBX_RC_GCOL_TextChanged(object sender, EventArgs e) => TbxToCol();
        private void TBX_RC_BCOL_TextChanged(object sender, EventArgs e) => TbxToCol();

        internal void TbxToCol()
        {
            if (TBX_RC_REDCOL.Text.Length != 0 && TBX_RC_GCOL.Text.Length != 0 && TBX_RC_BCOL.Text.Length != 0)
            {
                var r = int.Parse(TBX_RC_REDCOL.Text);
                var g = int.Parse(TBX_RC_GCOL.Text);
                var b = int.Parse(TBX_RC_BCOL.Text);
                RefreshDisplayingCol(Color.FromArgb(r, g, b));
            }

        }

        private void BTN_SetPixelAtCoords_Click(object sender, EventArgs e)
        {
            var boolean = TBX_RC_REDCOL.Text.Length != 0 && TBX_RC_GCOL.Text.Length != 0 && TBX_RC_BCOL.Text.Length != 0;
            if (wbmp != null && boolean == true)
            {
                var r = int.Parse(TBX_RC_REDCOL.Text);
                var g = int.Parse(TBX_RC_GCOL.Text);
                var b = int.Parse(TBX_RC_BCOL.Text);
                wbmp.SetPixel((int)NUPD_X_BMP.Value, (int)NUPD_Y_BMP.Value, Color.FromArgb(r, g, b));
                PICBX_WIMG.Image = wbmp;
            }
        }

        private void BTN_SaveOutputPathExamine_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Select one image...",

            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ubmp_savepath = sfd.FileName;
                TBX_SaveOutputPath.Text = ubmp_savepath;
            }
            sfd.Dispose();
        }

        private void TABPAGE_BMPCOL_Click(object sender, EventArgs e)
        {

        }

        private void BTN_SaveBmpToPath_Click(object sender, EventArgs e)
        {
            if (TBX_SaveOutputPath.Text != string.Empty || ubmp_savepath != "")
            {
                wbmp.Save(ubmp_savepath);
            }

        }

        private void BTN_BmpFullView_Click(object sender, EventArgs e)
        {
            if (LBX_FILES.SelectedIndex != -1)
            {
                var index = LBX_FILES.SelectedIndex;
                FuiEditor.Forms.PicViewer PVW = new FuiEditor.Forms.PicViewer(ttdmBmps[index]);
                PVW.ShowDialog();
                PVW.BringToFront();
            }

        }
    }
}
