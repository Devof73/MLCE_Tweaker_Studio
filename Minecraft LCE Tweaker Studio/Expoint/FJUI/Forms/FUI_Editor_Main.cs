using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Utils;
using FuiEditor;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI
{
    public partial class FUI_Editor_Main : Form
    {
        private static readonly byte[] PngStartPattern =
        {
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A
        };

        private string currentOpenFui = null;
        private bool shouldSaveFui = false;
        private byte[] fuiMainBytes;
        private List<FuiImageInfo> fuiImageInfo = new List<FuiImageInfo>();
        private List<byte[]> originalImagesData = new List<byte[]>();
        private List<ImageFormat> originalImageFormats = new List<ImageFormat>();
        private List<string> OriginalCurrentImagesSizes = new List<string>();
        public FUI_Editor_Main(string filepath)
        {
            InitializeComponent();
            Bitmap Ico = Properties.Resources.card_multiple;
            IntPtr Hicon = Ico.GetHicon();
            Icon myIcon = Icon.FromHandle(Hicon);
            Icon = myIcon;
            Ico.Dispose();
            myIcon.Dispose();
            imageList.ColorDepth = ColorDepth.Depth32Bit;;
            OpenFui(filepath);
            this.Text = "F.J.U.I. = " + filepath;
            InAppUserSettings.Default.S_Ins_Fui = InAppUserSettings.Default.S_Ins_Fui + 1;
            InitListSetMarks(filepath);
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

        private bool NotifySave()
        {
            DialogResult result = MessageBox.Show("", "", MessageBoxButtons.YesNo);

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

            byte[] filedata = File.ReadAllBytes(filepath);
            int pngIndex = ArrayUtils.SearchBytes(filedata, 0, PngStartPattern);
            if (pngIndex < 0)
            {
                return;
            }

            FuiImageInfo[] imageInfo = FuiUtils.GetImageInfo(filedata, pngIndex);
            List<byte[]> imagesData = FuiUtils.GetImagesData(filedata, pngIndex, imageInfo);
            originalImagesData.AddRange(imagesData);
            for (int i = 0; i < imagesData.Count; i++)
            {
                byte[] imageData = imagesData[i];
                using (MemoryStream stream = new MemoryStream(imageData, false))
                {
                    Image image = Image.FromStream(stream);
                    originalImageFormats.Add(image.RawFormat);
                    imageList.Images.Add(ImageUtils.CreateThumbnail(image, imageList.ImageSize));
                    imageListView.Items.Add($"{image.Width}x{image.Height}", i);
                    OriginalCurrentImagesSizes.Add($"{image.Width}x{image.Height}");
                    image.Dispose();
                }
            }

            fuiMainBytes = filedata.Take(pngIndex - imageInfo.Length * FuiImageInfo.NativeSize).ToArray();
            fuiImageInfo.AddRange(imageInfo);

           

            OnOpendFui(filepath);
        }

        private void SaveFui(string filepath)
        {
            List<byte> fuiBytes = new List<byte>();
            List<byte> imageSection = new List<byte>();
            int currentOffset = 0;

            fuiBytes.AddRange(fuiMainBytes);

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
            foreach (string file in files) Console.WriteLine(file);


        }

        private void imageListView_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string s = (string)e.Data.GetData(DataFormats.FileDrop);
            OpenFui(s);
            foreach (string file in files) Console.WriteLine(file);
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
            if (imageListView.SelectedIndices.Count != 0)
            {
                LBL_SELECTED_PIC_SIZE.Text = OriginalCurrentImagesSizes[imageListView.SelectedIndices[0]];
            }
            try
            {
                PB_SelectedIndexPreview.Image = ImageListSelectedToBitmap();
            }
            catch { }
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
                FUI_Editor_Main FUIM = new FUI_Editor_Main(filepath);
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
            Minecraft_LCE_Tweaker_Studio.Expoint.InAppUserSettings.Default.S_Ins_Fui = Minecraft_LCE_Tweaker_Studio.Expoint.InAppUserSettings.Default.S_Ins_Fui + 1;
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
            bool ColorToggle = false;
            var imgCnt = imageListView.Items.Count;
            FolderBrowserDialog _FBD = new FolderBrowserDialog();
            _FBD.Description = "Select a folder with image frames for this file.";
            _FBD.ShowNewFolderButton = false;
            if (_FBD.ShowDialog() is DialogResult.OK)
            {
                if (MessageBox.Show("¿Wanna correct textures color of this textures?", "¿?", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    ColorToggle = true;
                }
                else
                {
                    ColorToggle = false;
                }
                Console.WriteLine("Processing...");
                var fln = _FBD.SelectedPath;
                var flnsInPt = Directory.EnumerateFiles(fln);
                var flnsCast = flnsInPt.Cast<string>().ToArray();
                if (flnsInPt.Count() == imgCnt)
                {
                    for (int i = 1; i < flnsInPt.Count(); i++)
                    {
                        int selected = imageListView.Items[i].Index;
                        var filepath = flnsCast[i - 1];
                        byte[] filedata = File.ReadAllBytes(filepath);
                        ImageFormat originalFormat = originalImageFormats[selected];
                        using (MemoryStream stream = new MemoryStream(filedata, false))
                        {
                            Image imageLoaded = Image.FromStream(stream);
                            if (!ColorToggle && originalFormat == imageLoaded.RawFormat)
                            {
                                originalImagesData[selected] = filedata;
                            }
                            else
                            {
                                if (ColorToggle)
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
                else if (flnsInPt.Count() != imgCnt)
                {
                    MessageBox.Show("The selected folder framecount is different from this FUI.\n" +
                        "Current Fui Images Count: " + imgCnt + "\n"
                       + "Selected folder frames count: " + flnsInPt.Count(), "Error",
                       MessageBoxButtons.OK, icon: MessageBoxIcon.Hand);
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
                fiMarks.WriteLine(item.Index+" - "+item.Text+";");
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
                        Console.WriteLine(str);
                        var format = str.Substring(0, str.IndexOf("-"));
                        var indexInteger = str.Split('-')[0].Trim();
                        var labelOnIndex = str.Remove(0,str.IndexOf("-"));
                        Console.WriteLine(indexInteger);
                        Console.WriteLine(labelOnIndex.Remove(2));
                        imageListView.Items[int.Parse(indexInteger)].Text = labelOnIndex.Remove(0, 2);
                    }
                }
            }
            catch(Exception e ) { Console.WriteLine("[ERROR] "+ e+"\rValues: "+v1 + ", "+v2); }
        }

        private void SITEM_LABEL_EDIT_TextChanged(object sender, EventArgs e)
        {
            var selItem = imageListView.SelectedItems[0];
            selItem.Text = OriginalCurrentImagesSizes[selItem.Index]+" | "+SITEM_LABEL_EDIT.Text;
            SITEM_LABEL_EDIT.Text.Replace("-", " ");
            ImageListView_AfterLabelEdit(selItem, new LabelEditEventArgs(selItem.Index, selItem.Text));
        }

        private void SITEM_LABEL_EDIT_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void RestoreTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(currentOpenFui+"-userMarks.txt") == true)
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

        private void replaceRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ColorToggle = false;
            var imgCnt = imageListView.Items.Count;
            FolderBrowserDialog _FBD = new FolderBrowserDialog();
            _FBD.Description = "Select a folder with image frames for this file.";
            _FBD.ShowNewFolderButton = false;
            if (_FBD.ShowDialog() is DialogResult.OK)
            {
                if (MessageBox.Show("¿Wanna correct textures color of this textures?", "¿?", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    ColorToggle = true;
                }
                else
                {
                    ColorToggle = false;
                }
                Console.WriteLine("Processing...");
                var fln = _FBD.SelectedPath;
                var flnsInPt = Directory.EnumerateFiles(fln);
                var flnsCast = flnsInPt.Cast<string>().ToArray();
                if (flnsInPt.Count() == imgCnt)
                {
                    foreach (int i in imageListView.SelectedIndices)
                    {
                        int selected = imageListView.Items[i].Index;
                        var filepath = flnsCast[i - 1];
                        byte[] filedata = File.ReadAllBytes(filepath);
                        ImageFormat originalFormat = originalImageFormats[selected];
                        using (MemoryStream stream = new MemoryStream(filedata, false))
                        {
                            Image imageLoaded = Image.FromStream(stream);
                            if (!ColorToggle && originalFormat == imageLoaded.RawFormat)
                            {
                                originalImagesData[selected] = filedata;
                            }
                            else
                            {
                                if (ColorToggle)
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
                else if (flnsInPt.Count() != imgCnt)
                {
                    MessageBox.Show("The selected folder framecount is different from this FUI.\n" +
                        "Current Fui Images Count: " + imgCnt + "\n"
                       + "Selected folder frames count: " + flnsInPt.Count(), "Error",
                       MessageBoxButtons.OK, icon: MessageBoxIcon.Hand);
                }
            }
        }
    }
}
