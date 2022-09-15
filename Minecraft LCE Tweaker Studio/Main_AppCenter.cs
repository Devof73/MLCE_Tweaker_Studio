using System;
using System.ComponentModel;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;


namespace Minecraft_LCE_Tweaker_Studio
{
    public partial class Main_AppCenter : Form
    {
        string FileName = @"C:\";
        internal OpenFileDialog OFD = new OpenFileDialog();
        public CSAudioPlayer.cAudioPlayerLineOut AudioPlayerLineOut = new CSAudioPlayer.cAudioPlayerLineOut();
        
        internal const string ttf1_mojanglesRegular = "Mojangles";
        internal const string ttf2_minecrafter = "Minecrafter";
        internal const string ttf3_minecrafterAlt = "Minecrafter Alt";

        internal const string _FontPath = "{0}/Mojangles.ttf";
        internal const string _Font2Path = "{0}/Minecrafter.ttf";
        internal const string _Font3Path = "{0}/MinecrafterAlt.ttf";

        readonly internal byte[] _ResTtf1 = Properties.Resources.TTF_Mojangles;
        readonly internal byte[] _ResTtf2 = Properties.Resources.TTF_Minecrafter_Reg;
        readonly internal byte[] _ResTtf3 = Properties.Resources.TTF_Minecrafter_Alt;

        private string workingPath = "";

        internal const Int32 _ExitCodeErrorTtf = 0x4;
        internal const Int32 _UnknownException = 0x02;
        internal const Int32 _RuntimeException = 0x3;
        internal const Int32 _RestartCommand = 0x5;
        internal const Int32 _UserRestartCommand = 0x6;

        internal Color AnimatedColor = Color.Black;
        internal Color AnimatedColorA = Color.FromArgb(255, 192, 192, 0);
        internal Color AnimatedColorB = Color.Gainsboro;
        internal bool InstancesRunning = false;

        private const string rpcCliId = "1019318473068904478";

