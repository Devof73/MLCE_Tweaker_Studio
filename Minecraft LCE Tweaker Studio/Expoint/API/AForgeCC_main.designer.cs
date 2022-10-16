namespace AForge_CC_Frame_Viewer
{
    partial class AForgeCC_main
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
            this.CBX_CCList = new System.Windows.Forms.ComboBox();
            this.PNL_CC = new System.Windows.Forms.Panel();
            this.CBX1_RES = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PNL_CC_Controls = new System.Windows.Forms.Panel();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.NUPD_FPS = new System.Windows.Forms.NumericUpDown();
            this.btn_srec = new System.Windows.Forms.Button();
            this.btn4_rec = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BTN_CaptureCC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PB_cc_view = new System.Windows.Forms.PictureBox();
            this.LB_FS_Indicator1 = new System.Windows.Forms.Label();
            this.LBL_ccviewindicator2 = new System.Windows.Forms.Label();
            this.PNL_CC.SuspendLayout();
            this.PNL_CC_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPD_FPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_cc_view)).BeginInit();
            this.SuspendLayout();
            // 
            // CBX_CCList
            // 
            this.CBX_CCList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_CCList.FormattingEnabled = true;
            this.CBX_CCList.Location = new System.Drawing.Point(68, 14);
            this.CBX_CCList.Name = "CBX_CCList";
            this.CBX_CCList.Size = new System.Drawing.Size(128, 21);
            this.CBX_CCList.TabIndex = 0;
            this.CBX_CCList.SelectedIndexChanged += new System.EventHandler(this.CBX_CCList_SelectedIndexChanged);
            // 
            // PNL_CC
            // 
            this.PNL_CC.BackColor = System.Drawing.SystemColors.Control;
            this.PNL_CC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNL_CC.Controls.Add(this.CBX1_RES);
            this.PNL_CC.Controls.Add(this.button1);
            this.PNL_CC.Controls.Add(this.PNL_CC_Controls);
            this.PNL_CC.Controls.Add(this.BTN_CaptureCC);
            this.PNL_CC.Controls.Add(this.label1);
            this.PNL_CC.Controls.Add(this.CBX_CCList);
            this.PNL_CC.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_CC.Location = new System.Drawing.Point(0, 0);
            this.PNL_CC.Name = "PNL_CC";
            this.PNL_CC.Size = new System.Drawing.Size(800, 78);
            this.PNL_CC.TabIndex = 1;
            // 
            // CBX1_RES
            // 
            this.CBX1_RES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX1_RES.FormattingEnabled = true;
            this.CBX1_RES.Location = new System.Drawing.Point(202, 14);
            this.CBX1_RES.Name = "CBX1_RES";
            this.CBX1_RES.Size = new System.Drawing.Size(117, 21);
            this.CBX1_RES.TabIndex = 6;
            this.CBX1_RES.SelectedIndexChanged += new System.EventHandler(this.CBX1_RES_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(202, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "STOP CC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PNL_CC_Controls
            // 
            this.PNL_CC_Controls.BackColor = System.Drawing.Color.White;
            this.PNL_CC_Controls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNL_CC_Controls.Controls.Add(this.lbl_1);
            this.PNL_CC_Controls.Controls.Add(this.NUPD_FPS);
            this.PNL_CC_Controls.Controls.Add(this.btn_srec);
            this.PNL_CC_Controls.Controls.Add(this.btn4_rec);
            this.PNL_CC_Controls.Controls.Add(this.button5);
            this.PNL_CC_Controls.Controls.Add(this.button3);
            this.PNL_CC_Controls.Controls.Add(this.button2);
            this.PNL_CC_Controls.Location = new System.Drawing.Point(428, 3);
            this.PNL_CC_Controls.Name = "PNL_CC_Controls";
            this.PNL_CC_Controls.Size = new System.Drawing.Size(367, 70);
            this.PNL_CC_Controls.TabIndex = 5;
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(239, 9);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(52, 13);
            this.lbl_1.TabIndex = 6;
            this.lbl_1.Text = "REC FPS";
            // 
            // NUPD_FPS
            // 
            this.NUPD_FPS.Location = new System.Drawing.Point(297, 5);
            this.NUPD_FPS.Maximum = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.NUPD_FPS.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUPD_FPS.Name = "NUPD_FPS";
            this.NUPD_FPS.Size = new System.Drawing.Size(51, 20);
            this.NUPD_FPS.TabIndex = 7;
            this.NUPD_FPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUPD_FPS.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this.NUPD_FPS.ValueChanged += new System.EventHandler(this.NUPD_FPS_ValueChanged);
            // 
            // btn_srec
            // 
            this.btn_srec.Enabled = false;
            this.btn_srec.Location = new System.Drawing.Point(123, 24);
            this.btn_srec.Name = "btn_srec";
            this.btn_srec.Size = new System.Drawing.Size(115, 22);
            this.btn_srec.TabIndex = 6;
            this.btn_srec.Text = "Stop Recording";
            this.btn_srec.UseVisualStyleBackColor = true;
            this.btn_srec.Click += new System.EventHandler(this.btn_srec_Click);
            // 
            // btn4_rec
            // 
            this.btn4_rec.Location = new System.Drawing.Point(123, 2);
            this.btn4_rec.Name = "btn4_rec";
            this.btn4_rec.Size = new System.Drawing.Size(115, 22);
            this.btn4_rec.TabIndex = 5;
            this.btn4_rec.Text = "Record";
            this.btn4_rec.UseVisualStyleBackColor = true;
            this.btn4_rec.Click += new System.EventHandler(this.btn4_rec_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 37);
            this.button5.TabIndex = 3;
            this.button5.Text = "FULL WINDOW";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(123, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 22);
            this.button3.TabIndex = 1;
            this.button3.Text = "SAVE FRAME";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "FULLSCREEN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTN_CaptureCC
            // 
            this.BTN_CaptureCC.Location = new System.Drawing.Point(68, 41);
            this.BTN_CaptureCC.Name = "BTN_CaptureCC";
            this.BTN_CaptureCC.Size = new System.Drawing.Size(128, 30);
            this.BTN_CaptureCC.TabIndex = 2;
            this.BTN_CaptureCC.Text = "CAPTURE";
            this.BTN_CaptureCC.UseVisualStyleBackColor = true;
            this.BTN_CaptureCC.Click += new System.EventHandler(this.BTN_CaptureCC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Devices:";
            // 
            // PB_cc_view
            // 
            this.PB_cc_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_cc_view.BackColor = System.Drawing.Color.Black;
            this.PB_cc_view.Location = new System.Drawing.Point(0, 80);
            this.PB_cc_view.Name = "PB_cc_view";
            this.PB_cc_view.Size = new System.Drawing.Size(800, 456);
            this.PB_cc_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_cc_view.TabIndex = 2;
            this.PB_cc_view.TabStop = false;
            this.PB_cc_view.Click += new System.EventHandler(this.PB_cc_view_Click);
            this.PB_cc_view.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PB_cc_view_MouseDoubleClick);
            this.PB_cc_view.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PB_cc_view_PreviewKeyDown);
            // 
            // LB_FS_Indicator1
            // 
            this.LB_FS_Indicator1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LB_FS_Indicator1.AutoSize = true;
            this.LB_FS_Indicator1.BackColor = System.Drawing.Color.Transparent;
            this.LB_FS_Indicator1.ForeColor = System.Drawing.Color.Black;
            this.LB_FS_Indicator1.Location = new System.Drawing.Point(19, 101);
            this.LB_FS_Indicator1.Name = "LB_FS_Indicator1";
            this.LB_FS_Indicator1.Size = new System.Drawing.Size(148, 13);
            this.LB_FS_Indicator1.TabIndex = 6;
            this.LB_FS_Indicator1.Text = "[LMB / RMB] TOOGLE VIEW";
            this.LB_FS_Indicator1.Visible = false;
            // 
            // LBL_ccviewindicator2
            // 
            this.LBL_ccviewindicator2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LBL_ccviewindicator2.AutoSize = true;
            this.LBL_ccviewindicator2.BackColor = System.Drawing.Color.Transparent;
            this.LBL_ccviewindicator2.ForeColor = System.Drawing.Color.Black;
            this.LBL_ccviewindicator2.Location = new System.Drawing.Point(19, 119);
            this.LBL_ccviewindicator2.Name = "LBL_ccviewindicator2";
            this.LBL_ccviewindicator2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.LBL_ccviewindicator2.Size = new System.Drawing.Size(83, 15);
            this.LBL_ccviewindicator2.TabIndex = 7;
            this.LBL_ccviewindicator2.Text = "[ESC] RETURN";
            this.LBL_ccviewindicator2.Visible = false;
            // 
            // AForgeCC_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.LB_FS_Indicator1);
            this.Controls.Add(this.PNL_CC);
            this.Controls.Add(this.LBL_ccviewindicator2);
            this.Controls.Add(this.PB_cc_view);
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(816, 575);
            this.Name = "AForgeCC_main";
            this.Text = "AForge CC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.AForgeCC_main_Load);
            this.ResizeEnd += new System.EventHandler(this.AForgeCC_main_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AForgeCC_main_KeyPress);
            this.PNL_CC.ResumeLayout(false);
            this.PNL_CC.PerformLayout();
            this.PNL_CC_Controls.ResumeLayout(false);
            this.PNL_CC_Controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPD_FPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_cc_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBX_CCList;
        private System.Windows.Forms.Panel PNL_CC;
        private System.Windows.Forms.Button BTN_CaptureCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PB_cc_view;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PNL_CC_Controls;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label LB_FS_Indicator1;
        private System.Windows.Forms.Label LBL_ccviewindicator2;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Button btn_srec;
        private System.Windows.Forms.Button btn4_rec;
        private System.Windows.Forms.NumericUpDown NUPD_FPS;
        private System.Windows.Forms.ComboBox CBX1_RES;
    }
}

