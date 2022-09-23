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
namespace Minecraft_LCE_Tweaker_Studio.Expoint.Better_Forms
{
    public partial class EditionManager : Form
    {
        internal readonly string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MLCE Modding\\";
        MainCenter mai;
        List<string> savedataList = new List<string>();
        public EditionManager(MainCenter ma)
        {
            InitializeComponent();
            mai = ma;
            ReadDatas();
        }

        private void Btn_newSave_Click(object sender, EventArgs e)
        {
            Expoint.Better_Forms.CreateEdit_Name createEdit_Name = new Expoint.Better_Forms.CreateEdit_Name(mai);
            createEdit_Name.ShowDialog();
            //Directory.CreateDirectory(DataPath+)
        }
        internal void ReadDatas()
        {
            string[] foldsFns = Directory.EnumerateDirectories(DataPath+"\\savedata").Cast<string>().ToArray();
            foreach (string fold in foldsFns)
            {
                bool containsDirs =
                Directory.EnumerateDirectories(fold).Contains<string>(fold + "\\Common") ||
                Directory.EnumerateDirectories(fold).Contains<string>(fold + "\\Media")  ||
                Directory.EnumerateDirectories(fold).Contains<string>(fold + "\\DLC")    ||
                Directory.EnumerateDirectories(fold).Contains<string>(fold + "\\music");
                if (containsDirs)
                { 
                    var dir = new DirectoryInfo(fold);
                    LBX_EList.Items.Add((dir).Name + " | [" + dir.FullName + "]");
                    savedataList.Add(dir.FullName);
                }

            }
        }

        private void BTN_RemEdit_Click(object sender, EventArgs e)
        {
            var dir = LBX_EList.Text.Split('|')[1].Replace("[", "").Replace("]", "");
            if (MessageBox.Show(
            "Are you sure to delete [+" + dir + "]", "Sure?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
            {
                Directory.Delete(dir);
            }
        }

        private void LBX_EList_SelectedIndexChanged(object sender, EventArgs e)
        {
                BTN_RemEdit.Enabled = LBX_EList.SelectedIndex != -1;
            BTN_LoadSel.Enabled = LBX_EList.SelectedIndex != -1;
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditionManager_Load(object sender, EventArgs e)
        {

        }

        private void BTN_LoadSel_Click(object sender, EventArgs e)
        {
            try
            {
                mai.wktitle.Text = "MDWK: " + (LBX_EList.Text.Split('|')[1].Replace("[", "").Replace("]", ""));
                 mai.App_TVW_ListGAF_Dir((LBX_EList.Text.Split('|')[1].Replace("[", "").Replace("]", "")));
                this.Close();
            }
            catch
            {

            }
        }
    }
}
