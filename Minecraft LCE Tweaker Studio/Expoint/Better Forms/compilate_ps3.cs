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
using System.Net;
using ftp;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.Better_Forms
{
    public partial class compilate_ps3 : Form
    {
        internal string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MLCE Modding\\";

        CompilationLog CompLog;
        public compilate_ps3()
        {
            CompLog = new CompilationLog();
            InitializeComponent();
            timer1.Start();
            EnumerateProjects(Directory.EnumerateDirectories(Path.Combine(DataPath, "savedata\\")).Cast<string>().ToArray());
           // CompLog.WriteLine(Path.Combine(DataPath, "savedata\\"));
        }


        private void EnumerateProjects(string[] strings)
        {
            COBX_PROJECTS.Items.Clear();
            foreach (string str in strings)
            {
                COBX_PROJECTS.Items.Add (str);
                CompLog.WriteLine(str);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ControlBox = false;
            CompileUploadBackupAll();
        }
        private void CompileUploadBackupAll()
        {
            int slevel = 0;
            if (COBX_PROJECTS.SelectedIndex != -1)
            {
                bool reachable = false;
                try
                {
                    pgb_progress.Value += 10;
                    WebClient wc = new WebClient();
                    var str = wc.DownloadString(tbx1.Text + "/dev_hdd0/boot_plugins.txt");
                    CompLog.WriteLine(str);
                    reachable = !string.IsNullOrEmpty(str);
                    CompLog.WriteLine(reachable.ToString());
                    wc.Dispose();
                    pgb_progress.Update();
                    slevel=slevel + 10;
                }
                catch
                {
                    MessageBox.Show("Impossible to reach: " + tbx1.Text + "/dev_hdd0/boot_plugins.txt" + " - Operation cannot continue.");
                    return;
                }
                if (Directory.Exists((COBX_PROJECTS.SelectedItem as string)) == true && reachable == true)
                {
                    slevel = slevel + 10;
                    pgb_progress.Value += 10;
                    CompLog.WriteLine("[!!] Sucessfully reached server. Initialization...");
                    var root = (COBX_PROJECTS.SelectedItem as string);
                    DirectoryInfo DI = new DirectoryInfo(root);
                    var diName = DI.Name;
                    var prjRegion = diName.Split('-')[0]; var prjName = diName.Split('-')[1];
                    CompLog.WriteLine("[*] Creating variables...");
                    string[] ProjectsDirs =
                    {
                        root + "\\Common\\res\\TitleUpdate\\res",
                        root + "\\Common\\Media",
                        root + "\\music",
                        root + "\\DLC",
                    };
                    ftp.File_Transfer_Protocol FTP = new ftp.File_Transfer_Protocol();
                    bool HasCommon = Directory.Exists(ProjectsDirs[0]);
                    bool HasARC = Directory.Exists(ProjectsDirs[1]);
                    bool HasMusic = Directory.Exists(ProjectsDirs[2]);
                    bool HasDlc = Directory.Exists(ProjectsDirs[3]);

                    var dirGame = tbx1.Text + "/dev_hdd0/game/" + prjRegion;
                    var eboot = dirGame + "/USRDIR/EBOOT.BIN".Replace(System.Environment.NewLine, " ");
                    var backupPath = DataPath + "compilation_backups\\";
                    var USRDIR = dirGame + "/USRDIR";
                    string[] OnlineDirs =
                    {
                        USRDIR + "\\Common\\",
                        USRDIR + "\\Common\\res\\TitleUpdate\\res",
                        USRDIR + "\\Common\\Media",
                        USRDIR + "\\music\\",
                        USRDIR + "\\DLC",
                    };
                    slevel = slevel + 10;

                    CompLog.WriteLine("[!] Final Variables Result:");
                    CompLog.WriteLine($"---{nameof(root) + ":" + root}");
                    CompLog.WriteLine($"---{nameof(diName) + ":" + diName}");
                    CompLog.WriteLine($"---{nameof(prjName) + ":" + prjName}");
                    CompLog.WriteLine($"---{nameof(prjRegion) + ":" + prjRegion}");
                    CompLog.WriteLine($"---{nameof(HasCommon) + ":" + HasCommon}");
                    CompLog.WriteLine($"---{nameof(HasARC) + ":" + HasARC}");
                    CompLog.WriteLine($"---{nameof(HasMusic) + ":" + HasMusic}");
                    CompLog.WriteLine($"---{nameof(HasDlc) + ":" + HasDlc}");
                    CompLog.WriteLine($"---{nameof(dirGame) + ":" + eboot}");
                    pgb_progress.Value += 10;
                    CompLog.WriteLine("[...] Checking *dirGame existency on dev_hdd0");
                    bool gameExist = FTP.DirectoryExists(dirGame); CompLog.WriteLine("[!] boolean returned " + gameExist);
                    if (gameExist is true)
                    {
                        

                        CompLog.WriteLine("[...] Backing up original data to local directory");
                        CompLog.WriteLine("----> " + backupPath);
                        if (!Directory.Exists(backupPath)) { Directory.CreateDirectory(backupPath); }
                        var internalBackupPath = backupPath + "\\AFTER_" + prjRegion + "_" + prjName;
                        Directory.CreateDirectory(internalBackupPath);
                        Random RandomN = new Random(100);
                        Directory.CreateDirectory(internalBackupPath + "\\Common\\res");
                        Directory.CreateDirectory(internalBackupPath + "\\Common\\Media");
                        Directory.CreateDirectory(internalBackupPath + "\\Common\\res\\TitleUpdate\\");
                        Directory.CreateDirectory(internalBackupPath + "\\Common\\res\\TitleUpdate\\res");
                        if (HasCommon)
                        {
                            pgb_progress.Value += 10;
                            CompLog.WriteLine("[!] Project contains COMMON... ");
                            if (Directory.Exists(ProjectsDirs[0]))
                            {
                                slevel = slevel + 10;
                                // RECUPERA TODOS LOS ARCHIVOS EXISTENTES DENTRO DEL INDICE DIRECTORIO 0
                                // SI EL SERVIDOR YA CONTIENE UNO DE ELLOS LOS DESCARGA EN MODO DE COPIA DE SEGURIDAD
                                string[] files = Directory.GetFiles(ProjectsDirs[0]);
                                for (int i = 0; i < files.Length; i++)
                                {
                                    slevel = slevel + 10;
                                    var fi = new FileInfo(files[i]);
                                    var localBackupPath = internalBackupPath + "/Common/res/TitleUpdate/res";
                                    var query = OnlineDirs[1] + "/" + fi.Name;
                                    IfFtpExistDownloadBackupAndDelete(localBackupPath, query, files[i], true);
                                    CompLog.WriteLine("[!] Backing up...\r" +
                                                      "---> query: " + query + "\r" +
                                                      "---> bpath: " + backupPath);
                                }
                            }

                        }
                        if (HasARC)
                        {
                            slevel = slevel + 10;
                            pgb_progress.Value += 10;
                            CompLog.WriteLine("[!] Project contains ARC... ");
                            var media = USRDIR + "/Common/Media/MediaPS3.arc";
                            var mediaBackup = internalBackupPath + "\\Common\\Media.arc";
                            if (FTP.CheckFileExist(media, true) is true)
                            {
                                var newName = media + "_original" + RandomN.Next() + ".arc";
                                FTP.Rename(media, newName);
                                /* res1 = FTP.DownloadFile(media, mediaBackup);
                                 res2 = FTP.DeleteFileOnFtpServer(new Uri(media)); */
                                slevel = slevel + 10;
                                CompLog.WriteLine("[!] Successfully renamed " + media);
                                CompLog.WriteLine("[!] -> " + newName);
                            }
                            FTP.Upload(media, ProjectsDirs[1] + "\\MediaPS3.arc");
                            CompLog.WriteLine("[!] MEDIA = " + media);
                            CompLog.WriteLine("[!] LOCALFILE = " + ProjectsDirs[1] + "\\MediaPS3.arc");
                            CompLog.WriteLine("[!] Arc Successfully replaced.");
                            slevel = slevel + 10;
                        }
                        if (HasMusic)
                        {
                            slevel = slevel + 10;
                            string dir1 = ProjectsDirs[3] + "\\music";
                            string dir2 = ProjectsDirs[3] + "\\cds";
                            string[] musDirs = Directory.GetDirectories(ProjectsDirs[3]);
                            List<string> cdFiles = new List<string>();
                            List<string> musFiles = new List<string>();
                            bool able = musDirs.Contains<string>(dir1) &&
                                musDirs.Contains<string>(dir2);
                            if (able)
                            {
                                pgb_progress.Value += 10;
                                foreach (string fi in Directory.GetFiles(dir1))
                                {
                                    slevel = slevel + 10;
                                    if (new FileInfo(fi).Name.EndsWith(".binka"))
                                    {
                                        musFiles.Add(fi);
                                    }
                                }
                                foreach (string fi in Directory.GetFiles(dir2))
                                {
                                    slevel = slevel + 10;
                                    if (new FileInfo(fi).Name.EndsWith(".binka"))
                                    {
                                        cdFiles.Add(fi);
                                    }
                                }

                            }
                        }
                        if (HasDlc)
                        {
                            slevel = slevel + 10;
                            pgb_progress.Value += 10;
                            // upload all dlc to new folders
                            string[] dlcsFileNames = Directory.GetFiles(ProjectsDirs[3]);
                            CompLog.WriteLine("[!] total dlc detected: " + dlcsFileNames.Length);
                            for (int i = 0; i < dlcsFileNames.Length; i++)
                            {
                                CompLog.WriteLine("[%] " + i + " - " + dlcsFileNames[i]);
                                try
                                {
                                    var fi = new FileInfo(dlcsFileNames[i]);
                                    if (fi.Extension.ToLower() == ".pck")
                                    {
                                        var dirname = OnlineDirs[4] + "/" + fi.Name.ToLower().Trim().Replace(".pck", "");
                                        FTP.CreateDir(OnlineDirs[4], fi.Name.ToLower().Trim().Replace(".pck", ""));
                                        FTP.Upload(dirname + "/" + fi.Name, fi.FullName);
                                    }
                                }
                                catch (Exception err)
                                {
                                    CompLog.WriteLine("[!¡] Incident at stage " + i);
                                    CompLog.WriteLine($"[!*] {err.GetType().ToString().ToUpper()} ERROR -msg: {err.Message} -source: {err.Source}");
                                }

                            }
                            pgb_progress.Value += 20;
                        }
                        pgb_progress.Value = 100;
                        CompLog.WriteLine("[!] Transferency to PS3 successfully completed.");
                        CompLog.WriteLine("[!] Original data saved in "+ backupPath);
                        CompLog.WriteLine("[!] Satisfactory level reached value +" + slevel);
                        MessageBox.Show("!Operation Success With Level +" + slevel + ".\r");
                        pgb_progress.Value = 0;
                    }

                }
            }

        }
        /// <summary>
        ///  Revisa si existe un archivo en el servidor, caso true descarga una copia y luego reemplaza la del servidor.
        ///  
        /// </summary>
        /// <param name="LocalbackupDownloadPath">Directorio en donde se guardará la copia original.</param>
        /// <param name="OnlineExistencyQueryFileName">El archivo a preguntar en el servidor.</param>
        /// <param name="projectPath">El directorio del proyecto de la edición.</param>
        /// <param name="replacementSourceFileName">Archivo de prueba que reemplazará el original</param>
        /// <param name="QueryIsBinaryFile">El archivo es binario o de texto?</param>
        private void IfFtpExistDownloadBackupAndDelete
        (string LocalbackupDownloadPath,
         string OnlineExistencyQueryFileName,
         string replacementSourceFileName, 
         bool QueryIsBinaryFile)
        {
            OnlineExistencyQueryFileName = OnlineExistencyQueryFileName.Replace("\\", "/");
            #region Initial Log
            CompLog.WriteLine("[!] Running advanced replacement.");
            CompLog.WriteLine("[!] ----> "+LocalbackupDownloadPath);
            CompLog.WriteLine("[!] ----> "+OnlineExistencyQueryFileName);
            CompLog.WriteLine("[!] ----> "+replacementSourceFileName);
            #endregion

            ftp.File_Transfer_Protocol FTP = new ftp.File_Transfer_Protocol();
            bool exists = FTP.CheckFileExist(OnlineExistencyQueryFileName, QueryIsBinaryFile);

            CompLog.WriteLine("[!] Existency check returned " + exists);

            if (exists)
            {
                CompLog.WriteLine("[!] Replacing original file. Backingup...");
                var onlineFileName = OnlineExistencyQueryFileName.Split('\\').Last().Replace("\\","/");
                CompLog.WriteLine("[!] Online File Name returned " + onlineFileName);
                FTP.DownloadFile(onlineFileName,LocalbackupDownloadPath + "/" + onlineFileName);
                FTP.DeleteFileOnFtpServer(onlineFileName);
                FTP.Upload(OnlineExistencyQueryFileName, replacementSourceFileName);

            }
            else if (exists == false)
            {
                FTP.Upload(OnlineExistencyQueryFileName, replacementSourceFileName);
            }
            FTP.Dispose();
        }
        private void tbx1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void COBX_PROJECTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(COBX_PROJECTS.Items[COBX_PROJECTS.SelectedIndex] as string) )
            {
                btn1.Text = "COMPILE ("+(GetDirectorySize((COBX_PROJECTS.Items[COBX_PROJECTS.SelectedIndex] as string)) / 1024).ToString("N0", System.Globalization.CultureInfo.InvariantCulture) + "MBs )";
            }
        }
        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }

        private void RTBX_LOG_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CompLog.Output != RTBX_LOG.Text)
            {
                RTBX_LOG.Text = CompLog.Output;
                RTBX_LOG.SelectionLength = 0;
                RTBX_LOG.SelectionStart = RTBX_LOG.Text.Length;
                
            }
                
        }

        private void btn3_copy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.Clear();
            System.Windows.Forms.Clipboard.SetText(RTBX_LOG.Text);
        }

        private void btn4_backups_Click(object sender, EventArgs e)
        {
            Expoint.Better_Forms.form_backups FB = new form_backups();
            FB.ShowDialog();
        }
        /*
        internal void McSprx()
        {
            var PATH = Application.StartupPath + "\\MC.sprx";
            {
                if (File.Exists(PATH) is true)
                {
                    File_Transfer_Protocol ftp = new File_Transfer_Protocol();
                    ftp.Upload("ftp://ip/dir1/tid/usrdir/MC.sprx", PATH, "", "");
                }
            }
        }
        */
        private void compilate_ps3_Load(object sender, EventArgs e)
        {

        }
    }
    internal class CompilationLog
    {
        private static string output = ""; 
        
        internal CompilationLog()
        {
        }

        public string Output { get => output; }
        public void WriteLine(object msg)
        {
            Console.WriteLine(msg);
            output += "\r" + msg.ToString() ;
        }
    }
}
