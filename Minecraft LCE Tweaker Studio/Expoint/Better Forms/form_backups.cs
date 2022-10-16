using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.Better_Forms
{
    public partial class form_backups : Form
    {
        internal string BackupPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MLCE Modding\\compilation_backups";
        internal List<DirectoryInfo> BackupDirectories = new List<DirectoryInfo>();
        public form_backups()
        {
            InitializeComponent();
            AnalizeBackups();
        }
        internal void AnalizeBackups()
        {
            LBX_Backups.Items.Clear();
            string[] backupDirs = Directory.GetDirectories(BackupPath);
            for (int i = 0; i < backupDirs.Length; i++)
            {
                var DI = new DirectoryInfo(backupDirs[i]);
                BackupDirectories.Add(DI);
                LBX_Backups.Items.Add(i + " - " + DI.Name + " : [ " + DI.Root.Name + " ] ");
            }
        }
        internal int DirCopyn = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            if (LBX_Backups.SelectedIndex != -1)
            {
                var selectedDir = BackupDirectories[LBX_Backups.SelectedIndex];
                {
                    DirCopyn = DirCopyn + 1;
                    var name = selectedDir.FullName + "(" + DirCopyn + ")";
                    Directory.CreateDirectory(name);
                    {
                        CopyDirectory(selectedDir.FullName, name, true);
                        AnalizeBackups();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AnalizeBackups();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LBX_Backups.SelectedIndex != -1)
            {
                var selectedDir = BackupDirectories[LBX_Backups.SelectedIndex];
                {
                    Directory.Delete(selectedDir.FullName, true);
                    AnalizeBackups();
                }
            }

        }
        // MICROSOFT
        private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (LBX_Backups.SelectedIndex != -1)
            {
                System.Diagnostics.Process.Start(BackupDirectories[LBX_Backups.SelectedIndex].FullName);
            }
        }

        private void LBX_Backups_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = LBX_Backups.SelectedIndex != -1;
            button2.Enabled = LBX_Backups.SelectedIndex != -1;
            button3.Enabled = LBX_Backups.SelectedIndex != -1;
        }
    }
}
