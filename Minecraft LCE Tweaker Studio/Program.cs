using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Expoint.InAppUserSettings.Default.IsNewUser == true)
            {
                Application.Run(new Welcome_Form());

            }
            if (Expoint.InAppUserSettings.Default.IsNewUser == false)
            {
                Application.Run(new MainCenter());
            }

        }
    }
}
