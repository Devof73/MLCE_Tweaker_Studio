using FuiEditor.Forms;
namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI
{
    partial class EditorGUI
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
        private DarkUI.Controls.DarkContextMenu imageMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageReplaceStripMenu;
        private System.Windows.Forms.ToolStripMenuItem imageSaveStripMenu;
        private DarkUI.Controls.DarkContextMenu imageBulkMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageBulkSave;
        private System.Windows.Forms.ToolStripMenuItem imageEditAttributeStripMenu;
        private System.Windows.Forms.PictureBox PB_SelectedIndexPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        ///Forms.ChangableMenuListView imageListView
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorGUI));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedReplacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreAllTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreLegitDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpAllInvertedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceNewToMWModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createARCWithMWChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMixerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSelectedRangeInColorMixerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchToConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitAndSaveFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionIndexInvokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pVWInvokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toogleLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWUtilInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fReadLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testBend1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testBend2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testMWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMenuStrip = new DarkUI.Controls.DarkContextMenu();
            this.copySelectedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteSelectedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.previewGraphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSaveStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageReplaceStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageEditAttributeStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SITEM_LABEL_EDIT = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.debugDrawerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinGraphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinGraphicsInGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinGraphicsHudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinPS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageBulkMenuStrip = new DarkUI.Controls.DarkContextMenu();
            this.openInColorModGuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageBulkSave = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DRPDWN_WorkType = new DarkUI.Controls.DarkDropdownList();
            this.imageListView = new FuiEditor.Forms.ChangableMenuListView();
            this._RTBLOG = new System.Windows.Forms.RichTextBox();
            this.BTN_PREVIEW_DUMP = new DarkUI.Controls.DarkButton();
            this.BTN_PREVIEW_REVERTCOLOR = new DarkUI.Controls.DarkButton();
            this.LBL_SELECTED_PIC_SIZE = new System.Windows.Forms.Label();
            this.PB_SelectedIndexPreview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataBoardContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dumpAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IMGL_DataBoardThumbnails = new System.Windows.Forms.ImageList(this.components);
            this.InfoStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_SelectionIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_selected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_length = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_entries = new System.Windows.Forms.ToolStripStatusLabel();
            this._ANIM_WND = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.CMLV_DataBoard = new FuiEditor.Forms.ChangableMenuListView();
            this.menuStrip.SuspendLayout();
            this.imageMenuStrip.SuspendLayout();
            this.imageBulkMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SelectedIndexPreview)).BeginInit();
            this.dataBoardContextMenu.SuspendLayout();
            this.InfoStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNewToolStripMenuItem,
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.fileSaveStripMenu,
            this.fileSaveAsStripMenu,
            this.ReplaceAllItemsToolStripItem,
            this.fileSaveAllImagesStripMenu,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.restoreTagsToolStripMenuItem,
            this.DebugToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // openNewToolStripMenuItem
            // 
            this.openNewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openNewToolStripMenuItem.Name = "openNewToolStripMenuItem";
            resources.ApplyResources(this.openNewToolStripMenuItem, "openNewToolStripMenuItem");
            this.openNewToolStripMenuItem.Click += new System.EventHandler(this.openNewToolStripMenuItem_Click);
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
            this.toolStripMenuItem10.ForeColor = System.Drawing.Color.White;
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
            this.toolStripMenuItem9.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // fileSaveStripMenu
            // 
            resources.ApplyResources(this.fileSaveStripMenu, "fileSaveStripMenu");
            this.fileSaveStripMenu.ForeColor = System.Drawing.Color.White;
            this.fileSaveStripMenu.Name = "fileSaveStripMenu";
            this.fileSaveStripMenu.Click += new System.EventHandler(this.fileSaveStripMenu_Click);
            // 
            // fileSaveAsStripMenu
            // 
            resources.ApplyResources(this.fileSaveAsStripMenu, "fileSaveAsStripMenu");
            this.fileSaveAsStripMenu.ForeColor = System.Drawing.Color.White;
            this.fileSaveAsStripMenu.Name = "fileSaveAsStripMenu";
            this.fileSaveAsStripMenu.Click += new System.EventHandler(this.fileSaveAsStripMenu_Click);
            // 
            // ReplaceAllItemsToolStripItem
            // 
            resources.ApplyResources(this.ReplaceAllItemsToolStripItem, "ReplaceAllItemsToolStripItem");
            this.ReplaceAllItemsToolStripItem.ForeColor = System.Drawing.Color.White;
            this.ReplaceAllItemsToolStripItem.Name = "ReplaceAllItemsToolStripItem";
            this.ReplaceAllItemsToolStripItem.Click += new System.EventHandler(this.ReplaceAllItemsToolStripItem_Click);
            // 
            // fileSaveAllImagesStripMenu
            // 
            resources.ApplyResources(this.fileSaveAllImagesStripMenu, "fileSaveAllImagesStripMenu");
            this.fileSaveAllImagesStripMenu.ForeColor = System.Drawing.Color.White;
            this.fileSaveAllImagesStripMenu.Name = "fileSaveAllImagesStripMenu";
            this.fileSaveAllImagesStripMenu.Click += new System.EventHandler(this.fileSaveAllImagesStripMenu_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveNewToolStripMenuItem,
            this.advancedReplacementToolStripMenuItem,
            this.restoreAllTagsToolStripMenuItem,
            this.clearDataBoardToolStripMenuItem,
            this.restoreLegitDataToolStripMenuItem,
            this.invertAllToolStripMenuItem,
            this.dumpAllInvertedToolStripMenuItem,
            this.dumpAllToolStripMenuItem1,
            this.instanceNewToMWModeToolStripMenuItem,
            this.createARCWithMWChangesToolStripMenuItem,
            this.colorMixerToolStripMenuItem,
            this.openSelectedRangeInColorMixerToolStripMenuItem,
            this.patchToConsoleToolStripMenuItem,
            this.refreshFileToolStripMenuItem,
            this.exitAndSaveFastToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // saveNewToolStripMenuItem
            // 
            this.saveNewToolStripMenuItem.Name = "saveNewToolStripMenuItem";
            resources.ApplyResources(this.saveNewToolStripMenuItem, "saveNewToolStripMenuItem");
            // 
            // advancedReplacementToolStripMenuItem
            // 
            this.advancedReplacementToolStripMenuItem.Name = "advancedReplacementToolStripMenuItem";
            resources.ApplyResources(this.advancedReplacementToolStripMenuItem, "advancedReplacementToolStripMenuItem");
            // 
            // restoreAllTagsToolStripMenuItem
            // 
            this.restoreAllTagsToolStripMenuItem.Name = "restoreAllTagsToolStripMenuItem";
            resources.ApplyResources(this.restoreAllTagsToolStripMenuItem, "restoreAllTagsToolStripMenuItem");
            // 
            // clearDataBoardToolStripMenuItem
            // 
            this.clearDataBoardToolStripMenuItem.Name = "clearDataBoardToolStripMenuItem";
            resources.ApplyResources(this.clearDataBoardToolStripMenuItem, "clearDataBoardToolStripMenuItem");
            // 
            // restoreLegitDataToolStripMenuItem
            // 
            this.restoreLegitDataToolStripMenuItem.Name = "restoreLegitDataToolStripMenuItem";
            resources.ApplyResources(this.restoreLegitDataToolStripMenuItem, "restoreLegitDataToolStripMenuItem");
            // 
            // invertAllToolStripMenuItem
            // 
            this.invertAllToolStripMenuItem.Name = "invertAllToolStripMenuItem";
            resources.ApplyResources(this.invertAllToolStripMenuItem, "invertAllToolStripMenuItem");
            // 
            // dumpAllInvertedToolStripMenuItem
            // 
            this.dumpAllInvertedToolStripMenuItem.Name = "dumpAllInvertedToolStripMenuItem";
            resources.ApplyResources(this.dumpAllInvertedToolStripMenuItem, "dumpAllInvertedToolStripMenuItem");
            // 
            // dumpAllToolStripMenuItem1
            // 
            this.dumpAllToolStripMenuItem1.Name = "dumpAllToolStripMenuItem1";
            resources.ApplyResources(this.dumpAllToolStripMenuItem1, "dumpAllToolStripMenuItem1");
            // 
            // instanceNewToMWModeToolStripMenuItem
            // 
            this.instanceNewToMWModeToolStripMenuItem.Name = "instanceNewToMWModeToolStripMenuItem";
            resources.ApplyResources(this.instanceNewToMWModeToolStripMenuItem, "instanceNewToMWModeToolStripMenuItem");
            // 
            // createARCWithMWChangesToolStripMenuItem
            // 
            this.createARCWithMWChangesToolStripMenuItem.Name = "createARCWithMWChangesToolStripMenuItem";
            resources.ApplyResources(this.createARCWithMWChangesToolStripMenuItem, "createARCWithMWChangesToolStripMenuItem");
            // 
            // colorMixerToolStripMenuItem
            // 
            this.colorMixerToolStripMenuItem.Name = "colorMixerToolStripMenuItem";
            resources.ApplyResources(this.colorMixerToolStripMenuItem, "colorMixerToolStripMenuItem");
            // 
            // openSelectedRangeInColorMixerToolStripMenuItem
            // 
            this.openSelectedRangeInColorMixerToolStripMenuItem.Name = "openSelectedRangeInColorMixerToolStripMenuItem";
            resources.ApplyResources(this.openSelectedRangeInColorMixerToolStripMenuItem, "openSelectedRangeInColorMixerToolStripMenuItem");
            // 
            // patchToConsoleToolStripMenuItem
            // 
            this.patchToConsoleToolStripMenuItem.Name = "patchToConsoleToolStripMenuItem";
            resources.ApplyResources(this.patchToConsoleToolStripMenuItem, "patchToConsoleToolStripMenuItem");
            // 
            // refreshFileToolStripMenuItem
            // 
            this.refreshFileToolStripMenuItem.Name = "refreshFileToolStripMenuItem";
            resources.ApplyResources(this.refreshFileToolStripMenuItem, "refreshFileToolStripMenuItem");
            // 
            // exitAndSaveFastToolStripMenuItem
            // 
            this.exitAndSaveFastToolStripMenuItem.Name = "exitAndSaveFastToolStripMenuItem";
            resources.ApplyResources(this.exitAndSaveFastToolStripMenuItem, "exitAndSaveFastToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restoreTagsToolStripMenuItem
            // 
            this.restoreTagsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.restoreTagsToolStripMenuItem.Name = "restoreTagsToolStripMenuItem";
            resources.ApplyResources(this.restoreTagsToolStripMenuItem, "restoreTagsToolStripMenuItem");
            this.restoreTagsToolStripMenuItem.Click += new System.EventHandler(this.RestoreTagsToolStripMenuItem_Click);
            // 
            // DebugToolStripMenuItem
            // 
            this.DebugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionIndexInvokeToolStripMenuItem,
            this.copyDatToolStripMenuItem,
            this.pVWInvokeToolStripMenuItem,
            this.toogleLogToolStripMenuItem,
            this.cWUtilInfoToolStripMenuItem,
            this.fReadLogToolStripMenuItem,
            this.testBend1ToolStripMenuItem,
            this.testBend2ToolStripMenuItem,
            this.testMWToolStripMenuItem});
            this.DebugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem";
            resources.ApplyResources(this.DebugToolStripMenuItem, "DebugToolStripMenuItem");
            this.DebugToolStripMenuItem.Click += new System.EventHandler(this.DebugToolStripMenuItem_Click);
            // 
            // selectionIndexInvokeToolStripMenuItem
            // 
            this.selectionIndexInvokeToolStripMenuItem.Name = "selectionIndexInvokeToolStripMenuItem";
            resources.ApplyResources(this.selectionIndexInvokeToolStripMenuItem, "selectionIndexInvokeToolStripMenuItem");
            this.selectionIndexInvokeToolStripMenuItem.Click += new System.EventHandler(this.selectionIndexInvokeToolStripMenuItem_Click);
            // 
            // copyDatToolStripMenuItem
            // 
            this.copyDatToolStripMenuItem.Name = "copyDatToolStripMenuItem";
            resources.ApplyResources(this.copyDatToolStripMenuItem, "copyDatToolStripMenuItem");
            // 
            // pVWInvokeToolStripMenuItem
            // 
            this.pVWInvokeToolStripMenuItem.Name = "pVWInvokeToolStripMenuItem";
            resources.ApplyResources(this.pVWInvokeToolStripMenuItem, "pVWInvokeToolStripMenuItem");
            this.pVWInvokeToolStripMenuItem.Click += new System.EventHandler(this.pVWInvokeToolStripMenuItem_Click);
            // 
            // toogleLogToolStripMenuItem
            // 
            this.toogleLogToolStripMenuItem.Name = "toogleLogToolStripMenuItem";
            resources.ApplyResources(this.toogleLogToolStripMenuItem, "toogleLogToolStripMenuItem");
            this.toogleLogToolStripMenuItem.Click += new System.EventHandler(this.toogleLogToolStripMenuItem_Click);
            // 
            // cWUtilInfoToolStripMenuItem
            // 
            this.cWUtilInfoToolStripMenuItem.Name = "cWUtilInfoToolStripMenuItem";
            resources.ApplyResources(this.cWUtilInfoToolStripMenuItem, "cWUtilInfoToolStripMenuItem");
            this.cWUtilInfoToolStripMenuItem.Click += new System.EventHandler(this.cWUtilInfoToolStripMenuItem_Click);
            // 
            // fReadLogToolStripMenuItem
            // 
            this.fReadLogToolStripMenuItem.Name = "fReadLogToolStripMenuItem";
            resources.ApplyResources(this.fReadLogToolStripMenuItem, "fReadLogToolStripMenuItem");
            this.fReadLogToolStripMenuItem.Click += new System.EventHandler(this.fReadLogToolStripMenuItem_Click);
            // 
            // testBend1ToolStripMenuItem
            // 
            this.testBend1ToolStripMenuItem.Name = "testBend1ToolStripMenuItem";
            resources.ApplyResources(this.testBend1ToolStripMenuItem, "testBend1ToolStripMenuItem");
            this.testBend1ToolStripMenuItem.Click += new System.EventHandler(this.testBend1ToolStripMenuItem_Click);
            // 
            // testBend2ToolStripMenuItem
            // 
            this.testBend2ToolStripMenuItem.Name = "testBend2ToolStripMenuItem";
            resources.ApplyResources(this.testBend2ToolStripMenuItem, "testBend2ToolStripMenuItem");
            this.testBend2ToolStripMenuItem.Click += new System.EventHandler(this.testBend2ToolStripMenuItem_Click);
            // 
            // testMWToolStripMenuItem
            // 
            this.testMWToolStripMenuItem.Name = "testMWToolStripMenuItem";
            resources.ApplyResources(this.testMWToolStripMenuItem, "testMWToolStripMenuItem");
            this.testMWToolStripMenuItem.Click += new System.EventHandler(this.testMWToolStripMenuItem_Click);
            // 
            // imageMenuStrip
            // 
            this.imageMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.imageMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.imageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedDataToolStripMenuItem,
            this.pasteSelectedDataToolStripMenuItem,
            this.toolStripSeparator1,
            this.previewGraphicsToolStripMenuItem,
            this.inToolStripMenuItem,
            this.imageSaveStripMenu,
            this.imageReplaceStripMenu,
            this.imageEditAttributeStripMenu,
            this.SITEM_LABEL_EDIT,
            this.toolStripSeparator5,
            this.debugDrawerToolStripMenuItem,
            this.skinGraphicsToolStripMenuItem,
            this.skinGraphicsInGameToolStripMenuItem,
            this.skinGraphicsHudToolStripMenuItem,
            this.skinPS3ToolStripMenuItem,
            this.introToolStripMenuItem});
            this.imageMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.imageMenuStrip, "imageMenuStrip");
            this.imageMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.imageMenuStrip_Opening);
            // 
            // copySelectedDataToolStripMenuItem
            // 
            this.copySelectedDataToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.copySelectedDataToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.copySelectedDataToolStripMenuItem.Name = "copySelectedDataToolStripMenuItem";
            this.copySelectedDataToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.copySelectedDataToolStripMenuItem, "copySelectedDataToolStripMenuItem");
            this.copySelectedDataToolStripMenuItem.Click += new System.EventHandler(this.copySelectedDataToolStripMenuItem_Click);
            // 
            // pasteSelectedDataToolStripMenuItem
            // 
            this.pasteSelectedDataToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pasteSelectedDataToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pasteSelectedDataToolStripMenuItem.Name = "pasteSelectedDataToolStripMenuItem";
            this.pasteSelectedDataToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.pasteSelectedDataToolStripMenuItem, "pasteSelectedDataToolStripMenuItem");
            this.pasteSelectedDataToolStripMenuItem.Click += new System.EventHandler(this.pasteSelectedDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // previewGraphicsToolStripMenuItem
            // 
            this.previewGraphicsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.previewGraphicsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.previewGraphicsToolStripMenuItem.Name = "previewGraphicsToolStripMenuItem";
            this.previewGraphicsToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.previewGraphicsToolStripMenuItem, "previewGraphicsToolStripMenuItem");
            this.previewGraphicsToolStripMenuItem.Click += new System.EventHandler(this.previewGraphicsToolStripMenuItem_Click);
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.inToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.inToolStripMenuItem, "inToolStripMenuItem");
            this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // imageSaveStripMenu
            // 
            this.imageSaveStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.imageSaveStripMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.imageSaveStripMenu.Name = "imageSaveStripMenu";
            this.imageSaveStripMenu.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.imageSaveStripMenu, "imageSaveStripMenu");
            this.imageSaveStripMenu.Click += new System.EventHandler(this.OnClickImageSave);
            // 
            // imageReplaceStripMenu
            // 
            this.imageReplaceStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.imageReplaceStripMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.imageReplaceStripMenu.Name = "imageReplaceStripMenu";
            this.imageReplaceStripMenu.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.imageReplaceStripMenu, "imageReplaceStripMenu");
            this.imageReplaceStripMenu.Click += new System.EventHandler(this.OnClickImageReplace);
            // 
            // imageEditAttributeStripMenu
            // 
            this.imageEditAttributeStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.imageEditAttributeStripMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.imageEditAttributeStripMenu.Name = "imageEditAttributeStripMenu";
            this.imageEditAttributeStripMenu.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.imageEditAttributeStripMenu, "imageEditAttributeStripMenu");
            this.imageEditAttributeStripMenu.Click += new System.EventHandler(this.OnClickImageEditAttribute);
            // 
            // SITEM_LABEL_EDIT
            // 
            this.SITEM_LABEL_EDIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.SITEM_LABEL_EDIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.SITEM_LABEL_EDIT, "SITEM_LABEL_EDIT");
            this.SITEM_LABEL_EDIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SITEM_LABEL_EDIT.Name = "SITEM_LABEL_EDIT";
            this.SITEM_LABEL_EDIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SITEM_LABEL_EDIT_KeyPress);
            this.SITEM_LABEL_EDIT.Click += new System.EventHandler(this.SITEM_LABEL_EDIT_Click);
            this.SITEM_LABEL_EDIT.TextChanged += new System.EventHandler(this.SITEM_LABEL_EDIT_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // debugDrawerToolStripMenuItem
            // 
            this.debugDrawerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.debugDrawerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.debugDrawerToolStripMenuItem.Name = "debugDrawerToolStripMenuItem";
            this.debugDrawerToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.debugDrawerToolStripMenuItem, "debugDrawerToolStripMenuItem");
            this.debugDrawerToolStripMenuItem.Click += new System.EventHandler(this.debugDrawerToolStripMenuItem_Click);
            // 
            // skinGraphicsToolStripMenuItem
            // 
            this.skinGraphicsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.skinGraphicsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinGraphicsToolStripMenuItem.Name = "skinGraphicsToolStripMenuItem";
            resources.ApplyResources(this.skinGraphicsToolStripMenuItem, "skinGraphicsToolStripMenuItem");
            // 
            // skinGraphicsInGameToolStripMenuItem
            // 
            this.skinGraphicsInGameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.skinGraphicsInGameToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinGraphicsInGameToolStripMenuItem.Name = "skinGraphicsInGameToolStripMenuItem";
            resources.ApplyResources(this.skinGraphicsInGameToolStripMenuItem, "skinGraphicsInGameToolStripMenuItem");
            // 
            // skinGraphicsHudToolStripMenuItem
            // 
            this.skinGraphicsHudToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.skinGraphicsHudToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinGraphicsHudToolStripMenuItem.Name = "skinGraphicsHudToolStripMenuItem";
            resources.ApplyResources(this.skinGraphicsHudToolStripMenuItem, "skinGraphicsHudToolStripMenuItem");
            // 
            // skinPS3ToolStripMenuItem
            // 
            this.skinPS3ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.skinPS3ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinPS3ToolStripMenuItem.Name = "skinPS3ToolStripMenuItem";
            resources.ApplyResources(this.skinPS3ToolStripMenuItem, "skinPS3ToolStripMenuItem");
            // 
            // introToolStripMenuItem
            // 
            this.introToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.introToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.introToolStripMenuItem.Name = "introToolStripMenuItem";
            resources.ApplyResources(this.introToolStripMenuItem, "introToolStripMenuItem");
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList, "imageList");
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageBulkMenuStrip
            // 
            this.imageBulkMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.imageBulkMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.imageBulkMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInColorModGuiToolStripMenuItem,
            this.toolStripMenuItem1,
            this.replaceRangeToolStripMenuItem,
            this.imageBulkSave});
            this.imageBulkMenuStrip.Name = "imageBulkMenuStrip";
            resources.ApplyResources(this.imageBulkMenuStrip, "imageBulkMenuStrip");
            // 
            // openInColorModGuiToolStripMenuItem
            // 
            this.openInColorModGuiToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openInColorModGuiToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openInColorModGuiToolStripMenuItem.Name = "openInColorModGuiToolStripMenuItem";
            resources.ApplyResources(this.openInColorModGuiToolStripMenuItem, "openInColorModGuiToolStripMenuItem");
            this.openInColorModGuiToolStripMenuItem.Click += new System.EventHandler(this.openInColorModGuiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // replaceRangeToolStripMenuItem
            // 
            this.replaceRangeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.replaceRangeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.replaceRangeToolStripMenuItem.Name = "replaceRangeToolStripMenuItem";
            resources.ApplyResources(this.replaceRangeToolStripMenuItem, "replaceRangeToolStripMenuItem");
            this.replaceRangeToolStripMenuItem.Click += new System.EventHandler(this.replaceRangeToolStripMenuItem_Click);
            // 
            // imageBulkSave
            // 
            this.imageBulkSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.imageBulkSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.imageBulkSave.Name = "imageBulkSave";
            resources.ApplyResources(this.imageBulkSave, "imageBulkSave");
            this.imageBulkSave.Click += new System.EventHandler(this.OnClickImagesSave);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DRPDWN_WorkType);
            this.splitContainer1.Panel1.Controls.Add(this.imageListView);
            this.splitContainer1.Panel1.Controls.Add(this._RTBLOG);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BTN_PREVIEW_DUMP);
            this.splitContainer1.Panel2.Controls.Add(this.BTN_PREVIEW_REVERTCOLOR);
            this.splitContainer1.Panel2.Controls.Add(this.LBL_SELECTED_PIC_SIZE);
            this.splitContainer1.Panel2.Controls.Add(this.PB_SelectedIndexPreview);
            // 
            // DRPDWN_WorkType
            // 
            resources.ApplyResources(this.DRPDWN_WorkType, "DRPDWN_WorkType");
            this.DRPDWN_WorkType.Name = "DRPDWN_WorkType";
            // 
            // imageListView
            // 
            this.imageListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.imageListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
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
            // _RTBLOG
            // 
            resources.ApplyResources(this._RTBLOG, "_RTBLOG");
            this._RTBLOG.Name = "_RTBLOG";
            // 
            // BTN_PREVIEW_DUMP
            // 
            resources.ApplyResources(this.BTN_PREVIEW_DUMP, "BTN_PREVIEW_DUMP");
            this.BTN_PREVIEW_DUMP.Name = "BTN_PREVIEW_DUMP";
            // 
            // BTN_PREVIEW_REVERTCOLOR
            // 
            resources.ApplyResources(this.BTN_PREVIEW_REVERTCOLOR, "BTN_PREVIEW_REVERTCOLOR");
            this.BTN_PREVIEW_REVERTCOLOR.Name = "BTN_PREVIEW_REVERTCOLOR";
            // 
            // LBL_SELECTED_PIC_SIZE
            // 
            resources.ApplyResources(this.LBL_SELECTED_PIC_SIZE, "LBL_SELECTED_PIC_SIZE");
            this.LBL_SELECTED_PIC_SIZE.Name = "LBL_SELECTED_PIC_SIZE";
            // 
            // PB_SelectedIndexPreview
            // 
            this.PB_SelectedIndexPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.PB_SelectedIndexPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.PB_SelectedIndexPreview, "PB_SelectedIndexPreview");
            this.PB_SelectedIndexPreview.Name = "PB_SelectedIndexPreview";
            this.PB_SelectedIndexPreview.TabStop = false;
            this.PB_SelectedIndexPreview.Click += new System.EventHandler(this.PB_SelectedIndexPreview_Click);
            this.PB_SelectedIndexPreview.DoubleClick += new System.EventHandler(this.PB_SelectedIndexPreview_DoubleClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.AutoEllipsis = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ContextMenuStrip = this.dataBoardContextMenu;
            this.label1.Name = "label1";
            // 
            // dataBoardContextMenu
            // 
            this.dataBoardContextMenu.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.dataBoardContextMenu, "dataBoardContextMenu");
            this.dataBoardContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripSeparator2,
            this.dumpAllToolStripMenuItem,
            this.dumpSelectedToolStripMenuItem});
            this.dataBoardContextMenu.Name = "dataBoardContextMenu";
            this.dataBoardContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // dumpAllToolStripMenuItem
            // 
            this.dumpAllToolStripMenuItem.Name = "dumpAllToolStripMenuItem";
            resources.ApplyResources(this.dumpAllToolStripMenuItem, "dumpAllToolStripMenuItem");
            this.dumpAllToolStripMenuItem.Click += new System.EventHandler(this.dumpAllToolStripMenuItem_Click);
            // 
            // dumpSelectedToolStripMenuItem
            // 
            this.dumpSelectedToolStripMenuItem.Name = "dumpSelectedToolStripMenuItem";
            resources.ApplyResources(this.dumpSelectedToolStripMenuItem, "dumpSelectedToolStripMenuItem");
            this.dumpSelectedToolStripMenuItem.Click += new System.EventHandler(this.dumpSelectedToolStripMenuItem_Click);
            // 
            // IMGL_DataBoardThumbnails
            // 
            this.IMGL_DataBoardThumbnails.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.IMGL_DataBoardThumbnails, "IMGL_DataBoardThumbnails");
            this.IMGL_DataBoardThumbnails.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // InfoStrip1
            // 
            this.InfoStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.InfoStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_SelectionIndex,
            this.lbl_selected,
            this.lbl_length,
            this.lbl_entries});
            resources.ApplyResources(this.InfoStrip1, "InfoStrip1");
            this.InfoStrip1.Name = "InfoStrip1";
            // 
            // lbl_SelectionIndex
            // 
            this.lbl_SelectionIndex.Name = "lbl_SelectionIndex";
            resources.ApplyResources(this.lbl_SelectionIndex, "lbl_SelectionIndex");
            // 
            // lbl_selected
            // 
            this.lbl_selected.Name = "lbl_selected";
            resources.ApplyResources(this.lbl_selected, "lbl_selected");
            // 
            // lbl_length
            // 
            this.lbl_length.Name = "lbl_length";
            resources.ApplyResources(this.lbl_length, "lbl_length");
            // 
            // lbl_entries
            // 
            this.lbl_entries.Name = "lbl_entries";
            resources.ApplyResources(this.lbl_entries, "lbl_entries");
            // 
            // _ANIM_WND
            // 
            this._ANIM_WND.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this._ANIM_WND.Interval = 500;
            // 
            // CMLV_DataBoard
            // 
            resources.ApplyResources(this.CMLV_DataBoard, "CMLV_DataBoard");
            this.CMLV_DataBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.CMLV_DataBoard.ContextMenuStrip = this.dataBoardContextMenu;
            this.CMLV_DataBoard.HideSelection = false;
            this.CMLV_DataBoard.LargeImageList = this.IMGL_DataBoardThumbnails;
            this.CMLV_DataBoard.MultiSelectedContextMenuStrip = null;
            this.CMLV_DataBoard.Name = "CMLV_DataBoard";
            this.CMLV_DataBoard.SingleSelectedContextMenuStrip = null;
            this.CMLV_DataBoard.SmallImageList = this.IMGL_DataBoardThumbnails;
            this.CMLV_DataBoard.TileSize = new System.Drawing.Size(200, 200);
            this.CMLV_DataBoard.UseCompatibleStateImageBehavior = false;
            this.CMLV_DataBoard.SelectedIndexChanged += new System.EventHandler(this.CMLV_DataBoard_SelectedIndexChanged);
            this.CMLV_DataBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CMLV_DataBoard_MouseClick);
            this.CMLV_DataBoard.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CMLV_DataBoard_MouseDoubleClick);
            // 
            // EditorGUI
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InfoStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.CMLV_DataBoard);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "EditorGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FUI_Editor_Main_FormClosed_1);
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
            this.dataBoardContextMenu.ResumeLayout(false);
            this.InfoStrip1.ResumeLayout(false);
            this.InfoStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteSelectedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
       
        public ChangableMenuListView CMLV_DataBoard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList IMGL_DataBoardThumbnails;
        private System.Windows.Forms.ContextMenuStrip dataBoardContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dumpAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNewToolStripMenuItem;
        private System.Windows.Forms.StatusStrip InfoStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_selected;
        private System.Windows.Forms.ToolStripStatusLabel lbl_entries;
        private System.Windows.Forms.ToolStripStatusLabel lbl_length;
        private System.Windows.Forms.ToolStripMenuItem openInColorModGuiToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lbl_SelectionIndex;
        private System.Windows.Forms.ToolStripMenuItem previewGraphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugDrawerToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        public ChangableMenuListView imageListView;
        private System.Windows.Forms.ToolStripMenuItem DebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionIndexInvokeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pVWInvokeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toogleLogToolStripMenuItem;
        private System.Windows.Forms.RichTextBox _RTBLOG;
        private System.Windows.Forms.ToolStripMenuItem cWUtilInfoToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2AnimateWindow _ANIM_WND;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private DarkUI.Controls.DarkButton BTN_PREVIEW_DUMP;
        private DarkUI.Controls.DarkButton BTN_PREVIEW_REVERTCOLOR;
        private System.Windows.Forms.ToolStripMenuItem fReadLogToolStripMenuItem;
        private DarkUI.Controls.DarkDropdownList DRPDWN_WorkType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem skinGraphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinGraphicsInGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinGraphicsHudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinPS3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedReplacementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreAllTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDataBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreLegitDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpAllInvertedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem instanceNewToMWModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createARCWithMWChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorMixerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSelectedRangeInColorMixerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchToConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitAndSaveFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testBend1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testBend2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testMWToolStripMenuItem;
    }
}

