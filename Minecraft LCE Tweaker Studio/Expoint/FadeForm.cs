using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Minecraft_LCE_Tweaker_Studio.Expoint
{
    internal class FadeForm
    {
        System.Windows.Forms.Form SForm = null;
        System.Windows.Forms.Timer AnimController = new System.Windows.Forms.Timer();
        public FadeForm(System.Windows.Forms.Form Form)
        {
            SForm = Form;
        }
        public void AnimationStart()
        {
            AnimController = new System.Windows.Forms.Timer();
            AnimController.Interval = 5;
            AnimController.Tick += AnimController_Tick;
            AnimController.Start();
        }
        private void AnimController_Tick(object sender, EventArgs e)
        {
            if (SForm.Opacity == 1.0)
            {
                AnimController.Stop();
                return;
            }
            SForm.Opacity += 0.070;
            
        }
    }
}
