namespace Minecraft_LCE_Tweaker_Studio.Expoint.LOC
{
    partial class Editor
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


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.LV_LangStrings = new System.Windows.Forms.ListView();
            this.columnHeader_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_LangList = new System.Windows.Forms.ListView();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.LB_DebugStr_Parse = new Guna.UI.WinForms.GunaLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.FindedStringz = new System.Windows.Forms.ComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.Reset_strlist = new Guna.UI2.WinForms.Guna2Button();
            this.GoToNumber_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.ZoomMore_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.ZoomMinus_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.SearchBar = new Guna.UI.WinForms.GunaTextBox();
            this.SAVE_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.TC_Workspace = new System.Windows.Forms.TabControl();
            this.STR_EDIT = new System.Windows.Forms.TabPage();
            this.ADDI_TOOLS = new System.Windows.Forms.TabPage();
            this.gunaPanel3 = new Guna.UI.WinForms.GunaPanel();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Find_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.Find_TB = new Guna.UI.WinForms.GunaTextBox();
            this.TC_WorkTabs = new System.Windows.Forms.TabControl();
            this.tpg_MainWork = new System.Windows.Forms.TabPage();
            this.BGW_Saver = new System.ComponentModel.BackgroundWorker();
            this.BGW_Loader = new System.ComponentModel.BackgroundWorker();
            this.TTIP_ResultListHoveringMessage = new System.Windows.Forms.ToolTip(this.components);
            this.btn6_replacement = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gunaPanel1.SuspendLayout();
            this.gunaPanel2.SuspendLayout();
            this.TC_Workspace.SuspendLayout();
            this.STR_EDIT.SuspendLayout();
            this.ADDI_TOOLS.SuspendLayout();
            this.gunaPanel3.SuspendLayout();
            this.TC_WorkTabs.SuspendLayout();
            this.tpg_MainWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_LangStrings
            // 
            this.LV_LangStrings.BackColor = System.Drawing.Color.White;
            this.LV_LangStrings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_1,
            this.columnHeader_2});
            this.LV_LangStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LV_LangStrings.ForeColor = System.Drawing.Color.Black;
            this.LV_LangStrings.FullRowSelect = true;
            this.LV_LangStrings.HideSelection = false;
            this.LV_LangStrings.Location = new System.Drawing.Point(195, 62);
            this.LV_LangStrings.Name = "LV_LangStrings";
            this.LV_LangStrings.Size = new System.Drawing.Size(988, 279);
            this.LV_LangStrings.TabIndex = 11;
            this.LV_LangStrings.UseCompatibleStateImageBehavior = false;
            this.LV_LangStrings.View = System.Windows.Forms.View.Details;
            this.LV_LangStrings.SelectedIndexChanged += new System.EventHandler(this.lvMessages_SelectedIndexChanged_1);
            // 
            // columnHeader_1
            // 
            this.columnHeader_1.Text = "#";
            this.columnHeader_1.Width = 51;
            // 
            // columnHeader_2
            // 
            this.columnHeader_2.Text = "String Data";
            this.columnHeader_2.Width = 619;
            // 
            // LV_LangList
            // 
            this.LV_LangList.BackColor = System.Drawing.SystemColors.Window;
            this.LV_LangList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_0});
            this.LV_LangList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LV_LangList.ForeColor = System.Drawing.SystemColors.MenuText;
            this.LV_LangList.FullRowSelect = true;
            this.LV_LangList.HideSelection = false;
            this.LV_LangList.Location = new System.Drawing.Point(6, 62);
            this.LV_LangList.Name = "LV_LangList";
            this.LV_LangList.Size = new System.Drawing.Size(178, 629);
            this.LV_LangList.TabIndex = 10;
            this.LV_LangList.UseCompatibleStateImageBehavior = false;
            this.LV_LangList.View = System.Windows.Forms.View.Details;
            this.LV_LangList.SelectedIndexChanged += new System.EventHandler(this.duohnRabql_SelectedIndexChanged_1);
            // 
            // columnHeader_0
            // 
            this.columnHeader_0.Text = "Languages";
            this.columnHeader_0.Width = 178;
            // 
            // Message_TB
            // 
            this.Message_TB.BackColor = System.Drawing.Color.White;
            this.Message_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Message_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Message_TB.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Message_TB.Location = new System.Drawing.Point(6, 6);
            this.Message_TB.Multiline = true;
            this.Message_TB.Name = "Message_TB";
            this.Message_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Message_TB.Size = new System.Drawing.Size(970, 305);
            this.Message_TB.TabIndex = 12;
            this.Message_TB.Text = "String";
            this.Message_TB.TextChanged += new System.EventHandler(this.Message_TB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "GOTO #";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 28);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(128, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // sameToolStripMenuItem
            // 
            this.sameToolStripMenuItem.Name = "sameToolStripMenuItem";
            this.sameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sameToolStripMenuItem.Text = "Save";
            this.sameToolStripMenuItem.Click += new System.EventHandler(this.sameToolStripMenuItem_Click_1);
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel1.Controls.Add(this.LB_DebugStr_Parse);
            this.gunaPanel1.Controls.Add(this.guna2Button1);
            this.gunaPanel1.Controls.Add(this.FindedStringz);
            this.gunaPanel1.Controls.Add(this.gunaLabel1);
            this.gunaPanel1.Controls.Add(this.guna2Button2);
            this.gunaPanel1.Controls.Add(this.Reset_strlist);
            this.gunaPanel1.Controls.Add(this.GoToNumber_BTN);
            this.gunaPanel1.Controls.Add(this.numericUpDown1);
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Location = new System.Drawing.Point(6, 6);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(972, 71);
            this.gunaPanel1.TabIndex = 17;
            this.gunaPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaPanel1_Paint);
            // 
            // LB_DebugStr_Parse
            // 
            this.LB_DebugStr_Parse.AutoSize = true;
            this.LB_DebugStr_Parse.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LB_DebugStr_Parse.Location = new System.Drawing.Point(470, 12);
            this.LB_DebugStr_Parse.Name = "LB_DebugStr_Parse";
            this.LB_DebugStr_Parse.Size = new System.Drawing.Size(72, 13);
            this.LB_DebugStr_Parse.TabIndex = 29;
            this.LB_DebugStr_Parse.Text = "Debug Label";
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.DimGray;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(564, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(96, 46);
            this.guna2Button1.TabIndex = 27;
            this.guna2Button1.Text = "Refresh";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // FindedStringz
            // 
            this.FindedStringz.Location = new System.Drawing.Point(148, 28);
            this.FindedStringz.MaxLength = 5;
            this.FindedStringz.Name = "FindedStringz";
            this.FindedStringz.Size = new System.Drawing.Size(394, 21);
            this.FindedStringz.TabIndex = 28;
            this.FindedStringz.SelectedIndexChanged += new System.EventHandler(this.FindedStringz_SelectedIndexChanged_1);
            this.FindedStringz.Click += new System.EventHandler(this.FindedStringz_Click_1);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gunaLabel1.Location = new System.Drawing.Point(145, 12);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(103, 13);
            this.gunaLabel1.TabIndex = 25;
            this.gunaLabel1.Text = "Remembered Lines";
            // 
            // guna2Button2
            // 
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.DimGray;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(768, 12);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(96, 46);
            this.guna2Button2.TabIndex = 27;
            this.guna2Button2.Text = "Save String List";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click_1);
            // 
            // Reset_strlist
            // 
            this.Reset_strlist.CheckedState.Parent = this.Reset_strlist;
            this.Reset_strlist.CustomImages.Parent = this.Reset_strlist;
            this.Reset_strlist.FillColor = System.Drawing.Color.DimGray;
            this.Reset_strlist.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Reset_strlist.ForeColor = System.Drawing.Color.White;
            this.Reset_strlist.HoverState.Parent = this.Reset_strlist;
            this.Reset_strlist.Location = new System.Drawing.Point(870, 12);
            this.Reset_strlist.Name = "Reset_strlist";
            this.Reset_strlist.ShadowDecoration.Parent = this.Reset_strlist;
            this.Reset_strlist.Size = new System.Drawing.Size(96, 46);
            this.Reset_strlist.TabIndex = 26;
            this.Reset_strlist.Text = "Reset String List";
            this.Reset_strlist.Click += new System.EventHandler(this.Reset_strlist_Click);
            // 
            // GoToNumber_BTN
            // 
            this.GoToNumber_BTN.CheckedState.Parent = this.GoToNumber_BTN;
            this.GoToNumber_BTN.CustomImages.Parent = this.GoToNumber_BTN;
            this.GoToNumber_BTN.FillColor = System.Drawing.Color.DimGray;
            this.GoToNumber_BTN.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.GoToNumber_BTN.ForeColor = System.Drawing.Color.White;
            this.GoToNumber_BTN.HoverState.Parent = this.GoToNumber_BTN;
            this.GoToNumber_BTN.Location = new System.Drawing.Point(666, 12);
            this.GoToNumber_BTN.Name = "GoToNumber_BTN";
            this.GoToNumber_BTN.ShadowDecoration.Parent = this.GoToNumber_BTN;
            this.GoToNumber_BTN.Size = new System.Drawing.Size(96, 46);
            this.GoToNumber_BTN.TabIndex = 20;
            this.GoToNumber_BTN.Text = "Go";
            this.GoToNumber_BTN.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // ZoomMore_BTN
            // 
            this.ZoomMore_BTN.CheckedState.Parent = this.ZoomMore_BTN;
            this.ZoomMore_BTN.CustomImages.Parent = this.ZoomMore_BTN;
            this.ZoomMore_BTN.FillColor = System.Drawing.Color.DimGray;
            this.ZoomMore_BTN.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ZoomMore_BTN.ForeColor = System.Drawing.Color.White;
            this.ZoomMore_BTN.HoverState.Parent = this.ZoomMore_BTN;
            this.ZoomMore_BTN.Location = new System.Drawing.Point(190, 593);
            this.ZoomMore_BTN.Name = "ZoomMore_BTN";
            this.ZoomMore_BTN.ShadowDecoration.Parent = this.ZoomMore_BTN;
            this.ZoomMore_BTN.Size = new System.Drawing.Size(21, 44);
            this.ZoomMore_BTN.TabIndex = 18;
            this.ZoomMore_BTN.Text = "+";
            this.ZoomMore_BTN.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ZoomMinus_BTN
            // 
            this.ZoomMinus_BTN.CheckedState.Parent = this.ZoomMinus_BTN;
            this.ZoomMinus_BTN.CustomImages.Parent = this.ZoomMinus_BTN;
            this.ZoomMinus_BTN.FillColor = System.Drawing.Color.DimGray;
            this.ZoomMinus_BTN.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ZoomMinus_BTN.ForeColor = System.Drawing.Color.White;
            this.ZoomMinus_BTN.HoverState.Parent = this.ZoomMinus_BTN;
            this.ZoomMinus_BTN.Location = new System.Drawing.Point(190, 643);
            this.ZoomMinus_BTN.Name = "ZoomMinus_BTN";
            this.ZoomMinus_BTN.ShadowDecoration.Parent = this.ZoomMinus_BTN;
            this.ZoomMinus_BTN.Size = new System.Drawing.Size(21, 44);
            this.ZoomMinus_BTN.TabIndex = 19;
            this.ZoomMinus_BTN.Text = "-";
            this.ZoomMinus_BTN.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.BackColor = System.Drawing.Color.LightGray;
            this.gunaPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel2.Controls.Add(this.guna2Button3);
            this.gunaPanel2.Controls.Add(this.SearchBar);
            this.gunaPanel2.Controls.Add(this.SAVE_BTN);
            this.gunaPanel2.Controls.Add(this.guna2Button4);
            this.gunaPanel2.Location = new System.Drawing.Point(12, 6);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(1171, 50);
            this.gunaPanel2.TabIndex = 20;
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.DimGray;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.HoverState.Image")));
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2Button3.Location = new System.Drawing.Point(914, 4);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(45, 39);
            this.guna2Button3.TabIndex = 24;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click_1);
            // 
            // SearchBar
            // 
            this.SearchBar.BaseColor = System.Drawing.Color.White;
            this.SearchBar.BorderColor = System.Drawing.Color.Silver;
            this.SearchBar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBar.FocusedBaseColor = System.Drawing.Color.White;
            this.SearchBar.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.SearchBar.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.SearchBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchBar.Location = new System.Drawing.Point(618, 1);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.PasswordChar = '\0';
            this.SearchBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SearchBar.SelectedText = "";
            this.SearchBar.Size = new System.Drawing.Size(290, 43);
            this.SearchBar.TabIndex = 23;
            this.SearchBar.Text = "Search a individual string ";
            // 
            // SAVE_BTN
            // 
            this.SAVE_BTN.Animated = true;
            this.SAVE_BTN.BorderThickness = 1;
            this.SAVE_BTN.CheckedState.Parent = this.SAVE_BTN;
            this.SAVE_BTN.CustomImages.Parent = this.SAVE_BTN;
            this.SAVE_BTN.FillColor = System.Drawing.Color.DimGray;
            this.SAVE_BTN.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SAVE_BTN.ForeColor = System.Drawing.Color.White;
            this.SAVE_BTN.HoverState.FillColor = System.Drawing.Color.DarkGray;
            this.SAVE_BTN.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("SAVE_BTN.HoverState.Image")));
            this.SAVE_BTN.HoverState.Parent = this.SAVE_BTN;
            this.SAVE_BTN.Image = ((System.Drawing.Image)(resources.GetObject("SAVE_BTN.Image")));
            this.SAVE_BTN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SAVE_BTN.ImageSize = new System.Drawing.Size(50, 50);
            this.SAVE_BTN.Location = new System.Drawing.Point(6, 4);
            this.SAVE_BTN.Name = "SAVE_BTN";
            this.SAVE_BTN.ShadowDecoration.Parent = this.SAVE_BTN;
            this.SAVE_BTN.Size = new System.Drawing.Size(142, 40);
            this.SAVE_BTN.TabIndex = 22;
            this.SAVE_BTN.Text = "Save";
            this.SAVE_BTN.Click += new System.EventHandler(this.SAVE_BTN_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.FillColor = System.Drawing.Color.DimGray;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.HoverState.Image")));
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2Button4.Location = new System.Drawing.Point(965, 5);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(197, 39);
            this.guna2Button4.TabIndex = 21;
            this.guna2Button4.Text = "Dump LOC Strings";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click_1);
            // 
            // TC_Workspace
            // 
            this.TC_Workspace.Controls.Add(this.STR_EDIT);
            this.TC_Workspace.Controls.Add(this.ADDI_TOOLS);
            this.TC_Workspace.HotTrack = true;
            this.TC_Workspace.Location = new System.Drawing.Point(217, 348);
            this.TC_Workspace.Name = "TC_Workspace";
            this.TC_Workspace.SelectedIndex = 0;
            this.TC_Workspace.Size = new System.Drawing.Size(970, 343);
            this.TC_Workspace.TabIndex = 25;
            // 
            // STR_EDIT
            // 
            this.STR_EDIT.Controls.Add(this.Message_TB);
            this.STR_EDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.STR_EDIT.Location = new System.Drawing.Point(4, 22);
            this.STR_EDIT.Name = "STR_EDIT";
            this.STR_EDIT.Padding = new System.Windows.Forms.Padding(3);
            this.STR_EDIT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.STR_EDIT.Size = new System.Drawing.Size(962, 317);
            this.STR_EDIT.TabIndex = 0;
            this.STR_EDIT.Text = "EDIT STRING";
            this.STR_EDIT.UseVisualStyleBackColor = true;
            // 
            // ADDI_TOOLS
            // 
            this.ADDI_TOOLS.Controls.Add(this.gunaPanel3);
            this.ADDI_TOOLS.Controls.Add(this.gunaPanel1);
            this.ADDI_TOOLS.Location = new System.Drawing.Point(4, 22);
            this.ADDI_TOOLS.Name = "ADDI_TOOLS";
            this.ADDI_TOOLS.Padding = new System.Windows.Forms.Padding(3);
            this.ADDI_TOOLS.Size = new System.Drawing.Size(962, 317);
            this.ADDI_TOOLS.TabIndex = 1;
            this.ADDI_TOOLS.Text = "TOOLS";
            this.ADDI_TOOLS.UseVisualStyleBackColor = true;
            this.ADDI_TOOLS.Click += new System.EventHandler(this.ADDI_TOOLS_Click);
            // 
            // gunaPanel3
            // 
            this.gunaPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel3.Controls.Add(this.label2);
            this.gunaPanel3.Controls.Add(this.ResultListView);
            this.gunaPanel3.Controls.Add(this.Find_BTN);
            this.gunaPanel3.Controls.Add(this.Find_TB);
            this.gunaPanel3.Location = new System.Drawing.Point(6, 83);
            this.gunaPanel3.Name = "gunaPanel3";
            this.gunaPanel3.Size = new System.Drawing.Size(970, 228);
            this.gunaPanel3.TabIndex = 43;
            // 
            // ResultListView
            // 
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ResultListView.GridLines = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ResultListView.Location = new System.Drawing.Point(9, 47);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(956, 151);
            this.ResultListView.TabIndex = 41;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.SelectedIndexChanged += new System.EventHandler(this.ResultListView_SelectedIndexChanged);
            this.ResultListView.DoubleClick += new System.EventHandler(this.ResultListView_DoubleClick);
            this.ResultListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ResultListView_MouseDoubleClick);
            this.ResultListView.MouseLeave += new System.EventHandler(this.ResultListView_MouseLeave);
            this.ResultListView.MouseHover += new System.EventHandler(this.ResultListView_MouseHover);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#              TEXT";
            this.columnHeader1.Width = 948;
            // 
            // Find_BTN
            // 
            this.Find_BTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Find_BTN.BorderRadius = 2;
            this.Find_BTN.CheckedState.Parent = this.Find_BTN;
            this.Find_BTN.CustomImages.Parent = this.Find_BTN;
            this.Find_BTN.FillColor = System.Drawing.Color.DimGray;
            this.Find_BTN.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Find_BTN.ForeColor = System.Drawing.Color.White;
            this.Find_BTN.HoverState.Parent = this.Find_BTN;
            this.Find_BTN.Location = new System.Drawing.Point(748, 7);
            this.Find_BTN.Name = "Find_BTN";
            this.Find_BTN.ShadowDecoration.Parent = this.Find_BTN;
            this.Find_BTN.Size = new System.Drawing.Size(211, 33);
            this.Find_BTN.TabIndex = 39;
            this.Find_BTN.Text = "FIND";
            this.Find_BTN.Click += new System.EventHandler(this.Find_BTN_Click);
            // 
            // Find_TB
            // 
            this.Find_TB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Find_TB.BackColor = System.Drawing.Color.White;
            this.Find_TB.BaseColor = System.Drawing.Color.White;
            this.Find_TB.BorderColor = System.Drawing.Color.Silver;
            this.Find_TB.BorderSize = 3;
            this.Find_TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Find_TB.FocusedBaseColor = System.Drawing.Color.White;
            this.Find_TB.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Find_TB.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.Find_TB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Find_TB.ForeColor = System.Drawing.Color.Black;
            this.Find_TB.Location = new System.Drawing.Point(10, 7);
            this.Find_TB.Multiline = true;
            this.Find_TB.Name = "Find_TB";
            this.Find_TB.PasswordChar = '\0';
            this.Find_TB.SelectedText = "";
            this.Find_TB.Size = new System.Drawing.Size(732, 34);
            this.Find_TB.TabIndex = 38;
            this.Find_TB.Text = "Search Multiple String";
            // 
            // TC_WorkTabs
            // 
            this.TC_WorkTabs.Controls.Add(this.tpg_MainWork);
            this.TC_WorkTabs.HotTrack = true;
            this.TC_WorkTabs.Location = new System.Drawing.Point(-8, -25);
            this.TC_WorkTabs.Name = "TC_WorkTabs";
            this.TC_WorkTabs.SelectedIndex = 0;
            this.TC_WorkTabs.Size = new System.Drawing.Size(1228, 775);
            this.TC_WorkTabs.TabIndex = 26;
            // 
            // tpg_MainWork
            // 
            this.tpg_MainWork.Controls.Add(this.btn6_replacement);
            this.tpg_MainWork.Controls.Add(this.ZoomMinus_BTN);
            this.tpg_MainWork.Controls.Add(this.ZoomMore_BTN);
            this.tpg_MainWork.Controls.Add(this.gunaPanel2);
            this.tpg_MainWork.Controls.Add(this.TC_Workspace);
            this.tpg_MainWork.Controls.Add(this.LV_LangList);
            this.tpg_MainWork.Controls.Add(this.LV_LangStrings);
            this.tpg_MainWork.Location = new System.Drawing.Point(4, 22);
            this.tpg_MainWork.Name = "tpg_MainWork";
            this.tpg_MainWork.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_MainWork.Size = new System.Drawing.Size(1220, 749);
            this.tpg_MainWork.TabIndex = 0;
            this.tpg_MainWork.Text = "W1";
            this.tpg_MainWork.UseVisualStyleBackColor = true;
            this.tpg_MainWork.Click += new System.EventHandler(this.tpg_MainWork_Click);
            // 
            // BGW_Saver
            // 
            this.BGW_Saver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // BGW_Loader
            // 
            this.BGW_Loader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_Loader_DoWork);
            // 
            // TTIP_ResultListHoveringMessage
            // 
            this.TTIP_ResultListHoveringMessage.IsBalloon = true;
            this.TTIP_ResultListHoveringMessage.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TTIP_ResultListHoveringMessage.ToolTipTitle = "Add value to favorites.";
            // 
            // btn6_replacement
            // 
            this.btn6_replacement.CheckedState.Parent = this.btn6_replacement;
            this.btn6_replacement.CustomImages.Parent = this.btn6_replacement;
            this.btn6_replacement.FillColor = System.Drawing.Color.DimGray;
            this.btn6_replacement.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btn6_replacement.ForeColor = System.Drawing.Color.White;
            this.btn6_replacement.HoverState.Parent = this.btn6_replacement;
            this.btn6_replacement.Location = new System.Drawing.Point(185, 547);
            this.btn6_replacement.Name = "btn6_replacement";
            this.btn6_replacement.ShadowDecoration.Parent = this.btn6_replacement;
            this.btn6_replacement.Size = new System.Drawing.Size(31, 41);
            this.btn6_replacement.TabIndex = 26;
            this.btn6_replacement.Text = "X/O";
            this.btn6_replacement.Click += new System.EventHandler(this.btn6_replacement_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Double LMB Click to save it to favorites.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 696);
            this.Controls.Add(this.TC_WorkTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.Text = "LOC EDITOR by D.s.j.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.gunaPanel2.ResumeLayout(false);
            this.TC_Workspace.ResumeLayout(false);
            this.STR_EDIT.ResumeLayout(false);
            this.STR_EDIT.PerformLayout();
            this.ADDI_TOOLS.ResumeLayout(false);
            this.gunaPanel3.ResumeLayout(false);
            this.gunaPanel3.PerformLayout();
            this.TC_WorkTabs.ResumeLayout(false);
            this.tpg_MainWork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LV_LangStrings;
        private System.Windows.Forms.ColumnHeader columnHeader_1;
        private System.Windows.Forms.ColumnHeader columnHeader_2;
        private System.Windows.Forms.ListView LV_LangList;
        private System.Windows.Forms.ColumnHeader columnHeader_0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sameToolStripMenuItem;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI2.WinForms.Guna2Button ZoomMore_BTN;
        private Guna.UI2.WinForms.Guna2Button ZoomMinus_BTN;
        private Guna.UI2.WinForms.Guna2Button GoToNumber_BTN;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button SAVE_BTN;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.TabControl TC_Workspace;
        private System.Windows.Forms.TabPage STR_EDIT;
        private System.Windows.Forms.TabPage ADDI_TOOLS;
        private Guna.UI2.WinForms.Guna2Button Reset_strlist;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.ComboBox FindedStringz;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI.WinForms.GunaTextBox SearchBar;
        private Guna.UI.WinForms.GunaTextBox Find_TB;
        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Guna.UI2.WinForms.Guna2Button Find_BTN;
        private Guna.UI.WinForms.GunaLabel LB_DebugStr_Parse;
        private Guna.UI.WinForms.GunaPanel gunaPanel3;
        private System.Windows.Forms.TabControl TC_WorkTabs;
        private System.Windows.Forms.TabPage tpg_MainWork;
        private System.ComponentModel.BackgroundWorker BGW_Saver;
        private System.ComponentModel.BackgroundWorker BGW_Loader;
        private System.Windows.Forms.ToolTip TTIP_ResultListHoveringMessage;
        private Guna.UI2.WinForms.Guna2Button btn6_replacement;
        public System.Windows.Forms.TextBox Message_TB;
        private System.Windows.Forms.Label label2;
    }
}