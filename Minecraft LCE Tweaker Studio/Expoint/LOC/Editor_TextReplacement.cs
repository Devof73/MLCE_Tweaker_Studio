using System;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.LOC
{
    public partial class Editor_TextReplacement : Form
    {
        private Editor senderInst;
        string ortxt = "";
        public Editor_TextReplacement(Editor ins)
        {
            ortxt = ins.Message_TB?.Text;
            senderInst = ins;
            InitializeComponent();
        }

        private void btn2_contains_Click(object sender, EventArgs e)
        {
            bool containsVal = rtbx1_text.Text.Contains(tbx_query.Text);
            bool indexed = (rtbx1_text.Text.IndexOf(tbx_query.Text) != -1);
            MessageBox.Show($"Match Result:\rContains: {containsVal}\rIs Indexed: {indexed} as value {rtbx1_text.Text.IndexOf(tbx_query.Text)}");
        }

        private void btn1_replace_Click(object sender, EventArgs e)
        {
            if (rtbx1_text.Text.Contains(tbx_query.Text) is true)
            {
                rtbx1_text.Text = rtbx1_text.Text.Replace(tbx_query.Text, tbx_replacementValue.Text);
            }
        }

        private void btn4_aply_Click(object sender, EventArgs e)
        {
            senderInst.Message_TB.Text = rtbx1_text.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); this.Dispose(true);
        }

        private void rtbx1_text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_si.Text = "Selected Index: " + rtbx1_text.SelectionIndent;
                lbl_sil.Text = "Selected Index Length: " + rtbx1_text.SelectionLength;
                lbl_tl.Text = "Text Length: " + rtbx1_text.Text.Length;
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rtbx1_text.Text = originalText;
        }

        private void Editor_TextReplacement_Load(object sender, EventArgs e)
        {
            rtbx1_text.Text = ortxt;

        }
    }
}
