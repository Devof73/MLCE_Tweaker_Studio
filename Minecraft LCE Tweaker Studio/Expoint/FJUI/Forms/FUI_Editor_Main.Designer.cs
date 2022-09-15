using FuiEditor.Forms;
namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI
{
    partial class FUI_Editor_Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip imageMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageReplaceStripMenu;
        private System.Windows.Forms.ToolStripMenuItem imageSaveStripMenu;
        private System.Windows.Forms.ContextMenuStrip imageBulkMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageBulkSave;
        private System.Windows.Forms.ToolStripMenuItem imageEditAttributeStripMenu;
        private FuiEditor.Forms.ChangableMenuListView imageListView;
        private System.Windows.Forms.PictureBox PB_SelectedIndexPreview;
        private System.Windows.Forms.Button BTN_PREVIEW_DUMP;
        private System.Windows.Forms.Button BTN_PREVIEW_REVERTCOLOR;
        private System.Windows.Forms.SplitContainer splitContainer1;
        ///Forms.ChangableMenuListView imageListView
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUI_Editor_Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplaceAllItemsToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAllImagesStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageSaveStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageReplaceStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageEditAttributeStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SITEM_LABEL_EDIT = new System.Windows.Forms.ToolStripTextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageBulkMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageBulkSave = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_PREVIEW_DUMP = new System.Windows.Forms.Button();
            this.BTN_PREVIEW_REVERTCOLOR = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageListView = new FuiEditor.Forms.ChangableMenuListView();
            this.LBL_SELECTED_PIC_SIZE = new System.Windows.Forms.Label();
            this.PB_SelectedIndexPreview = new System.Windows.Forms.PictureBox();
            this.replaceRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.imageMenuStrip.SuspendLayout();
            this.imageBulkMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SelectedIndexPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Silver;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.fileSaveStripMenu,
            this.fileSaveAsStripMenu,
            this.ReplaceAllItemsToolStripItem,
            this.fileSaveAllImagesStripMenu,
            this.exitToolStripMenuItem,
            this.restoreTagsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.toolStripSeparator3,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripSeparator4,
            this.toolStripMenuItem15});
            this.toolStripMenuItem10.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Click += new System.EventHandler(this.OnClickFileOpen);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripMenuItem12
            // 
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.OnClickFileSave);
            // 
            // toolStripMenuItem13
            // 
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.OnClickFileSaveAs);
            // 
            // toolStripMenuItem14
            // 
            resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.OnClickFileSaveAllImages);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            resources.ApplyResources(this.toolStripMenuItem15, "toolStripMenuItem15");
            this.toolStripMenuItem15.Click += new System.EventHandler(this.OnClickFileExit);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // fileSaveStripMenu
            // 
            resources.ApplyResources(this.fileSaveStripMenu, "fileSaveStripMenu");
            this.fileSaveStripMenu.Name = "fileSaveStripMenu";
            this.fileSaveStripMenu.Click += new System.EventHandler(this.fileSaveStripMenu_Click);
            // 
            // fileSaveAsStripMenu
            // 
            resources.ApplyResources(this.fileSaveAsStripMenu, "fileSaveAsStripMenu");
            this.fileSaveAsStripMenu.Name = "fileSaveAsStripMenu";
            this.fileSaveAsStripMenu.Click += new System.EventHandler(this.fileSaveAsStripMenu_Click);
            // 
            // ReplaceAllItemsToolStripItem
            // 
            resources.ApplyResources(this.ReplaceAllItemsToolStripItem, "ReplaceAllItemsToolStripItem");
            this.ReplaceAllItemsToolStripItem.Name = "ReplaceAllItemsToolStripItem";
            this.ReplaceAllItemsToolStripItem.Click += new System.EventHandler(this.ReplaceAllItemsToolStripItem_Click);
            // 
            // fileSaveAllImagesStripMenu
            // 
            resources.ApplyResources(this.fileSaveAllImagesStripMenu, "fileSaveAllImagesStripMenu");
            this.fileSaveAllImagesStripMenu.Name = "fileSaveAllImagesStripMenu";
            this.fileSaveAllImagesStripMenu.Click += new System.EventHandler(this.fileSaveAllImagesStripMenu_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restoreTagsToolStripMenuItem
            // 
            this.restoreTagsToolStripMenuItem.Name = "restoreTagsToolStripMenuItem";
            resources.ApplyResources(this.restoreTagsToolStripMenuItem, "restoreTagsToolStripMenuItem");
            this.restoreTagsToolStripMenuItem.Click += new System.EventHandler(this.RestoreTagsToolStripMenuItem_Click);
            // 
            // imageMenuStrip
            // 
            this.imageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageSaveStripMenu,
            this.imageReplaceStripMenu,
            this.imageEditAttributeStripMenu,
            this.SITEM_LABEL_EDIT});
            this.imageMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.imageMenuStrip, "imageMenuStrip");
            // 
            // imageSaveStripMenu
            // 
            this.imageSaveStripMenu.Name = "imageSaveStripMenu";
            resources.ApplyResources(this.imageSaveStripMenu, "imageSaveStripMenu");
            this.imageSaveStripMenu.Click += new System.EventHandler(this.OnClickImageSave);
            // 
            // imageReplaceStripMenu
            // 
            this.imageReplaceStripMenu.Name = "imageReplaceStripMenu";
            resources.ApplyResources(this.imageReplaceStripMenu, "imageReplaceStripMenu");
            this.imageReplaceStripMenu.Click += new System.EventHandler(this.OnClickImageReplace);
            // 
            // imageEditAttributeStripMenu
            // 
            this.imageEditAttributeStripMenu.Name = "imageEditAttributeStripMenu";
            resources.ApplyResources(this.imageEditAttributeStripMenu, "imageEditAttributeStripMenu");
            this.imageEditAttributeStripMenu.Click += new System.EventHandler(this.OnClickImageEditAttribute);
            // 
            // SITEM_LABEL_EDIT
            // 
            this.SITEM_LABEL_EDIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.SITEM_LABEL_EDIT, "SITEM_LABEL_EDIT");
            this.SITEM_LABEL_EDIT.Name = "SITEM_LABEL_EDIT";
            this.SITEM_LABEL_EDIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SITEM_LABEL_EDIT_KeyPress);
            this.SITEM_LABEL_EDIT.Click += new System.EventHandler(this.SITEM_LABEL_EDIT_Click);
            this.SITEM_LABEL_EDIT.TextChanged += new System.EventHandler(this.SITEM_LABEL_EDIT_TextChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList, "imageList");
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageBulkMenuStrip
            // 
            this.imageBulkMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceRangeToolStripMenuItem,
            this.imageBulkSave});
            this.imageBulkMenuStrip.Name = "imageBulkMenuStrip";
            resources.ApplyResources(this.imageBulkMenuStrip, "imageBulkMenuStrip");
            // 
            // imageBulkSave
            // 
            this.imageBulkSave.Name = "imageBulkSave";
            resources.ApplyResources(this.imageBulkSave, "imageBulkSave");
            this.imageBulkSave.Click += new System.EventHandler(this.OnClickImagesSave);
            // 
            // BTN_PREVIEW_DUMP
            // 
            resources.ApplyResources(this.BTN_PREVIEW_DUMP, "BTN_PREVIEW_DUMP");
            this.BTN_PREVIEW_DUMP.ForeColor = System.Drawing.Color.Black;
            this.BTN_PREVIEW_DUMP.Name = "BTN_PREVIEW_DUMP";
            this.BTN_PREVIEW_DUMP.UseVisualStyleBackColor = true;
            this.BTN_PREVIEW_DUMP.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_PREVIEW_REVERTCOLOR
            // 
            resources.ApplyResources(this.BTN_PREVIEW_REVERTCOLOR, "BTN_PREVIEW_REVERTCOLOR");
            this.BTN_PREVIEW_REVERTCOLOR.ForeColor = System.Drawing.Color.Black;
            this.BTN_PREVIEW_REVERTCOLOR.Name = "BTN_PREVIEW_REVERTCOLOR";
            this.BTN_PREVIEW_REVERTCOLOR.UseVisualStyleBackColor = true;
            this.BTN_PREVIEW_REVERTCOLOR.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LBL_SELECTED_PIC_SIZE);
            this.splitContainer1.Panel2.Controls.Add(this.BTN_PREVIEW_REVERTCOLOR);
            this.splitContainer1.Panel2.Controls.Add(this.PB_SelectedIndexPreview);
            this.splitContainer1.Panel2.Controls.Add(this.BTN_PREVIEW_DUMP);
            // 
            // imageListView
            // 
            this.imageListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.imageListView.AllowDrop = true;
            this.imageListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imageListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageListView, "imageListView");
            this.imageListView.ForeColor = System.Drawing.Color.White;
            this.imageListView.HideSelection = false;
            this.imageListView.LabelEdit = true;
            this.imageListView.LargeImageList = this.imageList;
            this.imageListView.MultiSelectedContextMenuStrip = this.imageBulkMenuStrip;
            this.imageListView.Name = "imageListView";
            this.imageListView.SingleSelectedContextMenuStrip = this.imageMenuStrip;
            this.imageListView.SmallImageList = this.imageList;
            this.imageListView.StateImageList = this.imageList;
            this.imageListView.TileSize = new System.Drawing.Size(200, 200);
            this.imageListView.UseCompatibleStateImageBehavior = false;
            this.imageListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ImageListView_AfterLabelEdit);
            this.imageListView.ItemActivate += new System.EventHandler(this.imageListView_ItemActivate);
            this.imageListView.SelectedIndexChanged += new System.EventHandler(this.imageListView_SelectedIndexChanged);
            this.imageListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.imageListView_DragDrop);
            this.imageListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.imageListView_DragEnter);
            this.imageListView.DoubleClick += new System.EventHandler(this.imageListView_DoubleClick);
            // 
            // LBL_SELECTED_PIC_SIZE
            // 
            resources.ApplyResources(this.LBL_SELECTED_PIC_SIZE, "LBL_SELECTED_PIC_SIZE");
            this.LBL_SELECTED_PIC_SIZE.Name = "LBL_SELECTED_PIC_SIZE";
            // 
            // PB_SelectedIndexPreview
            // 
            this.PB_SelectedIndexPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PB_SelectedIndexPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.PB_SelectedIndexPreview, "PB_SelectedIndexPreview");
            this.PB_SelectedIndexPreview.Name = "PB_SelectedIndexPreview";
            this.PB_SelectedIndexPreview.TabStop = false;
            this.PB_SelectedIndexPreview.DoubleClick += new System.EventHandler(this.PB_SelectedIndexPreview_DoubleClick);
            // 
            // replaceRangeToolStripMenuItem
            // 
            this.replaceRangeToolStripMenuItem.Name = "replaceRangeToolStripMenuItem";
            resources.ApplyResources(this.replaceRangeToolStripMenuItem, "replaceRangeToolStripMenuItem");
            this.replaceRangeToolStripMenuItem.Click += new System.EventHandler(this.replaceRangeToolStripMenuItem_Click);
            // 
            // FUI_Editor_Main
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FUI_Editor_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FUI_Editor_Main_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.imageMenuStrip.ResumeLayout(false);
            this.imageMenuStrip.PerformLayout();
            this.imageBulkMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_SelectedIndexPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem fileSaveStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAllImagesStripMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplaceAllItemsToolStripItem;
        private System.Windows.Forms.ToolStripTextBox SITEM_LABEL_EDIT;
        private System.Windows.Forms.ToolStripMenuItem restoreTagsToolStripMenuItem;
        private System.Windows.Forms.Label LBL_SELECTED_PIC_SIZE;
        private System.Windows.Forms.ToolStripMenuItem replaceRangeToolStripMenuItem;
    }
}

