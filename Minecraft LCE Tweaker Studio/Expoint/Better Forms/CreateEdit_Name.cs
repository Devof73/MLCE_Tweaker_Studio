using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.Better_Forms
{
    public partial class CreateEdit_Name : Form
    {
        Main_AppCenter main;
        internal readonly string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MLCE Modding\\";
        internal const string DataSavePath_Name = "savedata";
        internal readonly string[] defaultResourcesNames =
        {
            "\\achievement",
            "\\armor",
            "\\environment",
            "\\art",
            "\\font",
            "\\gui",
            "\\item",
            "\\misc",
            "\\mob",
            "\\terrain",
            "\\textures",
            "items.png",
            "particles.png",
            "terrain.png",
            "pack.png",
            "terrainMipMapLevel2.png",
            "terrainMipMapLevel3.png",
            "colours.col",
        };
        public CreateEdit_Name(Main_AppCenter ma)
        {
            InitializeComponent();
            main = ma;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            var fn = "";
            if (!string.IsNullOrEmpty(TXTB_NameEdition.Text) && !string.IsNullOrEmpty(TXTB_EditionReg.Text)) { fn = CreateNewEdition(TXTB_NameEdition.Text, TXTB_EditionReg.Text); }
            if (!string.IsNullOrEmpty(fn)) { main.App_TVW_ListGAF_Dir(fn); }
            this.Close();
        }
    
        internal bool StringArrayIsEmpty(string[] array)
        {
            int emptyValues = 0;
            foreach (string s in array)
            {
                if (s == string.Empty) { emptyValues++; }
            }
            if (emptyValues >= array.Length) { return true; }
            else { return false; }
            
        }
        private string CreateNewEdition(string name, string region)
        {
            var res = TBX_COMMON_RES_FN.Text;
            var tex1 = TBX_ITEMS_TEX_FN.Text;
            var tex2 = TBX_TERRAIN_TEX_FN.Text;
            var arcFn = TBX_ARC_FN.Text;
            var particles = TBX_PARTICLES_TEX_FN.Text;
            var soundtracks = TBX_BINKA_RES_FN.Text;

            bool WithArc = arcFn != "" && File.Exists(arcFn) == true && new FileInfo(arcFn).Extension.ToLower() == ".arc";
            bool WithCommon = res != "";
            bool WithItems = tex1 != "";
            bool WithTerrain = tex2 != "";
            bool WithParticles = particles != "";
            bool WithOst = soundtracks != "";

            string finalPath = DataPath + DataSavePath_Name;//$"\\{region}-{name}\\";
            Directory.CreateDirectory(finalPath);
            if (Directory.Exists(finalPath) is true)
            {
                var targetPath = finalPath + $"\\{region}-{name}\\";
                Directory.CreateDirectory(targetPath);
                if (Directory.Exists(targetPath) is true)
                {
                    Directory.CreateDirectory(targetPath + "Common");
           
                    if (WithCommon == true && File.Exists(res) && (new FileInfo(res)).Extension.ToLower() == ".png")
                    {
                        CopyDirectory(res, targetPath + "Common\\", true);
                    }
                    if (WithItems == true && File.Exists(tex1) && (new FileInfo(tex1)).Extension.ToLower() == ".png")
                    {
                        Directory.CreateDirectory(targetPath + "Common\\res");
                        Directory.CreateDirectory(targetPath + "Common\\res\\TitleUpdate\\res\\");
                        File.Copy(tex1, targetPath + "Common\\res\\TitleUpdate\\res\\items.png");
                    }
                    if (WithTerrain == true && File.Exists(tex2) && (new FileInfo(tex2)).Extension.ToLower() == ".png")
                    {
                        if (File.Exists(res+"\\terrainMipMapLevel2.png") && File.Exists(res + "\\terrainMipMapLevel3.png") )
                        {
                            File.Copy(res+ "\\terrainMipMapLevel2.png", res+ "\\terrainMipMapLevel2.png");
                        }
                        File.Copy(tex2, targetPath + "Common\\Terrain.png");
                    }
                    if (WithArc) { Directory.CreateDirectory(targetPath + "Common\\Media"); File.Copy(arcFn, targetPath + "Common\\Media\\MediaPS3.arc"); }
                    if (!StringArrayIsEmpty(arc_pcks))
                    {
                        Directory.CreateDirectory(targetPath + "DLC");

                        for (int i = 0; i < arc_pcks.Length; i++)
                        {
                            File.Copy(arc_pcks[i], targetPath + "DLC\\"+new FileInfo(arc_pcks[i]).Name+".pck");
                        }
                         
                    }
                    if (WithOst)
                    {
                        Directory.CreateDirectory(targetPath + "music");
                        var ost_music = soundtracks + "\\music";
                        var ost_cds = soundtracks + "\\cds";
                        if (Directory.Exists(ost_cds))
                        {
                            Directory.CreateDirectory(targetPath + "music\\cds");
                            var Files = Directory.GetFiles(ost_cds);
                            for (int i = 0; i < Files.Length; i++)
                            {
                                FileInfo FI = new FileInfo(Files[i]);

                                if (FI.Extension.ToLower() is ".binka")
                                {
                                    File.Copy(Files[i], targetPath + "music\\cds\\" + FI.Name);
                                }
                            }
                        }
                        if (Directory.Exists(ost_music))
                        {
                            Directory.CreateDirectory(targetPath + "music\\music");
                            var Files = Directory.GetFiles(ost_music);
                            for (int i = 0; i < Files.Length; i++)
                            {
                                FileInfo FI = new FileInfo(Files[i]);

                                if (FI.Extension.ToLower() is ".binka")
                                {
                                    File.Copy(Files[i], targetPath + "music\\music\\" + FI.Name);
                                }
                            }
                        }

                    }                    
                    if (WithParticles)
                    {
                        var target = targetPath + "Common\\res\\TitleUpdate\\res";
                        Directory.CreateDirectory(target);
                        {
                            File.Copy(particles, target + "\\particles.png");
                        }
                    }
                    var datestamp = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} && {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}";
                    string param =
                        "// <--- Do no rename any of these files. DSJ MLCE PARAMS--->|n|" +
                        "projectName = \"" + name + "\";|n|" +
                        "projectRegion = \"" + region + "\"|n|" +
                        "hasCommon = \"" + Directory.Exists(targetPath + "Common\\").ToString() + "\"|n|" +
                        "hasArc = \"" + (Directory.Exists(targetPath + "Common\\") && Directory.Exists(targetPath + "Common\\Media")).ToString() + "\"|n|" +
                        "hasMusic = \"" + (Directory.Exists(targetPath + "music\\").ToString()) + "\"|n|" +
                        "creationDate = \""+ datestamp+"\"|n|";
                    File.WriteAllText(targetPath + "projectDefaultParams.ini", param.Replace("|n|", Environment.NewLine));
                }
            }
            return finalPath;

        }
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTN_arcSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ARC Compressed Resources | *.arc";
            ofd.Multiselect = false;
            ofd.CheckFileExists = false;
            ofd.Title = "Add an ARC to this new edition";
            ofd.DefaultExt = ".arc";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                TBX_ARC_FN.Text = ofd.FileName;
            }
            else
            {
                TBX_ARC_FN.Text = "";
            }
            ofd.Dispose();

        }

        private void btn_itsel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Portable Network Graphics | *.png";
            ofd.Multiselect = false;
            ofd.CheckFileExists = false;
            ofd.Title = "items";
            ofd.DefaultExt = ".png";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                TBX_ITEMS_TEX_FN.Text= ofd.FileName;
            }
            else
            {
                TBX_ITEMS_TEX_FN.Text = "";
            }
            ofd.Dispose();
        }

        private void btn_terr_sel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Portable Network Graphics | *.png";
            ofd.Multiselect = false;
            ofd.CheckFileExists = false;
            ofd.Title = "terrain";
            ofd.DefaultExt = ".png";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                TBX_TERRAIN_TEX_FN.Text = ofd.FileName;
            }
            else
            {
                TBX_TERRAIN_TEX_FN.Text = "";
            }
            ofd.Dispose();
        }

        private void btn_comm_sel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.Description = "Select a RES folder to this edit.";
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                TBX_COMMON_RES_FN.Text = ofd.SelectedPath;
            }
            else
            {
                TBX_COMMON_RES_FN.Text = "";
            }
            ofd.Dispose();
        }
        internal string[] arc_pcks = { };
        private void BTN_PCK_ADD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter =  "Content Package | *.PCK";
            ofd.Multiselect = true;
            ofd.CheckFileExists = false;
            ofd.Title = "Select pacakages...";
            ofd.DefaultExt = ".pck";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                List<string> list = new List<string>();
                list.AddRange(ofd.FileNames);
                arc_pcks = list.ToArray();
                
                foreach (string fn in ofd.FileNames)
                {
                    LBX_PCK.Items.Add(fn.Replace(".pck", ""));
                }
            }
            else
            {
                TBX_ARC_FN.Text = "";
            }
            ofd.Dispose();

        }

        private void BTN_PCK_CLEAR_Click(object sender, EventArgs e)
        {
            LBX_PCK.Items.Clear();
        }

        private void BTN_PCK_REMOVE_Click(object sender, EventArgs e)
        {
            if (LBX_PCK.SelectedIndex != -1) { LBX_PCK.Items.Remove(LBX_PCK.Items[LBX_PCK.SelectedIndex]); arc_pcks.SetValue(null, LBX_PCK.SelectedIndex); }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_bink_sel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.Description = "Select a music folder to this edit.";
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                TBX_BINKA_RES_FN.Text = ofd.SelectedPath;
                
            }
            else
            {
                TBX_BINKA_RES_FN.Text = "";
            }
            ofd.Dispose();
        }

        private void btn_particles_sel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "particles.png | particles.png";
            ofd.Multiselect = false;
            ofd.CheckFileExists = false;
            ofd.Title = "particles";
            ofd.DefaultExt = ".png";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() is DialogResult.OK)
            {
                TBX_PARTICLES_TEX_FN.Text = ofd.FileName;
            }
            else
            {
                TBX_PARTICLES_TEX_FN.Text = "";
            }
            ofd.Dispose();
        }
    }
}
