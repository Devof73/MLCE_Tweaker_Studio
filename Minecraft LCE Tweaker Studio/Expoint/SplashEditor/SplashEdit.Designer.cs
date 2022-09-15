namespace Minecraft_LCE_Tweaker_Studio.Expoint.SplashEditor
{
    partial class SplashEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashEdit));
            this.LBX_SplashValues = new System.Windows.Forms.ListBox();
            this.gtb_value_entry = new Guna.UI2.WinForms.Guna2TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.BTN_Sel_GameFolder = new Guna.UI2.WinForms.Guna2Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBX_SplashValues
            // 
            this.LBX_SplashValues.BackColor = System.Drawing.Color.Gray;
            this.LBX_SplashValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBX_SplashValues.Font = new System.Drawing.Font("Minecraft", 9F);
            this.LBX_SplashValues.ForeColor = System.Drawing.Color.Yellow;
            this.LBX_SplashValues.FormattingEnabled = true;
            this.LBX_SplashValues.Items.AddRange(new object[] {
            "No file."});
            this.LBX_SplashValues.Location = new System.Drawing.Point(11, 41);
            this.LBX_SplashValues.Name = "LBX_SplashValues";
            this.LBX_SplashValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.LBX_SplashValues.Size = new System.Drawing.Size(377, 353);
            this.LBX_SplashValues.TabIndex = 0;
            this.LBX_SplashValues.SelectedIndexChanged += new System.EventHandler(this.LBX_SplashValues_SelectedIndexChanged);
            // 
            // gtb_value_entry
            // 
            this.gtb_value_entry.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gtb_value_entry.DefaultText = "";
            this.gtb_value_entry.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.gtb_value_entry.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.gtb_value_entry.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gtb_value_entry.DisabledState.Parent = this.gtb_value_entry;
            this.gtb_value_entry.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gtb_value_entry.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtb_value_entry.FocusedState.Parent = this.gtb_value_entry;
            this.gtb_value_entry.Font = new System.Drawing.Font("Minecraft", 9F);
            this.gtb_value_entry.ForeColor = System.Drawing.Color.Black;
            this.gtb_value_entry.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtb_value_entry.HoverState.Parent = this.gtb_value_entry;
            this.gtb_value_entry.Location = new System.Drawing.Point(12, 403);
            this.gtb_value_entry.Name = "gtb_value_entry";
            this.gtb_value_entry.PasswordChar = '\0';
            this.gtb_value_entry.PlaceholderForeColor = System.Drawing.Color.Black;
            this.gtb_value_entry.PlaceholderText = "Your Text";
            this.gtb_value_entry.SelectedText = "";
            this.gtb_value_entry.ShadowDecoration.Parent = this.gtb_value_entry;
            this.gtb_value_entry.Size = new System.Drawing.Size(376, 25);
            this.gtb_value_entry.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(402, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.arrow_collapse_down;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(112, 22);
            this.toolStripButton2.Text = "Save Splashes";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.card_multiple;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton3.Text = "New Instance";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.delete;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(130, 22);
            this.toolStripButton1.Text = "Exit Without Save";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.receipt_text_remove;
            this.guna2Button1.ImageSize = new System.Drawing.Size(22, 22);
            this.guna2Button1.Location = new System.Drawing.Point(12, 437);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(185, 37);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "Remove Selected";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // BTN_Sel_GameFolder
            // 
            this.BTN_Sel_GameFolder.Animated = true;
            this.BTN_Sel_GameFolder.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Sel_GameFolder.BorderThickness = 1;
            this.BTN_Sel_GameFolder.CheckedState.Parent = this.BTN_Sel_GameFolder;
            this.BTN_Sel_GameFolder.CustomImages.Parent = this.BTN_Sel_GameFolder;
            this.BTN_Sel_GameFolder.FillColor = System.Drawing.Color.Gainsboro;
            this.BTN_Sel_GameFolder.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.BTN_Sel_GameFolder.ForeColor = System.Drawing.Color.Black;
            this.BTN_Sel_GameFolder.HoverState.Parent = this.BTN_Sel_GameFolder;
            this.BTN_Sel_GameFolder.Image = global::Minecraft_LCE_Tweaker_Studio.Properties.Resources.form_textbox__1_;
            this.BTN_Sel_GameFolder.ImageSize = new System.Drawing.Size(22, 22);
            this.BTN_Sel_GameFolder.Location = new System.Drawing.Point(203, 437);
            this.BTN_Sel_GameFolder.Name = "BTN_Sel_GameFolder";
            this.BTN_Sel_GameFolder.ShadowDecoration.Parent = this.BTN_Sel_GameFolder;
            this.BTN_Sel_GameFolder.Size = new System.Drawing.Size(185, 37);
            this.BTN_Sel_GameFolder.TabIndex = 11;
            this.BTN_Sel_GameFolder.Text = "Add Splash";
            this.BTN_Sel_GameFolder.UseTransparentBackground = true;
            this.BTN_Sel_GameFolder.Click += new System.EventHandler(this.BTN_Sel_GameFolder_Click);
            // 
            // SplashEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(402, 486);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.BTN_Sel_GameFolder);
            this.Controls.Add(this.gtb_value_entry);
            this.Controls.Add(this.LBX_SplashValues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SplashEdit";
            this.Text = "SplashEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashEdit_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBX_SplashValues;
        private Guna.UI2.WinForms.Guna2TextBox gtb_value_entry;
        private Guna.UI2.WinForms.Guna2Button BTN_Sel_GameFolder;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}