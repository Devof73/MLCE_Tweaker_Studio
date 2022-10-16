namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms
{
    partial class AskToInvertRedBlueOnReplacement
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
            this.PICBX_TargetImage = new Guna.UI.WinForms.GunaPictureBox();
            this.PICBX_msgIco = new Guna.UI.WinForms.GunaPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LABEL_MESSAGE = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PICBX_TargetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PICBX_msgIco)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PICBX_TargetImage
            // 
            this.PICBX_TargetImage.BaseColor = System.Drawing.Color.White;
            this.PICBX_TargetImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PICBX_TargetImage.Location = new System.Drawing.Point(13, 13);
            this.PICBX_TargetImage.Name = "PICBX_TargetImage";
            this.PICBX_TargetImage.Size = new System.Drawing.Size(71, 62);
            this.PICBX_TargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PICBX_TargetImage.TabIndex = 0;
            this.PICBX_TargetImage.TabStop = false;
            // 
            // PICBX_msgIco
            // 
            this.PICBX_msgIco.BaseColor = System.Drawing.Color.White;
            this.PICBX_msgIco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PICBX_msgIco.Location = new System.Drawing.Point(90, 29);
            this.PICBX_msgIco.Name = "PICBX_msgIco";
            this.PICBX_msgIco.Size = new System.Drawing.Size(34, 32);
            this.PICBX_msgIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PICBX_msgIco.TabIndex = 1;
            this.PICBX_msgIco.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btn3);
            this.panel1.Controls.Add(this.btn2);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 33);
            this.panel1.TabIndex = 2;
            // 
            // LABEL_MESSAGE
            // 
            this.LABEL_MESSAGE.AutoSize = true;
            this.LABEL_MESSAGE.Location = new System.Drawing.Point(130, 29);
            this.LABEL_MESSAGE.Name = "LABEL_MESSAGE";
            this.LABEL_MESSAGE.Size = new System.Drawing.Size(35, 13);
            this.LABEL_MESSAGE.TabIndex = 3;
            this.LABEL_MESSAGE.Text = "label1";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(258, 4);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 4;
            this.btn1.Text = "No";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(179, 4);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 5;
            this.btn2.Text = "Yes ";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(6, 5);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(149, 23);
            this.btn3.TabIndex = 6;
            this.btn3.Text = "Always Continue For Now";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // AskToInvertRedBlueOnReplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 123);
            this.ControlBox = false;
            this.Controls.Add(this.LABEL_MESSAGE);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PICBX_msgIco);
            this.Controls.Add(this.PICBX_TargetImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AskToInvertRedBlueOnReplacement";
            this.Text = "¿?";
            ((System.ComponentModel.ISupportInitialize)(this.PICBX_TargetImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PICBX_msgIco)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox PICBX_TargetImage;
        private Guna.UI.WinForms.GunaPictureBox PICBX_msgIco;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LABEL_MESSAGE;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn3;
    }
}