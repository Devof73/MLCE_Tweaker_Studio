using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms
{
    public partial class HudViewer : Form
    {
        public EditorGUI Ins_Main = null;
        internal string FileName = "";
        List<byte[]> PrwData = null;
        public HudViewer(EditorGUI sender)
        {
            InitializeComponent();
            Ins_Main = sender;
            FileName = Ins_Main.CurrentFuiFileName;
        }
        public HudViewer(string fn)
        {
            InitializeComponent();
            FileName = fn;
        }
        public HudViewer(string fn, List<byte[]> dat)
        {
            InitializeComponent();
            FileName = fn;
            PrwData = dat;
        }
        internal Bitmap GetBitmapFromIndex(int index)
        {
            try
            {
                var trgt = Ins_Main;
                var dat = trgt.InstanceData[index];
                using (MemoryStream ms = new MemoryStream(dat))
                {
                    return new Bitmap(ms);
                }
            }
            catch
            {
                return SystemIcons.Error.ToBitmap() ;
            }
           
        }
        internal void GraphDesign()
        {
            if (PrwData != null)
            {
                
                GNPIC_VIEW.Image = (new MinecraftLegacyConsoleRE.GameFile_FUI.SkinGraphicsPreviewDrawer()).RenderPreview(new MinecraftLegacyConsoleRE.GameFile_FUI(FileName));
            }
            else
            {
                MinecraftLegacyConsoleRE.GameFile_FUI File = new MinecraftLegacyConsoleRE.GameFile_FUI(FileName);
                GNPIC_VIEW.Image = File.GraphicalType.Graph(File);
            }
            
        }

        private void HudViewer_Load(object sender, EventArgs e)
        {
            GraphDesign();
        }
    }
}
