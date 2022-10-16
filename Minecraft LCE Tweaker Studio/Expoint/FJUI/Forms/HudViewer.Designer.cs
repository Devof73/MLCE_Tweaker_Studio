namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms
{
    partial class HudViewer
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
            this.PNL_VIEW = new System.Windows.Forms.Panel();
            this.GNPIC_VIEW = new Guna.UI.WinForms.GunaPictureBox();
            this.PNL_VIEW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNPIC_VIEW)).BeginInit();
            this.SuspendLayout();
            // 
            // PNL_VIEW
            // 
            this.PNL_VIEW.BackColor = System.Drawing.Color.Silver;
            this.PNL_VIEW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNL_VIEW.Controls.Add(this.GNPIC_VIEW);
            this.PNL_VIEW.Location = new System.Drawing.Point(13, 13);
            this.PNL_VIEW.Name = "PNL_VIEW";
            this.PNL_VIEW.Size = new System.Drawing.Size(775, 425);
            this.PNL_VIEW.TabIndex = 0;
            // 
            // GNPIC_VIEW
            // 
            this.GNPIC_VIEW.BaseColor = System.Drawing.Color.White;
            this.GNPIC_VIEW.Location = new System.Drawing.Point(3, 3);
            this.GNPIC_VIEW.Name = "GNPIC_VIEW";
            this.GNPIC_VIEW.Size = new System.Drawing.Size(767, 417);
            this.GNPIC_VIEW.TabIndex = 1;
            this.GNPIC_VIEW.TabStop = false;
            // 
            // HudViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PNL_VIEW);
            this.Name = "HudViewer";
            this.Text = "HudViewer";
            this.Load += new System.EventHandler(this.HudViewer_Load);
            this.PNL_VIEW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GNPIC_VIEW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_VIEW;
        private Guna.UI.WinForms.GunaPictureBox GNPIC_VIEW;
    }
}