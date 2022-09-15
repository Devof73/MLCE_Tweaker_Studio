using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace DevNotepad
{
    public partial class MainEditor : Form
    {
        public MainEditor()
        {
            InitializeComponent();
            Timer_TickEvents.Start();
        }
        public MainEditor(string fn)
        {
            InitializeComponent();
            Timer_TickEvents.Start();
            var filename = fn;
            System.IO.StreamReader sr = new System.IO.StreamReader(filename);
            var data = sr.ReadToEnd();
            originalText = data;
            path = filename;
            TSSL_FilePath.Text = filename;
            RTB_main_Workspace.Text = data;
            RTB_main_Workspace.Refresh();
        }
        internal int sel_index;
        Color defaultInputColor = Color.White;
        bool NeedsSave = true;
        int charsModifiedNow = 0;
        int ticksEvent = 0;
        string path = "none";
        string originalText = "";
        bool txt_EditorCodeMode = false;
        bool txt_EditorCommonMode = true;
        internal Font currentEntryFont = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        internal bool App_SaveCurrentProjectFile(bool sfd = false)
        {
            if (path != "none" && path != String.Empty && sfd == false)
            {
                File.WriteAllText(path, RTB_main_Workspace.Text);
            }
            else if (sfd is true && path is "none")
            {
                SaveFileDialog sfdl = new SaveFileDialog()
                {
                    SupportMultiDottedExtensions = true, 
                    RestoreDirectory = true, Title = "Select Project Save Output."
                };
                if (sfdl.ShowDialog() == DialogResult.OK)
                {
                    path = sfdl.FileName;
                    File.WriteAllText(path, this.RTB_main_Workspace.Text);
                }
                sfdl.Dispose();
            }
            return File.Exists(path);
        }
        int mode = 0;
        internal bool App_CheckIfSaveIsNeeded()
        {
            if (RTB_main_Workspace.Text == String.Empty)
            {
                NeedsSave = false;
            }
            else if (RTB_main_Workspace.Text == originalText)
            {
                NeedsSave = false;
            }
            else if (path == "none" && RTB_main_Workspace.Text == string.Empty)
            {
                NeedsSave = false;
            }
            else if (path == "none" && RTB_main_Workspace.Text != string.Empty)
            {
                NeedsSave = true;
            }
            else if (path != "none" && File.Exists(path))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(path);
                var data = sr.ReadToEnd();
                if (data != this.RTB_main_Workspace.Text)
                {
                    NeedsSave = true;
                }
                sr.Close();
            }
            switch (NeedsSave)
            {
                case true:{TSSL_FileNeedsToBeSaved.Text = "File Needs Be Saved."; TSSL_FileNeedsToBeSaved.ForeColor = Color.OrangeRed;  break;}
                case false: { TSSL_FileNeedsToBeSaved.Text = "File No Needs To Be Saved."; TSSL_FileNeedsToBeSaved.ForeColor = Color.Green; break; }
            }

            //TSSL_FileNeedsToBeSaved.Text 
            return NeedsSave;
        }
        internal void App_DetectMethodFragment()
        {
            var last_line = RTB_main_Workspace.Lines[RTB_main_Workspace.Lines.Length-2];
            var key = "(";
            var matchString = Regex.Escape(key);
            foreach (Match match in Regex.Matches(last_line, matchString))
            {
                try
                {
                    if (last_line.Contains("(") && last_line.Contains(")"))
                    {
                        char empt = ' ';
                        string[] spaced_values = last_line.Split(empt);
                        foreach (var value in spaced_values)
                        {
                            if (value.Contains("("))
                            {
                                int appearingAtIndex = value.IndexOf("(");
                                
                                int var_index = RTB_main_Workspace.Text.IndexOf(value);
                                RTB_main_Workspace.Select(var_index, value.Length);
                                var classic_mtd_color = App_ColorCSharpCodeReferences(RTB_main_Workspace.SelectedText);
                                RTB_main_Workspace.SelectionColor = classic_mtd_color;
                                RTB_main_Workspace.Select(sel_index, 0);
                            }
                        }

                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message + "\rSource:" + ex.Source + "\rStackTrace:" + ex.StackTrace + "\rMatch Index: "+ match.Index+ "\rMatch Length: "+match.Length);
                    Console.ReadLine();
                    return;
                }

            };
        }

        internal Color App_ColorCSharpCodeReferences(string refName)
        {
            var obj_color = Color.FromArgb(75, 155, 198);
            var condition_worker_color = Color.FromArgb(216, 160, 223);
            var function_color = Color.FromArgb(220, 204, 120);
            if (refName == "")
            { return Color.White; }

            else if (refName == "object" || refName == "string" || refName == "int" || refName == "var" || refName == "short" || refName == "long" || refName == "byte" || refName == "bool" || refName == "void" || refName == "true" || refName == "false" || refName == "using" || refName == "internal" || refName == "private" || refName == "public" || refName == "readonly" || refName == "const" || refName == "static")
            { return obj_color; }
            else if (refName == "for" || refName == "foreach" || refName == "if" || refName == "break" || refName == "continue" || refName == "goto" || refName == "in" || refName == "return" || refName == "else")
            { return condition_worker_color; }
            else if (refName.EndsWith("()") || refName.EndsWith(")") || refName.Contains("(")) 
            {
                return function_color;
            }
            else
            {
                return defaultInputColor;
            }
        }

        internal void App_CodeModeDetectValues()
        {
            string[] common_codes = {"object", "string", "int","Array", "var", "short", "long", "byte", "for", "foreach", "continue", "break", "void",
            "switch", "bool", "false", "true", "using", "internal", "private", "public", "readonly", "static", "else", "if", "in", "switch", "return"};
            foreach (string value in common_codes)
            {
                
                if (RTB_main_Workspace.Text.Contains(value))
                {
                    var matchString = Regex.Escape(value);
                    foreach (Match match in Regex.Matches(RTB_main_Workspace.Text, matchString))
                    {

                        try
                        {
                            string getString = RTB_main_Workspace.Text.Substring(match.Index, value.Length + 1);
                            RTB_main_Workspace.Select(match.Index, value.Length);
                            RTB_main_Workspace.SelectionColor = App_ColorCSharpCodeReferences(value);
                            RTB_main_Workspace.Select(RTB_main_Workspace.TextLength, 0);
                            RTB_main_Workspace.SelectionColor = RTB_main_Workspace.ForeColor;
                            RTB_main_Workspace.ForeColor = defaultInputColor;
                            RTB_main_Workspace.Select(sel_index, 0);

                        }
                        catch
                        {
                            return;
                        }
                        
                    };
                }
            }
            
        }
        internal void App_Open()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Open A File To Start Editing It As Text"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filename = ofd.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                var data = sr.ReadToEnd();
                originalText = data;
                path = filename;
                TSSL_FilePath.Text = filename;
                RTB_main_Workspace.Text = data;
                RTB_main_Workspace.Refresh();
                sr.Close();
            }
        }
        private void wordColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void TSMI_OpenBTN_Click(object sender, EventArgs e)
        {
            App_Open();
        }
        private void RTB_main_Workspace_TextChanged(object sender, EventArgs e)
        {
            sel_index = RTB_main_Workspace.SelectionStart;
            charsModifiedNow = charsModifiedNow + 1;
            //if (ticksEvent == 5 && mode == 2 && txt_EditorCodeMode == true)
            {
               
            }
            if (charsModifiedNow == 10)
            {
                charsModifiedNow = 0;
                App_CheckIfSaveIsNeeded();
            }
            if (charsModifiedNow == 9 && txt_EditorCodeMode == true)
            {
                if (RTB_main_Workspace.Lines[RTB_main_Workspace.Lines.Length - 2].Contains("("))
                {
                    App_DetectMethodFragment();
                }
                App_CodeModeDetectValues();

                
            }
        }
        /// <summary>
        /// Función del contador principal de ticks en la aplicación,
        /// cada 5 veces repetido este método, se ejecuta un evento especial de comprobación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_TickEvents_Tick(object sender, EventArgs e)
        {
            sel_index = RTB_main_Workspace.SelectionStart;
            App_CheckIfSaveIsNeeded();
            ticksEvent = ticksEvent + 1;
            
            if (ticksEvent == 10 && mode == 2 && txt_EditorCodeMode == true)
            {
                App_CodeModeDetectValues();
                App_DetectMethodFragment();
            }
            
            if (ticksEvent == 20) { ticksEvent = 0; }
            RTB_main_Workspace.SelectionStart = sel_index;
        }
        private void TSRBTN_FClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0x02);
        }
        private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = NeedsSave;
            if (e.Cancel == true)
            {
                string msg = "Changes in this project is not saved. You will lose your work if you don't save.\r¿Wanna save?";
                if (MessageBox.Show(msg, "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (App_SaveCurrentProjectFile() == true)
                    {
                        Environment.Exit(0x03);
                    }
                    else if (App_SaveCurrentProjectFile() == false)
                    {
                        App_SaveCurrentProjectFile(true);
                    }
                    else
                    {
                        MessageBox.Show("Cannot Save.", "Unknown Exception.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    Environment.Exit(0x03);
                }
            }
        }

        private void TSBTN_ROTF_Click(object sender, EventArgs e)
        {
            if (originalText != String.Empty)
            {
                if (originalText == RTB_main_Workspace.Text == false)
                {
                    if (MessageBox.Show("¿Are you sure to discard all the changes and restart the file?", "Work Reset Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        RTB_main_Workspace.Text = originalText;
                    }
                }
                else
                {
                    MessageBox.Show("No changes you made yet.", "Cannot Reset Work", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (originalText == String.Empty || originalText == RTB_main_Workspace.Text)
            {
                MessageBox.Show("No changes you made yet.", "Cannot Reset Work", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TSTMI_CodeMode_Click(object sender, EventArgs e)
        {
            TSTMI_CodeMode.Checked = true; txt_EditorCodeMode = true;
            TSTMI_CTM_Mode.Checked = false; txt_EditorCommonMode = false;
            mode = 2;
            RTB_main_Workspace.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void TSTMI_CTM_Mode_Click(object sender, EventArgs e)
        {
            TSTMI_CodeMode.Checked = false; txt_EditorCodeMode = false;
            TSTMI_CTM_Mode.Checked = true; txt_EditorCommonMode = true;
            mode = 0;
        }

        private void TSBTN_txtzoom_more_Click(object sender, EventArgs e)
        {
            float size = currentEntryFont.Size;
            size = size + 1;
            RTB_main_Workspace.Font =
            new System.Drawing.Font(currentEntryFont.OriginalFontName, size
            , System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void RTB_main_Workspace_FontChanged(object sender, EventArgs e)
        {
            currentEntryFont = RTB_main_Workspace.Font;
        }

        private void TSBTN_txtzoom_minus_Click(object sender, EventArgs e)
        {
            float size = currentEntryFont.Size;
            size = size - 1;
            RTB_main_Workspace.Font =
            new System.Drawing.Font(currentEntryFont.OriginalFontName, size
            , System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void TSBTN_TestBnt_Click(object sender, EventArgs e)
        {
            App_DetectMethodFragment();
        }

        private void RTB_main_Workspace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                sel_index = RTB_main_Workspace.SelectionIndent;
            }
        }

        private void RTB_main_Workspace_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void RTB_main_Workspace_Click(object sender, EventArgs e)
        {
            var label1 = TSSL_RTBWS_SelIndex;
            var label2 = TSSL_RTBWS_SelLength;
            label1.Text = $"Selection Index: [{RTB_main_Workspace.SelectionStart}]";
            label2.Text = $"Selection Length: [{RTB_main_Workspace.SelectionLength}]";
          
        }

        private void TSTMI_ColorDetWords_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FontDialog fdl = new FontDialog()
            {
                ShowColor = true,
                ShowApply = false,
                ShowHelp = false,
                ShowEffects = false,
            
            };
            if (fdl.ShowDialog() is DialogResult.OK)
            {
                var sfont = fdl.Font;
                this.RTB_main_Workspace.Font = sfont;
                this.RTB_main_Workspace.ForeColor = fdl.Color;
            }
            fdl.Dispose();
        }
    }
}
