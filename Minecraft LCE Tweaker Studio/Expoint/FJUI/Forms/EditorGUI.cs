using FuiEditor;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Minecraft_LCE_Tweaker_Studio.Expoint.CMIX;
using Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms;
using FuiEditor.Forms;
using MetroFramework.Controls;
using System.Runtime.InteropServices;
using DiscordRPC.Logging;
using System.Diagnostics;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI
{
    public partial class EditorGUI : Form
    {
        private static readonly byte[] PngStartPattern =
        {
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A
        };

        private string currentOpenFui = null;
        private bool shouldSaveFui = false;
        private List<FuiImageInfo> fuiImageInfo = new List<FuiImageInfo>();
        private List<byte[]> originalImagesData = new List<byte[]>();
        private List<ImageFormat> originalImageFormats = new List<ImageFormat>();
        private List<string> OriginalCurrentImagesSizes = new List<string>();
        private List<byte[]> DataBoardItems = new List<byte[]>();
        private _RuntimeLog RLog = new _RuntimeLog();
        private ToolStripMenuItem[] _DynamicContextButtons;
        private List<ImageList> MwModeThumbnails = null;
        private List<ChangableMenuListView> MwModeTypesGuis = null;
        private List<byte[]> MwTypesData = new List<byte[]>();
        private bool MWMode = false;
        static MinecraftLegacyConsoleRE mcre = new MinecraftLegacyConsoleRE();
        public string CurrentFuiFileName { get { return currentOpenFui; } }
        public List<byte[]> InstanceData
        {
            get { return originalImagesData; }
        }
        #region AppBackend
        public EditorGUI(string filepath)
        {
            InitializeComponent();
            DefaultInitialization(filepath);
            _ANIM_WND.SetAnimateWindow(this, Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND, 600);
            DRPDWN_WorkType.Enabled = false;
        }
        /// <summary>
        /// INSTANCE EDITOR GUI FOR MULTIEDITING
        /// </summary>
        /// <param name="Folderpath"></param>
        /// <param name="Multi"></param>
        public EditorGUI(string folderpath, bool Multi)
        {
            var Folderpath = folderpath;
            Console.WriteLine("DI = " + Folderpath);
            string[] types = mcre.SkinTypesR;
           
            MWMode = Multi;
            if (Multi)
            {
                MwModeTypesGuis = new List<ChangableMenuListView>();
                MwModeThumbnails = new List<ImageList>();
                DRPDWN_WorkType.Enabled = true;
                DRPDWN_WorkType.SelectedItemChanged += DRPDWN_WorkType_SelectedItemChanged;
                for (int i = 0; i < types.Length; i++)
                {
                    var file = Folderpath + "\\" + types[i] + ".fui";
                    if (File.Exists(file))
                    {
                        var data = File.ReadAllBytes(file);
                        MwTypesData.Add(data);
                    }
                    if (types[i] is null)
                    {
                        MessageBox.Show(String.Format("ERR: Types[{0}] returned null", i));
                        Environment.Exit(0x0);
                    }
                }
                for (int i = 0; i < MwTypesData.Count; i++)
                {
                    DRPDWN_WorkType.Items.Add(new DarkUI.Controls.DarkDropdownItem(types[i]));

                    var gui = new ChangableMenuListView();
                    var imgl = new ImageList();
                    OpenFui(MwTypesData[i], gui, imgl);
                    gui.LargeImageList = imgl;
                    gui.SmallImageList = imgl;

                    MwModeThumbnails.Add(imgl);
                    MwModeTypesGuis.Add(gui);

                    if (MwTypesData[i] is null)
                    {
                        MessageBox.Show(String.Format("ERR: MwTypesData[{0}] returned null", i));
                        Environment.Exit(0x0);
                    }
                }
            }
            else
            {
                Close();
            }

        }
        public new void Dispose()
        {
            RLog = null;
            imageList.Dispose();
            originalImageFormats = null;
            DataBoardItems = null;
            originalImagesData = null;
            OriginalCurrentImagesSizes = null;
            Dispose(true);
        }
        private void DRPDWN_WorkType_SelectedItemChanged(object sender, EventArgs e)
        {
            int index = DRPDWN_WorkType.Items.IndexOf(DRPDWN_WorkType.SelectedItem);
            if (index != -1)
            {
                MW_SETLISTITEMS(imageListView, MwModeTypesGuis[index]);
            }
           
        }
        private void MW_SETLISTITEMS(ChangableMenuListView @base, ChangableMenuListView target)
        {
            @base.LargeImageList = target.LargeImageList;
            @base.SmallImageList = target.SmallImageList;
            var items = target.Items;
            @base.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                @base.Items.Add(items[i]);
            }
        }
        internal void GhostInitialization()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Visible = false;
            }
        }
        internal void DefaultInitialization(string filepath)
        {
            Bitmap Ico = Properties.Resources.card_multiple;
            IntPtr Hicon = Ico.GetHicon();
            Icon myIcon = Icon.FromHandle(Hicon);
            Icon = myIcon;
            Ico.Dispose();
            myIcon.Dispose();
            _DynamicContextButtons = new ToolStripMenuItem[5] 
            {   
                skinGraphicsToolStripMenuItem,
                skinGraphicsInGameToolStripMenuItem,
                skinGraphicsHudToolStripMenuItem,
                skinPS3ToolStripMenuItem,
                introToolStripMenuItem
            };

            imageList.ColorDepth = ColorDepth.Depth32Bit;
            OpenFui(filepath);
            this.Text = "FJ UI Graphics || " + Path.GetFileName(filepath);
            InAppUserSettings.Default.S_Ins_Fui = InAppUserSettings.Default.S_Ins_Fui + 1;
            InitListSetMarks(filepath);
            Ico.Dispose();
            myIcon.Dispose();
        }
        private void OnClickFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Fui files (*.fui)|*.fui|All Files (*.*)|*.*";
            fileDialog.RestoreDirectory = true;
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                OriginalCurrentImagesSizes.Clear();
                string filepath = fileDialog.FileName;
                OpenFui(filepath);
                this.Text = "F.J.U.I. = " + filepath;
            }
            fileDialog.Dispose();
        }
        private void OnClickFileSave(object sender, EventArgs e)
        {
            SaveFui(currentOpenFui);
        }
        private void OnClickFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                Filter = "Fui Files (*.fui)|*.fui",
                Title = "",
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                SaveFui(filepath);
            }
            fileDialog.Dispose();
        }
        private void OnClickFileExit(object sender, EventArgs e)
        {
            Close();
        }
        private void OnClickImageReplace(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show("No image selected.", "Error");
                return;
            }
            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
               "Correcting color..", false);
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("")
            {
                Filters =
                {
                    new CommonFileDialogFilter("PNG", "*.png"),
                    new CommonFileDialogFilter("JPEG", "*.jpg;*.jpeg"),
                    new CommonFileDialogFilter("All files", "*.*")
                },
                Controls =
                {
                    correctColorCb
                },
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                int selected = imageListView.SelectedIndices[0];
                string filepath = fileDialog.FileName;
                byte[] filedata = File.ReadAllBytes(filepath);
                ImageFormat originalFormat = originalImageFormats[selected];

                using (MemoryStream stream = new MemoryStream(filedata, false))
                {
                    Image imageLoaded = Image.FromStream(stream);

                    if (!correctColorCb.IsChecked && originalFormat == imageLoaded.RawFormat)
                    {
                        originalImagesData[selected] = filedata;
                    }
                    else
                    {
                        if (correctColorCb.IsChecked)
                        {
                            ImageUtils.ReverseColorRB((Bitmap)imageLoaded);
                        }

                        MemoryStream saveStream = new MemoryStream();

                        imageLoaded.Save(saveStream, originalFormat);
                        originalImagesData[selected] = saveStream.ToArray();

                        saveStream.Dispose();
                    }

                    imageList.Images[selected].Dispose();
                    imageList.Images[selected] = ImageUtils.CreateThumbnail(imageLoaded, imageList.ImageSize);
                    imageListView.Items[selected].Text = $"{imageLoaded.Width}x{imageLoaded.Height}";

                    imageLoaded.Dispose();
                }

                shouldSaveFui = true;
            }
        }
        private void OnClickImageSave(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show("", "");
                return;
            }

            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
               "Save correcting color", false);

            ImageFormat[] imageFormats =
            {
                ImageFormat.Png,
                ImageFormat.Jpeg
            };

            CommonSaveFileDialog fileDialog = new CommonSaveFileDialog("")
            {
                Filters =
                {
                    new CommonFileDialogFilter("PNG", "*.png"),
                    new CommonFileDialogFilter("JPEG", "*.jpg;*.jpeg")
                },
                Controls =
                {
                    correctColorCb
                },
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string filepath = fileDialog.FileName;
                int selected = imageListView.SelectedIndices[0];
                byte[] imageData = originalImagesData[selected];
                ImageFormat saveFormat = imageFormats[fileDialog.SelectedFileTypeIndex - 1];
                ImageFormat imageFormat = originalImageFormats[selected];

                if (!correctColorCb.IsChecked && saveFormat == imageFormat)
                {
                    File.WriteAllBytes(filepath, imageData);
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image imageSave = Image.FromStream(stream);

                        if (correctColorCb.IsChecked)
                        {
                            ImageUtils.ReverseColorRB((Bitmap)imageSave);
                        }

                        imageSave.Save(filepath, saveFormat);
                        imageSave.Dispose();
                    }
                }
            }

            fileDialog.Dispose();
        }
        private void OnClickFileSaveAllImages(object sender, EventArgs e)
        {
            Dictionary<ImageFormat, string> extensions = new Dictionary<ImageFormat, string>()
            {
                {
                    ImageFormat.Png, ".png"
                },
                {
                    ImageFormat.Jpeg, ".jpg"
                }
            };

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("")
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                string filepathBase = Path.Combine(directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");


                for (int i = 0; i < originalImageFormats.Count; i++)
                {
                    ImageFormat imageFormat = originalImageFormats[i];
                    FuiImageInfo imageInfo = fuiImageInfo[i];
                    int attribute = imageInfo.Attribute;
                    string filepath;

                    if (extensions.ContainsKey(imageFormat))
                    {
                        string extension = extensions[imageFormat];

                        filepath = string.Format(filepathBase, i, extension);
                    }
                    else
                    {
                        filepath = string.Format(filepathBase, i, ".unknown");
                    }

                    File.WriteAllBytes(filepath, originalImagesData[i]);
                }
            }
        }
        private void OnClickImageEditAttribute(object sender, EventArgs e)
        {
            throw new NotImplementedException("Edit Attribute");
        }
        private void OnClickImagesSave(object sender, EventArgs e)
        {
            Dictionary<ImageFormat, string> extensions = new Dictionary<ImageFormat, string>()
            {
                {
                    ImageFormat.Png, ".png"
                },
                {
                    ImageFormat.Jpeg, ".jpg"
                }
            };

            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
                "", false);

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("")
            {
                Controls =
                {
                    correctColorCb
                },
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                string filepathBase = Path.Combine(
                    directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");
                int[] selectedIndices = imageListView.SelectedIndices.Cast<int>().ToArray();

                for (int i = 0; i < selectedIndices.Length; i++)
                {
                    int selected = selectedIndices[i];
                    ImageFormat imageFormat = originalImageFormats[selected];
                    FuiImageInfo imageInfo = fuiImageInfo[selected];
                    byte[] filedata = originalImagesData[selected];
                    string filepath;

                    if (extensions.ContainsKey(imageFormat))
                    {
                        string extension = extensions[imageFormat];

                        filepath = string.Format(filepathBase, i, extension);
                    }
                    else
                    {
                        filepath = string.Format(filepathBase, i, ".unknown");
                    }

                    if (!correctColorCb.IsChecked)
                    {
                        File.WriteAllBytes(filepath, filedata);
                    }
                    else
                    {
                        using (MemoryStream stream = new MemoryStream(filedata, false))
                        {
                            Image imageSave = Image.FromStream(stream);

                            ImageUtils.ReverseColorRB((Bitmap)imageSave);
                            imageSave.Save(filepath, imageFormat);

                            imageSave.Dispose();
                        }
                    }
                }
            }
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {

            if (shouldSaveFui && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = NotifySave();
            }

        }
        private void OnOpendFui(string filepath)
        {
            currentOpenFui = filepath;
            fileSaveStripMenu.Enabled = true;
            fileSaveAsStripMenu.Enabled = true;
            fileSaveAllImagesStripMenu.Enabled = true;
            ReplaceAllItemsToolStripItem.Enabled = true;
            SetStatus(Path.GetFileName(filepath));
        }
        private void OnOpenFui()
        {
            foreach (Image image in imageList.Images)
            {
                image.Dispose();
            }
            fuiImageInfo.Clear();
            originalImagesData.Clear();
            originalImageFormats.Clear();
            imageList.Images.Clear();
            imageListView.Items.Clear();
            currentOpenFui = null;
            ReplaceAllItemsToolStripItem.Enabled = false;
            fileSaveStripMenu.Enabled = false;
            fileSaveAsStripMenu.Enabled = false;
            shouldSaveFui = false;
            fileSaveAllImagesStripMenu.Enabled = false;

            SetStatus(null);
        }
        private void OnSavedFui(string filepath)
        {
            shouldSaveFui = false;
            MessageBox.Show(string.Format("Sucessfully saved FUI.\r{0}", filepath));
        }
        private bool  NotifySave()
        {
            DialogResult result = MessageBox.Show("You work should be saved! All" +
                " unsaved changes will be lost!\ryes: close\rno: cancel", "Are you sure from close?",
                MessageBoxButtons.YesNo, icon: MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                return false;
            }

            return true;
        }
        private void SetStatus(string message)
        {
            if (message != null)
            {
                Text = message + " - Fui Editor";
            }
            else
            {
                Text = "Fui Editor";
            }
        }
        private void OpenFui(string filepath)
        { 
            
            OnOpenFui();
            MinecraftLegacyConsoleRE.GameFile_FUI @File = new MinecraftLegacyConsoleRE.GameFile_FUI(filepath);
            //var imagesData = @File.FullData;
            var imgDat = @File.ImagesData;
            var imgInfo = File.ImagesInfos;
            /*
            int pngIndex = ArrayUtils.SearchBytes(filedata, 0, PngStartPattern);
            if (pngIndex < 0)
            {
                return;
            }

            FuiImageInfo[] imageInfo = FuiUtils.GetImageInfo(filedata, pngIndex);
            List<byte[]> imagesData = FuiUtils.GetImagesData(filedata, pngIndex, imageInfo);
            originalImagesData.AddRange(imagesData);
            */
            
            for (int i = 0; i < imgDat.Count; i++)
            {
                byte[] imageData = imgDat[i];
                using (MemoryStream stream = new MemoryStream(imageData, false))
                {
                    Image image = Image.FromStream(stream);
                    originalImageFormats.Add(image.RawFormat);
                    imageList.Images.Add(ImageUtils.CreateThumbnail(image, imageList.ImageSize));
                    imageListView.Items.Add($"{image.Width}x{image.Height}", i);
                    OriginalCurrentImagesSizes.Add($"{image.Width}x{image.Height}");
                    image.Dispose();
                    imageListView.Items[i].Tag = i;
                }
            }
            lbl_selected.Text = "Total entries: " + imageListView.Items.Count;
            //fuiMainBytes = filedata.Take(pngIndex - imageInfo.Length * FuiImageInfo.NativeSize).ToArray();
            fuiImageInfo.AddRange(imgInfo);
            OnOpendFui(filepath);
        }
        private void OpenFui(string filepath, ChangableMenuListView imageViewer, ImageList ImageList)
        {
            fuiImageInfo.Clear();
            OnOpenFui();
            MinecraftLegacyConsoleRE.GameFile_FUI @File = new MinecraftLegacyConsoleRE.GameFile_FUI(filepath);
            var imgDat = File.ImagesData;
            var imgInfo = File.ImagesInfos;

            for (int i = 0; i < imgDat.Count; i++)
            {
                byte[] imageData = imgDat[i];
                using (MemoryStream stream = new MemoryStream(imageData, false))
                {
                    Image image = Image.FromStream(stream);
                    originalImageFormats.Add(image.RawFormat);
                    ImageList.Images.Add(ImageUtils.CreateThumbnail(image, ImageList.ImageSize));
                    imageViewer.Items.Add($"{image.Width}x{image.Height}", i);
                    OriginalCurrentImagesSizes.Add($"{image.Width}x{image.Height}");
                    image.Dispose();
                    imageViewer.Items[i].Tag = i;
                }
            }
            
            //fuiMainBytes = filedata.Take(pngIndex - imageInfo.Length * FuiImageInfo.NativeSize).ToArray();
            fuiImageInfo.AddRange(imgInfo);
            OnOpendFui(filepath);
        }
        private void OpenFui(byte[] data, ChangableMenuListView imageViewer, ImageList ImageList)
        {
            MinecraftLegacyConsoleRE.GameFile_FUI @File = new MinecraftLegacyConsoleRE.GameFile_FUI(data);
            var imgDat = File.ImagesData;
            for (int i = 0; i < imgDat.Count; i++)
            {
                byte[] imageData = imgDat[i];
                using (MemoryStream stream = new MemoryStream(imageData, false))
                {
                    Image image = Image.FromStream(stream);
                    originalImageFormats.Add(image.RawFormat);
                    ImageList.Images.Add(ImageUtils.CreateThumbnail(image, ImageList.ImageSize));
                    imageViewer.Items.Add($"{image.Width}x{image.Height}", i);
                    OriginalCurrentImagesSizes.Add($"{image.Width}x{image.Height}");
                    image.Dispose();
                    imageViewer.Items[i].Tag = i;
                }
            }
        }
        private void SaveFui(string filepath)
        {
            List<byte> fuiBytes = new List<byte>();
            List<byte> imageSection = new List<byte>();
            int currentOffset = 0;
            for (int i = 0; i < fuiImageInfo.Count; i++)
            {
                FuiImageInfo imageInfo = fuiImageInfo[i];
                using (MemoryStream imageStream = new MemoryStream(originalImagesData[i], false))
                {
                    Image imageSave = Image.FromStream(imageStream);

                    byte[] imageBytes = originalImagesData[i];
                    imageInfo.Width = imageSave.Width;
                    imageInfo.Height = imageSave.Height;
                    imageInfo.ImageOffset = currentOffset;
                    imageInfo.ImageSize = imageBytes.Length;

                    fuiBytes.AddRange(imageInfo.ToByteArray());
                    imageSection.AddRange(imageBytes);

                    currentOffset += imageBytes.Length;
                    imageSave.Dispose();
                }
            }

            fuiBytes.AddRange(imageSection);
            File.WriteAllBytes(filepath, FuiUtils.ProcessHeader(fuiBytes.ToArray()));

            OnSavedFui(filepath);
        }
        private void imageListView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string s = (string)e.Data.GetData(DataFormats.FileDrop);
            OpenFui(s);
            foreach (string file in files) RLog.WriteLine(file);


        }
        private void imageListView_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string s = (string)e.Data.GetData(DataFormats.FileDrop);
            OpenFui(s);
            foreach (string file in files) RLog.WriteLine(file);
        }

        private void imageListView_ItemActivate(object sender, EventArgs e)
        {



        }
        internal Image ImageListSelectedToBitmap()
        {
            int selected = imageListView.SelectedIndices[0];
            byte[] imageData = originalImagesData[selected];
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                Image imageValue = Image.FromStream(stream);
                stream.Dispose();

                return imageValue;

            }
        }
        private void imageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count > 0)
            {
                try
                {
                    var i = imageListView.SelectedIndices[0];
                    RLog.WriteBoolean(i != 0);
                    LBL_SELECTED_PIC_SIZE.Text = OriginalCurrentImagesSizes[i];
                    lbl_selected.Text = "Selected Indices: " + imageListView.SelectedItems.Count;
                    lbl_length.Text = string.Format("Selected Data Length: {0} bytes", originalImagesData[i].Length);
                    lbl_entries.Text = "Total entries: " + imageListView.Items.Count;
                    lbl_SelectionIndex.Text = string.Format("Index: {0}", imageListView.SelectedIndices[i]);

                    PB_SelectedIndexPreview.Image = ImageListSelectedToBitmap();
                }
                catch (Exception ex)
                {
                    RLog.WriteLine(string.Format("[{0}] ERROR : {1}, {2}, {3}, {4}", DateTime.Now.ToLongTimeString(), ex.Message
                        , ex.StackTrace, ex.TargetSite.Name, ex.TargetSite.MemberType));
                    return;
                }
                
            }
     
        }
        private void imageListView_DoubleClick(object sender, EventArgs e)
        {
            FuiEditor.Forms.PicViewer PV = new FuiEditor.Forms.PicViewer(ImageListSelectedToBitmap());
            PV.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void PB_SelectedIndexPreview_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
              "", false);

            ImageFormat[] imageFormats =
            {
                ImageFormat.Png,
                ImageFormat.Jpeg
            };

            CommonSaveFileDialog fileDialog = new CommonSaveFileDialog("")
            {
                Filters =
                {
                    new CommonFileDialogFilter("PNG", "*.png"),
                    new CommonFileDialogFilter("JPEG", "*.jpg;*.jpeg")
                },
                Controls =
                {
                    correctColorCb
                },
                RestoreDirectory = true
            };
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (correctColorCb.IsChecked)
                {
                    ImageUtils.ReverseColorRB((Bitmap)PB_SelectedIndexPreview.Image);
                }
                ImageFormat saveFormat = imageFormats[fileDialog.SelectedFileTypeIndex - 1];
                PB_SelectedIndexPreview.Image.Save(fileDialog.FileName, saveFormat);
                //File.WriteAllBytes();
            }

            fileDialog.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageUtils.ReverseColorRB((Bitmap)PB_SelectedIndexPreview.Image);
            PB_SelectedIndexPreview.Image = PB_SelectedIndexPreview.Image;
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "FUI Bitmap Array (*.fui)|*.fui|All Files (*.*)|*.*";
            fileDialog.Title = "";
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                imageList.ColorDepth = ColorDepth.Depth32Bit;
                EditorGUI FUIM = new EditorGUI(filepath);
                FUIM.Show();
                /*OpenFui(filepath);
                this.Text = "FUI Editor: " + filepath;
                */

            }

        }

        private void fileSaveStripMenu_Click(object sender, EventArgs e)
        {
            SaveFui(currentOpenFui);
        }

        private void FUI_Editor_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void fileSaveAsStripMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                Filter = "Fui Files (*.fui)|*.fui",
                Title = "",
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                SaveFui(filepath);
            }
        }

        private void fileSaveAllImagesStripMenu_Click(object sender, EventArgs e)
        {
            Dictionary<ImageFormat, string> extensions = new Dictionary<ImageFormat, string>()
            {
                {
                    ImageFormat.Png, ".png"
                },
                {
                    ImageFormat.Jpeg, ".jpg"
                }
            };

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("folder_dumpall")
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                string filepathBase = Path.Combine(directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");


                for (int i = 0; i < originalImageFormats.Count; i++)
                {
                    ImageFormat imageFormat = originalImageFormats[i];
                    FuiImageInfo imageInfo = fuiImageInfo[i];
                    int attribute = imageInfo.Attribute;
                    string filepath;
                    Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(originalImagesData[i]));
                    Utils.ImageUtils.ReverseColorRB(bmp);
                    if (extensions.ContainsKey(imageFormat))
                    {
                        string extension = extensions[imageFormat];

                        filepath = string.Format(filepathBase, i, extension);
                    }
                    else
                    {
                        filepath = string.Format(filepathBase, i, ".unknown");
                    }
                    if (imageListView.Items[i].Text != OriginalCurrentImagesSizes[i])
                    {
                        //filepath = directorySelected + @"\" + imageListView.Items[i].Text + ".png";
                    }
                    File.WriteAllBytes(filepath, originalImagesData[i]);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose(true);
            Close();
        }

        private void ReplaceAllItemsToolStripItem_Click(object sender, EventArgs e)
        {
            ReplaceAll();
        }
        private void ReplaceAll()
        {

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("folder_repall")
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                string filepathBase = Path.Combine(directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");
                DirectoryInfo cdi = new DirectoryInfo(directorySelected);
                var FilesInDir = cdi.GetFiles();
                if (FilesInDir.Length == originalImageFormats.Count)
                {
                    FileInfo fn = new FileInfo(currentOpenFui);
                    var result = MessageBox.Show("Folder has images inverted colors or not?\rcancel: Let you deside for each...", "¿?", buttons: MessageBoxButtons.YesNoCancel);
                    bool letDeside = false;
                    if (result is DialogResult.Yes)
                    {
                        letDeside = false;
                    }
                    else if (result is DialogResult.Cancel)
                    {
                        letDeside = true;
                    }
                    else if (result is DialogResult.No)
                    {
                        letDeside = false;
                    }
                    var di = new DirectoryInfo(directorySelected);
                    for (int i = 0; i < originalImageFormats.Count; i++)
                    {
                        ImageFormat imageFormat = originalImageFormats[i];
                        //FuiImageInfo imageInfo = fuiImageInfo[i];
                        var name = string.Format(filepathBase, i, new FileInfo(di.GetFiles()[i].Extension));
                        RLog.WriteLine("NAME : " + name);
                        if (File.Exists(name))
                        {
                            Bitmap bmp = (Bitmap)Bitmap.FromFile(name);
                            Bitmap resultbmp = bmp;
                            bool invertRb = false;
                            if (letDeside)
                            {
                                var askForm = new Expoint.FJUI.Forms.AskToInvertRedBlueOnReplacement(name, $"Wanna invert RB values in this image?\r{i}/{originalImageFormats.Count}"
                                );
                                if (askForm.IsSkiping == false)
                                {
                                    invertRb = askForm.ShowDialog() is DialogResult.Yes;
                                }
                                else
                                {
                                    invertRb = false;
                                }
                                RLog.WriteLine("[!] " + invertRb.ToString());
                                askForm.Dispose();
                            }
                            if (invertRb)
                            { resultbmp = Utils.ImageUtils.ReverseColorRB(bmp); }

                            imageList.Images[i].Dispose();
                            imageList.Images[i] = ImageUtils.CreateThumbnail(resultbmp, imageList.ImageSize);
                            imageListView.Items[i].Text = $"{i} : {resultbmp.Width}x{resultbmp.Height}";
                            imageListView.Tag = i;
                        }

                    }

                }

            }
        }
        private void ImageListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

            System.IO.FileInfo fi = new FileInfo(currentOpenFui);
            var fiName = fi.Name;
            try { File.Delete(fi.DirectoryName + @"\" + fiName + "-userMarks.txt"); } catch { }

            StreamWriter fiMarks = File.CreateText(fi.DirectoryName + @"\" + fiName + "-userMarks.txt");
            foreach (ListViewItem item in imageListView.Items)
            {
                fiMarks.WriteLine(item.Index + " - " + item.Text + ";");
            }
            fiMarks.Flush();
            fiMarks.Close();
        }
        private void InitListSetMarks(string filename)
        {
            var v1 = "";
            var v2 = "";
            try
            {
                if (File.Exists(filename + "-userMarks.txt"))
                {
                    FileStream FiStr = File.OpenRead(filename + "-userMarks.txt");
                    StreamReader FiReader = new StreamReader(FiStr);
                    string data = FiReader.ReadToEnd();
                    FiStr.Close();
                    FiReader.Close();

                    string[] strs = data.Split(';');
                    foreach (string str in strs)
                    {
                        RLog.WriteLine(str);
                        var format = str.Substring(0, str.IndexOf("-"));
                        var indexInteger = str.Split('-')[0].Trim();
                        var labelOnIndex = str.Remove(0, str.IndexOf("-"));
                        RLog.WriteLine(indexInteger);
                        RLog.WriteLine(labelOnIndex.Remove(2));
                        imageListView.Items[int.Parse(indexInteger)].Text = labelOnIndex.Remove(0, 2);
                    }
                }
            }
            catch (Exception e) { RLog.WriteLine("[ERROR] " + e + "\rValues: " + v1 + ", " + v2); }
        }

        private void SITEM_LABEL_EDIT_TextChanged(object sender, EventArgs e)
        {
            var selItem = imageListView.SelectedItems[0];
            selItem.Text = OriginalCurrentImagesSizes[selItem.Index] + " | " + SITEM_LABEL_EDIT.Text;
            SITEM_LABEL_EDIT.Text.Replace("-", " ");
            ImageListView_AfterLabelEdit(selItem, new LabelEditEventArgs(selItem.Index, selItem.Text));
        }

        private void SITEM_LABEL_EDIT_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void RestoreTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(currentOpenFui + "-userMarks.txt") == true)
            {
                File.Delete(currentOpenFui + "-userMarks.txt");
                foreach (ListViewItem item in imageListView.Items)
                {
                    item.Text = OriginalCurrentImagesSizes[item.Index];
                }

            }
            else
            {
                MessageBox.Show("This file does no have a userMarks savedata.");
            }
        }

        private void SITEM_LABEL_EDIT_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Trata de reemplazar graficos desde el rango seleccionado por el usuario, si el archivo correspondiente no existe intenta con otro formato. caso contrario return.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replaceRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(imageListView.SelectedItems.Count > 1)
            {
                ReplaceRange();
            }
            else if(imageListView.SelectedItems.Count == 1)
            {
                MessageBox.Show("Selected more than only a file.", "!", buttons: MessageBoxButtons.OK) ;
            }
        }
        private void ReplaceRange()
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("folder_repRange")
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };
            Dictionary<ImageFormat, string> extensions = new Dictionary<ImageFormat, string>()
            {
                {
                    ImageFormat.Png, ".png"
                },
                {
                    ImageFormat.Jpeg, ".jpg"
                }
            };
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                DirectoryInfo cdi = new DirectoryInfo(directorySelected);
                var FilesInDir = cdi.GetFiles();
                string filepathBase = Path.Combine(
                    directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");

                if (FilesInDir.Length == originalImagesData.Count)
                {

                    var selected = imageListView.SelectedItems;
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var file = selected[i];
                        var item = file.Index;
                        var ext = ".png";
                        bool jpg = false;
                        string fn = string.Format(filepathBase, (int)file.Tag, ext);
                        if (File.Exists(fn) is false)
                        {
                            ext = ".jpg";
                            fn = string.Format(filepathBase, (int)file.Tag, ext);
                            jpg = true;
                        }
                        if (File.Exists(fn) is false && jpg == true)
                        {
                            Console.WriteLine("[!] Missed file in {0} at index {1}", directorySelected, file.Index);
                            return;
                        }
                        if (File.Exists(fn) is true)
                        {
                            Console.WriteLine("[!] Index {0} is now {1}", item, fn);
                            Image selImg = Image.FromFile(fn);
                            imageList.Images[item].Dispose();
                            imageList.Images[item] = ImageUtils.CreateThumbnail(selImg, imageList.ImageSize);
                            originalImagesData[item] = ImageToByteArray(selImg);

                            imageListView.Items[item].Text = item + $" - {selImg.Width}x{selImg.Height}";
                            selImg.Dispose();
                        }

                    }
                }
                else if (FilesInDir.Length != originalImageFormats.Count)
                {
                    MessageBox.Show("Cannot continue operation..." +
                        " The selected folder is not the right one " +
                        "to continue with the replacement (it does not" +
                        " contain the same number of images as the file)," +
                        " it must first have had a modified folder of the same" +
                        " type, for this use the \"Dump all images\" function and " +
                        "create a new one folder..", "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Hand);
                    RLog.WriteLine(GetRestDif(FilesInDir.Length, originalImageFormats.Count) + " unknown files.");
                }

            }
            fileDialog.Dispose();
        }
