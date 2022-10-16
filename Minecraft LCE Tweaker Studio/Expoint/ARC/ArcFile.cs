using System.Linq;

namespace ARC_Studio.Workers
{
    class PS3ARCWorker
    {

        public void ExtractArchive(string arcPath, string workingPath)
        {
            global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list = new global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry>();
            byte[] array = global::ARC_Studio.Workers.ARC.FileUtils.smethod_0(arcPath);
            global::System.IO.MemoryStream memoryStream = null;
            if (array != null)
            {
                memoryStream = new global::System.IO.MemoryStream(array);
                int num = this.class47_0.method_4(memoryStream);
                for (int i = 0; i < num; i++)
                {
                    string name = this.method_0(memoryStream);
                    int pos = this.class47_0.method_4(memoryStream);
                    int size = this.class47_0.method_4(memoryStream);
                    ARC_Studio.Workers.ARC.ArcEntry item = new ARC_Studio.Workers.ARC.ArcEntry(name, size, pos);
                    list.Add(item);
                }
            }
            this.method_1(workingPath, list, memoryStream);
        }

        private string method_0(global::System.IO.MemoryStream memoryStream_0)
        {
            byte[] array = new byte[2];
            memoryStream_0.Read(array, 0, 2);
            if (global::System.BitConverter.IsLittleEndian)
            {
                global::System.Array.Reverse(array);
            }
            short num = global::System.BitConverter.ToInt16(array, 0);
            byte[] array2 = new byte[(int)num];
            memoryStream_0.Read(array2, 0, (int)num);
            global::System.Text.Encoding utf = global::System.Text.Encoding.UTF8;
            return utf.GetString(array2);
        }

        private void method_1(string string_0, global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list_0, global::System.IO.MemoryStream memoryStream_0)
        {
            foreach (ARC_Studio.Workers.ARC.ArcEntry arcEntry in list_0)
            {
                byte[] array = new byte[arcEntry.Size];
                memoryStream_0.Read(array, 0, arcEntry.Size);
                string text = string_0 + arcEntry.Name;
                string directoryName = global::System.IO.Path.GetDirectoryName(text);
                global::System.IO.Directory.CreateDirectory(directoryName);
                global::ARC_Studio.Workers.ARC.FileUtils.WriteFile(array, text);
            }
        }

        public void BuildArchive(string arcPath, string workingPath)
        {
            global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
            global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list = new global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry>();
            global::System.Collections.Generic.List<string> list2 = this.method_4(workingPath);
            foreach (string text in list2)
            {
                byte[] array = global::ARC_Studio.Workers.ARC.FileUtils.smethod_0(text);
                int size = array.Length;
                int pos = (int)memoryStream.Position;
                string name = text.Substring(workingPath.Length);
                memoryStream.Write(array, 0, array.Length);
                ARC_Studio.Workers.ARC.ArcEntry item = new ARC_Studio.Workers.ARC.ArcEntry(name, size, pos);
                list.Add(item);
            }
            global::System.IO.MemoryStream memoryStream2 = this.method_3(list);
            int num = (int)memoryStream2.Length;
            foreach (ARC_Studio.Workers.ARC.ArcEntry arcEntry in list)
            {
                arcEntry.Pos += num;
            }
            memoryStream2 = this.method_3(list);
            this.method_2(arcPath, memoryStream2, memoryStream);
        }

        private void method_2(string string_0, global::System.IO.MemoryStream memoryStream_0, global::System.IO.MemoryStream memoryStream_1)
        {
            using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(string_0, global::System.IO.FileMode.Create)))
            {
                binaryWriter.Write(memoryStream_0.ToArray());
                binaryWriter.Write(memoryStream_1.ToArray());
            }
        }

        private global::System.IO.MemoryStream method_3(global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list_0)
        {
            global::Class47 @class = new global::Class47();
            global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
            @class.method_10(list_0.Count, memoryStream);
            foreach (ARC_Studio.Workers.ARC.ArcEntry arcEntry in list_0)
            {
                @class.method_12(arcEntry.Name, memoryStream);
                @class.method_10(arcEntry.Pos, memoryStream);
                @class.method_10(arcEntry.Size, memoryStream);
            }
            return memoryStream;
        }

        private global::System.Collections.Generic.List<string> method_4(string string_0)
        {
            global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
            foreach (string item in global::System.IO.Directory.GetFiles(string_0))
            {
                list.Add(item);
            }
            foreach (string string_ in global::System.IO.Directory.GetDirectories(string_0))
            {
                list.AddRange(this.method_4(string_));
            }
            return list;
        }

        public PS3ARCWorker()
        {
            this.class47_0 = new global::Class47();
        }

        private global::Class47 class47_0;
    }
}


