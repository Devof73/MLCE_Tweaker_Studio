using AForge.Video;
using AForge.Video.DirectShow;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;



namespace AForge_CC_Frame_Viewer
{
    public partial class AForgeCC_main : Form
    {
        public AForgeCC_main()
        {

            InitializeComponent();
            CBX_CCList.Items.Clear();
            ListDevices();
            Panels = new Panel[] { PNL_CC, PNL_CC_Controls };
        }
        SharpAvi.Output.AviWriter videoWriter;
        IAviVideoStream mp4;
        internal bool MovRecording = false;
        List<Bitmap> RecordingFramesList = new List<Bitmap>();
        Panel[] Panels = null;
        FilterInfoCollection CaptureDevice;
        VideoCaptureDevice FinalFrame = null;
        VideoCaptureDevice[] VCDs = new VideoCaptureDevice[15];
        Thread TimeEvent;
        System.Windows.Forms.Timer QTE;
        internal int TimeTicks = 0;
        bool WindowedViewing = false;
        bool WindowFullscreen = false;
        bool CC_IsCapturing = false;

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen == false)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                fullscreen = true;
            }
            else if (fullscreen == true)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

                fullscreen = false;
                this.Size = new Size(816, 575);
            }
        }
        internal void ExitFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            WindowFullscreen = false;
            this.Size = new Size(816, 575);
        }
        internal void ListDevices()
        {
            VCDs = new VideoCaptureDevice[15];
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int index = 0;
            foreach (FilterInfo Device in CaptureDevice)
            {
                CBX_CCList.Items.Add(Device.Name);
                var vcd = new VideoCaptureDevice(Device.MonikerString);
                VCDs[index] = vcd;
                index++;

            }
        }
        internal void InitCapturing(int cc_index)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cc_index].MonikerString);// specified web cam and its filter moniker string
            FinalFrame.VideoResolution = FinalFrame.VideoCapabilities[CBX1_RES.SelectedIndex];
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
            FinalFrame.Start();
            try
            {

                BTN_CaptureCC.Enabled = false;
                button1.Enabled = true;
                CC_IsCapturing = FinalFrame.IsRunning;
                UnleashCounter();

            }
            catch
            {
                MessageBox.Show("CC Is Running but a error is ocurred while getting device info.");
            }

            //FinalFrame.VideoResolution
        }
        internal static Bitmap CCBITMAP = null;
        internal void FinalFrame_NewFrame(object sender, NewFrameEventArgs e)
        {
            var frame = e.Frame.Clone() as Bitmap;
            // clone the bitmap
            if (MovRecording == true && videoWriter != null && mp4 != null)
            {
                CcMp4AddFrame(frame.Clone() as Bitmap);

            }
            if (MovRecording == false && videoWriter != null)
            {
                videoWriter.Close();
            }
            if (MovRecording == false)
            {
                PB_cc_view.Image = frame;
            }

        }
        internal void CcMp4AddFrame(Bitmap bmp, int width = 1280, int height = 720)
        {
            var buffer = new byte[width * height * 4];
            var bits = bmp.LockBits(new System.Drawing.Rectangle(0, 0, 1280, 720), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
            bmp.UnlockBits(bits);
            //var data = BitmapToByteArray(bmp);
            mp4.WriteFrame(false, buffer, 0, buffer.Length);
        }
        internal void OrganizeFullscreenDesign()
        {
            var wh = this.Size.Height;
            var ww = this.Size.Width;
            PB_cc_view.Size = new Size(ww, wh);
            PB_cc_view.Dock = DockStyle.Fill;
            LB_FS_Indicator1.Visible = true;
            int v1_lb_pos_x = this.PB_cc_view.Bounds.Left;
            int v1_lb_pos_y = this.PB_cc_view.Bounds.Bottom;
            LBL_ccviewindicator2.Visible = true;
            LB_FS_Indicator1.BringToFront();
            LBL_ccviewindicator2.BringToFront();
            LB_FS_Indicator1.Location = new System.Drawing.Point(v1_lb_pos_x + 12, v1_lb_pos_y - 20);
            LBL_ccviewindicator2.Location = new System.Drawing.Point(v1_lb_pos_x + 12, v1_lb_pos_y - 40);

        }
        internal bool WindowedCC(bool Condition)
        {
            if (Condition == false)
            {
                Panels[0].Hide();
                Panels[1].Hide();
                Panels[2].Hide();
                Condition = true;
                OrganizeFullscreenDesign();
                return true;
            }
            else if (Condition == true)
            {
                Panels[0].Show();
                Panels[1].Show();
                Panels[2].Show();
                PB_cc_view.Size = new Size(775, 429);
                WindowedViewing = false;
                ExitFullscreen();
                PB_cc_view.Dock = DockStyle.None;
                LBL_ccviewindicator2.Visible = false;
                Condition = false;
                LB_FS_Indicator1.Visible = false;
                return false;
            }
            else
            {
                WindowedViewing = false;
                return false;
            }

        }
        internal void UnleashCounter()
        {
            TimeEvent = new Thread(StartCount);
            TimeEvent.Start();
        }
        internal void StartCount()
        {
            QTE = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            QTE.Start();
            QTE.Tick += QTE_Tick;
        }

        private void QTE_Tick(object sender, EventArgs e)
        {
            TimeTicks = TimeTicks + 1;

            LBL_ccviewindicator2.Text = "[ESC] RETURN\r" + "RUNNING: " + FinalFrame.IsRunning.ToString().ToUpper() + " | ELAPSED: " + TimeTicks.ToString() + "SG";

        }

        private void BTN_CaptureCC_Click(object sender, EventArgs e)
        {
            RecordingFramesList.Clear();
            InitCapturing(CBX_CCList.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordingFramesList.Clear();
            BTN_CaptureCC.Enabled = true;
            button1.Enabled = false;
            FinalFrame.Stop();
            CC_IsCapturing = FinalFrame.IsRunning;

            if (TimeEvent.IsAlive == true)
            {
                TimeEvent.Suspend();
            }
            TimeTicks = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame != null)
            {
                if (FinalFrame.IsRunning)
                {
                    e.Cancel = true;
                    MessageBox.Show("First, stop the capture device.");
                }
                else
                {
                    e.Cancel = false;
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowedCC(WindowedViewing);
            PB_cc_view.Focus();

        }

        private void AForgeCC_main_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowedViewing == true && Panels[0].Visible == false && Panels[1].Visible == false)
            {

                var wh = this.Size.Height;
                var ww = this.Size.Width;
                PB_cc_view.Size = new Size(ww, wh);
                PB_cc_view.Dock = DockStyle.Fill;
                PB_cc_view.Location = new System.Drawing.Point(0, 0);
                PB_cc_view.Refresh(); LB_FS_Indicator1.Visible = true;

            }
            else
            {
                Panels[0].Visible = true;
                Panels[1].Visible = true;

                WindowedViewing = false;
                PB_cc_view.Dock = DockStyle.None; LB_FS_Indicator1.Visible = false;

            }
        }

        private void PB_cc_view_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Escape || e.Alt)
            {
                WindowedCC(WindowedViewing);
            }
        }

        private void AForgeCC_main_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Escape)
            {
                WindowedCC(WindowedViewing);
            }
        }

        private void PB_cc_view_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowedViewing = WindowedCC(WindowedViewing);
            if (WindowFullscreen == true)
            {
                GoFullscreen(WindowFullscreen);
            }
            if (e.Button == MouseButtons.Right)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowFullscreen = false;
                this.Size = new Size(816, 575);
            }
        }

        private void PB_cc_view_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowedViewing = WindowedCC(WindowedViewing);
            GoFullscreen(WindowFullscreen);
            int v1_lb_pos_x = this.PB_cc_view.Bounds.Left;
            int v1_lb_pos_y = this.PB_cc_view.Bounds.Bottom;
            LBL_ccviewindicator2.Visible = true;
            LB_FS_Indicator1.BringToFront();
            LBL_ccviewindicator2.BringToFront();
            LB_FS_Indicator1.Location = new System.Drawing.Point(v1_lb_pos_x + 12, v1_lb_pos_y - 20);
            LBL_ccviewindicator2.Location = new System.Drawing.Point(v1_lb_pos_x + 12, v1_lb_pos_y - 40);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            PB_cc_view.Image.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\cc_capture_frame{new Random().Next(1000)}.png");

        }

        private void AForgeCC_main_Load(object sender, EventArgs e)
        {

        }

        internal void InitCcRecording()
        {
            int[] dtt = { DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second };
            var ccName = CBX_CCList.Items[CBX_CCList.SelectedIndex] as string;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            + $"\\{ccName} {dtt[2]}_{dtt[1]}_{dtt[0]}-{dtt[3]}_{dtt[4]}_{dtt[5]}.mp4";
            btn4_rec.Enabled = false;
            btn_srec.Enabled = true;
            MovRecording = true;
            NUPD_FPS.Enabled = false;
            var inputFps = NUPD_FPS.Value;
            videoWriter = new AviWriter(path) { FramesPerSecond = inputFps, };
            mp4 = videoWriter.AddMJpegWpfVideoStream(1280, 720, 100);
        }
        private void btn4_rec_Click(object sender, EventArgs e)
        {
            InitCcRecording();
        }

        private void btn_srec_Click(object sender, EventArgs e)
        {
            NUPD_FPS.Enabled = true;
            btn4_rec.Enabled = true;
            btn_srec.Enabled = false;
            MovRecording = false;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {


        }

        private void NUPD_FPS_ValueChanged(object sender, EventArgs e)
        {
        }

        private void CBX_CCList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX_CCList.SelectedIndex != -1)
            {
                CBX1_RES.Items.Clear();
                var caps = VCDs[CBX_CCList.SelectedIndex].VideoCapabilities;
                for (int i = 0; i < caps.Length; i++)
                {
                    var s = caps[i];
                    CBX1_RES.Items.Add($"{s.FrameSize.Width} x {s.FrameSize.Height} | {s.AverageFrameRate} afps");
                }
            }
        }

        private void CBX1_RES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FinalFrame != null)
            {
                FinalFrame.VideoResolution = FinalFrame.VideoCapabilities[CBX1_RES.SelectedIndex];
            }
        }
    }
}

