namespace Minecraft_LCE_Tweaker_Studio.Expoint.Better_Forms
{
    partial class compilate_ps3
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
            this.components = new System.ComponentModel.Container();
            this.tbx1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.COBX_PROJECTS = new System.Windows.Forms.ListBox();
            this.pgb_progress = new System.Windows.Forms.ProgressBar();
            this.RTBX_LOG = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn3_copy = new System.Windows.Forms.Button();
            this.btn4_backups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx1
            // 
            this.tbx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbx1.Location = new System.Drawing.Point(59, 261);
            this.tbx1.MaxLength = 25;
            this.tbx1.Name = "tbx1";
            this.tbx1.Size = new System.Drawing.Size(227, 26);
            this.tbx1.TabIndex = 0;
            this.tbx1.Text = "ftp://192.168.0";
            this.tbx1.TextChanged += new System.EventHandler(this.tbx1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PS3 IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(292, 261);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(226, 26);
            this.btn1.TabIndex = 4;
            this.btn1.Text = "COMPILE";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(292, 293);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(226, 23);
            this.btn2.TabIndex = 5;
            this.btn2.Text = "CANCEL";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // COBX_PROJECTS
            // 
            this.COBX_PROJECTS.ColumnWidth = 1;
            this.COBX_PROJECTS.Font = new System.Drawing.Font("Mojangles", 15F);
            this.COBX_PROJECTS.FormattingEnabled = true;
            this.COBX_PROJECTS.HorizontalExtent = 1;
            this.COBX_PROJECTS.HorizontalScrollbar = true;
            this.COBX_PROJECTS.ItemHeight = 22;
            this.COBX_PROJECTS.Location = new System.Drawing.Point(12, 28);
            this.COBX_PROJECTS.Name = "COBX_PROJECTS";
            this.COBX_PROJECTS.Size = new System.Drawing.Size(506, 224);
            this.COBX_PROJECTS.TabIndex = 6;
            this.COBX_PROJECTS.SelectedIndexChanged += new System.EventHandler(this.COBX_PROJECTS_SelectedIndexChanged);
            // 
            // pgb_progress
            // 
            this.pgb_progress.Location = new System.Drawing.Point(12, 293);
            this.pgb_progress.Name = "pgb_progress";
            this.pgb_progress.Size = new System.Drawing.Size(274, 23);
            this.pgb_progress.TabIndex = 7;
            // 
            // RTBX_LOG
            // 
            this.RTBX_LOG.Location = new System.Drawing.Point(12, 322);
            this.RTBX_LOG.Name = "RTBX_LOG";
            this.RTBX_LOG.ReadOnly = true;
            this.RTBX_LOG.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RTBX_LOG.Size = new System.Drawing.Size(506, 153);
            this.RTBX_LOG.TabIndex = 8;
            this.RTBX_LOG.Text = "<----- MLCE COMPILATOR REGISTRY ----->";
            this.RTBX_LOG.TextChanged += new System.EventHandler(this.RTBX_LOG_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn3_copy
            // 
            this.btn3_copy.Location = new System.Drawing.Point(444, 481);
            this.btn3_copy.Name = "btn3_copy";
            this.btn3_copy.Size = new System.Drawing.Size(74, 23);
            this.btn3_copy.TabIndex = 9;
            this.btn3_copy.Text = "Copy";
            this.btn3_copy.UseVisualStyleBackColor = true;
            this.btn3_copy.Click += new System.EventHandler(this.btn3_copy_Click);
            // 
            // btn4_backups
            // 
            this.btn4_backups.Location = new System.Drawing.Point(364, 481);
            this.btn4_backups.Name = "btn4_backups";
            this.btn4_backups.Size = new System.Drawing.Size(74, 23);
            this.btn4_backups.TabIndex = 10;
            this.btn4_backups.Text = "Backups...";
            this.btn4_backups.UseVisualStyleBackColor = true;
            this.btn4_backups.Click += new System.EventHandler(this.btn4_backups_Click);
            // 
            // compilate_ps3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 516);
            this.Controls.Add(this.btn4_backups);
            this.Controls.Add(this.btn3_copy);
            this.Controls.Add(this.RTBX_LOG);
            this.Controls.Add(this.pgb_progress);
            this.Controls.Add(this.COBX_PROJECTS);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "compilate_ps3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "compilate_ps3";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.compilate_ps3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbx1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.ListBox COBX_PROJECTS;
        private System.Windows.Forms.ProgressBar pgb_progress;
        private System.Windows.Forms.RichTextBox RTBX_LOG;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn3_copy;
        private System.Windows.Forms.Button btn4_backups;
    }
}