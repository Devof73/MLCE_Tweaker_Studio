using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Minecraft_LCE_Tweaker_Studio
{
    public partial class About_help : Form
    {
        internal Main_AppCenter theSenderInstance;
        internal bool msstoping = false;
        internal CSAudioPlayer.AudioPlayer cplo = new CSAudioPlayer.AudioPlayer();

        internal Timer bufftimer = new Timer();
        public About_help(Main_AppCenter senderToManage)
        {
            cplo.Channels = CSAudioPlayer.Channels.channels2;
            cplo.Mode = CSAudioPlayer.Mode.WasapiOut;
            cplo.DecodeMode = CSAudioPlayer.DecodeMode.LocalCodecs;
            cplo.UserName = "dev";
            cplo.UserKey = "dev";
            cplo.AudioDevice = cplo.GetDeviceDefaultIndex(CSAudioPlayer.Mode.WasapiOut);
            InitializeComponent();
            theSenderInstance = senderToManage;
            var appPath = Application.StartupPath;
            var filepath = appPath+ @"\Expoint\dannyskey.wav";
            Console.WriteLine(filepath);
            cplo.FileName = filepath;
            bufftimer.Interval = 40;
            bufftimer.Start();
            bufftimer.Tick += Bufftimer_Tick;
            cplo.Open(filepath);
            cplo.Play();
            Console.WriteLine("fn = {0}, state = {1}, length = {2}", cplo.FileName, cplo.PlaybackState.ToString(), cplo.Length.ToString());

        }
        internal bool shouldClose = false;
        int sclevel = 500;
        int speedmultiplier = 1;
        int creditsEndX = 7400;
        private void Bufftimer_Tick(object sender, EventArgs e)
        {
            sclevel = sclevel - speedmultiplier;
            lbl_spd.Text = "Double RMB to skip.\rspd: " + speedmultiplier;

            if (PNL_MAIN.Location.Y > -creditsEndX)
            {
                PNL_MAIN.Location = new Point(0, sclevel);
                pnl_titles.Location = new Point(0, sclevel-200);
            }
            else if (PNL_MAIN.Location.Y >= creditsEndX)
            {
                if (shouldClose == true)
                {
                    this.Close();
                    this.Dispose();
                    theSenderInstance.Show();
                }
            }
            if(Btn_Continue.Location.Y < 0)
            {
                About_help_FormClosing(Btn_Continue, new FormClosingEventArgs(CloseReason.FormOwnerClosing, false));
            }
            if (msstoping == true)
            {
                
             
                cplo.Volume--;
                if (shouldClose == true && cplo.Volume == 0)
                {
                    this.Close();
                    this.Dispose();
                    theSenderInstance.Show();
                }
                cplo.Volume = cplo.Volume--; 
            }
        }

        private void About_help_FormClosing(object sender, FormClosingEventArgs e)
        {
            msstoping = true;
         
            if (cplo.PlaybackState == CSCore.SoundOut.PlaybackState.Playing)
            {
                e.Cancel = true;
                shouldClose = true;
            }
            if (cplo.Volume == 0)
            {
                e.Cancel = false;
            }
        }

        private void Btn_Continue_Click(object sender, EventArgs e)
        {
            this.Close();
            theSenderInstance.Show();
        }

        private void About_help_Click(object sender, EventArgs e)
        {
            speedmultiplier = speedmultiplier + 1;
        }

        private void PNL_MAIN_Click(object sender, EventArgs e)
        {
            

        }

        private void PNL_MAIN_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void PNL_MAIN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
                theSenderInstance.Show();
            }
        }

        private void PNL_MAIN_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left )
            {
                speedmultiplier = speedmultiplier + 1;
            }
            if (e.Button == MouseButtons.Right)
            {
                speedmultiplier = speedmultiplier - 1;
            }
        }

        private void About_help_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/3hASD2hZuk");
        }

        private void label38_Click(object sender, EventArgs e) => pictureBox10_Click(sender, e);

        private void label39_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCinKPxoqVHoZwpIWJ3zppdw");
        }
                
    }
}
