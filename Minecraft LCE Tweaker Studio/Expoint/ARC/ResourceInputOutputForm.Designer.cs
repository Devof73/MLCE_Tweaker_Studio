namespace Minecraft_LCE_Tweaker_Studio.Expoint.ARC
{
    partial class ResourceInputOutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceInputOutputForm));
            this.GTBX_descompressionFilePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TABC_RIOF = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.GNTBX_OutPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LBL_CompressionWarning = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GNTBX_CompDataFolderTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNTB_CompResultFileTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbtn_ForceDesc = new Guna.UI2.WinForms.Guna2Button();
            this.GNBTN_DecompressStart = new Guna.UI2.WinForms.Guna2Button();
            this.GNBTN_SelectOutDataFolder = new Guna.UI2.WinForms.Guna2Button();
            this.GNBTN_SelectFile = new Guna.UI2.WinForms.Guna2Button();
            this.GNBTN_CompressionStart = new Guna.UI2.WinForms.Guna2Button();
            this.GNBTN_SelectDataFolder = new Guna.UI2.WinForms.Guna2Button();
            this.GNBTN_SelectTargetFile = new Guna.UI2.WinForms.Guna2Button();
            this.TABC_RIOF.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GTBX_descompressionFilePath
            // 
            this.GTBX_descompressionFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTBX_descompressionFilePath.DefaultText = "C:\\Users\\";
            this.GTBX_descompressionFilePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTBX_descompressionFilePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTBX_descompressionFilePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTBX_descompressionFilePath.DisabledState.Parent = this.GTBX_descompressionFilePath;
            this.GTBX_descompressionFilePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTBX_descompressionFilePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTBX_descompressionFilePath.FocusedState.Parent = this.GTBX_descompressionFilePath;
            this.GTBX_descompressionFilePath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTBX_descompressionFilePath.HoverState.Parent = this.GTBX_descompressionFilePath;
            this.GTBX_descompressionFilePath.Location = new System.Drawing.Point(26, 35);
            this.GTBX_descompressionFilePath.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.GTBX_descompressionFilePath.Name = "GTBX_descompressionFilePath";
            this.GTBX_descompressionFilePath.PasswordChar = '\0';
            this.GTBX_descompressionFilePath.PlaceholderText = "";
            this.GTBX_descompressionFilePath.SelectedText = "";
            this.GTBX_descompressionFilePath.SelectionStart = 9;
            this.GTBX_descompressionFilePath.ShadowDecoration.Parent = this.GTBX_descompressionFilePath;
            this.GTBX_descompressionFilePath.Size = new System.Drawing.Size(400, 39);
            this.GTBX_descompressionFilePath.TabIndex = 0;
            this.GTBX_descompressionFilePath.TextChanged += new System.EventHandler(this.GTBX_descompressionFilePath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mojang", 9F);
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descompression ARC File";
            // 
            // TABC_RIOF
            // 
            this.TABC_RIOF.Controls.Add(this.tabPage1);
            this.TABC_RIOF.Controls.Add(this.tabPage2);
            this.TABC_RIOF.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TABC_RIOF.Location = new System.Drawing.Point(-1, 0);
            this.TABC_RIOF.Name = "TABC_RIOF";
            this.TABC_RIOF.SelectedIndex = 0;
            this.TABC_RIOF.Size = new System.Drawing.Size(623, 310);
            this.TABC_RIOF.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbtn_ForceDesc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.GNBTN_DecompressStart);
            this.tabPage1.Controls.Add(this.GNTBX_OutPath);
            this.tabPage1.Controls.Add(this.GNBTN_SelectOutDataFolder);
            this.tabPage1.Controls.Add(this.GTBX_descompressionFilePath);
            this.tabPage1.Controls.Add(this.GNBTN_SelectFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Decompress";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mojang", 9F);
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Output Folder";
            // 
            // GNTBX_OutPath
            // 
            this.GNTBX_OutPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTBX_OutPath.DefaultText = "C:\\Users\\";
            this.GNTBX_OutPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTBX_OutPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTBX_OutPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTBX_OutPath.DisabledState.Parent = this.GNTBX_OutPath;
            this.GNTBX_OutPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTBX_OutPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTBX_OutPath.FocusedState.Parent = this.GNTBX_OutPath;
            this.GNTBX_OutPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTBX_OutPath.HoverState.Parent = this.GNTBX_OutPath;
            this.GNTBX_OutPath.Location = new System.Drawing.Point(26, 102);
            this.GNTBX_OutPath.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.GNTBX_OutPath.Name = "GNTBX_OutPath";
            this.GNTBX_OutPath.PasswordChar = '\0';
            this.GNTBX_OutPath.PlaceholderText = "";
            this.GNTBX_OutPath.SelectedText = "";
            this.GNTBX_OutPath.SelectionStart = 9;
            this.GNTBX_OutPath.ShadowDecoration.Parent = this.GNTBX_OutPath;
            this.GNTBX_OutPath.Size = new System.Drawing.Size(398, 46);
            this.GNTBX_OutPath.TabIndex = 11;
            this.GNTBX_OutPath.TextChanged += new System.EventHandler(this.GNTBX_OutPath_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LBL_CompressionWarning);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.GNBTN_CompressionStart);
            this.tabPage2.Controls.Add(this.GNTBX_CompDataFolderTB);
            this.tabPage2.Controls.Add(this.GNBTN_SelectDataFolder);
            this.tabPage2.Controls.Add(this.GNTB_CompResultFileTb);
            this.tabPage2.Controls.Add(this.GNBTN_SelectTargetFile);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compress";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LBL_CompressionWarning
            // 
            this.LBL_CompressionWarning.AutoSize = true;
            this.LBL_CompressionWarning.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CompressionWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LBL_CompressionWarning.Location = new System.Drawing.Point(25, 153);
            this.LBL_CompressionWarning.Name = "LBL_CompressionWarning";
            this.LBL_CompressionWarning.Size = new System.Drawing.Size(556, 32);
            this.LBL_CompressionWarning.TabIndex = 23;
            this.LBL_CompressionWarning.Text = "Target data folder must contain a minimum of 4 .FUI files for texture pack,\r\nor +" +
    "20 for game modifying. Leave blank \"Target File\" TextBox to create a new ARC. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mojang", 9F);
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Data Folder";
            // 
            // GNTBX_CompDataFolderTB
            // 
            this.GNTBX_CompDataFolderTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTBX_CompDataFolderTB.DefaultText = "";
            this.GNTBX_CompDataFolderTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTBX_CompDataFolderTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTBX_CompDataFolderTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTBX_CompDataFolderTB.DisabledState.Parent = this.GNTBX_CompDataFolderTB;
            this.GNTBX_CompDataFolderTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTBX_CompDataFolderTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTBX_CompDataFolderTB.FocusedState.Parent = this.GNTBX_CompDataFolderTB;
            this.GNTBX_CompDataFolderTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTBX_CompDataFolderTB.HoverState.Parent = this.GNTBX_CompDataFolderTB;
            this.GNTBX_CompDataFolderTB.Location = new System.Drawing.Point(28, 37);
            this.GNTBX_CompDataFolderTB.Margin = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.GNTBX_CompDataFolderTB.Name = "GNTBX_CompDataFolderTB";
            this.GNTBX_CompDataFolderTB.PasswordChar = '\0';
            this.GNTBX_CompDataFolderTB.PlaceholderText = "";
            this.GNTBX_CompDataFolderTB.SelectedText = "";
            this.GNTBX_CompDataFolderTB.ShadowDecoration.Parent = this.GNTBX_CompDataFolderTB;
            this.GNTBX_CompDataFolderTB.Size = new System.Drawing.Size(398, 41);
            this.GNTBX_CompDataFolderTB.TabIndex = 19;
            // 
            // GNTB_CompResultFileTb
            // 
            this.GNTB_CompResultFileTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTB_CompResultFileTb.DefaultText = "";
            this.GNTB_CompResultFileTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTB_CompResultFileTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTB_CompResultFileTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTB_CompResultFileTb.DisabledState.Parent = this.GNTB_CompResultFileTb;
            this.GNTB_CompResultFileTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTB_CompResultFileTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTB_CompResultFileTb.FocusedState.Parent = this.GNTB_CompResultFileTb;
            this.GNTB_CompResultFileTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTB_CompResultFileTb.HoverState.Parent = this.GNTB_CompResultFileTb;
            this.GNTB_CompResultFileTb.Location = new System.Drawing.Point(28, 99);
            this.GNTB_CompResultFileTb.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.GNTB_CompResultFileTb.Name = "GNTB_CompResultFileTb";
            this.GNTB_CompResultFileTb.PasswordChar = '\0';
            this.GNTB_CompResultFileTb.PlaceholderText = "";
            this.GNTB_CompResultFileTb.SelectedText = "";
            this.GNTB_CompResultFileTb.ShadowDecoration.Parent = this.GNTB_CompResultFileTb;
            this.GNTB_CompResultFileTb.Size = new System.Drawing.Size(398, 41);
            this.GNTB_CompResultFileTb.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mojang", 9F);
            this.label4.Location = new System.Drawing.Point(25, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Target File";
            // 
            // gbtn_ForceDesc
            // 
            this.gbtn_ForceDesc.Animated = true;
            this.gbtn_ForceDesc.BackColor = System.Drawing.Color.Transparent;
            this.gbtn_ForceDesc.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbtn_ForceDesc.BorderRadius = 2;
            this.gbtn_ForceDesc.BorderThickness = 1;
            this.gbtn_ForceDesc.CheckedState.Parent = this.gbtn_ForceDesc;
            this.gbtn_ForceDesc.CustomImages.Parent = this.gbtn_ForceDesc;
            this.gbtn_ForceDesc.Enabled = false;
            this.gbtn_ForceDesc.FillColor = System.Drawing.Color.White;
            this.gbtn_ForceDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbtn_ForceDesc.ForeColor = System.Drawing.Color.Black;
            this.gbtn_ForceDesc.HoverState.Parent = this.gbtn_ForceDesc;
            this.gbtn_ForceDesc.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.arrow_collapse_down1;
            this.gbtn_ForceDesc.ImageSize = new System.Drawing.Size(28, 28);
            this.gbtn_ForceDesc.Location = new System.Drawing.Point(188, 221);
            this.gbtn_ForceDesc.Name = "gbtn_ForceDesc";
            this.gbtn_ForceDesc.PressedColor = System.Drawing.Color.DarkGray;
            this.gbtn_ForceDesc.ShadowDecoration.Parent = this.gbtn_ForceDesc;
            this.gbtn_ForceDesc.Size = new System.Drawing.Size(154, 37);
            this.gbtn_ForceDesc.TabIndex = 15;
            this.gbtn_ForceDesc.Text = "Force Decompress";
            this.gbtn_ForceDesc.UseTransparentBackground = true;
            this.gbtn_ForceDesc.Click += new System.EventHandler(this.gbtn_ForceDesc_Click);
            // 
            // GNBTN_DecompressStart
            // 
            this.GNBTN_DecompressStart.Animated = true;
            this.GNBTN_DecompressStart.BackColor = System.Drawing.Color.Transparent;
            this.GNBTN_DecompressStart.BorderColor = System.Drawing.Color.Gainsboro;
            this.GNBTN_DecompressStart.BorderRadius = 2;
            this.GNBTN_DecompressStart.BorderThickness = 1;
            this.GNBTN_DecompressStart.CheckedState.Parent = this.GNBTN_DecompressStart;
            this.GNBTN_DecompressStart.CustomImages.Parent = this.GNBTN_DecompressStart;
            this.GNBTN_DecompressStart.Enabled = false;
            this.GNBTN_DecompressStart.FillColor = System.Drawing.Color.White;
            this.GNBTN_DecompressStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBTN_DecompressStart.ForeColor = System.Drawing.Color.Black;
            this.GNBTN_DecompressStart.HoverState.Parent = this.GNBTN_DecompressStart;
            this.GNBTN_DecompressStart.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.arrow_collapse_down1;
            this.GNBTN_DecompressStart.ImageSize = new System.Drawing.Size(28, 28);
            this.GNBTN_DecompressStart.Location = new System.Drawing.Point(28, 221);
            this.GNBTN_DecompressStart.Name = "GNBTN_DecompressStart";
            this.GNBTN_DecompressStart.PressedColor = System.Drawing.Color.DarkGray;
            this.GNBTN_DecompressStart.ShadowDecoration.Parent = this.GNBTN_DecompressStart;
            this.GNBTN_DecompressStart.Size = new System.Drawing.Size(154, 37);
            this.GNBTN_DecompressStart.TabIndex = 13;
            this.GNBTN_DecompressStart.Text = "Decompress";
            this.GNBTN_DecompressStart.UseTransparentBackground = true;
            this.GNBTN_DecompressStart.Click += new System.EventHandler(this.GNBTN_DecompressStart_Click);
            // 
            // GNBTN_SelectOutDataFolder
            // 
            this.GNBTN_SelectOutDataFolder.Animated = true;
            this.GNBTN_SelectOutDataFolder.BackColor = System.Drawing.Color.Transparent;
            this.GNBTN_SelectOutDataFolder.BorderColor = System.Drawing.Color.Gainsboro;
            this.GNBTN_SelectOutDataFolder.BorderRadius = 2;
            this.GNBTN_SelectOutDataFolder.BorderThickness = 1;
            this.GNBTN_SelectOutDataFolder.CheckedState.Parent = this.GNBTN_SelectOutDataFolder;
            this.GNBTN_SelectOutDataFolder.CustomImages.Parent = this.GNBTN_SelectOutDataFolder;
            this.GNBTN_SelectOutDataFolder.FillColor = System.Drawing.Color.White;
            this.GNBTN_SelectOutDataFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBTN_SelectOutDataFolder.ForeColor = System.Drawing.Color.Black;
            this.GNBTN_SelectOutDataFolder.HoverState.Parent = this.GNBTN_SelectOutDataFolder;
            this.GNBTN_SelectOutDataFolder.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.folder_arrow_down;
            this.GNBTN_SelectOutDataFolder.ImageSize = new System.Drawing.Size(28, 28);
            this.GNBTN_SelectOutDataFolder.Location = new System.Drawing.Point(435, 102);
            this.GNBTN_SelectOutDataFolder.Name = "GNBTN_SelectOutDataFolder";
            this.GNBTN_SelectOutDataFolder.PressedColor = System.Drawing.Color.DarkGray;
            this.GNBTN_SelectOutDataFolder.ShadowDecoration.Parent = this.GNBTN_SelectOutDataFolder;
            this.GNBTN_SelectOutDataFolder.Size = new System.Drawing.Size(139, 46);
            this.GNBTN_SelectOutDataFolder.TabIndex = 12;
            this.GNBTN_SelectOutDataFolder.Text = "Select Output";
            this.GNBTN_SelectOutDataFolder.UseTransparentBackground = true;
            this.GNBTN_SelectOutDataFolder.Click += new System.EventHandler(this.GNBTN_SelectOutDataFolder_Click);
            // 
            // GNBTN_SelectFile
            // 
            this.GNBTN_SelectFile.Animated = true;
            this.GNBTN_SelectFile.BackColor = System.Drawing.Color.Transparent;
            this.GNBTN_SelectFile.BorderColor = System.Drawing.Color.Gainsboro;
            this.GNBTN_SelectFile.BorderRadius = 2;
            this.GNBTN_SelectFile.BorderThickness = 1;
            this.GNBTN_SelectFile.CheckedState.Parent = this.GNBTN_SelectFile;
            this.GNBTN_SelectFile.CustomImages.Parent = this.GNBTN_SelectFile;
            this.GNBTN_SelectFile.FillColor = System.Drawing.Color.White;
            this.GNBTN_SelectFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBTN_SelectFile.ForeColor = System.Drawing.Color.Black;
            this.GNBTN_SelectFile.HoverState.Parent = this.GNBTN_SelectFile;
            this.GNBTN_SelectFile.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.cube;
            this.GNBTN_SelectFile.ImageSize = new System.Drawing.Size(28, 28);
            this.GNBTN_SelectFile.Location = new System.Drawing.Point(435, 35);
            this.GNBTN_SelectFile.Name = "GNBTN_SelectFile";
            this.GNBTN_SelectFile.PressedColor = System.Drawing.Color.DarkGray;
            this.GNBTN_SelectFile.ShadowDecoration.Parent = this.GNBTN_SelectFile;
            this.GNBTN_SelectFile.Size = new System.Drawing.Size(139, 39);
            this.GNBTN_SelectFile.TabIndex = 10;
            this.GNBTN_SelectFile.Text = "Select File";
            this.GNBTN_SelectFile.UseTransparentBackground = true;
            this.GNBTN_SelectFile.Click += new System.EventHandler(this.GNBTN_SelectFile_Click);
            // 
            // GNBTN_CompressionStart
            // 
            this.GNBTN_CompressionStart.Animated = true;
            this.GNBTN_CompressionStart.BackColor = System.Drawing.Color.Transparent;
            this.GNBTN_CompressionStart.BorderColor = System.Drawing.Color.Gainsboro;
            this.GNBTN_CompressionStart.BorderRadius = 2;
            this.GNBTN_CompressionStart.BorderThickness = 1;
            this.GNBTN_CompressionStart.CheckedState.Parent = this.GNBTN_CompressionStart;
            this.GNBTN_CompressionStart.CustomImages.Parent = this.GNBTN_CompressionStart;
            this.GNBTN_CompressionStart.FillColor = System.Drawing.Color.White;
            this.GNBTN_CompressionStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBTN_CompressionStart.ForeColor = System.Drawing.Color.Black;
            this.GNBTN_CompressionStart.HoverState.Parent = this.GNBTN_CompressionStart;
            this.GNBTN_CompressionStart.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.arrow_collapse_down1;
            this.GNBTN_CompressionStart.ImageSize = new System.Drawing.Size(28, 28);
            this.GNBTN_CompressionStart.Location = new System.Drawing.Point(28, 221);
            this.GNBTN_CompressionStart.Name = "GNBTN_CompressionStart";
            this.GNBTN_CompressionStart.PressedColor = System.Drawing.Color.DarkGray;
            this.GNBTN_CompressionStart.ShadowDecoration.Parent = this.GNBTN_CompressionStart;
            this.GNBTN_CompressionStart.Size = new System.Drawing.Size(154, 37);
            this.GNBTN_CompressionStart.TabIndex = 21;
            this.GNBTN_CompressionStart.Text = "Compress";
            this.GNBTN_CompressionStart.UseTransparentBackground = true;
            this.GNBTN_CompressionStart.Click += new System.EventHandler(this.GNBTN_CompressionSt);
            // 
            // GNBTN_SelectDataFolder
            // 
            this.GNBTN_SelectDataFolder.Animated = true;
            this.GNBTN_SelectDataFolder.BackColor = System.Drawing.Color.Transparent;
            this.GNBTN_SelectDataFolder.BorderColor = System.Drawing.Color.Gainsboro;
            this.GNBTN_SelectDataFolder.BorderRadius = 2;
            this.GNBTN_SelectDataFolder.BorderThickness = 1;
            this.GNBTN_SelectDataFolder.CheckedState.Parent = this.GNBTN_SelectDataFolder;
            this.GNBTN_SelectDataFolder.CustomImages.Parent = this.GNBTN_SelectDataFolder;
            this.GNBTN_SelectDataFolder.FillColor = System.Drawing.Color.White;
            this.GNBTN_SelectDataFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBTN_SelectDataFolder.ForeColor = System.Drawing.Color.Black;
            this.GNBTN_SelectDataFolder.HoverState.Parent = this.GNBTN_SelectDataFolder;
            this.GNBTN_SelectDataFolder.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.folder_arrow_down;
            this.GNBTN_SelectDataFolder.ImageSize = new System.Drawing.Size(28, 28);
            this.GNBTN_SelectDataFolder.Location = new System.Drawing.Point(435, 37);
            this.GNBTN_SelectDataFolder.Name = "GNBTN_SelectDataFolder";
            this.GNBTN_SelectDataFolder.PressedColor = System.Drawing.Color.DarkGray;
            this.GNBTN_SelectDataFolder.ShadowDecoration.Parent = this.GNBTN_SelectDataFolder;
            this.GNBTN_SelectDataFolder.Size = new System.Drawing.Size(139, 41);
            this.GNBTN_SelectDataFolder.TabIndex = 20;
            this.GNBTN_SelectDataFolder.Text = "Select Data";
            this.GNBTN_SelectDataFolder.UseTransparentBackground = true;
            this.GNBTN_SelectDataFolder.Click += new System.EventHandler(this.GNBTN_SelectDataFolder_Click);
            // 
            // GNBTN_SelectTargetFile
            // 
            this.GNBTN_SelectTargetFile.Animated = true;
            this.GNBTN_SelectTargetFile.BackColor = System.Drawing.Color.Transparent;
            this.GNBTN_SelectTargetFile.BorderColor = System.Drawing.Color.Gainsboro;
            this.GNBTN_SelectTargetFile.BorderRadius = 2;
            this.GNBTN_SelectTargetFile.BorderThickness = 1;
            this.GNBTN_SelectTargetFile.CheckedState.Parent = this.GNBTN_SelectTargetFile;
            this.GNBTN_SelectTargetFile.CustomImages.Parent = this.GNBTN_SelectTargetFile;
            this.GNBTN_SelectTargetFile.FillColor = System.Drawing.Color.White;
            this.GNBTN_SelectTargetFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBTN_SelectTargetFile.ForeColor = System.Drawing.Color.Black;
            this.GNBTN_SelectTargetFile.HoverState.Parent = this.GNBTN_SelectTargetFile;
            this.GNBTN_SelectTargetFile.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.cube;
            this.GNBTN_SelectTargetFile.ImageSize = new System.Drawing.Size(28, 28);
            this.GNBTN_SelectTargetFile.Location = new System.Drawing.Point(435, 99);
            this.GNBTN_SelectTargetFile.Name = "GNBTN_SelectTargetFile";
            this.GNBTN_SelectTargetFile.PressedColor = System.Drawing.Color.DarkGray;
            this.GNBTN_SelectTargetFile.ShadowDecoration.Parent = this.GNBTN_SelectTargetFile;
            this.GNBTN_SelectTargetFile.Size = new System.Drawing.Size(139, 41);
            this.GNBTN_SelectTargetFile.TabIndex = 18;
            this.GNBTN_SelectTargetFile.Text = "Select File";
            this.GNBTN_SelectTargetFile.UseTransparentBackground = true;
            this.GNBTN_SelectTargetFile.Click += new System.EventHandler(this.GNBTN_SelectTargetFile_Click);
            // 
            // ResourceInputOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 309);
            this.Controls.Add(this.TABC_RIOF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResourceInputOutputForm";
            this.Text = "ARC I/O Builder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResourceInputOutputForm_FormClosed);
            this.Load += new System.EventHandler(this.ResourceInputOutputForm_Load);
            this.TABC_RIOF.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox GTBX_descompressionFilePath;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button GNBTN_SelectFile;
        private System.Windows.Forms.TabControl TABC_RIOF;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2TextBox GNTBX_OutPath;
        private Guna.UI2.WinForms.Guna2Button GNBTN_SelectOutDataFolder;
        private Guna.UI2.WinForms.Guna2Button GNBTN_DecompressStart;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button gbtn_ForceDesc;
        private System.Windows.Forms.Label LBL_CompressionWarning;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button GNBTN_CompressionStart;
        private Guna.UI2.WinForms.Guna2TextBox GNTBX_CompDataFolderTB;
        private Guna.UI2.WinForms.Guna2Button GNBTN_SelectDataFolder;
        private Guna.UI2.WinForms.Guna2TextBox GNTB_CompResultFileTb;
        private Guna.UI2.WinForms.Guna2Button GNBTN_SelectTargetFile;
        private System.Windows.Forms.Label label4;
    }
}