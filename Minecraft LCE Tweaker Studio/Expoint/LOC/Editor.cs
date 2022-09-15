using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweaker.Workers;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.LOC
{
    public partial class Editor : Form
    {
        internal Single FSize = 12;
        internal string openedloc = "";
        int lastselect = 0;
        internal string LOC_DIR;
        LanguagesContainer languagesContainer_0 = new LanguagesContainer();
        MessageEntry messageEntry_0 = new MessageEntry();

        public Editor(string localise)
        {
            InitializeComponent();
            LOC_DIR = localise;
            BGW_Loader.RunWorkerAsync();
            BGW_Loader.ProgressChanged += BGW_Loader_ProgressChanged;
        }

        private void BGW_Loader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BGW_Loader_DoWork(object sender, DoWorkEventArgs e)
        {
            var localise = LOC_DIR;
            openedloc = localise;
            LanguagesParser languagesParser = new LanguagesParser();
            languagesContainer_0 = languagesParser.Parse(localise);
            method_5();
            method_4(languagesContainer_0);
            Text = "Localization Editor - " + localise;
        }
        private void tbMessage_TextChanged(object sender, global::System.EventArgs e)
        {
            if (messageEntry_0 != null)
            {
                messageEntry_0.Message = Message_TB.Text;
            }
        }

        private void method_5()
        {
            messageEntry_0 = null;
            Message_TB.Clear();
        }

        private void method_4(LanguagesContainer languagesContainer_1)
        {
            foreach (string text in languagesContainer_1.Languages.Keys)
            {
                ListViewItem listViewItem = new ListViewItem(text);
                listViewItem.Tag = languagesContainer_1.Languages[text];
                LV_LangList.Items.Add(listViewItem);
            }
        }


        private void method_6(global::System.Collections.Generic.List<MessageEntry> list_0)
        {
            LV_LangStrings.Items.Clear();
            int num = 1;
            foreach (MessageEntry messageEntry in list_0)
            {
                ListViewItem listViewItem = new ListViewItem(num.ToString());
                listViewItem.Tag = messageEntry;
                listViewItem.SubItems.Add(messageEntry.Message);
                LV_LangStrings.Items.Add(listViewItem);
                num++;
            }
        }

        private void duohnRabql_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LV_LangList.SelectedItems.Count > 0)
            {
                method_5();
                LanguageEntry languageEntry = LV_LangList.SelectedItems[0].Tag as LanguageEntry;
                method_6(languageEntry.Messages);
            }
        }

        private void lvMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.LV_LangStrings.SelectedItems.Count > 0)
            {
                MessageEntry messageEntry = this.LV_LangStrings.SelectedItems[0].Tag as MessageEntry;
                this.messageEntry_0 = messageEntry;
                this.Message_TB.Text = messageEntry.Message;
            }
        }

        private void tbMessage_TextChanged_1(object sender, EventArgs e)
        {

            if (this.messageEntry_0 != null)
            {
                this.messageEntry_0.Message = this.Message_TB.Text;
            }
        }

        private void sameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        internal static string smethod_3(string string_0, string string_1, string string_2, string string_3 = "")
        {
            global::System.Windows.Forms.SaveFileDialog saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
            string result = null;
            saveFileDialog.DefaultExt = string_0;
            saveFileDialog.Filter = string_1;
            saveFileDialog.InitialDirectory = string_2;
            saveFileDialog.FileName = string_3;
            global::System.Windows.Forms.DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == global::System.Windows.Forms.DialogResult.OK)
            {
                result = saveFileDialog.FileName;
            }
            return result;
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void LOCEditor_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string lines = "";
            string linesx = "";
            foreach (ListViewItem line in LV_LangStrings.Items)
            {
                lines += line.SubItems[1].Text + "\n";

            }
            foreach (string line in lines.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None))
            {
                if (line.Contains("{*"))
                {
                    foreach (string linex in line.Split(new[] { "{*" }, StringSplitOptions.None))
                    {
                        if (linex.Contains("CONTROLLER") || linex.Contains("ARMOR") || linex.Contains("SHANK") && !linex.Contains(" "))
                        {
                            string lon = "{*" + linex.Split(new[] { "*}" }, StringSplitOptions.None)[0] + "*}";
                            if (!linesx.Contains(lon))
                                linesx += lon + "\n";
                        }
                    }
                }
            }
            System.IO.File.WriteAllText("text.txt", linesx);
        }

        private void dumpCurrentLangTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            FSize++;
            Message_TB.Font = new Font("Microsoft Sans Serif", FSize);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            FSize--;
            Message_TB.Font = new Font("Microsoft Sans Serif", FSize);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                LV_LangStrings.Select();
                int i = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0)) - 1;
                LV_LangStrings.Items[i].Focused = true;
                LV_LangStrings.Items[i].Selected = true;
                LV_LangStrings.Items[lastselect].Selected = false;
                LV_LangStrings.Items[i].EnsureVisible();
                lastselect = i;
            }
            catch
            {

            }
        }

        private void duohnRabql_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (LV_LangList.SelectedItems.Count > 0)
            {
                method_5();
                LanguageEntry languageEntry = LV_LangList.SelectedItems[0].Tag as LanguageEntry;
                method_6(languageEntry.Messages);
            }
            if (LV_LangStrings.Items.Count != 0)
            {
                string lines = "";
                int Numb = 1;
                foreach (ListViewItem line in LV_LangStrings.Items)
                {
                    lines += "#" + Numb++ + " - " + line.SubItems[1].Text + "\n";
                }
                Properties.Settings.Default.LanguageText = lines;
            }

        }

        private void lvMessages_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.LV_LangStrings.SelectedItems.Count > 0)
            {
                MessageEntry messageEntry = this.LV_LangStrings.SelectedItems[0].Tag as MessageEntry;
                this.messageEntry_0 = messageEntry;
                this.Message_TB.Text = messageEntry.Message;
            }
        }

        private void sameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.languagesContainer_0 != null)
            {
                if (!string.IsNullOrWhiteSpace(openedloc))
                {

                    LanguageBuilder languageBuilder = new LanguageBuilder();
                    languageBuilder.Build(this.languagesContainer_0, openedloc);
                    MessageBox.Show("Sucessfully Saved LOC to: " + LOC_DIR);
                }
            }
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            //languages.loc
            LOC_DIR = openedloc;
            tpg_MainWork.Text = LOC_DIR.Substring(LOC_DIR.Length - 20, 20);

            InAppUserSettings.Default.S_Ins_Loc = InAppUserSettings.Default.S_Ins_Loc + 1;
            try
            {
                if (Expoint.LOC.Properties.Settings.Default.UserSavedIntList.Count != 0)
                {
                    FindedStringz.Items.AddRange(Expoint.LOC.Properties.Settings.Default.UserSavedIntList.Cast<string>().ToArray());
                }
            }
            catch { }

            //filedir_label.Text = openedloc;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            string lines = "";

            int Numb = 1;
            foreach (ListViewItem line in LV_LangStrings.Items)
            {
                lines += "#" + Numb++ + " - " + line.SubItems[1].Text + "\n";

            }
            /*
			foreach (string line in lines.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None))
			{
				if (line.Contains("{*"))
				{
					foreach (string linex in line.Split(new[] { "{*" }, StringSplitOptions.None))
					{
						if (linex.Contains("CONTROLLER") || linex.Contains("ARMOR") || linex.Contains("SHANK") && !linex.Contains(" "))
						{
							string lon = "{*" + linex.Split(new[] { "*}" }, StringSplitOptions.None)[0] + "*}";
							if (!linesx.Contains(lon))
								linesx += lon + "\n";
						}
					}
				}
			}*/
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text File | *.txt";
            SFD.DefaultExt = ".txt";
            SFD.AddExtension = true;
            if ( SFD.ShowDialog() is DialogResult.OK)
            {
                string file = SFD.FileName;
                System.IO.File.AppendAllText(file, lines);
            }
            SFD.Dispose();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            int Numb = 1;
            string lines = "";
            foreach (ListViewItem line in LV_LangStrings.Items)
            {

                lines += "\r\r" + "{#" + ++Numb + "}" + line.SubItems[1].Text;

            }

        }

        private void SAVE_BTN_Click(object sender, EventArgs e)
        {
            BGW_Saver.RunWorkerAsync();
        }
        private void GraphList()
        {
            FindedStringz.Items.Clear();
            RichTextBox dtb = new RichTextBox();
            dtb.Text = Properties.Settings.Default.FindedStrings;
            string[] lines = dtb.Lines;
            foreach (string Numb in lines)
            {
                //if (Numb.Length == 4/* || Numb == String.Empty == false*/)
                {


                }
            }
        }
        private void FindedStringz_Click(object sender, EventArgs e)
        {
            GraphList();
        }
        /*
		private void AddStringToCBItems_MTD1()
        {
			///Convert The Properties String To string[] Lines and add it to the combobox
			string[] LinesNow;
			string TextYet = Properties.Settings.Default.UserSavedFindedLines;
			RichTextBox debugTB = new RichTextBox();
			debugTB.Text = TextYet;
			LinesNow = debugTB.Lines;
			FindedStringz.Items.Clear();
			FindedStringz.Items.AddRange(LinesNow);
		}
		*/
        private void FindedStringz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string STR_Value = FindedStringz.Text;
            STR_Value = STR_Value.Replace("#", "");
            int INT_Value = Int16.Parse(STR_Value);
            numericUpDown1.Value = INT_Value;


        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reset_strlist_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FindedStrings = "";
            FindedStringz.Items.Clear();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (FindedStringz == null || LOC.Properties.Settings.Default.FindedStrings == null)
                {
                    MessageBox.Show("The userlist data returned null, save a list first. And Try Again..", "Error", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
                if (FindedStringz.Items.Contains((Properties.Settings.Default.UserLegitStrings.Cast<string>().ToArray())) == false)
                {
                    FindedStringz.Items.AddRange(Properties.Settings.Default.UserLegitStrings.Cast<string>().ToArray());
                }

            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("The userlist data returned null, save a list first. And Try Again..", "Error", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                Console.WriteLine("EX: " + ex.Message);
            }


            //GraphList();
        }

        private void FindedStringz_Click_1(object sender, EventArgs e)
        {
            ///GraphList();
        }

        private void FindedStringz_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string STR_Value = FindedStringz.Text;
            string[] InvalidChars = {"A","a", "B","b", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W","X", "Y",
            "z", "Z", "c","d", "e", "f", "g", "h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z"
            ,"_","*","+","[","]","{","}",",",";",".",":","-","<",">","!","¡","¿","?","=",")","(","/","&","%","$","´",
            "á", "é", "í","ó","ú","ý",};
            foreach (var c in InvalidChars)
            {
                STR_Value = STR_Value.Replace(c, "");
                STR_Value = STR_Value.Replace("#", "");
                LB_DebugStr_Parse.Text = STR_Value;
            }

            int INT_Value = FastInt32Parse(STR_Value);

            numericUpDown1.Value = INT_Value;
            GoToListIndex(Int16.Parse(STR_Value));
        }
        private void GoToListIndex(int Indexz)
        {
            LV_LangStrings.Select();
            LV_LangStrings.Items[Indexz - 1].Focused = true;
            LV_LangStrings.Items[Indexz - 1].Selected = true;
            LV_LangStrings.Items[lastselect].Selected = false;
            LV_LangStrings.Items[Indexz - 1].EnsureVisible();
            lastselect = Indexz - 1;
        }
        private int FastInt32Parse(string s)
        {
            return Int32.Parse(s);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            System.Collections.Specialized.StringCollection items = new System.Collections.Specialized.StringCollection();
            items.AddRange(FindedStringz.Items.Cast<string>().ToArray());
            Properties.Settings.Default.UserSavedIntList = items;
            Properties.Settings.Default.Save();
        }

        private void ADDI_TOOLS_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            //lvMessages.FindItemWithText(SearchBar.Text).Focused = true;
            try
            {
                int I = LV_LangStrings.FindItemWithText(SearchBar.Text).Index;
                LV_LangStrings.Items[I].Focused = true;
                LV_LangStrings.Items[I].Selected = true;
                LV_LangStrings.Items[lastselect].Selected = false;
                LV_LangStrings.Items[I].EnsureVisible();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show($"Language container don´t contains: {SearchBar}. string value.", "Not Finded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void Find_BTN_Click(object sender, EventArgs e)
        {
            string LANG = Properties.Settings.Default.LanguageText;
            ResultListView.Items.Clear();
            string ValueForFind = Find_TB.Text;
            RichTextBox GetTextRTB = new RichTextBox();
            GetTextRTB.Text = LANG;
            GetTextRTB.Visible = false;
            string[] Lines = GetTextRTB.Lines;

            string IntOnlyString = LANG;

            /* foreach (var c in InvalidChars)
			 {
				 IntOnlyString.Replace(c, string.Empty);
			 }
			*/
            foreach (string text in Lines)
            {

                if (text.Contains(ValueForFind) == true)
                {
                    ResultListView.Items.Add(text);
                }
            }
        }


        private void ResultListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Message_TB_TextChanged(object sender, EventArgs e)
        {
            if (messageEntry_0 != null)
            {
                messageEntry_0.Message = Message_TB.Text;
            }

        }
        internal bool opened;
        internal string opened_url;

        internal void NewTab()
        {
            TabPage newTab = new TabPage(opened_url.Substring(LOC_DIR.Length - 20, 20));

            TC_WorkTabs.TabPages.Add(newTab);


        }
        private void btn_ReadFile_Click(object sender, EventArgs e)
        {
            if (opened == true || opened_url != string.Empty)
            {
                if (opened_url != string.Empty)
                {

                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.languagesContainer_0 != null)
            {
                if (!string.IsNullOrWhiteSpace(openedloc))
                {

                    LanguageBuilder languageBuilder = new LanguageBuilder();
                    languageBuilder.Build(this.languagesContainer_0, openedloc);
                    MessageBox.Show("Sucessfully Saved LOC to: " + LOC_DIR);
                }
            }

        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            InAppUserSettings.Default.S_Ins_Loc = InAppUserSettings.Default.S_Ins_Loc - 1;
        }

        private void ResultListView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ResultListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var ms_x = e.X;
            var ms_y = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                var clickedItem = ResultListView.GetItemAt(ms_x, ms_y);
                if (clickedItem != null)
                {
                    if (FindedStringz.Items.Contains(clickedItem.Text) == false)
                        FindedStringz.Items.Add(clickedItem.Text);
                    MessageBox.Show("Added entry!...  " + clickedItem.Text + "\rTo favorites.");
                }
            }
        }

        private void ResultListView_MouseHover(object sender, EventArgs e)
        {
            TTIP_ResultListHoveringMessage.Show("Double click in string value line to add it to favorites!.", this);
        }

        private void ResultListView_MouseLeave(object sender, EventArgs e)
        {
            TTIP_ResultListHoveringMessage.Hide(this);
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FindedStringz.Items.Count != 0)
            {

            }
        }

        private void btn6_replacement_Click(object sender, EventArgs e)
        {
            Editor_TextReplacement etr = new Editor_TextReplacement(this);
            etr.ShowDialog();
        }

        private void tpg_MainWork_Click(object sender, EventArgs e)
        {

        }
    }
}

