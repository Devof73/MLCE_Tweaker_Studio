namespace DevNotepad
{
    partial class MainEditor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RTB_main_Workspace = new System.Windows.Forms.RichTextBox();
            this.STRP_StateArea = new System.Windows.Forms.StatusStrip();
            this.TSSL_RTBWS_SelIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSL_RTBWS_SelLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSL_FileNeedsToBeSaved = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSL_FilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSTR_Controls = new System.Windows.Forms.ToolStrip();
            this.TSDDBTN_FileOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSMI_OpenBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.TSI_NewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TSI_SaveFileBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.TSI_SaveAsBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDDBTN_Tools = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSTMI_CodeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSTMI_CTM_Mode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSTMI_ColorDetWords = new System.Windows.Forms.ToolStripMenuItem();
            this.TSRBTN_FClose = new System.Windows.Forms.ToolStripButton();
            this.TSBTN_ROTF = new System.Windows.Forms.ToolStripButton();
            this.TSBTN_txtzoom_more = new System.Windows.Forms.ToolStripButton();
            this.TSBTN_TestBnt = new System.Windows.Forms.ToolStripButton();
            this.TSBTN_txtzoom_minus = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Timer_TickEvents = new System.Windows.Forms.Timer(this.components);
            this.STRP_StateArea.SuspendLayout();
            this.TSTR_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTB_main_Workspace
            // 
            this.RTB_main_Workspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_main_Workspace.BackColor = System.Drawing.Color.Black;
            this.RTB_main_Workspace.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB_main_Workspace.ForeColor = System.Drawing.Color.White;
            this.RTB_main_Workspace.Location = new System.Drawing.Point(0, 26);
            this.RTB_main_Workspace.Name = "RTB_main_Workspace";
            this.RTB_main_Workspace.Size = new System.Drawing.Size(830, 459);
            this.RTB_main_Workspace.TabIndex = 0;
            this.RTB_main_Workspace.Text = "";
            this.RTB_main_Workspace.SelectionChanged += new System.EventHandler(this.RTB_main_Workspace_SelectionChanged);
            this.RTB_main_Workspace.Click += new System.EventHandler(this.RTB_main_Workspace_Click);
            this.RTB_main_Workspace.FontChanged += new System.EventHandler(this.RTB_main_Workspace_FontChanged);
            this.RTB_main_Workspace.TextChanged += new System.EventHandler(this.RTB_main_Workspace_TextChanged);
            this.RTB_main_Workspace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RTB_main_Workspace_KeyPress);
            // 
            // STRP_StateArea
            // 
            this.STRP_StateArea.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.STRP_StateArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_RTBWS_SelIndex,
            this.TSSL_RTBWS_SelLength,
            this.TSSL_FileNeedsToBeSaved,
            this.TSSL_FilePath});
            this.STRP_StateArea.Location = new System.Drawing.Point(0, 487);
            this.STRP_StateArea.Name = "STRP_StateArea";
            this.STRP_StateArea.Size = new System.Drawing.Size(830, 22);
            this.STRP_StateArea.TabIndex = 1;
            this.STRP_StateArea.Text = "statusStrip1";
            // 
            // TSSL_RTBWS_SelIndex
            // 
            this.TSSL_RTBWS_SelIndex.BackColor = System.Drawing.Color.White;
            this.TSSL_RTBWS_SelIndex.Font = new System.Drawing.Font("Consolas", 8.999999F, System.Drawing.FontStyle.Bold);
            this.TSSL_RTBWS_SelIndex.ForeColor = System.Drawing.Color.Black;
            this.TSSL_RTBWS_SelIndex.Name = "TSSL_RTBWS_SelIndex";
            this.TSSL_RTBWS_SelIndex.Size = new System.Drawing.Size(147, 17);
            this.TSSL_RTBWS_SelIndex.Text = "Selection Index: [-]";
            // 
            // TSSL_RTBWS_SelLength
            // 
            this.TSSL_RTBWS_SelLength.BackColor = System.Drawing.Color.White;
            this.TSSL_RTBWS_SelLength.Font = new System.Drawing.Font("Consolas", 8.999999F, System.Drawing.FontStyle.Bold);
            this.TSSL_RTBWS_SelLength.ForeColor = System.Drawing.Color.Black;
            this.TSSL_RTBWS_SelLength.Name = "TSSL_RTBWS_SelLength";
            this.TSSL_RTBWS_SelLength.Size = new System.Drawing.Size(154, 17);
            this.TSSL_RTBWS_SelLength.Text = "Selection Length: [-]";
            // 
            // TSSL_FileNeedsToBeSaved
            // 
            this.TSSL_FileNeedsToBeSaved.BackColor = System.Drawing.Color.White;
            this.TSSL_FileNeedsToBeSaved.Font = new System.Drawing.Font("Consolas", 8.999999F, System.Drawing.FontStyle.Bold);
            this.TSSL_FileNeedsToBeSaved.ForeColor = System.Drawing.Color.Black;
            this.TSSL_FileNeedsToBeSaved.Name = "TSSL_FileNeedsToBeSaved";
            this.TSSL_FileNeedsToBeSaved.Size = new System.Drawing.Size(70, 17);
            this.TSSL_FileNeedsToBeSaved.Text = "Not Saved";
            // 
            // TSSL_FilePath
            // 
            this.TSSL_FilePath.BackColor = System.Drawing.Color.White;
            this.TSSL_FilePath.Font = new System.Drawing.Font("Consolas", 8.999999F, System.Drawing.FontStyle.Bold);
            this.TSSL_FilePath.Name = "TSSL_FilePath";
            this.TSSL_FilePath.Size = new System.Drawing.Size(119, 17);
            this.TSSL_FilePath.Text = "No File Selected";
            // 
            // TSTR_Controls
            // 
            this.TSTR_Controls.AllowMerge = false;
            this.TSTR_Controls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TSTR_Controls.Font = new System.Drawing.Font("Consolas", 8.999999F, System.Drawing.FontStyle.Bold);
            this.TSTR_Controls.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TSTR_Controls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDDBTN_FileOptions,
            this.TSDDBTN_Tools,
            this.TSRBTN_FClose,
            this.TSBTN_ROTF,
            this.TSBTN_txtzoom_more,
            this.TSBTN_TestBnt,
            this.TSBTN_txtzoom_minus,
            this.toolStripButton1});
            this.TSTR_Controls.Location = new System.Drawing.Point(0, 0);
            this.TSTR_Controls.Name = "TSTR_Controls";
            this.TSTR_Controls.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TSTR_Controls.Size = new System.Drawing.Size(830, 25);
            this.TSTR_Controls.TabIndex = 2;
            this.TSTR_Controls.Text = "ts_Controls";
            // 
            // TSDDBTN_FileOptions
            // 
            this.TSDDBTN_FileOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_OpenBTN,
            this.TSI_NewFile,
            this.TSI_SaveFileBTN,
            this.TSI_SaveAsBTN});
            this.TSDDBTN_FileOptions.ForeColor = System.Drawing.Color.Black;
            this.TSDDBTN_FileOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDDBTN_FileOptions.Name = "TSDDBTN_FileOptions";
            this.TSDDBTN_FileOptions.Size = new System.Drawing.Size(48, 22);
            this.TSDDBTN_FileOptions.Text = "File";
            // 
            // TSMI_OpenBTN
            // 
            this.TSMI_OpenBTN.Name = "TSMI_OpenBTN";
            this.TSMI_OpenBTN.Size = new System.Drawing.Size(144, 22);
            this.TSMI_OpenBTN.Text = "Open...";
            this.TSMI_OpenBTN.Click += new System.EventHandler(this.TSMI_OpenBTN_Click);
            // 
            // TSI_NewFile
            // 
            this.TSI_NewFile.Name = "TSI_NewFile";
            this.TSI_NewFile.Size = new System.Drawing.Size(144, 22);
            this.TSI_NewFile.Text = "New...";
            // 
            // TSI_SaveFileBTN
            // 
            this.TSI_SaveFileBTN.Name = "TSI_SaveFileBTN";
            this.TSI_SaveFileBTN.Size = new System.Drawing.Size(144, 22);
            this.TSI_SaveFileBTN.Text = "Save";
            // 
            // TSI_SaveAsBTN
            // 
            this.TSI_SaveAsBTN.Name = "TSI_SaveAsBTN";
            this.TSI_SaveAsBTN.Size = new System.Drawing.Size(144, 22);
            this.TSI_SaveAsBTN.Text = "Save As...";
            // 
            // TSDDBTN_Tools
            // 
            this.TSDDBTN_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSTMI_CodeMode,
            this.TSTMI_CTM_Mode,
            this.TSTMI_ColorDetWords});
            this.TSDDBTN_Tools.ForeColor = System.Drawing.Color.Black;
            this.TSDDBTN_Tools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDDBTN_Tools.Name = "TSDDBTN_Tools";
            this.TSDDBTN_Tools.Size = new System.Drawing.Size(55, 22);
            this.TSDDBTN_Tools.Text = "Tools";
            // 
            // TSTMI_CodeMode
            // 
            this.TSTMI_CodeMode.Name = "TSTMI_CodeMode";
            this.TSTMI_CodeMode.Size = new System.Drawing.Size(214, 22);
            this.TSTMI_CodeMode.Text = "Code Mode (2)";
            this.TSTMI_CodeMode.Click += new System.EventHandler(this.TSTMI_CodeMode_Click);
            // 
            // TSTMI_CTM_Mode
            // 
            this.TSTMI_CTM_Mode.Name = "TSTMI_CTM_Mode";
            this.TSTMI_CTM_Mode.Size = new System.Drawing.Size(214, 22);
            this.TSTMI_CTM_Mode.Text = "Common Text Mode (0)";
            this.TSTMI_CTM_Mode.Click += new System.EventHandler(this.TSTMI_CTM_Mode_Click);
            // 
            // TSTMI_ColorDetWords
            // 
            this.TSTMI_ColorDetWords.Name = "TSTMI_ColorDetWords";
            this.TSTMI_ColorDetWords.Size = new System.Drawing.Size(214, 22);
            this.TSTMI_ColorDetWords.Text = "Words Color (1)";
            this.TSTMI_ColorDetWords.Click += new System.EventHandler(this.TSTMI_ColorDetWords_Click);
            // 
            // TSRBTN_FClose
            // 
            this.TSRBTN_FClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSRBTN_FClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSRBTN_FClose.Name = "TSRBTN_FClose";
            this.TSRBTN_FClose.Size = new System.Drawing.Size(88, 22);
            this.TSRBTN_FClose.Text = "Force Close";
            this.TSRBTN_FClose.Click += new System.EventHandler(this.TSRBTN_FClose_Click);
            // 
            // TSBTN_ROTF
            // 
            this.TSBTN_ROTF.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSBTN_ROTF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBTN_ROTF.Name = "TSBTN_ROTF";
            this.TSBTN_ROTF.Size = new System.Drawing.Size(179, 22);
            this.TSBTN_ROTF.Text = "Reset Original Text File";
            this.TSBTN_ROTF.Click += new System.EventHandler(this.TSBTN_ROTF_Click);
            // 
            // TSBTN_txtzoom_more
            // 
            this.TSBTN_txtzoom_more.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSBTN_txtzoom_more.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSBTN_txtzoom_more.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBTN_txtzoom_more.Name = "TSBTN_txtzoom_more";
            this.TSBTN_txtzoom_more.Size = new System.Drawing.Size(53, 22);
            this.TSBTN_txtzoom_more.Text = "Zoom +";
            this.TSBTN_txtzoom_more.Click += new System.EventHandler(this.TSBTN_txtzoom_more_Click);
            // 
            // TSBTN_TestBnt
            // 
            this.TSBTN_TestBnt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSBTN_TestBnt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSBTN_TestBnt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBTN_TestBnt.Name = "TSBTN_TestBnt";
            this.TSBTN_TestBnt.Size = new System.Drawing.Size(81, 22);
            this.TSBTN_TestBnt.Text = "TestButton";
            this.TSBTN_TestBnt.Visible = false;
            this.TSBTN_TestBnt.Click += new System.EventHandler(this.TSBTN_TestBnt_Click);
            // 
            // TSBTN_txtzoom_minus
            // 
            this.TSBTN_txtzoom_minus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSBTN_txtzoom_minus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSBTN_txtzoom_minus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBTN_txtzoom_minus.Name = "TSBTN_txtzoom_minus";
            this.TSBTN_txtzoom_minus.Size = new System.Drawing.Size(53, 22);
            this.TSBTN_txtzoom_minus.Text = "Zoom -";
            this.TSBTN_txtzoom_minus.Click += new System.EventHandler(this.TSBTN_txtzoom_minus_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(109, 22);
            this.toolStripButton1.Text = "Change Font...";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Timer_TickEvents
            // 
            this.Timer_TickEvents.Interval = 1000;
            this.Timer_TickEvents.Tick += new System.EventHandler(this.Timer_TickEvents_Tick);
            // 
            // MainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.STRP_StateArea);
            this.Controls.Add(this.RTB_main_Workspace);
            this.Controls.Add(this.TSTR_Controls);
            this.Name = "MainEditor";
            this.Text = "Dev Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
            this.STRP_StateArea.ResumeLayout(false);
            this.STRP_StateArea.PerformLayout();
            this.TSTR_Controls.ResumeLayout(false);
            this.TSTR_Controls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_main_Workspace;
        private System.Windows.Forms.StatusStrip STRP_StateArea;
        private System.Windows.Forms.ToolStrip TSTR_Controls;
        private System.Windows.Forms.ToolStripDropDownButton TSDDBTN_FileOptions;
        private System.Windows.Forms.ToolStripMenuItem TSMI_OpenBTN;
        private System.Windows.Forms.ToolStripMenuItem TSI_NewFile;
        private System.Windows.Forms.ToolStripMenuItem TSI_SaveFileBTN;
        private System.Windows.Forms.ToolStripMenuItem TSI_SaveAsBTN;
        private System.Windows.Forms.ToolStripButton TSRBTN_FClose;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_FileNeedsToBeSaved;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_FilePath;
        private System.Windows.Forms.Timer Timer_TickEvents;
        private System.Windows.Forms.ToolStripButton TSBTN_ROTF;
        private System.Windows.Forms.ToolStripDropDownButton TSDDBTN_Tools;
        private System.Windows.Forms.ToolStripMenuItem TSTMI_CodeMode;
        private System.Windows.Forms.ToolStripMenuItem TSTMI_CTM_Mode;
        private System.Windows.Forms.ToolStripMenuItem TSTMI_ColorDetWords;
        private System.Windows.Forms.ToolStripButton TSBTN_txtzoom_more;
        private System.Windows.Forms.ToolStripButton TSBTN_txtzoom_minus;
        private System.Windows.Forms.ToolStripButton TSBTN_TestBnt;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_RTBWS_SelIndex;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_RTBWS_SelLength;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

