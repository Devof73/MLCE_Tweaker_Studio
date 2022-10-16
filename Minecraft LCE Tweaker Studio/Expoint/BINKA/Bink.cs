using System;
using System.Windows.Forms;


namespace Minecraft_LCE_Tweaker_Studio.Expoint.Audio
{
    public class Bink
    {
        [global::System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern global::System.IntPtr LoadLibrary(string lpFileName);

        [global::System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern global::System.IntPtr FreeLibrary(global::System.IntPtr library);

        public unsafe string Binka(string infile, string outDir = null, bool last = true, string working = null)
        {
            bool flag = working == null;
            string text;
            string text2;
            string path;
            if (flag)
            {
                var WorkingBasePath = Application.StartupPath + "\\Expoint\\BINKA\\Resources";
                working = WorkingBasePath;
                text = WorkingBasePath + "\\binka_encode.exe";
                text2 = WorkingBasePath + "\\mss32.dll";
                path = WorkingBasePath + "\\binkawin.asi";
                Console.WriteLine("[bink] All working set.");
                /*
				text = ExtractResource("Minecraft_LCE_Tweaker_Studio.Resources.binka_encode.exe", working, "binka_encode.exe");
				text2 = ExtractResource("Minecraft_LCE_Tweaker_Studio.Resources.mss32.dll", working, "mss32.dll");
				path = ExtractResource("Minecraft_LCE_Tweaker_Studio.Resources.binkawin.asi", working, "binkawin.asi");
				*/
                library = LoadLibrary(text2);

            }
            else
            {
                text = working + "\\binka_encode.exe";
                text2 = working + "\\mss32.dll";
                path = working + "\\binkawin.asi";
            }
            bool flag2 = GetType(infile) == "WAV";
            if (flag2)
            {
                string[] array = CreateArg(infile, outDir);
                global::System.Diagnostics.Process process = new global::System.Diagnostics.Process();
                process.StartInfo.FileName = text;
                process.StartInfo.Arguments = string.Concat(new string[]
                {
                    " \"",
                    array[0],
                    "\" \"",
                    array[1],
                    "\""
                });
                process.StartInfo.WindowStyle = global::System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
            else
            {
                bool flag3 = GetType(infile) == "BINKA";
                if (flag3)
                {
                    string[] array2 = CreateArg(infile, outDir);
                    byte[] array3 = global::System.IO.File.ReadAllBytes(array2[0]);
                    uint num = 0U;
                    AIL_set_redist_directory(".");
                    AIL_startup();
                    global::System.IntPtr intPtr;
                    bool flag4 = AIL_decompress_ASI(array3, (uint)array3.Length, ".binka", &intPtr, &num, 0U) == 0;
                    if (flag4)
                    {
                        throw new global::System.Exception("AIL ERROR");
                    }
                    Console.WriteLine("...");
                    byte[] array4 = new byte[num];
                    global::System.Runtime.InteropServices.Marshal.Copy(intPtr, array4, 0, array4.Length);
                    AIL_mem_free_lock(intPtr);
                    AIL_shutdown();
                    global::System.IO.File.WriteAllBytes(array2[1], array4);
                }
            }
            if (last)
            {
                FreeLibrary(library);
                FreeLibrary(library);
                global::System.IO.File.Delete(text);
                global::System.IO.File.Delete(path);
                while (global::System.IO.File.Exists(text2))
                {
                    try
                    {
                        global::System.IO.File.Delete(text2);
                    }
                    catch
                    {
                        FreeLibrary(library);
                    }
                }
            }
            return working;
        }
        private static string GetType(string loc)
        {
            string a = global::System.IO.Path.GetExtension(loc).ToLower();
            bool flag = a == ".binka";
            string result;
            if (flag)
            {
                result = "BINKA";
            }
            else
            {
                bool flag2 = a == ".wav";
                if (!flag2)
                {
                    throw new global::System.Exception("File type not valid. To use MP3 or other audio formats, convert to wav format before using tool");
                }
                result = "WAV";
            }
            return result;
        }
        private static string[] CreateArg(string inFile, string outdir = null)
        {
            string[] array = new string[2];
            array[0] = inFile;
            string type = GetType(inFile);
            bool flag = type == "BINKA";
            if (flag)
            {
                bool flag2 = outdir.Length > 3;
                if (flag2)
                {
                    array[1] = outdir + "\\" + global::System.IO.Path.GetFileName(inFile.Replace(".binka", ".wav"));
                }
                else
                {
                    array[1] = global::System.IO.Path.GetFullPath(inFile.Replace(".binka", ".wav"));
                }
            }
            else
            {
                bool flag3 = type == "WAV";
                if (flag3)
                {
                    bool flag4 = outdir.Length > 3;
                    if (flag4)
                    {
                        array[1] = outdir + "\\" + global::System.IO.Path.GetFileName(inFile.Replace(".wav", ".binka"));
                    }
                    else
                    {
                        array[1] = global::System.IO.Path.GetFullPath(inFile.Replace(".wav", ".binka"));
                    }
                }
            }
            bool flag5 = !global::System.IO.Directory.Exists(global::System.IO.Path.GetDirectoryName(array[1]));
            if (flag5)
            {
                global::System.IO.Directory.CreateDirectory(global::System.IO.Path.GetDirectoryName(array[1]));
            }
            return array;
        }
        internal static string ExtractResource(string resource, string path, string filename)
        {
            global::System.Reflection.Assembly executingAssembly = global::System.Reflection.Assembly.GetExecutingAssembly();
            global::System.IO.Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resource);
            byte[] array = new byte[(int)manifestResourceStream.Length];
            manifestResourceStream.Read(array, 0, array.Length);
            manifestResourceStream.Close();
            bool flag = !global::System.IO.Directory.Exists(path);
            if (flag)
            {
                global::System.IO.Directory.CreateDirectory(path);
            }
            path = path + "\\" + filename;
            global::System.IO.File.WriteAllBytes(path, array);
            return path;
        }

        [global::System.Runtime.InteropServices.DllImport("mss32.dll", EntryPoint = "_AIL_decompress_ASI@24")]
        private unsafe static extern int AIL_decompress_ASI([global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] indata, uint insize, [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string ext, global::System.IntPtr* result, uint* resultsize, uint zero);

        [global::System.Runtime.InteropServices.DllImport("mss32.dll", EntryPoint = "_AIL_last_error@0")]
        private static extern global::System.IntPtr AIL_last_error();

        [global::System.Runtime.InteropServices.DllImport("mss32.dll", EntryPoint = "_AIL_set_redist_directory@4")]
        private static extern global::System.IntPtr AIL_set_redist_directory([global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPStr)] string redistDir);

        [global::System.Runtime.InteropServices.DllImport("mss32.dll", EntryPoint = "_AIL_mem_free_lock@4")]
        private static extern void AIL_mem_free_lock(global::System.IntPtr ptr);

        [global::System.Runtime.InteropServices.DllImport("mss32.dll", EntryPoint = "_AIL_startup@0")]
        private static extern int AIL_startup();

        [global::System.Runtime.InteropServices.DllImport("mss32.dll", EntryPoint = "_AIL_shutdown@0")]
        private static extern int AIL_shutdown();

        public Bink()
        {
        }

        private static global::System.IntPtr library;
    }
}