namespace ARC_Studio.Workers.ARC
{
    public class ArcEntry
    {
        public ArcEntry()
        {

        }

        public ArcEntry(string name, int size, int pos)
        {

            string_0 = name;
            int_0 = size;
            int_1 = pos;
        }

        public string Name
        {
            get
            {
                return string_0;
            }
            set
            {
                string_0 = value;
            }
        }

        public int Size
        {
            get
            {
                return int_0;
            }
            set
            {
                int_0 = value;
            }
        }

        public int Pos
        {
            get
            {
                return int_1;
            }
            set
            {
                int_1 = value;
            }
        }

        private string string_0;

        private int int_0;

        private int int_1;
    }
}



namespace ARC_Studio.Workers.ARC
{
    public class FileUtils
    {
        internal static byte[] smethod_0(string string_0)
        {
            byte[] array = null;
            if (global::System.IO.File.Exists(string_0))
            {
                using (global::System.IO.BinaryReader binaryReader = new global::System.IO.BinaryReader(global::System.IO.File.Open(string_0, global::System.IO.FileMode.Open)))
                {
                    long length = binaryReader.BaseStream.Length;
                    binaryReader.BaseStream.Seek(0L, global::System.IO.SeekOrigin.Begin);
                    array = new byte[length];
                    binaryReader.Read(array, 0, (int)length);
                }
            }
            return array;
        }

        internal static string smethod_1(string string_0, string string_1, string string_2, string string_3 = "")
        {
            global::System.Windows.Forms.OpenFileDialog openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
            string result = null;
            string_2 = global::ARC_Studio.Workers.ARC.FileUtils.smethod_2(string_2);
            openFileDialog.DefaultExt = string_0;
            openFileDialog.Filter = string_1;
            openFileDialog.InitialDirectory = string_2;
            openFileDialog.FileName = string_3;
            global::System.Windows.Forms.DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == global::System.Windows.Forms.DialogResult.OK)
            {
                result = openFileDialog.FileName;
            }
            return result;
        }

