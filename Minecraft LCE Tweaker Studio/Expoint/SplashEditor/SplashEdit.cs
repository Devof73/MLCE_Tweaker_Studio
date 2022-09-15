using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.SplashEditor
{
    public partial class SplashEdit : Form
    {
        RichTextBox dbgrtb = new RichTextBox();
        public SplashEdit(string filename)
        {
            InitializeComponent();
            
            dbgrtb.Visible = false;
            dbgrtb.Text = File.ReadAllText(filename);
            Read(dbgrtb, LBX_SplashValues);
            InAppUserSettings.Default.S_Ins_SPT = InAppUserSettings.Default.S_Ins_SPT + 1;
        }
        internal void Read(RichTextBox lines, ListBox Target)
        {
            Target.Items.Clear();
            foreach (string line in lines.Lines)
            {
                if (line != String.Empty)
                {
                    Target.Items.Add(line);
                }
            }
        }
        internal string BeginSave(ListBox Lbx, string path)
        {
            dbgrtb.Text = string.Empty;
            foreach (string line in Lbx.Items)
            {
                if (line != String.Empty)
                {
                    dbgrtb.AppendText(line + "\r");
                }
            }
            File.WriteAllText(path, dbgrtb.Text);
            return path;
        }
        private void BTN_Sel_GameFolder_Click(object sender, EventArgs e)
        {
            var value = gtb_value_entry.Text;
            if (value == String.Empty)
            {
                MessageBox.Show("Value is empty. Cannot add splash.");
            }
            else
            {
                LBX_SplashValues.Items.Add(value);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = LBX_SplashValues.SelectedItems;
                foreach (var item in selected)
                {
                    LBX_SplashValues.Items.Remove(item);
                }
            }
            catch
            {

            }
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Splash List | *.txt";
            SFD.Title = "Select Save Location.";
            if (InAppUserSettings.Default.GAF_PATH != "/-" && InAppUserSettings.Default.GAF_PATH != string.Empty)
            {
                SFD.InitialDirectory = (InAppUserSettings.Default.GAF_PATH);
            }
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                var OperationMSG = BeginSave(LBX_SplashValues, SFD.FileName);
                MessageBox.Show("PATH : " + OperationMSG, "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SFD.Dispose();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Splash List | *.txt";
            OFD.Title = "Select File Location.";
            if (InAppUserSettings.Default.GAF_PATH != "/-" && InAppUserSettings.Default.GAF_PATH != string.Empty)
            {
                OFD.InitialDirectory = (InAppUserSettings.Default.GAF_PATH);
            }
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                SplashEdit sedit = new SplashEdit(OFD.FileName);
                sedit.Show();
            }
            OFD.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LBX_SplashValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            gtb_value_entry.Text = LBX_SplashValues.Items[LBX_SplashValues.SelectedIndex].ToString() ;
            
        }

        private void SplashEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            InAppUserSettings.Default.S_Ins_SPT = InAppUserSettings.Default.S_Ins_SPT -1;
        }
    }
}
