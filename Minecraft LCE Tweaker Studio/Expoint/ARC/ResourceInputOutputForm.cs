using System;
using System.IO;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.ARC
{
    public partial class ResourceInputOutputForm : Form
    {
        internal ARC_Studio.Workers.PS3ARCWorker ArcFile = new ARC_Studio.Workers.PS3ARCWorker();
        internal FolderBrowserDialog FBD;
        internal OpenFileDialog OpenFileDialog;
        internal string _ltFbdTag = "nul";
        internal string _outPath = "\\nul";
        internal string _inPath = "\\nul";

        public ResourceInputOutputForm()
        {
            InitializeComponent();
        }
        public ResourceInputOutputForm(string quickInput, string quickOutput, MainCenter clientMain)
        {
            InitializeComponent();
            _inPath = quickInput;
            _outPath = quickOutput;
            GNTBX_OutPath.Text = _outPath;
            GTBX_descompressionFilePath.Text = _inPath;

            if (MessageBox.Show("Decompress?:\r" + quickInput,
                                "¿?",
                                MessageBoxButtons.YesNo,
                                icon: MessageBoxIcon.Question
                                ) is DialogResult.Yes)
            {
                var reOut = _outPath + @"\arc\";
                Directory.CreateDirectory(reOut);
                GNBTN_DecompressStart.Enabled = true;
                try
                {
                    ArcFile.ExtractArchive(_inPath, reOut);
                    if (MessageBox.Show("Sucessfully extracted data, saved on path... " + reOut + "\nWanna change workspace to ARC path?", "Operation Ended.", MessageBoxButtons.YesNo) is DialogResult.Yes)
                    {
                        clientMain.App_TVW_ListGAF_Dir(reOut);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
        internal bool RefreshFlag()
        {
            var flag = Directory.Exists(_inPath)
            && Directory.Exists(_outPath);
            GNBTN_DecompressStart.Enabled = flag;
            return flag;
        }
        internal string RequestFolderSelection(string windowDescription, object windowTag)
        {
            FBD = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = windowDescription,
                Tag = windowTag
            };
            if (FBD.ShowDialog() is DialogResult.OK)
            {
                return FBD.SelectedPath;
            }
            else
            {
                FBD = null;
                return "\\NA";
            }
        }
        private void GTBX_descompressionFilePath_TextChanged(object sender, EventArgs e)
        {
            RefreshFlag();
        }
        private void GNBTN_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "ARC Resource File | *.arc";
            OpenFileDialog.Title = "Select Resource.";
            OpenFileDialog.Multiselect = false;
            OpenFileDialog.DefaultExt = ".arc";
            OpenFileDialog.AddExtension = true;
            OpenFileDialog.SupportMultiDottedExtensions = true;
            if (OpenFileDialog.ShowDialog() is DialogResult.OK && OpenFileDialog.CheckPathExists is true && OpenFileDialog.CheckFileExists is true)
            {
                _inPath = OpenFileDialog.FileName;
                GTBX_descompressionFilePath.Text = OpenFileDialog.FileName;
                GNBTN_DecompressStart.Enabled = true;
            }
        }
        private void GNBTN_SelectOutDataFolder_Click(object sender, EventArgs e)
        {
            var path = RequestFolderSelection("Select Output Data Folder.", "selOutPath") + @"\";
            if (!string.IsNullOrEmpty(path) is true && Directory.Exists(path))
            {
                GNTBX_OutPath.Text = path;
                _outPath = path;
                GNBTN_DecompressStart.Enabled = true;
            }

        }

        private void GNBTN_DecompressStart_Click(object sender, EventArgs e)
        {
            ArcFile.ExtractArchive(_inPath, _outPath);
        }

        private void ResourceInputOutputForm_Load(object sender, EventArgs e)
        {
            Expoint.InAppUserSettings.Default.S_Ins_Arc++;
        }

        private void ResourceInputOutputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Expoint.InAppUserSettings.Default.S_Ins_Arc--;
        }

        private void GNTBX_OutPath_TextChanged(object sender, EventArgs e)
        {
            RefreshFlag();
        }

        private void gbtn_ForceDesc_Click(object sender, EventArgs e)
        {
            ArcFile.ExtractArchive(_inPath, _outPath);
        }

        private void GNBTN_SelectDataFolder_Click(object sender, EventArgs e)
        {
            var fPath = RequestFolderSelection("Select Compression Data.", "compSelDat");
            if (fPath != null || fPath != "\\NA" || fPath != string.Empty && Directory.Exists(fPath))
            {
                GNTBX_CompDataFolderTB.Text = fPath;
            }
        }

        private void GNBTN_CompressionSt(object sender, EventArgs e)
        {
            var targetFile = GNTB_CompResultFileTb.Text;
            var fileData = GNTBX_CompDataFolderTB.Text;
            ArcFile = new ARC_Studio.Workers.PS3ARCWorker();
            if (string.IsNullOrEmpty(fileData) is true)
            {
                MessageBox.Show("A parameter is missing, check and try again.", "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Hand);
                return;
            }
            if (GNTB_CompResultFileTb.Text == string.Empty)
            {
                FileInfo FI = new FileInfo(fileData);
                var datDir = FI.Directory;
                var fnlpath = datDir + @"\" + FI.Name + @"\_ArcData.arc";
                File.Create(fnlpath).Close();
                targetFile = fnlpath;
                FI = null;

            }
            try
            {
                ArcFile.BuildArchive(targetFile, fileData);
                MessageBox.Show("Sucessfully extracted data, saved on path... " + targetFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Hand);
            }
        }

        private void GNBTN_SelectTargetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "ARC Resource File | *.arc";
            OpenFileDialog.Title = "Select Resource.";
            OpenFileDialog.Multiselect = false;
            OpenFileDialog.DefaultExt = ".arc";
            OpenFileDialog.AddExtension = true;
            OpenFileDialog.SupportMultiDottedExtensions = true;
            if (OpenFileDialog.ShowDialog() is DialogResult.OK && OpenFileDialog.CheckPathExists is true && OpenFileDialog.CheckFileExists is true)
            {
                GNTB_CompResultFileTb.Text = OpenFileDialog.FileName;
            }
        }
    }
}