        private static string smethod_2(string string_0)
        {
            try
            {
                if (!string.IsNullOrEmpty(string_0))
                {
                    string_0 = global::System.IO.Path.GetDirectoryName(string_0);
                }
            }
            catch (global::System.Exception)
            {
            }
            return string_0;
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

        internal static string smethod_4(string string_0, string string_1 = "Conversion output folder")
        {
            string result = null;
            using (global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new global::System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.Description = string_1;
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.RootFolder = global::System.Environment.SpecialFolder.MyComputer;
                folderBrowserDialog.SelectedPath = string_0;
                if (folderBrowserDialog.ShowDialog() == global::System.Windows.Forms.DialogResult.OK)
                {
                    result = folderBrowserDialog.SelectedPath;
                }
            }
            return result;
        }

        internal static string smethod_5(string string_0)
        {
            string text = string_0;
            int num = text.LastIndexOf('\\');
            if (num > 0)
            {
                text = text.Substring(num + 1);
            }
            num = text.LastIndexOf('.');
            if (num > 0)
            {
                text = text.Substring(0, num);
            }
            return text;
        }

        public static void WriteFile(global::System.IO.MemoryStream stream, string filename)
        {
            using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(filename, global::System.IO.FileMode.Create)))
            {
                byte[] buffer = stream.ToArray();
                binaryWriter.Write(buffer);
            }
        }

        public static void WriteFile(byte[] bytes, string filename)
        {
            using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(filename, global::System.IO.FileMode.Create)))
            {
                binaryWriter.Write(bytes);
            }
        }

        public static short ReadShort(global::System.IO.BinaryReader reader)
        {
            byte[] array = new byte[2];
            array = reader.ReadBytes(2);
            if (global::System.BitConverter.IsLittleEndian)
            {
                global::System.Array.Reverse(array);
            }
            return global::System.BitConverter.ToInt16(array, 0);
        }

        public static byte[] ReadBytes(global::System.IO.BinaryReader reader, int fieldSize, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder byteOrder)
        {
            byte[] array = new byte[fieldSize];
            if (byteOrder == global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.LittleEndian)
            {
                return reader.ReadBytes(fieldSize);
            }
            for (int i = fieldSize - 1; i > -1; i--)
            {
                array[i] = reader.ReadByte();
            }
            return array;
        }

        public static uint smethod_6(global::System.IO.BinaryReader reader, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder byteOrder)
        {
            if (byteOrder == global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.LittleEndian)
            {
                return (uint)reader.ReadInt32();
            }
            return global::System.BitConverter.ToUInt32(global::ARC_Studio.Workers.ARC.FileUtils.ReadBytes(reader, 4, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.BigEndian), 0);
        }

        public static void smethod_7(global::System.IO.BinaryWriter writer, uint value, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder byteOrder)
        {
            byte[] array = global::System.BitConverter.GetBytes(value);
            if (byteOrder == global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.BigEndian)
            {
                array = array.Reverse<byte>().ToArray<byte>();
            }
            writer.Write(array);
        }

        internal static void smethod_8(string string_0)
        {
            foreach (string path in global::System.IO.Directory.GetFiles(string_0))
            {
                global::System.IO.File.Delete(path);
            }
        }

        internal static void smethod_9(string string_0)
        {
            if (!global::System.IO.Directory.Exists(string_0))
            {
                global::System.IO.Directory.CreateDirectory(string_0);
            }
        }

        public static string CheckFolderSep(string folderPath)
        {
            if (folderPath != null && !folderPath.EndsWith("\\"))
            {
                folderPath += "\\";
            }
            return folderPath;
        }

        public static bool CheckFolderExists(string folderPath)
        {
            folderPath = global::ARC_Studio.Workers.ARC.FileUtils.CheckFolderSep(folderPath);
            return global::System.IO.Directory.Exists(folderPath);
        }

        internal static void smethod_10(string string_0)
        {
            if (global::System.IO.File.Exists(string_0))
            {
                global::System.IO.File.Delete(string_0);
            }
        }

        internal static void smethod_11(string string_0, string string_1)
        {
            if (global::System.IO.File.Exists(string_0))
            {
                global::System.IO.File.Move(string_0, string_1);
            }
        }

        internal static void smethod_12(string string_0, string string_1)
        {
            if (global::System.IO.File.Exists(string_0))
            {
                if (global::System.IO.File.Exists(string_1))
                {
                    global::ARC_Studio.Workers.ARC.FileUtils.smethod_10(string_1);
                }
                global::System.IO.File.Copy(string_0, string_1);
            }
        }

        public static void CopyFoldersAndFiles(string source, string target)
        {
            global::System.IO.DirectoryInfo source2 = new global::System.IO.DirectoryInfo(source);
            global::System.IO.DirectoryInfo target2 = new global::System.IO.DirectoryInfo(target);
            global::ARC_Studio.Workers.ARC.FileUtils.CopyFoldersAndFiles(source2, target2);
        }

        public static void CopyFoldersAndFiles(global::System.IO.DirectoryInfo source, global::System.IO.DirectoryInfo target)
        {
            global::Class43 @class = new global::Class43();
            foreach (global::System.IO.DirectoryInfo directoryInfo in source.GetDirectories())
            {
                global::ARC_Studio.Workers.ARC.FileUtils.CopyFoldersAndFiles(directoryInfo, target.CreateSubdirectory(directoryInfo.Name));
            }
            foreach (global::System.IO.FileInfo fileInfo in source.GetFiles())
            {
                @class.method_0(fileInfo.FullName, global::System.IO.Path.Combine(target.FullName, fileInfo.Name));
            }
        }

        internal static long smethod_13(string string_0)
        {
            global::System.IO.FileInfo fileInfo = new global::System.IO.FileInfo(string_0);
            return fileInfo.Length;
        }

        public FileUtils()
        {
        }

        public enum ByteOrder
        {
            LittleEndian,
            BigEndian
        }
    }
}
