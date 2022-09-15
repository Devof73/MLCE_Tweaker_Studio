
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.Clipboard
{
    public partial class AppClipboardForm : Form
    {
        internal StringCollection _ConfigSaved = new StringCollection();
        internal string[] _userClipboardValues;
        public AppClipboardForm()
        {
            InitializeComponent();
        } 
        /// <summary>
        /// Initialize, adding new items to clipboard collection.
        /// </summary>
        /// <param name="stringArray"></param>
        public AppClipboardForm(string[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                lbx1_savedClipboard.Items.Add(stringArray[i].Replace("¨", ""));
            }
        }
        public void RefreshValues()
        {
          
            _ConfigSaved = Expoint.InAppUserSettings.Default.ClipboardTextCollection;
            if (_ConfigSaved?.Count != 0)
            {
                string[] aNormalStringArray = _ConfigSaved.Cast<string>().ToArray();
                bool containsDataText = System.Windows.Forms.Clipboard.ContainsText(TextDataFormat.Text);
                if (containsDataText == true)
                {
                    var text = System.Windows.Forms.Clipboard.GetText();
                    if (aNormalStringArray.Contains<string>(text) == false)
                    {
                        _ConfigSaved.Add(text);
                        aNormalStringArray = _ConfigSaved.Cast<string>().ToArray();
                        _userClipboardValues = aNormalStringArray;
                    }
                }
                lbx1_savedClipboard.Items.Clear();
                foreach (string str in _ConfigSaved)
                {
                    lbx1_savedClipboard.Items.Add(str);
                }
                _userClipboardValues = lbx1_savedClipboard.Items.Cast<string>().ToArray();

            }
           
        }
        public void SaveValues (bool saving)
        {
            _ConfigSaved = new StringCollection();
            string[] unArrayNormalitoDeStrings = lbx1_savedClipboard.Items.Cast<string>().ToArray();
            if (unArrayNormalitoDeStrings.Length is 0)
            {
                return;
            }
            else if (unArrayNormalitoDeStrings.Length != 0)
            {
                _ConfigSaved.Clear();
                _ConfigSaved.AddRange(unArrayNormalitoDeStrings);
                Expoint.InAppUserSettings.Default.ClipboardTextCollection = _ConfigSaved;
                if (saving) { InAppUserSettings.Default.Save(); }
            }
            _userClipboardValues = unArrayNormalitoDeStrings;
        }
        private void _btn2_clipSaveCurrent_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Clipboard.GetText() != null && lbx1_savedClipboard.Items.Contains(System.Windows.Forms.Clipboard.GetText()) is false)
            {
                lbx1_savedClipboard.Items.Add(System.Windows.Forms.Clipboard.GetText());
            }
        }

        private void Btn5_DumpClipboard_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Clipboard Savedata|*.scl";
            sfd.Title = "Dump a backup of the clipboard.";
            sfd.OverwritePrompt = true;
            sfd.SupportMultiDottedExtensions = false;
            sfd.ShowHelp = false;
            sfd.DefaultExt = ".scl";
            if (sfd.ShowDialog() is DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(File.Create(sfd.FileName));
                foreach (object obj in lbx1_savedClipboard.Items)
                {
                    SW.WriteLine((string)obj + "¨");
                }
                SW.Flush();
                SW.Close();
            }
            sfd.Dispose();
        }

        private void _btn3__Click(object sender, EventArgs e)
        {
            _ConfigSaved = new StringCollection();
            _userClipboardValues = new string[] {};
            lbx1_savedClipboard.Items.Clear();
            InAppUserSettings.Default.ClipboardTextCollection = new StringCollection() { ";" };
        }

        private void _btn3_copySelected_Click(object sender, EventArgs e)
        {
            if (lbx1_savedClipboard.SelectedIndex != -1 && (string)lbx1_savedClipboard.Items[lbx1_savedClipboard.SelectedIndex] != string.Empty)
            {
                var strobj = (string)lbx1_savedClipboard.Items[lbx1_savedClipboard.SelectedIndex];
                System.Windows.Forms.Clipboard.SetText(strobj);
            }
        }

        private void AppClipboardForm_Load(object sender, EventArgs e)
        {
            RTBX_CurrentClipboard.Text = System.Windows.Forms.Clipboard.GetText(TextDataFormat.Text);
            RefreshValues();
        }

        private void _btn1_winclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppClipboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveValues(true);
        }
    }
}
