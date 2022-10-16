using System;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio
{
    public partial class Welcome_Form : Form
    {
        Expoint.InAppUserSettings UserSettings = new Expoint.InAppUserSettings();
        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void BTN_MainMessageOk_Click(object sender, EventArgs e)
        {
            BTN_MainMessageOk.Hide();
            LB_Loading_Indicator.Visible = true;
            UserSettings.IsNewUser = false;
            Expoint.InAppUserSettings.Default.IsNewUser = false;
            Expoint.InAppUserSettings.Default.Save();
            MainCenter main_AppCenter = new MainCenter();
            main_AppCenter.Show();
            this.Hide();
        }
    }
}
