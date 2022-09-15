namespace Minecraft_LCE_Tweaker_Studio.Expoint.LOC
{
    partial class Editor_TextReplacement
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
            this.rtbx1_text = new System.Windows.Forms.RichTextBox();
            this.tbx_query = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btn2_contains = new System.Windows.Forms.Button();
            this.btn1_replace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_replacementValue = new System.Windows.Forms.TextBox();
            this.lbl_si = new System.Windows.Forms.Label();
            this.lbl_sil = new System.Windows.Forms.Label();
            this.lbl_tl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn4_aply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbx1_text
            // 
            this.rtbx1_text.Location = new System.Drawing.Point(0, 0);
            this.rtbx1_text.Name = "rtbx1_text";
            this.rtbx1_text.Size = new System.Drawing.Size(403, 159);
            this.rtbx1_text.TabIndex = 0;
            this.rtbx1_text.Text = "";
            this.rtbx1_text.TextChanged += new System.EventHandler(this.rtbx1_text_TextChanged);
            // 
            // tbx_query
            // 
            this.tbx_query.Location = new System.Drawing.Point(0, 198);
            this.tbx_query.Name = "tbx_query";
            this.tbx_query.Size = new System.Drawing.Size(326, 20);
            this.tbx_query.TabIndex = 1;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(0, 182);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(101, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Query to find in text:";
            // 
            // btn2_contains
            // 
            this.btn2_contains.Location = new System.Drawing.Point(328, 196);
            this.btn2_contains.Name = "btn2_contains";
            this.btn2_contains.Size = new System.Drawing.Size(75, 23);
            this.btn2_contains.TabIndex = 3;
            this.btn2_contains.Text = "Contains?";
            this.btn2_contains.UseVisualStyleBackColor = true;
            this.btn2_contains.Click += new System.EventHandler(this.btn2_contains_Click);
            // 
            // btn1_replace
            // 
            this.btn1_replace.Location = new System.Drawing.Point(328, 234);
            this.btn1_replace.Name = "btn1_replace";
            this.btn1_replace.Size = new System.Drawing.Size(75, 23);
            this.btn1_replace.TabIndex = 4;
            this.btn1_replace.Text = "Replace";
            this.btn1_replace.UseVisualStyleBackColor = true;
            this.btn1_replace.Click += new System.EventHandler(this.btn1_replace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Replace query by:";
            // 
            // tbx_replacementValue
            // 
            this.tbx_replacementValue.Location = new System.Drawing.Point(0, 235);
            this.tbx_replacementValue.Name = "tbx_replacementValue";
            this.tbx_replacementValue.Size = new System.Drawing.Size(326, 20);
            this.tbx_replacementValue.TabIndex = 5;
            // 
            // lbl_si
            // 
            this.lbl_si.AutoSize = true;
            this.lbl_si.Location = new System.Drawing.Point(0, 162);
            this.lbl_si.Name = "lbl_si";
            this.lbl_si.Size = new System.Drawing.Size(90, 13);
            this.lbl_si.TabIndex = 7;
            this.lbl_si.Text = "Selected Index: 0";
            // 
            // lbl_sil
            // 
            this.lbl_sil.AutoSize = true;
            this.lbl_sil.Location = new System.Drawing.Point(146, 162);
            this.lbl_sil.Name = "lbl_sil";
            this.lbl_sil.Size = new System.Drawing.Size(126, 13);
            this.lbl_sil.TabIndex = 8;
            this.lbl_sil.Text = "Selected Index Length: 0";
            // 
            // lbl_tl
            // 
            this.lbl_tl.AutoSize = true;
            this.lbl_tl.Location = new System.Drawing.Point(302, 162);
            this.lbl_tl.Name = "lbl_tl";
            this.lbl_tl.Size = new System.Drawing.Size(76, 13);
            this.lbl_tl.TabIndex = 9;
            this.lbl_tl.Text = "Text Length: 0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Undo to Original";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn4_aply
            // 
            this.btn4_aply.Location = new System.Drawing.Point(191, 266);
            this.btn4_aply.Name = "btn4_aply";
            this.btn4_aply.Size = new System.Drawing.Size(103, 23);
            this.btn4_aply.TabIndex = 12;
            this.btn4_aply.Text = "Apply";
            this.btn4_aply.UseVisualStyleBackColor = true;
            this.btn4_aply.Click += new System.EventHandler(this.btn4_aply_Click);
            // 
            // Editor_TextReplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 301);
            this.ControlBox = false;
            this.Controls.Add(this.rtbx1_text);
            this.Controls.Add(this.btn4_aply);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_tl);
            this.Controls.Add(this.lbl_sil);
            this.Controls.Add(this.lbl_si);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_replacementValue);
            this.Controls.Add(this.btn1_replace);
            this.Controls.Add(this.btn2_contains);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.tbx_query);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Editor_TextReplacement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Text";
            this.Load += new System.EventHandler(this.Editor_TextReplacement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbx1_text;
        private System.Windows.Forms.TextBox tbx_query;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btn2_contains;
        private System.Windows.Forms.Button btn1_replace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_replacementValue;
        private System.Windows.Forms.Label lbl_si;
        private System.Windows.Forms.Label lbl_sil;
        private System.Windows.Forms.Label lbl_tl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn4_aply;
    }
}