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

namespace Minecraft_LCE_Tweaker_Studio.Expoint.BINKA
{
    
    public partial class AudioBinkInputOutputForm : Form
    {
        internal static Audio.Bink bink = new Audio.Bink();
        public AudioBinkInputOutputForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Invoke new Instance for descompression of provided filename.
        /// </summary>
        /// <param name="fastfile">The complete path of the target file what you want to comp/decomp.</param>
        internal AudioBinkInputOutputForm(string fastfile)
        {
             // Operation Index, 0 : return, 1 : binknow, 2 : binktowav
            InstaWorkFf(fastfile);
        }
        internal void InstaWorkFf(string targetfilename)
        {
            var format = Path.GetExtension(targetfilename).ToLower();
            string respMessage = "MISSING_RESPONSE";
            switch (format)
            {
                case ".binka":
                    {
                        respMessage = "Decompress: \"" + targetfilename + "\"?";
                        break;
                    }
                case ".wav":
                    {
                        respMessage = "Make a new BINKA from this selected audio?";
                        break;
                    }

            }

            if (format != ".wav" && format != ".binka")
            {
                return;
              
            }
            else
            {
                var result = MessageBox.Show(respMessage, "¿?", buttons: MessageBoxButtons.YesNo);
                if (result is DialogResult.Yes)
                {
                    try
                    {
                        var outPath = Path.GetDirectoryName(targetfilename);
                        bink.Binka(targetfilename, outPath, false, null);
                        MessageBox.Show("Successfully converted: \r" + FnIn + "\rSaved in path: " + outPath + (new FileInfo(targetfilename).Name));
                   
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Error: " + err.GetType().ToString() + " - " + err.Message);
                    }
                }
               
            }
          
        }
        private void btn1_iselection_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "BINKA Deep Audio File|*.binka|Wave Audio Files|*.wav",
                AddExtension = true,
                Title = "Select .WAV",
            };
            if (ofd.ShowDialog()  is DialogResult.OK)
            {
                var fn = ofd.FileName;
                tbx_input.Text = fn;
                FnIn = fn ;
                btn4_playaudio.Enabled = true;
            }
            var fext = Path.GetExtension(ofd.FileName).ToLower();
            SelFileIsWav = fext is ".wav";
            btn3_binkwav.Enabled = !SelFileIsWav;
            btn3_binknow.Enabled = SelFileIsWav;
            lbl2_trackname.Text = "TrackName: "+(new FileInfo(FnIn)).Name;

        }
        internal bool SelFileIsWav = false;
        internal string FnIn;
        internal string FnOut = @"C:\";
        private void btn3_binknow_Click(object sender, EventArgs e)
        {
            if (SelFileIsWav is true && FnIn.EndsWith(".wav"))
            {
                var FnIn = tbx_input.Text;
                bink.Binka(FnIn, FnOut, false, null);
            }
        }

        private void btn3_binkwav_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelFileIsWav is false && FnIn.EndsWith(".binka"))
                {
                    var outPath = Path.GetDirectoryName(FnIn);
                    bink.Binka(FnIn, outPath, false, null);
                    MessageBox.Show("Successfully converted: \r" + FnIn + "\rSaved in path: " + outPath +(new FileInfo(FnIn).Name));
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("[EX] {0}\r{1}\r{2}\r{3}", err.GetType().ToString(), err.Message, err.Source, err.HResult);
            }
        }

        private void AudioBinkInputOutputForm_Load(object sender, EventArgs e)
        {

        }
        internal string latestSongPath = "";
        internal string latestSongDir = "";
        internal CSAudioPlayer.AudioPlayer audioOut;
        private void btn4_playaudio_Click(object sender, EventArgs e)
        {
            if (FnIn == null)
            {
                btn4_playaudio.Enabled = false;
                return;
            }
            if (audioOut != null && audioOut.PlaybackState == CSCore.SoundOut.PlaybackState.Playing)
            {
                audioOut.Pause();
            }
            if (Directory.Exists(latestSongDir) is true && tbx_input.Text == FnIn && audioOut != null)
            {
                try
                {
                    audioOut.Resume();
                }
                catch
                {
                    audioOut = null;
                    audioOut = new CSAudioPlayer.AudioPlayer()
                    {
                        FileName = latestSongPath,
                        Channels = CSAudioPlayer.Channels.channels2,
                        AudioDevice = 1,
                        Mode = CSAudioPlayer.Mode.WasapiOut
                          ,
                        Volume = 100,
                    };
                    audioOut.Play();
                    LBL3_Duration.Text = "Duration: "+audioOut.Length.ToString();
                }
            }
            // SI FNIN EXISTE Y INPUT ES IGUAL A FNIN EJECUTAR 
            if (File.Exists(FnIn) is true && tbx_input.Text == FnIn)
            {
                // CONSIGUE EXTENSIÓN DEL ARCHIVO Y LO REGISTRA
                var ext = Path.GetExtension(FnIn).ToLower(); Console.WriteLine("EXT: {0} ", ext);
                // CANCELA SI LA EXTENSIÓN NO ES NINGUNA.
                if (string.IsNullOrEmpty(ext) is true) { return; }
                // EN CASO DE QUE SEA BINKA
                if (ext == ".binka" == true)
                {
                    Console.WriteLine("Ex is binka. Processing...");
                        // CONSIGUE EL ARCHIVO CONVERTIDO Y LO HACE SONAR...
                    try
                    {
                        var outPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\mlce_temp";
                        try { Directory.Delete(outPath, true); } catch { }
                        Console.WriteLine("-.- Please wait...");
                        if (Directory.Exists(outPath) == false) { Directory.CreateDirectory(outPath); };
                        latestSongDir = outPath;
                        bink.Binka(FnIn, outPath, true, null);
                        string fileName = outPath + "\\" + (new FileInfo(FnIn).Name.Replace(".binka", ".wav"));
                        Console.WriteLine("Final Filename result = " + fileName);
                        latestSongPath = fileName;
                        Console.WriteLine("lts: " + latestSongPath);
                        audioOut = new CSAudioPlayer.AudioPlayer();
                        audioOut.Channels = CSAudioPlayer.Channels.channels2;
                        audioOut.Mode = CSAudioPlayer.Mode.WasapiOut;
                        audioOut.DecodeMode = CSAudioPlayer.DecodeMode.LocalCodecs;
                        audioOut.UserName = "dev";
                        audioOut.UserKey = "dev";
                        audioOut.FileName = fileName;
                        audioOut.AudioDevice = audioOut.GetDeviceDefaultIndex(CSAudioPlayer.Mode.WasapiOut);
                        audioOut.Play();
                        button1.Enabled = true;
                        MessageBox.Show(string.Format("previewing {0} ...", fileName));
                        Console.WriteLine("AO != null is " + (audioOut != null));
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("[EX] {0}\r{1}\r{2}\r{3}", err.GetType().ToString(), err.Message, err.Source, err.HResult);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // DETIENE EL AUDIO SI ESTE ESTA ASIGNADO.
            if (audioOut != null && string.IsNullOrEmpty(latestSongPath) is false)
            {
                audioOut.Stop();
                audioOut = null;
                button1.Enabled = false;
             
            }
        }
    }
}
