namespace Minecraft_LCE_Tweaker_Studio.Expoint.ITC
{
    partial class SpriteConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpriteConverterForm));
            this.LB_Files = new System.Windows.Forms.ListBox();
            this.LBX_NeededFiles = new System.Windows.Forms.ListBox();
            this.TB_TextureFolderPath = new System.Windows.Forms.TextBox();
            this.BTN_SelectTexFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tbx_OutFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_SelectOutPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BTN_buildSprite = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.lbx_totalTerrainFiles = new System.Windows.Forms.ListBox();
            this.lbx_TerrainNeededFiles = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_TerrainFolderUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_tbtf_fsd = new System.Windows.Forms.Button();
            this.btn_odf_sfd = new System.Windows.Forms.Button();
            this.tbx_TerrainOutputFn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pbx_result = new System.Windows.Forms.PictureBox();
            this.btn_buildTerrain = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_result)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_Files
            // 
            this.LB_Files.FormattingEnabled = true;
            this.LB_Files.Location = new System.Drawing.Point(287, 121);
            this.LB_Files.Name = "LB_Files";
            this.LB_Files.Size = new System.Drawing.Size(306, 368);
            this.LB_Files.TabIndex = 0;
            // 
            // LBX_NeededFiles
            // 
            this.LBX_NeededFiles.FormattingEnabled = true;
            this.LBX_NeededFiles.Location = new System.Drawing.Point(599, 121);
            this.LBX_NeededFiles.Name = "LBX_NeededFiles";
            this.LBX_NeededFiles.Size = new System.Drawing.Size(176, 368);
            this.LBX_NeededFiles.TabIndex = 1;
            // 
            // TB_TextureFolderPath
            // 
            this.TB_TextureFolderPath.Location = new System.Drawing.Point(288, 39);
            this.TB_TextureFolderPath.Name = "TB_TextureFolderPath";
            this.TB_TextureFolderPath.Size = new System.Drawing.Size(406, 20);
            this.TB_TextureFolderPath.TabIndex = 2;
            this.TB_TextureFolderPath.TextChanged += new System.EventHandler(this.TB_TextureFolderPath_TextChanged);
            // 
            // BTN_SelectTexFolder
            // 
            this.BTN_SelectTexFolder.Location = new System.Drawing.Point(700, 38);
            this.BTN_SelectTexFolder.Name = "BTN_SelectTexFolder";
            this.BTN_SelectTexFolder.Size = new System.Drawing.Size(75, 23);
            this.BTN_SelectTexFolder.TabIndex = 3;
            this.BTN_SelectTexFolder.Text = "...";
            this.BTN_SelectTexFolder.UseVisualStyleBackColor = true;
            this.BTN_SelectTexFolder.Click += new System.EventHandler(this.BTN_SelectTexFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Items Textures Folder";
            // 
            // Tbx_OutFolder
            // 
            this.Tbx_OutFolder.Location = new System.Drawing.Point(287, 80);
            this.Tbx_OutFolder.Name = "Tbx_OutFolder";
            this.Tbx_OutFolder.Size = new System.Drawing.Size(406, 20);
            this.Tbx_OutFolder.TabIndex = 5;
            this.Tbx_OutFolder.TextChanged += new System.EventHandler(this.Tbx_OutFolder_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output Destination";
            // 
            // BTN_SelectOutPath
            // 
            this.BTN_SelectOutPath.Location = new System.Drawing.Point(700, 78);
            this.BTN_SelectOutPath.Name = "BTN_SelectOutPath";
            this.BTN_SelectOutPath.Size = new System.Drawing.Size(75, 23);
            this.BTN_SelectOutPath.TabIndex = 7;
            this.BTN_SelectOutPath.Text = "...";
            this.BTN_SelectOutPath.UseVisualStyleBackColor = true;
            this.BTN_SelectOutPath.Click += new System.EventHandler(this.BTN_SelectOutPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Needed Files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Files";
            // 
            // BTN_buildSprite
            // 
            this.BTN_buildSprite.Location = new System.Drawing.Point(287, 501);
            this.BTN_buildSprite.Name = "BTN_buildSprite";
            this.BTN_buildSprite.Size = new System.Drawing.Size(488, 23);
            this.BTN_buildSprite.TabIndex = 10;
            this.BTN_buildSprite.Text = "Build Items.png";
            this.BTN_buildSprite.UseVisualStyleBackColor = true;
            this.BTN_buildSprite.Click += new System.EventHandler(this.BTN_buildSprite_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "label6";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(822, 599);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.LB_Files);
            this.tabPage1.Controls.Add(this.BTN_buildSprite);
            this.tabPage1.Controls.Add(this.LBX_NeededFiles);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TB_TextureFolderPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.BTN_SelectTexFolder);
            this.tabPage1.Controls.Add(this.BTN_SelectOutPath);
            this.tabPage1.Controls.Add(this.Tbx_OutFolder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(814, 573);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Items";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.originalItems;
            this.pictureBox2.Location = new System.Drawing.Point(14, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 544);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btn_buildTerrain);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lbx_totalTerrainFiles);
            this.tabPage2.Controls.Add(this.lbx_TerrainNeededFiles);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbx_TerrainFolderUrl);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btn_tbtf_fsd);
            this.tabPage2.Controls.Add(this.btn_odf_sfd);
            this.tabPage2.Controls.Add(this.tbx_TerrainOutputFn);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.pbx_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 573);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Terrain";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Terrain Block Textures Folder";
            // 
            // lbx_totalTerrainFiles
            // 
            this.lbx_totalTerrainFiles.FormattingEnabled = true;
            this.lbx_totalTerrainFiles.Location = new System.Drawing.Point(287, 123);
            this.lbx_totalTerrainFiles.Name = "lbx_totalTerrainFiles";
            this.lbx_totalTerrainFiles.Size = new System.Drawing.Size(306, 368);
            this.lbx_totalTerrainFiles.TabIndex = 10;
            // 
            // lbx_TerrainNeededFiles
            // 
            this.lbx_TerrainNeededFiles.FormattingEnabled = true;
            this.lbx_TerrainNeededFiles.Location = new System.Drawing.Point(599, 123);
            this.lbx_TerrainNeededFiles.Name = "lbx_TerrainNeededFiles";
            this.lbx_TerrainNeededFiles.Size = new System.Drawing.Size(176, 368);
            this.lbx_TerrainNeededFiles.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Total Files";
            // 
            // tbx_TerrainFolderUrl
            // 
            this.tbx_TerrainFolderUrl.Location = new System.Drawing.Point(288, 41);
            this.tbx_TerrainFolderUrl.Name = "tbx_TerrainFolderUrl";
            this.tbx_TerrainFolderUrl.Size = new System.Drawing.Size(406, 20);
            this.tbx_TerrainFolderUrl.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(600, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Needed Files";
            // 
            // btn_tbtf_fsd
            // 
            this.btn_tbtf_fsd.Location = new System.Drawing.Point(700, 40);
            this.btn_tbtf_fsd.Name = "btn_tbtf_fsd";
            this.btn_tbtf_fsd.Size = new System.Drawing.Size(75, 23);
            this.btn_tbtf_fsd.TabIndex = 13;
            this.btn_tbtf_fsd.Text = "...";
            this.btn_tbtf_fsd.UseVisualStyleBackColor = true;
            this.btn_tbtf_fsd.Click += new System.EventHandler(this.btn_tbtf_fsd_Click);
            // 
            // btn_odf_sfd
            // 
            this.btn_odf_sfd.Location = new System.Drawing.Point(700, 80);
            this.btn_odf_sfd.Name = "btn_odf_sfd";
            this.btn_odf_sfd.Size = new System.Drawing.Size(75, 23);
            this.btn_odf_sfd.TabIndex = 17;
            this.btn_odf_sfd.Text = "...";
            this.btn_odf_sfd.UseVisualStyleBackColor = true;
            this.btn_odf_sfd.Click += new System.EventHandler(this.btn_odf_sfd_Click);
            // 
            // tbx_TerrainOutputFn
            // 
            this.tbx_TerrainOutputFn.Location = new System.Drawing.Point(287, 82);
            this.tbx_TerrainOutputFn.Name = "tbx_TerrainOutputFn";
            this.tbx_TerrainOutputFn.Size = new System.Drawing.Size(406, 20);
            this.tbx_TerrainOutputFn.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Output Destination Filename";
            // 
            // pbx_result
            // 
            this.pbx_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_result.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.terrain;
            this.pbx_result.Location = new System.Drawing.Point(16, 23);
            this.pbx_result.Name = "pbx_result";
            this.pbx_result.Size = new System.Drawing.Size(256, 544);
            this.pbx_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_result.TabIndex = 0;
            this.pbx_result.TabStop = false;
            // 
            // btn_buildTerrain
            // 
            this.btn_buildTerrain.Location = new System.Drawing.Point(287, 497);
            this.btn_buildTerrain.Name = "btn_buildTerrain";
            this.btn_buildTerrain.Size = new System.Drawing.Size(488, 23);
            this.btn_buildTerrain.TabIndex = 20;
            this.btn_buildTerrain.Text = "Build Terrain.png";
            this.btn_buildTerrain.UseVisualStyleBackColor = true;
            this.btn_buildTerrain.Click += new System.EventHandler(this.btn_buildTerrain_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(488, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Preview Terrain.png";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SpriteConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 628);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpriteConverterForm";
            this.Text = "SpriteConverterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpriteConverterForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Files;
        private System.Windows.Forms.ListBox LBX_NeededFiles;
        private System.Windows.Forms.TextBox TB_TextureFolderPath;
        private System.Windows.Forms.Button BTN_SelectTexFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tbx_OutFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_SelectOutPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTN_buildSprite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbx_totalTerrainFiles;
        private System.Windows.Forms.ListBox lbx_TerrainNeededFiles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_TerrainFolderUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_tbtf_fsd;
        private System.Windows.Forms.Button btn_odf_sfd;
        private System.Windows.Forms.TextBox tbx_TerrainOutputFn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbx_result;
        private System.Windows.Forms.Button btn_buildTerrain;
        private System.Windows.Forms.Button button1;
    }
}