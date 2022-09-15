namespace Minecraft_LCE_Tweaker_Studio.Expoint.BINKA
{
    partial class AudioBinkInputOutputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_input = new System.Windows.Forms.TextBox();
            this.btn1_iselection = new System.Windows.Forms.Button();
            this.btn3_binknow = new System.Windows.Forms.Button();
            this.btn3_binkwav = new System.Windows.Forms.Button();
            this.lbl2_trackname = new System.Windows.Forms.Label();
            this.LBL3_Duration = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn4_playaudio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename";
            // 
            // tbx_input
            // 
            this.tbx_input.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.tbx_input.Location = new System.Drawing.Point(15, 26);
            this.tbx_input.Name = "tbx_input";
            this.tbx_input.Size = new System.Drawing.Size(365, 20);
            this.tbx_input.TabIndex = 1;
            // 
            // btn1_iselection
            // 
            this.btn1_iselection.Location = new System.Drawing.Point(386, 26);
            this.btn1_iselection.Name = "btn1_iselection";
            this.btn1_iselection.Size = new System.Drawing.Size(60, 20);
            this.btn1_iselection.TabIndex = 2;
            this.btn1_iselection.Text = "[...]";
            this.btn1_iselection.UseVisualStyleBackColor = true;
            this.btn1_iselection.Click += new System.EventHandler(this.btn1_iselection_Click);
            // 
            // btn3_binknow
            // 
            this.btn3_binknow.Location = new System.Drawing.Point(129, 52);
            this.btn3_binknow.Name = "btn3_binknow";
            this.btn3_binknow.Size = new System.Drawing.Size(108, 24);
            this.btn3_binknow.TabIndex = 10;
            this.btn3_binknow.Text = "WAV to BINKA";
            this.btn3_binknow.UseVisualStyleBackColor = true;
            this.btn3_binknow.Click += new System.EventHandler(this.btn3_binknow_Click);
            // 
            // btn3_binkwav
            // 
            this.btn3_binkwav.Location = new System.Drawing.Point(15, 52);
            this.btn3_binkwav.Name = "btn3_binkwav";
            this.btn3_binkwav.Size = new System.Drawing.Size(108, 24);
            this.btn3_binkwav.TabIndex = 11;
            this.btn3_binkwav.Text = "BINKA to WAV";
            this.btn3_binkwav.UseVisualStyleBackColor = true;
            this.btn3_binkwav.Click += new System.EventHandler(this.btn3_binkwav_Click);
            // 
            // lbl2_trackname
            // 
            this.lbl2_trackname.AutoSize = true;
            this.lbl2_trackname.Location = new System.Drawing.Point(300, 51);
            this.lbl2_trackname.Name = "lbl2_trackname";
            this.lbl2_trackname.Size = new System.Drawing.Size(76, 13);
            this.lbl2_trackname.TabIndex = 13;
            this.lbl2_trackname.Text = "Trackname: ...";
            // 
            // LBL3_Duration
            // 
            this.LBL3_Duration.AutoSize = true;
            this.LBL3_Duration.Location = new System.Drawing.Point(300, 67);
            this.LBL3_Duration.Name = "LBL3_Duration";
            this.LBL3_Duration.Size = new System.Drawing.Size(95, 13);
            this.LBL3_Duration.TabIndex = 14;
            this.LBL3_Duration.Text = "Duration: 00:00:00";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.stop;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(243, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn4_playaudio
            // 
            this.btn4_playaudio.BackgroundImage = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.play_pause;
            this.btn4_playaudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn4_playaudio.Enabled = false;
            this.btn4_playaudio.Location = new System.Drawing.Point(449, 25);
            this.btn4_playaudio.Name = "btn4_playaudio";
            this.btn4_playaudio.Size = new System.Drawing.Size(50, 22);
            this.btn4_playaudio.TabIndex = 12;
            this.btn4_playaudio.UseVisualStyleBackColor = true;
            this.btn4_playaudio.Click += new System.EventHandler(this.btn4_playaudio_Click);
            // 
            // AudioBinkInputOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 99);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LBL3_Duration);
            this.Controls.Add(this.lbl2_trackname);
            this.Controls.Add(this.btn4_playaudio);
            this.Controls.Add(this.btn3_binkwav);
            this.Controls.Add(this.btn3_binknow);
            this.Controls.Add(this.btn1_iselection);
            this.Controls.Add(this.tbx_input);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AudioBinkInputOutputForm";
            this.ShowIcon = false;
            this.Text = "BINKA I/O AUDIO";
            this.Load += new System.EventHandler(this.AudioBinkInputOutputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_input;
        private System.Windows.Forms.Button btn1_iselection;
        private System.Windows.Forms.Button btn3_binknow;
        private System.Windows.Forms.Button btn3_binkwav;
        private System.Windows.Forms.Button btn4_playaudio;
        private System.Windows.Forms.Label lbl2_trackname;
        private System.Windows.Forms.Label LBL3_Duration;
        private System.Windows.Forms.Button button1;
    }
}