        internal const string rpcMessage_working = "Working on {0} instances.";
        internal const string rpcMessage_onProject = "Working on the project.";
        internal const string rpcMessage_onfui = "Working in FJUI Editor.";
        internal const string rpcMessage_onarc = "Working in arc i/o.";
        internal const string rpcMessage_onLoc = "Working in game Localization.";
        internal const string rpcMessage_onSC = "Working in game Sprite Converter.";
        internal const string rpcMessage_onCol = "Working in game Coloration Editor.";
        internal const string rpcMessage_onbink = "Working in game binka i/o.";
        internal const string rpcMessage_compiling = "Compiling {0}";
        internal readonly string[] rpcMessage_Idling = { 
            "Idle",
            "Idle thinking ideas..",
            "Idle looking into the distance..",
            "Idle testing program..",
            "Idle looking far.",
            "Idle, going to shop.",
            "Idle, going to sleep",
            "Idle testing program."};
        internal DiscordRPC.DiscordRpcClient RPCCli = new DiscordRPC.DiscordRpcClient(rpcCliId);
        public Main_AppCenter()
        {
            InitializeComponent();
            Expoint.InAppUserSettings.Default.PropertyChanged += Default_PropertyChanged;
            RPC_SetPresence(DateTime.Now, false);
            DetectFonts(_FontPath, ttf1_mojanglesRegular, _ResTtf1);
            DetectFonts(_Font2Path, ttf2_minecrafter, _ResTtf2);
            DetectFonts(_Font3Path, ttf3_minecrafterAlt, _ResTtf3);
            File.WriteAllBytes(Application.StartupPath + "\\Expoint\\BINKA\\Resources\\binkawin.asi", Properties.Resources.binkawin);
            File.WriteAllBytes(Application.StartupPath + "\\Expoint\\BINKA\\Resources\\mss32.dll", Properties.Resources.mss32);
            File.WriteAllBytes(Application.StartupPath + "\\Expoint\\BINKA\\Resources\\binka_encode.exe", Properties.Resources.binka_encode);
            ///File.WriteAllBytes(Application.StartupPath + "\\Expoint\\dannyskey.wav", Properties.Resources.Ex´pomt)
            CommonTimer.Start();
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "MLCE Modding"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "MLCE Modding");
            }
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "MLCE Modding\\savedata"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "MLCE Modding\\savedata");
            }

        }
        internal void RPC_SetPresence(DateTime StartTime, bool Update,string State = "", string Details = "", string LargeImgKey = "", string SmallImageKey = "",string LargeImageToolTip = "", string SmallImageToolTip = "")
        {
           if (Update)
            {
                RPCCli.UpdateDetails(Details);
                RPCCli.UpdateState(State);
                RPCCli.UpdateLargeAsset(LargeImgKey, LargeImageToolTip);
                RPCCli.UpdateSmallAsset(SmallImageKey, SmallImageToolTip);
                RPCCli.UpdateStartTime(StartTime);
            }
            else if (Update is false)
            {

                RPCCli = new DiscordRPC.DiscordRpcClient(rpcCliId);
                RPCCli.Initialize();
                RPCCli.UpdateDetails(Details);
                RPCCli.UpdateState(State);
                RPCCli.UpdateStartTime(StartTime);
            }

        }
        internal void RPC_SetMessage()
        {
            var instances = Expoint.InAppUserSettings.Default.S_Ins_Arc
                + Expoint.InAppUserSettings.Default.S_Ins_Col
                + Expoint.InAppUserSettings.Default.S_Ins_Fui
                + Expoint.InAppUserSettings.Default.S_Ins_Loc
                + Expoint.InAppUserSettings.Default.S_Ins_Pck
                + Expoint.InAppUserSettings.Default.S_Ins_SPT
                + Expoint.InAppUserSettings.Default.S_Ins_Arc;
            bool idle = instances is 0;
            if (!workingPath.Contains("MLCE Modding\\savedata"))
            {
                RPCCli?.UpdateDetails("");
            }
            
            else if (Expoint.InAppUserSettings.Default.S_Ins_Col != 0 && instances == 1)
            {
                RPCCli?.UpdateState(rpcMessage_onCol);
            }
            else if (Expoint.InAppUserSettings.Default.S_Ins_Fui != 0 && instances == 1)
            {
                RPCCli?.UpdateState(rpcMessage_onfui);

            }
            else if (Expoint.InAppUserSettings.Default.S_Ins_Loc != 0 && instances == 1) { RPCCli?.UpdateState(rpcMessage_onLoc); }
            else if (Expoint.InAppUserSettings.Default.S_Ins_Arc != 0 && instances == 1)
            {
                RPCCli?.UpdateState(rpcMessage_onarc);
            }
            else if (Expoint.InAppUserSettings.Default.S_Ins_SPT != 0 && instances == 1)
            {
                RPCCli?.UpdateState(rpcMessage_onSC);
            }
            else if (workingPath.Contains("MLCE Modding\\savedata"))
            {
                RPCCli?.UpdateDetails(rpcMessage_onProject);
            }
            else if (idle)
            {
                RPCCli?.UpdateState(rpcMessage_Idling[new Random().Next(rpcMessage_Idling.Length)]);
            }
            else if (instances > 1)
            {
                RPCCli?.UpdateState(string.Format(rpcMessage_working, instances - 1));
                return;
            }
        }
        private void DetectFonts(string instpath,string fname, byte[] DataArray, float chkFntSize = 12, FontStyle style = FontStyle.Regular, GraphicsUnit GU = GraphicsUnit.Pixel)
        {
            if (CheckTtfExist(fname, chkFntSize, style, GU) is false)
            {
                TtfDoesntExists(DataArray, fname, instpath);
            }
        }
        bool CheckTtfExist(string chkFntName, float chkFntSize, FontStyle style = FontStyle.Regular, GraphicsUnit GU = GraphicsUnit.Pixel)
        {
            string fontName = chkFntName;
            float fontSize = chkFntSize;

            using (Font fontTester = new Font(
                   fontName,
                   fontSize,
                   style,
                   GU))
            {
                if (fontTester.Name == fontName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        bool WriteAndInstall_Ttf(byte[] ttfResourceBytes, string path)
        {
            try
            {
                var basedir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var fnPath = string.Format(path, basedir);
                File.WriteAllBytes(fnPath, ttfResourceBytes);
                Console.WriteLine(fnPath + "\r" + nameof(ttfResourceBytes));
                if (File.Exists(fnPath) is true)
                {
                    var prc = System.Diagnostics.Process.Start(fnPath);
                    prc.PriorityClass = ProcessPriorityClass.High;
                    prc.WaitForExit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                try { File.Delete(Application.StartupPath + @"\ttfError.txt"); } catch {}
                File.WriteAllText(Application.StartupPath+@"\ttfError.txt",ex.ToString() + "\r"+ex.Message+"\r"+ex.Source+"\r"+ex.StackTrace+"\r"+ex.TargetSite.Name);
                return false;
            }
            
        }
        bool TtfDoesntExists(byte[] ttfdata,string name, string instPath)
         
        {
            MessageBox.Show($"Installing TTF... [{name}]");
            if (WriteAndInstall_Ttf(ttfdata, instPath) is true)
            {
                Console.WriteLine("TTF Instalation Request Success. Restarting...");
                Application.Restart(); 
                Environment.Exit(0x2); 
                return true; 
            }


            bool finalResult = CheckTtfExist(ttf1_mojanglesRegular, 12) is false;
            if (finalResult == true)
            {
                MessageBox.Show("TTF install error or canceled, cannot start. Try again later.", "Error");
                Environment.Exit(_ExitCodeErrorTtf);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InstancesRunning =
            Expoint.InAppUserSettings.Default.S_Ins_Arc != 0 &&
            Expoint.InAppUserSettings.Default.S_Ins_Col != 0 &&
            Expoint.InAppUserSettings.Default.S_Ins_Fui != 0 &&
            Expoint.InAppUserSettings.Default.S_Ins_Loc != 0 &&
            Expoint.InAppUserSettings.Default.S_Ins_SPT != 0 &&
            Expoint.InAppUserSettings.Default.S_Ins_Pck != 0;

            LB_APP_Instances.Text = $"ARC: {Expoint.InAppUserSettings.Default.S_Ins_Arc}\rFourj: {Expoint.InAppUserSettings.Default.S_Ins_Fui}\rLOC: {Expoint.InAppUserSettings.Default.S_Ins_Loc}\rSPT: {Expoint.InAppUserSettings.Default.S_Ins_Pck}\rSEDIT: {Expoint.InAppUserSettings.Default.S_Ins_SPT}\rCOL: {Expoint.InAppUserSettings.Default.S_Ins_Col}";
        }
        internal string App_CheckFormatCommonCapabilities(FileInfo FI)
        {
            if (FI.Extension == ".png" || FI.Extension == ".jpg" || FI.Extension == ".jpeg")
            {
                FuiEditor.Forms.PicViewer PVW = new FuiEditor.Forms.PicViewer(new Bitmap(FI.FullName));
                PVW.ShowDialog();
                PVW.BringToFront();
                return ".png";
            }
            if (FI.Extension == ".zip" || FI.Extension == ".rar" || FI.Extension == ".txt" || FI.Extension == ".mp3" || FI.Extension == ".wav" || FI.Extension == ".flac")
            {
                if (FI.Extension == ".txt")
                {
                    if (MessageBox.Show("Wanna open this TXT on the game splashes editor?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string fname = FI.FullName;
                        Expoint.SplashEditor.SplashEdit sed = new Expoint.SplashEditor.SplashEdit(fname);
                        sed.Show();
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(FI.FullName);
                    }
                }
            }
            else
            {
                return null;
            }
            return FI.Extension;
        }
        internal void App_CheckFormatCapabilities(FileInfo FI)
        {
            BTN_FUI_TOOL.Enabled = FI.Extension == ".fui";
            BTN_LOC_TOOL.Enabled = FI.Extension == ".loc";
            BTN_TOOL_SPLASH.Enabled = FI.Extension == ".txt";
            BTN_ARC_TOOL.Enabled = FI.Extension == ".arc";
            BTN_COL_TOOL.Enabled = FI.Extension == ".col";
            BTN_BINK_TOOL.Enabled = FI.Extension == ".binka";
        }
        internal void App_DisplayFiInfo(FileInfo FI)
        {
            LB_CDate.Text = FI.CreationTime.ToLongDateString();
            LB_FSize.Text = FI.Length.ToString();
            LB_ROnly.Text = FI.IsReadOnly.ToString();
            LB_FName.Text = FI.Name.ToString();
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                OFD.Filter = "ARC Resources File|*.arc|FUI Bitmap Array|*.fui|Localization Container|*.loc|Environment Coloration List|*.col|Wave Form Audio|*.wav|BINKA Compressed Audio|*.binka|App Clipboard Savedata|*.scl";
                OFD.Multiselect = false;

                OFD.FileOk += OFD_FileOk;
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    FileName = OFD.FileName;
                    LB_SELFILEDIR.Text = "...." + FileName.Substring(FileName.LastIndexOf(@"\"), FileName.Length - FileName.LastIndexOf(@"\") - 10);
                    LB_State.Text = "Trying to decript: " + FileName.Substring(FileName.LastIndexOf(@"\"), FileName.Length - FileName.LastIndexOf(@"\"));
                    FileInfo FI = new FileInfo(FileName);
                    App_DisplayFiInfo(FI);
                    App_CheckFormatCapabilities(FI);
                    LB_State.Text = "Ready";
                }
            }
            catch (Exception ex)
            {
                LB_State.Text = "ERROR " + $"({ex.Message})";
            }
            LB_State.Text = "Not Ready";


        }

        private void OFD_FileOk(object sender, CancelEventArgs e)
        {
            LB_State.Text = "File Ready";
        }

        private void LB_State_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            Environment.Exit(0x01);
        }



        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit(); Application.Restart(); Application.Run();
        }

        private void BTN_LOC_TOOL_Click(object sender, EventArgs e)
        {
            try
            {
                Expoint.LOC.Editor LOC_EditWorker = new Expoint.LOC.Editor(FileName);
                LOC_EditWorker.Show();
            }
            catch
            {

            }

        }

        private void LB_Filename_FormClosing(object sender, FormClosingEventArgs e)
        {
            Expoint.InAppUserSettings.Default.S_Ins_Arc = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Fui = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Loc = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Pck = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Col = 0;
            Expoint.InAppUserSettings.Default.S_Ins_SPT = 0;
            Expoint.InAppUserSettings.Default.Save();
            Environment.Exit(0x001);
        }

        private void BTN_FUI_TOOL_Click(object sender, EventArgs e)
        {
            Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.FUI_Editor_Main FUIEM = new Expoint.FJUI.FUI_Editor_Main(FileName);
            FUIEM.Show();
        }
        internal void App_TVW_ListGAF_Dir(string path)
        {
            LB_State.Text = "Reading Directory = " + path;
            TEVW_FAV_GAMEDATA_FOLDER.Nodes.Clear();
            if (path != "" && Directory.Exists(path))
                Expoint.InAppUserSettings.Default.GAF_PATH = path;
            workingPath = path;
            LoadDirectory(path);
        }
        private void BTN_Sel_GameFolder_Click(object sender, EventArgs e)
        {
            LB_State.Text = "Invoking Folder Request...";
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = true;
            FBD.SelectedPath = LB_GAF.Text;
            DialogResult drResult = FBD.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
            {
                LB_State.Text = "FBD: OK";
                LB_GAF.Text = FBD.SelectedPath;
                App_TVW_ListGAF_Dir(FBD.SelectedPath);
            }

            else
            {
                LB_State.Text = "Not Ready";
            }
        }
        public void LoadDirectory(string Dir)
        {
            isGameDat_flag = 1;
            DirectoryInfo di = new DirectoryInfo(Dir);

            //Setting ProgressBar Maximum Value
            TreeNode tds = TEVW_FAV_GAMEDATA_FOLDER.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.ImageIndex = 3;
            LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
        }
        static int isGameDat_flag = 1;
        private void App_Graph_MANICONS(FileInfo fi, TreeNode tds, string file)
        {

            if (fi.Extension == ".png" || fi.Extension == ".jpg" || fi.Extension == ".jpeg")
            {
                tds.ImageIndex = 0;
            }
            if (fi.Extension == ".fui")
            {
                tds.ImageIndex = 8;
            }
            if (file.EndsWith(".txt"))
            {

                tds.ImageIndex = 18;
            }

            if (file.EndsWith(".arc"))
            {

                isGameDat_flag++;
            }
            if (file.EndsWith(".fui"))
            {
                isGameDat_flag++;
                tds.ImageIndex = 8;
            }
            if (file.EndsWith(".loc"))
            {
                isGameDat_flag++;
                tds.ImageIndex = 16;
            }
            if (file.EndsWith(".col"))
            {
                isGameDat_flag++;
                tds.ImageIndex = 19;
            }
        }
        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            // Loop through them to see files
            foreach (string file in Files)
            {

                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                App_Graph_MANICONS(fi, tds, file);
                if (isGameDat_flag == 4)
                {
                    TEVW_FAV_GAMEDATA_FOLDER.TopNode.ImageIndex = 11;
                    TEVW_FAV_GAMEDATA_FOLDER.TopNode.Tag = TEVW_FAV_GAMEDATA_FOLDER.TopNode.Tag.ToString() + "\r✱ Minecraft ARC Folder ✱";
                }
                tds.Tag = fi.FullName;
            }
        }
        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.ImageIndex = 3;
                tds.Tag = di.FullName;
                LoadFiles(subdirectory, tds);
                LoadSubDirectories(subdirectory, tds);
            }
        }


        private void TEVW_FAV_GAMEDATA_FOLDER_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode theNode = this.TEVW_FAV_GAMEDATA_FOLDER.GetNodeAt(e.X, e.Y);
            if (theNode != null && theNode.Tag != null)
            {
                // Change the ToolTip only if the pointer moved to a new node.
                if (theNode.Tag.ToString() != this.TIP_FGAMEFOLDER_DET.GetToolTip(this.TEVW_FAV_GAMEDATA_FOLDER))
                    this.TIP_FGAMEFOLDER_DET.SetToolTip(this.TEVW_FAV_GAMEDATA_FOLDER, theNode.Tag.ToString());

            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.TIP_FGAMEFOLDER_DET.SetToolTip(this.TEVW_FAV_GAMEDATA_FOLDER, "");
            }
        }

        private void TEVW_FAV_GAMEDATA_FOLDER_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (TEVW_FAV_GAMEDATA_FOLDER.SelectedNode != null)
                {
                    string sTag = TEVW_FAV_GAMEDATA_FOLDER.SelectedNode.Tag.ToString();
                    string sRtag = sTag.Substring(sTag.LastIndexOf("\\"));
                    LB_TEVW_SELC_FILE.Text = sRtag;
                }
               

            }
            catch
            {
                // IGNORE
            }


        }

        private void TEVW_FAV_GAMEDATA_FOLDER_DoubleClick(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Expoint.InAppUserSettings.Default.GAF_PATH != "/-" || Expoint.InAppUserSettings.Default.GAF_PATH != @"C:\")
            {
                if (LB_GAF.Text != "/-")
                {
                    Expoint.InAppUserSettings.Default.GAF_PATH = LB_GAF.Text;
                    string GAF_PATH = Expoint.InAppUserSettings.Default.GAF_PATH;
                    LB_State.Text = "Saved Initial Modding Workspace Folder: GAF_PATH";
                    MessageBox.Show("Saved Initial Modding Workspace Folder!\r" + GAF_PATH);
                }
                else
                {
                    MessageBox.Show("Select GAF Folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Select GAF Folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void Main_AppCenter_Load(object sender, EventArgs e)
        {
            Expoint.InAppUserSettings.Default.S_Ins_Arc = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Pck = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Fui = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Loc = 0;
            Expoint.InAppUserSettings.Default.S_Ins_SPT = 0;
            Expoint.InAppUserSettings.Default.S_Ins_Col = 0;
            if (Expoint.InAppUserSettings.Default.GAF_PATH != "/-" || Expoint.InAppUserSettings.Default.GAF_PATH != @"C:\")
            {
                try
                {
                    App_TVW_ListGAF_Dir(Expoint.InAppUserSettings.Default.GAF_PATH);
                }
                catch
                {


                }
            }
        }

        private void TEVW_FAV_GAMEDATA_FOLDER_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void TEVW_FAV_GAMEDATA_FOLDER_Click(object sender, EventArgs e)
        {

        }

        private void TEVW_FAV_GAMEDATA_FOLDER_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (FileName != "C:\\")
            {
                App_CheckFormatCommonCapabilities(new FileInfo(FileName));
            }
        }

        private void TEVW_FAV_GAMEDATA_FOLDER_ControlAdded(object sender, ControlEventArgs e)
        {


        }

        private void BTN_PCK_TOOL_Click(object sender, EventArgs e)
        {
            Expoint.ITC.SpriteConverterForm SCF = new Expoint.ITC.SpriteConverterForm();
            SCF.Show();
        }

        private void BTN_TOOL_SPLASH_Click(object sender, EventArgs e)
        {

        }
        private void BTN_ARC_TOOL_Click(object sender, EventArgs e)
        {
            if (FileName.EndsWith(".arc") && File.Exists(FileName))
            {
                FileInfo fi = new FileInfo(FileName);
                Directory.CreateDirectory(fi.DirectoryName + @"\arcData");
                Expoint.ARC.ResourceInputOutputForm RIOF = new Expoint.ARC.ResourceInputOutputForm(FileName, fi.DirectoryName + @"\", this);
                {
                    RIOF.Show();
                }
                fi = null;
            }
            else
            {
                Expoint.ARC.ResourceInputOutputForm RIOF = new Expoint.ARC.ResourceInputOutputForm();
                RIOF.Show();
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

    

        private void BTN_INST_SPRITE_TOOL_Click(object sender, EventArgs e)
        {
            
        }

        private void LBL_ResetSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All Settings Will Be Lost, are sure of reset user-app settings?.",
                "¿?", MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Exclamation) is DialogResult.Yes)
            {
                Expoint.InAppUserSettings.Default.Reset();
            }
        }

        private void TEVW_FAV_GAMEDATA_FOLDER_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                wksp_targetFile = TEVW_FAV_GAMEDATA_FOLDER.SelectedNode.Tag.ToString();
                FileInfo FI = new FileInfo(TEVW_FAV_GAMEDATA_FOLDER.SelectedNode.Tag.ToString());
                if (FI.Extension != String.Empty)
                {
                    App_CheckFormatCapabilities(FI);
                   
                    FileName = FI.FullName;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("EX! : " + ex.Message);
            }
        }

        private void BTN_CMIX_TOOL_Click(object sender, EventArgs e)
        {
            Expoint.CMIX.ColorGuiHelper CMIX = new Expoint.CMIX.ColorGuiHelper();
            CMIX.Show();
        }

        private void BTN_CBR_TOOL_Click(object sender, EventArgs e)
        {
            if (FileName.EndsWith(".scl"))
            {
                var result = MessageBox.Show("You have currently a file opened what we can open with this tool, wanna edit it?", "¿?", buttons: MessageBoxButtons.OK) is DialogResult.Yes;

                if (result is true)
                {
                    TextReader sr = File.OpenText(FileName);
                    string data = sr.ReadToEnd();
                    sr.Close();
                    if (data.Contains("¨") == false)
                    {
                        MessageBox.Show("Invalid saveboard value.", "Invalid File Error.", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Hand);
                        return;
                    }
                    else if (data.Contains("¨") is true)
                    {
                        var lines = data.Split('¨');
                        Expoint.Clipboard.AppClipboardForm APCP = new Expoint.Clipboard.AppClipboardForm(lines);
                        APCP.ShowDialog();
                    }

                }
                else
                {
                    Expoint.Clipboard.AppClipboardForm APCP = new Expoint.Clipboard.AppClipboardForm();
                    APCP.ShowDialog();
                }


            }
            else
            {
                Expoint.Clipboard.AppClipboardForm APCP = new Expoint.Clipboard.AppClipboardForm();
                APCP.ShowDialog();
            }
        }

        private void BTN_COL_TOOL_Click(object sender, EventArgs e)
        {
            App_CheckFormatCapabilities(new FileInfo(FileName));
            if (FileName.EndsWith(".col"))
            {
                LB_State.Text = "Ready";
                COL_Editor.COLEditor colTool = new COL_Editor.COLEditor(FileName);
                colTool.Name = "workWindowCol(" + Expoint.InAppUserSettings.Default.S_Ins_Col + ")";
                colTool.ShowDialog();
            }
            else if (FileName.EndsWith(".col") is false)
            {
                ElseInstanceCol();
            }
            else
            {
                ElseInstanceCol();
            }


        }
        private void ElseInstanceCol()
        {
            COL_Editor.COLEditor colTool = new COL_Editor.COLEditor();
            colTool.Name = "workWindowCol(" + Expoint.InAppUserSettings.Default.S_Ins_Col + ")";
            colTool.ShowDialog();
        }
        private void siticoneLabel2_Click(object sender, EventArgs e)
        {
            string bug = "a";
            for (int i = 0; i < 50; i++)
            {
                bug = bug + bug;
                MessageBox.Show("pepe is going to turn off your pc spawn of satan");
            }
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        private void BTN_SPRITE_TOOL_DoubleClick(object sender, EventArgs e)
        {
            BTN_PCK_TOOL_Click(sender, e);
        }

        private void BTN_ARC_TOOL_DoubleClick(object sender, EventArgs e)
        {
            BTN_ARC_TOOL_Click(sender, e);
        }

        private void Btn4_Credits_Click(object sender, EventArgs e)
        {
            this.Hide();
            About_help abh = new About_help(this);
            abh.Show();
        }

        private void BTN_BINK_TOOL_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(FileName).ToLower() is ".wav" || Path.GetExtension(FileName).ToLower() is ".binka")
            {
                var result = MessageBox.Show("You have selected a compatible file with the binka tool. Wanna open it?"
                + "\rYes: Open to comp/uncomp\rNo: Make Binka Instance.\rCancel: Close", "¿?", buttons: MessageBoxButtons.YesNoCancel);
                if (result is DialogResult.Yes)
                {
                    Expoint.BINKA.AudioBinkInputOutputForm ABIOF = new Expoint.BINKA.AudioBinkInputOutputForm(FileName)
                    {
                    };
                    ABIOF.Show();
                }
                else if (result is DialogResult.No)
                {
                    Expoint.BINKA.AudioBinkInputOutputForm ABIOF = new Expoint.BINKA.AudioBinkInputOutputForm()
                    {};
                    ABIOF.Show();
                }
            }
            else
            {
                Expoint.BINKA.AudioBinkInputOutputForm ABIOF = new Expoint.BINKA.AudioBinkInputOutputForm()
                { };
                ABIOF.Show();
            }
           
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (FileName != "")
            {
                FileName = "";
                BTN_ARC_TOOL.Enabled = true;
                BTN_BINK_TOOL.Enabled = true;
                BTN_CBR_TOOL.Enabled = true;
                BTN_CMIX_TOOL.Enabled = true;
                BTN_SPRITE_TOOL.Enabled = true;
                BTN_TOOL_SPLASH.Enabled = true;
                BTN_COL_TOOL.Enabled = true;
            }
        }    
        internal int anim_col_r = 0;
        internal int anim_col_g = 0;
        internal int anim_col_b = 0;
        int ticks = 0;
        private void CommonTimer_Tick(object sender, EventArgs e)
        {
            if (InstancesRunning == false)
            {
                TickColoring();
                AppSetColorStyle(AnimatedColor);
                ticks++;
                if (ticks == 10)
                {
                    ticks = 0;
                    RPC_SetMessage();
                }
            }
        }
        bool decreasing = false;
        private Color TickColoring()
        {
            var ar = AnimatedColorA.R;
            var ag = AnimatedColorA.G;
            var ab = AnimatedColorA.B;

            var br = AnimatedColorB.R;
            var bg = AnimatedColorB.G;
            var bb = AnimatedColorB.B;

            var AA = ar + ag + ab;
            var AB = br + bg + bb;
            if (ar < br && anim_col_r < br && decreasing == false)
            {
                anim_col_r++;
            }
            if (ag < bg && anim_col_g < bg && decreasing == false)
            {
                anim_col_g++;
            }
            if (ab < bb && anim_col_b < bb && decreasing == false)
            {
                anim_col_b++;
            }
            if (anim_col_r >= br && anim_col_g >= bg && anim_col_b >= bb || AA == AB)
            {
                decreasing = true;
            }
            if (decreasing == true)
            {
                if (anim_col_r > ar) { anim_col_r--; }
                if (anim_col_g > ag) { anim_col_g--; }

                if (anim_col_b > ab) { anim_col_b--; }
            }
            if (decreasing == true && anim_col_r == ar && anim_col_g == ag && anim_col_b == ab)
            {
                decreasing = false;
            }
            // decre
            //Console.WriteLine($"Col: dec: {decreasing}:{anim_col_r},{anim_col_g},{anim_col_b} | T: {br},{bg},{bb} | A: {ar},{ag},{bb} |aa {AA} : ab {AB}");
            AnimatedColor = Color.FromArgb(anim_col_r, anim_col_g, anim_col_b);
            return AnimatedColor;
        }
        private void AppSetColorStyle(Color col)
        {
            BTN_TOOL_SPLASH.FillColor = col;
            BTN_CMIX_TOOL.FillColor = col;
            BTN_CBR_TOOL.FillColor = col; BTN_BINK_TOOL.FillColor = col; BTN_COL_TOOL.FillColor = col;
        }

        private void BTN_NWEDIT_Click(object sender, EventArgs e)
        {
            Expoint.Better_Forms.EditionManager em = new Expoint.Better_Forms.EditionManager(this);
            em.ShowDialog();
        }

        private void BTN_COMPILE_EDITION_Click(object sender, EventArgs e)
        {
            Expoint.Better_Forms.compilate_ps3 cps3 = new Expoint.Better_Forms.compilate_ps3(); 
            cps3.ShowDialog();
        }

        private void Main_AppCenter_Enter(object sender, EventArgs e)
        {
            InstancesRunning = false;
        }

        private void Main_AppCenter_Leave(object sender, EventArgs e)
        {
            InstancesRunning = true;
        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }
        internal string wksp_targetFile = null;
        internal bool wksp_targetIsFile = false;
        private void TEVW_FAV_GAMEDATA_FOLDER_MouseClick(object sender, MouseEventArgs e)
        {
            var ms_x = e.X;
            var ms_y = e.Y;
            var selectedNode = TEVW_FAV_GAMEDATA_FOLDER.GetNodeAt(ms_x, ms_y);
            if (selectedNode != null)
            {
                var path = selectedNode.Tag as string;
                bool isdir = ItsDir((string)path);
                ctwk_btn5.Enabled = isdir;
                ctwk_btn2.Enabled = isdir;
                ctwk_btn1.Enabled = isdir;
                ctwk_btn4.Enabled = !isdir;
                wksp_targetIsFile = !isdir;
            }

        }
        internal bool ItsDir(string path)
        {
            try
            {
                return !Path.HasExtension(path) || (path.EndsWith("\\") && !Path.HasExtension(path));
            }
            catch
            {
                return false;
            }
        }

        private void ctwk_tbx1_Click(object sender, EventArgs e)
        {

        }

        private void ctwk_tbx1_TextChanged(object sender, EventArgs e)
        {
                ctwk_btn6.Enabled = ctwk_tbx1.Text != "" && ctwk_tbx1.Text != string.Empty;
        }

        private void ctwk_btn6_Click(object sender, EventArgs e)
        {
            char[] illegal = { '/', '}', '{', '[', ']', '<', '>', '#', ':', '*', '"', ':', '?', '|' };

            FileInfo Obj;
            if (wksp_targetIsFile == true)
            {
                Obj = new FileInfo(wksp_targetFile);
                var name = CharRemove(ctwk_tbx1.Text, illegal);
                var location = Obj.Directory.FullName;
                var fname = location.TrimEnd(illegal) + "\\" + name;
                File.Create(fname).Close();
                File.WriteAllBytes(fname, File.ReadAllBytes(wksp_targetFile));
                File.Delete(wksp_targetFile);
                App_TVW_ListGAF_Dir(workingPath);
            }
            Obj = null;
          

        }
        private string CharRemove(string target, char[] illegal)
        {
            var text = target;
            for (int chr = 0; chr < illegal.Length; chr++)
            {
                text.Replace(illegal[chr], '_');
            }
            return text;
        }
        internal void AddFileToWkTree(bool addExt, string InitialDir, string defaultExt, bool multiselect, string filter)
        {
            if (ItsDir(wksp_targetFile))
            {
                try
                {
                    OFD = new OpenFileDialog()
                    {
                        AddExtension = addExt,
                        InitialDirectory = InitialDir,
                        Multiselect = multiselect,
                        DefaultExt = defaultExt,
                        DereferenceLinks = true,
                        Filter = filter,
                    };
                    bool result = OFD.ShowDialog() is DialogResult.OK;
                    if (result is true)
                    {
                        foreach (string filename in OFD.FileNames)
                        {
                            var fi = new FileInfo(wksp_targetFile);
                            var fidir = fi.DirectoryName;
                            var outName = Path.Combine(fidir, "\\" + fi.Name);

                            if (File.Exists(outName))
                            {
                                MessageBox.Show("Already exists file, sustitute?", "¿?", buttons: MessageBoxButtons.YesNoCancel);
                            }
                            byte[] data = File.ReadAllBytes(OFD.FileName);
                            File.Create(outName).Close();
                            File.WriteAllBytes(outName, data);

                        }
                        App_TVW_ListGAF_Dir(workingPath);
                    }

                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("File Permissions error. Check savedata folder:\r"+Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\MLCE Modding\\savedata", "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
                
            }
        }
       
        private void ctwk_btn2_Click(object sender, EventArgs e)
        {
          

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[!] Checking dir.");
            if (ItsDir(wksp_targetFile))
            {
                Console.WriteLine("[!] resultado = {0}", ItsDir(wksp_targetFile));
                var di = new DirectoryInfo(wksp_targetFile);
                Directory.CreateDirectory(di.Parent.FullName + "\\" + TTTBX_filename.Text);
            }
        }

        private void ctwk_btn1_Click(object sender, EventArgs e)
        {
            AddFileToWkTree(false, workingPath, "", true, "png|*.png|arc|*.arc|txt|*.txt|jpeg|*.jpeg|color|*.col|loc|*.loc|fui|*.fui|bmp|*.bmp|binka|*.binka");
        }

        private void ctwk_btn4_Click(object sender, EventArgs e)
        {
            var fname = wksp_targetFile;
            bool result = MessageBox.Show("Are you sure, from delete the selected target?", "¿?", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Exclamation) == DialogResult.Yes;
            if (result is true)
            {
                File.Delete(fname);
                App_TVW_ListGAF_Dir(workingPath);
            }
        }

        private void ctwk_btn5_Click(object sender, EventArgs e)
        {
            if (wksp_targetFile.Split('-')[0].Length == 9)
            {
                MessageBox.Show("Cannot delete a project folder...");
            }
            else if (ItsDir(wksp_targetFile))
            {
                var dir = new DirectoryInfo(wksp_targetFile);
                if ((dir.Extension == ""))
                {
                    Directory.Delete(dir.FullName, true);
                }
                MessageBox.Show("!Deleted " + dir.FullName);
            }

        }
    }
}