#endregion    
        private int CountFormattedFiles(string[] dirGetFiles, string Extension)
        {
            int count = 0;
            for
            (int i = 0; i < dirGetFiles.Length; i++)
            {
                var fi = new FileInfo(dirGetFiles[i]);
                if (fi.Extension.ToLower() == Extension.ToLower()) { count++; }
            }
            return count;
        }
        private int GetRestDif(int n1, int n2)
        {
            int backsteps = 0;
            for (int i = n1; i > n2; i--)
            {
                backsteps++;
            }
            return backsteps;
        }
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RLog.WriteLine("[*] Reversing color RB");
            var selIndexes = imageListView.SelectedItems;
            if (selIndexes.Count != 0)
            {
                InvertIndexedBitmapRb(selIndexes);
            }
        }
        internal void InvertIndexedBitmapRb(ListView.SelectedListViewItemCollection selectedIndices)
        {

            for (int i = 0; i < selectedIndices.Count; i++)
            {
                var selIndex = selectedIndices[i].Index;
                var selected = originalImagesData[selIndex];
                RLog.WriteLine("[?] Index -> " + selIndex);
                Bitmap imageLoaded = ByteArrayToBitmap(selected);
                ImageFormat originalFormat = originalImageFormats[selIndex];
                MemoryStream saveStream = new MemoryStream();
                if (imageLoaded != null)
                {
                    RLog.WriteLine("[!] Operating..");
                    ImageUtils.ReverseColorRB((Bitmap)imageLoaded);
                    imageLoaded.Save(saveStream, originalFormat);
                    originalImagesData[selIndex] = saveStream.ToArray();
                    imageList.Images[selIndex] = ImageUtils.CreateThumbnail(imageLoaded, imageList.ImageSize);
                    imageListView.Items[selIndex].Text = $"{imageLoaded.Width}x{imageLoaded.Height}";
                    saveStream.Dispose();
                    RLog.WriteLine("[!] Success");

                    shouldSaveFui = true;
                }
            }

        }
        internal Bitmap ByteArrayToBitmap(byte[] data)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(data))
            {
                return bmp = new Bitmap(ms);
            }
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            RLog.WriteLine("[*] Reversing color RB");
            var selIndexes = imageListView.SelectedItems;
            if (selIndexes.Count != 0)
            {
                InvertIndexedBitmapRb(selIndexes);
            }
        }
        private void FUI_Editor_Main_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            InAppUserSettings.Default.S_Ins_Fui = InAppUserSettings.Default.S_Ins_Fui - 1;
        }
        private int DATABOARDSELECTED = -1;
        private void copySelectedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected = imageListView.SelectedIndices[0];
            if (imageListView.SelectedIndices.Count == 1)
            {
                System.Windows.Forms.Clipboard.SetDataObject(originalImagesData[selected]);
                byte[] imageData = originalImagesData[selected];
                using (MemoryStream stream = new MemoryStream(imageData, false))
                {
                    Image image = Image.FromStream(stream);
                    DataBoardItems.Add(ImageToByteArray(image));
                    CMLV_DataBoard.Items.Add($"{image.Width}x{image.Height}", IMGL_DataBoardThumbnails.Images.Count);
                    IMGL_DataBoardThumbnails.Images.Add(ImageUtils.CreateThumbnail(image, imageList.ImageSize));
                    int index = IMGL_DataBoardThumbnails.Images.Count;
                    //if (index != 1)
                    {
                        //  index = IMGL_DataBoardThumbnails.Images.Count + 1;
                    }
                    image.Dispose();
                }
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DATABOARDSELECTED != -1)
            {
                CMLV_DataBoard.Items.RemoveAt(DATABOARDSELECTED);
                IMGL_DataBoardThumbnails.Images.RemoveAt(DATABOARDSELECTED);
            }
        }
        private void CMLV_DataBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMLV_DataBoard.SelectedIndices.Count != 0)
            {
                DATABOARDSELECTED = CMLV_DataBoard.SelectedIndices[0];
            }
        }
        private void CMLV_DataBoard_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void CMLV_DataBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                bool selected = CMLV_DataBoard.SelectedIndices[0] != -1;
                bool hasitems = CMLV_DataBoard.Items.Count != 0;
                removeToolStripMenuItem.Enabled = selected;
                clearToolStripMenuItem.Enabled = hasitems;
                dumpAllToolStripMenuItem.Enabled = hasitems;
                dumpSelectedToolStripMenuItem.Enabled = (hasitems && selected) is true;
            }
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMGL_DataBoardThumbnails.Images.Clear();
            CMLV_DataBoard.Items.Clear();
        }
        private void dumpAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("folder_dumpall")
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                bool hasitems = CMLV_DataBoard.Items.Count != 0;
                if (hasitems)
                {

                    for (int i = 0; i < DataBoardItems.Count; i++)
                    {
                        using (MemoryStream ms = new MemoryStream(DataBoardItems[i]))
                        {
                            Bitmap.FromStream(ms).Save(directorySelected + "\\data_" + i + ".png");
                        }
                    }
                }
            }
            fileDialog.Dispose();

        }
        private void dumpSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool selected = CMLV_DataBoard.SelectedIndices[0] != -1;
            if (selected)
            {
                using (MemoryStream ms = new MemoryStream(DataBoardItems[CMLV_DataBoard.SelectedIndices[0]]))
                {
                    Bitmap.FromStream(ms).Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\data_" + CMLV_DataBoard.SelectedIndices[0] + ".png");
                }
            }
        }
        private void pasteSelectedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sel = CMLV_DataBoard.SelectedIndices[0];
            if (CMLV_DataBoard.SelectedItems.Count != 0 && imageListView.SelectedIndices != null)
            {
                byte[] data = DataBoardItems[sel];
                using (MemoryStream ms = new MemoryStream(data))
                {
                    Bitmap bmp = (Bitmap)Bitmap.FromStream(ms);
                    imageList.Images[imageListView.SelectedIndices[0]].Dispose();
                    imageList.Images[imageListView.SelectedIndices[0]] = ImageUtils.CreateThumbnail(bmp, imageList.ImageSize);
                    imageListView.Items[imageListView.SelectedIndices[0]].Text = $"{bmp.Width}x{bmp.Height}";
                    imageListView.Items[imageListView.SelectedIndices[0]].ImageIndex = imageListView.SelectedIndices[0];
                    originalImagesData[sel] = data;
                    bmp.Dispose();
                }
            }
        }
        private void openNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClickFileOpen(sender, e);
        }
        private void openInColorModGuiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count != 0)
            {
                var docDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var finalDir = docDir + "\\exFrames\\";
                var finalFile = finalDir + Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}.png";
                try { Directory.Delete(finalDir, true); } catch { }
                Directory.CreateDirectory(finalDir);
                RLog.WriteLine(finalFile);
                for (int bmps = 0; bmps < imageListView.SelectedIndices.Count; bmps++)
                {
                    var data = originalImagesData[bmps];
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        var bmp = Bitmap.FromStream(ms);
                        bmp.Save(finalFile.Replace("{0}", bmps.ToString()));
                        bmp.Dispose();
                    }
                }
                string[] WorkFiles = Directory.GetFiles(finalDir);
                if (WorkFiles.Length > 0)
                {
                    ColorGuiHelper CGH = new ColorGuiHelper(WorkFiles, this);
                    CGH.Show();
                }

            }
        }
        private void previewGraphicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new HudViewer(currentOpenFui, this.originalImagesData)).ShowDialog();
        }
        private void debugDrawerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imagen = (new MinecraftLegacyConsoleRE.GameFile_FUI.SkinGraphicsPreviewDrawer()).RenderPreview(new MinecraftLegacyConsoleRE.GameFile_FUI(currentOpenFui));
            (new PicViewer(imagen)).ShowDialog();
        }
        private void METRO_TABC_WORK_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void DebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Environment.UserName != "JP")
            {
                DebugToolStripMenuItem.Visible = false;
            }

        }
        private void pVWInvokeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PRUEBA DE INVOQUE DEBUG PARA VER IMAGENES 
            PicViewer pvw = new PicViewer(new Bitmap(200, 200));
            pvw.ShowDialog();

        }
        private void selectionIndexInvokeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageListView_SelectedIndexChanged(sender, e);
        }
        bool LogToggled = false;
        Timer _DebugTesterLogTimer = null;
        private void toogleLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogToggled = !LogToggled;
            switch (LogToggled)
            {
                case true:
                    {
                       // _RTBLOG = new RichTextBox();
                        _RTBLOG.Size = new Size(725, 62);
                        _RTBLOG.Dock = DockStyle.Bottom;
                        _RTBLOG.Visible = true;
                        _RTBLOG.BringToFront(); _RTBLOG.Refresh();
                        _RTBLOG.Location = new Point(3, 283);
                        _DebugTesterLogTimer = new Timer() { Interval = 65 }; _DebugTesterLogTimer.Tick += _DebugTesterLogTimer_Tick;
                        _DebugTesterLogTimer.Start();
                        splitContainer1.Size = new Size(563, 243); // 563; 308
                        CMLV_DataBoard.Size = new Size(147, 243); //147; 309
                        _RTBLOG.Parent = this;
                        break;
                    }
                case false:
                    {
                        splitContainer1.Size = new Size(563, 308);
                        CMLV_DataBoard.Size = new Size(147, 309);
                        this.Size = new Size(741, 415);
                        break;
                    }

            }
        }
        private void _DebugTesterLogTimer_Tick(object sender, EventArgs e)
        {
            switch (_DebugTesterLogTimer != null)
            {
                case true:
                    {
                        if (_RTBLOG.Text != RLog.Output && _RTBLOG.Text.Length != RLog.Output.Length)
                        {
                            _RTBLOG.Text = RLog.Output;
                        }
                        break;
                    }
                case false:
                    {             
                        _DebugTesterLogTimer = null;
                        break;
                    }
            }
        }
        private void cWUtilInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var s = "------ [!] ------" +
                   "INT_IMG_VIEWER_SINDEX = {0}\r" +
                   "INT_IMG_VIEWER_TCOUNT = {1}\r" +
                   "DB_IMG_VIEWER_TSIZE = {2}\r" +
                   "INT_IMG_VIEWER_SINDICES = {3}\r" +
                   "TSP_PRC_TOTAL_TIME = {4}\r" +
                   "STR_RPC_DETAILS = {5}\r" +
                   "STR_RPC_STATE = {6}\r"+
                   "MW_MODE = {7}"
                   ;
                var imgv = imageListView;
                var sf = string.Format(s, imgv.SelectedIndices[0], imgv.Items.Count, originalImagesData[imgv.SelectedIndices[0]].Length
                , imgv.SelectedIndices.Count, Process.GetCurrentProcess().StartTime.ToShortTimeString(), "na", "na", MWMode);
                RLog.WriteLine(sf);
            }
            catch (Exception ex)
            {
                RLog.WriteLine(string.Format("[{0}] ERROR : {1}, {2}, {3}, {4}", DateTime.Now.ToLongTimeString(), ex.Message
                    , ex.StackTrace, ex.TargetSite.Name, ex.TargetSite.MemberType));
                return;
            }
        }

        private void imageMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void PB_SelectedIndexPreview_Click(object sender, EventArgs e)
        {

        }

        private void fReadLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RLog.Output
                );
        }

        private void testBend1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinecraftLegacyConsoleRE.GameFile_FUI.Customizer.BEND_CUSTOMIZER BC = new MinecraftLegacyConsoleRE.GameFile_FUI.Customizer.BEND_CUSTOMIZER();
            var b = BC.SG_MAKE_GUI_WINDOW("C:\\Users\\JP\\Desktop\\Desks\\Escritorio 1\\Minecraft PS3 Modding Tool Kit\\Ediciones\\Minecraft Ultimate Edition\\80.0\\.Java\\rrtext\\textures\\gui\\light_mode\\advancements\\window.png");
            (new PicViewer(b[1])).ShowDialog();
            
        }

        private void testBend2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinecraftLegacyConsoleRE.GameFile_FUI.Customizer.BEND_CUSTOMIZER BC = new MinecraftLegacyConsoleRE.GameFile_FUI.Customizer.BEND_CUSTOMIZER();
            var b = BC.SG_MAKE_BUTTONS("C:\\Users\\JP\\Desktop\\Desks\\Escritorio 1\\Minecraft PS3 Modding Tool Kit\\Ediciones\\Minecraft Ultimate Edition\\80.0\\.Java\\rrtext\\textures\\gui\\light_mode\\widgets.png");
            (new PicViewer(b[1])).ShowDialog();
            (new PicViewer(b[0])).ShowDialog();
            (new PicViewer(b[2])).ShowDialog();

        }

        private void testMWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditorGUI("C:\\Users\\JP\\Desktop\\Desks\\Escritorio 1\\Minecraft PS3 Modding Tool Kit\\Ediciones\\Minecraft Ultimate Edition\\80.0\\Original", true).ShowDialog() ;
        }
    }
    internal class _RuntimeLog
    {
        private static string output = "";

        internal _RuntimeLog()
        {
            output = $"[{DateTime.Now.ToLongDateString()}] <- INITIALIZATION -> ";
        }

        public string Output { get => output; }
        public void WriteLine(object msg)
        {
            var d = DateTime.Now.ToLongTimeString();
            var f = string.Format("[{0}] ", d);
            Console.WriteLine(d+msg);
            output += "\r" +string.Format(f)
                + msg.ToString();
        }
        public void WriteChar(char c)
        {
            Console.Write(c);
            output += "\r" + c;
        }
        public void WriteBoolean(bool b)
        {
            var literal = $"bool: {b} - hash: {b.GetHashCode()}";
            Console.WriteLine(literal);
            WriteLine(literal);
        }
        public void WriteInteger(int i)
        {
            var literal = $"int: {i} - hash: {i.GetHashCode()}";
            Console.WriteLine(literal);
            WriteLine(literal);
        }
    }
}



