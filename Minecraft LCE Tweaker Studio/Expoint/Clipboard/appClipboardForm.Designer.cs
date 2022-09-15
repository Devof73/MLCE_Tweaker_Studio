namespace Minecraft_LCE_Tweaker_Studio.Expoint.Clipboard
{
    partial class AppClipboardForm
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
            this.lbx1_savedClipboard = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTBX_CurrentClipboard = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._btn2_clipSaveCurrent = new System.Windows.Forms.Button();
            this._btn1_winclose = new System.Windows.Forms.Button();
            this._btn3_ = new System.Windows.Forms.Button();
            this._btn3_copySelected = new System.Windows.Forms.Button();
            this.Btn5_DumpClipboard = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbx1_savedClipboard
            // 
            this.lbx1_savedClipboard.BackColor = System.Drawing.SystemColors.Control;
            this.lbx1_savedClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx1_savedClipboard.FormattingEnabled = true;
            this.lbx1_savedClipboard.Items.AddRange(new object[] {
            ";"});
            this.lbx1_savedClipboard.Location = new System.Drawing.Point(12, 136);
            this.lbx1_savedClipboard.Name = "lbx1_savedClipboard";
            this.lbx1_savedClipboard.Size = new System.Drawing.Size(397, 275);
            this.lbx1_savedClipboard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Clipboard";
            // 
            // RTBX_CurrentClipboard
            // 
            this.RTBX_CurrentClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTBX_CurrentClipboard.Location = new System.Drawing.Point(12, 29);
            this.RTBX_CurrentClipboard.Name = "RTBX_CurrentClipboard";
            this.RTBX_CurrentClipboard.Size = new System.Drawing.Size(398, 88);
            this.RTBX_CurrentClipboard.TabIndex = 2;
            this.RTBX_CurrentClipboard.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Saved Clipboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Btn5_DumpClipboard);
            this.panel1.Controls.Add(this._btn3_copySelected);
            this.panel1.Controls.Add(this._btn3_);
            this.panel1.Controls.Add(this._btn1_winclose);
            this.panel1.Controls.Add(this._btn2_clipSaveCurrent);
            this.panel1.Location = new System.Drawing.Point(-2, 433);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 61);
            this.panel1.TabIndex = 4;
            // 
            // _btn2_clipSaveCurrent
            // 
            this._btn2_clipSaveCurrent.Location = new System.Drawing.Point(290, 21);
            this._btn2_clipSaveCurrent.Name = "_btn2_clipSaveCurrent";
            this._btn2_clipSaveCurrent.Size = new System.Drawing.Size(79, 23);
            this._btn2_clipSaveCurrent.TabIndex = 5;
            this._btn2_clipSaveCurrent.Text = "Save Current";
            this._btn2_clipSaveCurrent.UseVisualStyleBackColor = true;
            this._btn2_clipSaveCurrent.Click += new System.EventHandler(this._btn2_clipSaveCurrent_Click);
            // 
            // _btn1_winclose
            // 
            this._btn1_winclose.Location = new System.Drawing.Point(369, 21);
            this._btn1_winclose.Name = "_btn1_winclose";
            this._btn1_winclose.Size = new System.Drawing.Size(48, 23);
            this._btn1_winclose.TabIndex = 6;
            this._btn1_winclose.Text = "Close";
            this._btn1_winclose.UseVisualStyleBackColor = true;
            this._btn1_winclose.Click += new System.EventHandler(this._btn1_winclose_Click);
            // 
            // _btn3_
            // 
            this._btn3_.Location = new System.Drawing.Point(14, 21);
            this._btn3_.Name = "_btn3_";
            this._btn3_.Size = new System.Drawing.Size(94, 23);
            this._btn3_.TabIndex = 7;
            this._btn3_.Text = "Clear";
            this._btn3_.UseVisualStyleBackColor = true;
            this._btn3_.Click += new System.EventHandler(this._btn3__Click);
            // 
            // _btn3_copySelected
            // 
            this._btn3_copySelected.Location = new System.Drawing.Point(206, 21);
            this._btn3_copySelected.Name = "_btn3_copySelected";
            this._btn3_copySelected.Size = new System.Drawing.Size(84, 23);
            this._btn3_copySelected.TabIndex = 8;
            this._btn3_copySelected.Text = "Copy Selected";
            this._btn3_copySelected.UseVisualStyleBackColor = true;
            this._btn3_copySelected.Click += new System.EventHandler(this._btn3_copySelected_Click);
            // 
            // Btn5_DumpClipboard
            // 
            this.Btn5_DumpClipboard.Location = new System.Drawing.Point(126, 21);
            this.Btn5_DumpClipboard.Name = "Btn5_DumpClipboard";
            this.Btn5_DumpClipboard.Size = new System.Drawing.Size(79, 23);
            this.Btn5_DumpClipboard.TabIndex = 9;
            this.Btn5_DumpClipboard.Text = "Dump";
            this.Btn5_DumpClipboard.UseVisualStyleBackColor = true;
            this.Btn5_DumpClipboard.Click += new System.EventHandler(this.Btn5_DumpClipboard_Click);
            // 
            // AppClipboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RTBX_CurrentClipboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbx1_savedClipboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AppClipboardForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "appClipboardForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppClipboardForm_FormClosing);
            this.Load += new System.EventHandler(this.AppClipboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx1_savedClipboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RTBX_CurrentClipboard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btn3_copySelected;
        private System.Windows.Forms.Button _btn3_;
        private System.Windows.Forms.Button _btn1_winclose;
        private System.Windows.Forms.Button _btn2_clipSaveCurrent;
        private System.Windows.Forms.Button Btn5_DumpClipboard;
    }
}