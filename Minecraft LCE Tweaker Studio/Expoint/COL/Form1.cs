using Minecraft_LCE_Tweaker_Studio.Expoint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace COL_Editor
{
    public partial class COLEditor : Form
    {
        #region variables

        Classes.COL.COLFile cf = new Classes.COL.COLFile();
        string Version = "1.1";
        string BaseURL = "https://pckstudio.xyz/Studio/COL/api/";
        string BackURL = "https://phoenixarc.github.io/pckstudio.tk/studio/COL/api/";

        #endregion

        #region startup
        public COLEditor()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Invokes new editor instance fastly with the provided filename.
        /// </summary>
        /// <param name="filename"></param>
        public COLEditor(string filename)
        {
            InitializeComponent();
            try
            {
                {
                    cf.Open(filename);
                    cf.OpenFile = filename;
                    treeView1.Nodes.Clear();
                    foreach (object[] obj in cf.entries)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = obj[0].ToString();
                        tn.Tag = obj[1].ToString();
                        treeView1.Nodes.Add(tn);
                    }
                    metroTextBox1.Enabled = true;
                    metroCheckBox1.Enabled = true;
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }
            }
            catch
            {
                MessageBox.Show("Unsupported .COL File!");
            }

        }
        private void COLEditor_Load(object sender, EventArgs e)
        {
            InAppUserSettings.Default.S_Ins_Col++;
            /*
            WebClient wc = new WebClient();
            try
            {
                if(float.Parse(wc.DownloadString(BaseURL + "colupdate.txt")) > float.Parse(Version))
                {

                    if (MessageBox.Show("Update avaliable!\ndo you want to update?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Process.Start(Environment.CurrentDirectory + "\\COLUpdater.exe");
                    else
                        uPDATEToolStripMenuItem.Visible = true;
                }
            }
            catch
            {
                try
                {
                    if (float.Parse(wc.DownloadString(BackURL + "colupdate.txt")) > float.Parse(Version))
                    {

                        if (MessageBox.Show("Update avaliable!\ndo you want to update?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            Process.Start(Environment.CurrentDirectory + "\\COLUpdater.exe");
                        else
                            uPDATEToolStripMenuItem.Visible = true;
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show("Could Not connect to the server\nPlease check PhoenixARC's Twitter for news");
                }
            }
            */
        }

        #endregion

        #region TreeView Actions

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            metroTextBox2.Text = treeView1.SelectedNode.Text;
            if (treeView1.SelectedNode.Tag != null)
            {
                pictureBox1.BackColor = Color.FromArgb(StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[0], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[1], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[2]);
                metroTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
                numericUpDown1.Value = StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[0];
                numericUpDown2.Value = StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[1];
                numericUpDown3.Value = StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[2];
            }
        }

        #endregion

        #region Utils

        static byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        #endregion

        #region Color Actions

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (metroTextBox1.Text.Length)
            {
                case (0):
                    treeView1.SelectedNode.Tag = "000000";
                    break;
                case (1):
                    treeView1.SelectedNode.Tag = "00000" + metroTextBox1.Text;
                    break;
                case (2):
                    treeView1.SelectedNode.Tag = "0000" + metroTextBox1.Text;
                    break;
                case (3):
                    treeView1.SelectedNode.Tag = "000" + metroTextBox1.Text;
                    break;
                case (4):
                    treeView1.SelectedNode.Tag = "00" + metroTextBox1.Text;
                    break;
                case (5):
                    treeView1.SelectedNode.Tag = "0" + metroTextBox1.Text;
                    break;
                case (6):
                    treeView1.SelectedNode.Tag = metroTextBox1.Text;
                    break;

            }

            if (treeView1.SelectedNode.Tag != null)
            {
                pictureBox1.BackColor = Color.FromArgb(StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[0], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[1], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[2]);
                metroTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                metroTextBox1.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                metroTextBox1.Enabled = true;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown1.Value.ToString())));
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown2.Value.ToString())));
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown3.Value.ToString())));
            treeView1.SelectedNode.Tag = BitConverter.ToString(new byte[] { bytes[0], bytes[4], bytes[8] }).Replace("-", "");
            if (treeView1.SelectedNode.Tag != null)
            {
                pictureBox1.BackColor = Color.FromArgb(StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[0], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[1], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[2]);
                metroTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown1.Value.ToString())));
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown2.Value.ToString())));
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown3.Value.ToString())));
            treeView1.SelectedNode.Tag = BitConverter.ToString(new byte[] { bytes[0], bytes[4], bytes[8] }).Replace("-", "");
            if (treeView1.SelectedNode.Tag != null)
            {
                pictureBox1.BackColor = Color.FromArgb(StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[0], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[1], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[2]);
                metroTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown1.Value.ToString())));
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown2.Value.ToString())));
            bytes.AddRange(BitConverter.GetBytes(int.Parse(numericUpDown3.Value.ToString())));
            treeView1.SelectedNode.Tag = BitConverter.ToString(new byte[] { bytes[0], bytes[4], bytes[8] }).Replace("-", "");
            if (treeView1.SelectedNode.Tag != null)
            {
                pictureBox1.BackColor = Color.FromArgb(StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[0], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[1], StringToByteArrayFastest(treeView1.SelectedNode.Tag.ToString())[2]);
                metroTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
            }
            bytes = null;
        }

        #endregion

        #region MenuStrip Actions

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Colours File|*.col";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    cf.Open(opf.FileName);
                    cf.OpenFile = opf.FileName;
                    treeView1.Nodes.Clear();
                    foreach (object[] obj in cf.entries)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = obj[0].ToString();
                        tn.Tag = obj[1].ToString();
                        treeView1.Nodes.Add(tn);
                    }
                    metroTextBox1.Enabled = true;
                    metroCheckBox1.Enabled = true;
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }
            }
            catch
            {
                MessageBox.Show("Unsupported .COL File!");
            }

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                cf.entries.Clear();
                foreach (TreeNode tn in treeView1.Nodes)
                {
                    cf.entries.Add(new object[] { tn.Text, tn.Tag.ToString() });
                }
                cf.Save();
                MessageBox.Show("COL Saved!!");
            }
            catch
            {
                MessageBox.Show("Error Saving .COL File!");
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cf.OpenFile = "";
                cf.entries.Clear();
                foreach (TreeNode tn in treeView1.Nodes)
                {
                    cf.entries.Add(new object[] { tn.Text, tn.Tag.ToString() });
                }
                cf.Save();
                MessageBox.Show("COL Saved!!");
            }
            catch
            {
                MessageBox.Show("Error Saving .COL File!");
            }
        }

        #endregion

        #region Update Toostrip

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            try
            {
                if (float.Parse(wc.DownloadString(BaseURL + "colupdate.txt")) > float.Parse(Version))
                {

                    if (MessageBox.Show("Update avaliable!\ndo you want to update?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Process.Start(Environment.CurrentDirectory + "\\COLUpdater.exe");
                    else
                        uPDATEToolStripMenuItem.Visible = true;
                }
            }
            catch
            {
                try
                {
                    if (float.Parse(wc.DownloadString(BackURL + "colupdate.txt")) > float.Parse(Version))
                    {

                        if (MessageBox.Show("Update avaliable!\ndo you want to update?", "UPDATE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            Process.Start(Environment.CurrentDirectory + "\\COLUpdater.exe");
                        else
                            uPDATEToolStripMenuItem.Visible = true;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Could Not connect to the server\nPlease check PhoenixARC's Twitter for news");
                }
            }
        }

        #endregion
    }
}
