using CSAudioPlayer;
using ftp;
using Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms;
using System;
using System.Text;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio
{
    public partial class Dbgform : Form
    {
        readonly MainCenter senderInstance = null;
        public Dbgform(MainCenter Initial)
        {
            InitializeComponent();
            senderInstance = Initial;
            RefreshState();
        }
        internal void RefreshState()
        {
            lbx2_mctrls.Items.Clear();
            var s = senderInstance;
            GGS_1.Checked = s.RPCCli != null && s.RPCCli.IsInitialized;
            GGS_2.Checked = s.CommonTimer.Enabled;
            var ctrls = senderInstance.Controls;
            for (int i = 0; i < ctrls.Count; i++)
            {
                var c = ctrls[i];
                lbx2_mctrls.Items.Add(c.Name + " - " + c.ToString());
            }
        }

        private void GGS_1_CheckedChanged(object sender, EventArgs e)
        {
            switch (GGS_1.Checked)
            {
                case true:
                    { if (senderInstance.RPCCli != null && senderInstance.RPCCli.IsInitialized == false) { senderInstance.RPCCli.Initialize(); } break; }
                case false:
                    { senderInstance.RPCCli.ClearPresence(); senderInstance.RPCCli.Deinitialize(); break; }
            }
        }

        private void GGS_2_CheckedChanged(object sender, EventArgs e)
        {
            switch (GGS_2.Checked)
            {
                case true:
                    { senderInstance.CommonTimer.Start(); break; }
                case false:
                    { senderInstance.CommonTimer.Stop(); break; }
            }
        }

        private void lbx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn2.Enabled = lbx1.SelectedItem != null;
        }

        readonly AudioPlayer ply = new AudioPlayer();
        private void btn2_Click(object sender, EventArgs e)
        {
            ply.Channels = CSAudioPlayer.Channels.channels2;
            ply.Mode = CSAudioPlayer.Mode.WasapiOut;
            ply.DecodeMode = CSAudioPlayer.DecodeMode.LocalCodecs;
            ply.UserName = "dev";
            ply.UserKey = "dev";
            ply.AudioDevice = ply.GetDeviceDefaultIndex(CSAudioPlayer.Mode.WasapiOut);
            ply.Open(lbx1.Items[lbx1.SelectedIndex].ToString());
        }

        private void Btn1_hide_Click(object sender, EventArgs e)
        {
            if (lbx2_mctrls.SelectedIndex != -1)
            {
                var ctrl = senderInstance.Controls[lbx2_mctrls.SelectedIndex];
                if (ctrl != null)
                {
                    ctrl.Visible = !ctrl.Visible;
                }
            }

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            RefreshState();
            this.Close();
        }

        readonly File_Transfer_Protocol FTP = new File_Transfer_Protocol();
        private void btn5_Click(object sender, EventArgs e)
        {
            var dat = Encoding.ASCII.GetBytes("Work mtfka");
            FTP.Upload("ftp://" + textBox1.Text + "/dev_hdd0/tmp/debuggertest.txt", dat);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            FTP.DeleteFileOnFtpServer("ftp://" + textBox1.Text + "/dev_hdd0/tmp/debuggertest.txt", false, false);
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            AForge_CC_Frame_Viewer.AForgeCC_main aff = new AForge_CC_Frame_Viewer.AForgeCC_main();
            aff.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            HudViewer hv = new HudViewer(senderInstance.FileName);
            hv.ShowDialog();
        }
    }
}
