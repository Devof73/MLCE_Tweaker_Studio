using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COL_Editor.Classes
{
    static class COL
    {
        public class COLFile
        {
            public string OpenFile = "";
            byte[] data;
            List<byte> extradata = new List<byte>();
            public List<object[]> entries = new List<object[]>();
            public void Open(string filePath)
            {
                data = File.ReadAllBytes(filePath);
                COL.Open(this, entries, data, extradata);
                foreach (object[] obj in entries)
                {
                    Console.WriteLine(obj[0].ToString() + " - #" + obj[1]);
                }
                //File.WriteAllBytes(Path.GetDirectoryName(filePath) + "\\coloursExtraData.col.bin", extradata.ToArray());
            }
            public void Save()
            {
                List<byte> SaveData = new List<byte>();
                SaveData.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x01 });
                Console.WriteLine(entries.Count);
                List<byte> ItemAmmount = new List<byte>();
                ItemAmmount.AddRange(BitConverter.GetBytes(entries.Count));
                ItemAmmount.Reverse();
                byte[] ItemNum = ItemAmmount.ToArray();
                ItemNum.Reverse();
                Console.WriteLine(BitConverter.ToString(ItemNum));
                SaveData.AddRange(ItemNum);
                foreach (object[] obj in entries)
                {
                    //Console.WriteLine(obj[0] + " - #" + obj[1]);
                    byte[] NameLength = (BitConverter.GetBytes(obj[0].ToString().Length));
                    SaveData.Add(NameLength[1]);
                    SaveData.Add(NameLength[0]);
                    SaveData.AddRange(Encoding.ASCII.GetBytes(obj[0].ToString()));
                    SaveData.Add(data[SaveData.Count]);
                    SaveData.AddRange(StringToByteArrayFastest(obj[1].ToString()));
                }
                SaveData.AddRange(extradata);
                if (OpenFile == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Colours File|*.col";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        OpenFile = sfd.FileName;
                        File.WriteAllBytes(sfd.FileName, SaveData.ToArray());
                    }

                }
                else
                {
                    File.WriteAllBytes(OpenFile, SaveData.ToArray());
                }
            }
        }
        public static void Open(COLFile This, List<object[]> entries, byte[] data, List<byte> extradata)
        {
            List<byte> MaxEntArrTemp = new List<byte>();
            MaxEntArrTemp.AddRange(data.Skip(4).Take(4));
            MaxEntArrTemp.Reverse();
            int MaxEntries = BitConverter.ToInt32(MaxEntArrTemp.ToArray(), 0);
            int i = 1;
            int LeftAt = 8;
            while (i <= MaxEntries)
            {
                List<byte> ItemNameLength = new List<byte>();
                ItemNameLength.AddRange(data.Skip(LeftAt).Take(2));
                ItemNameLength.Reverse();
                int EntryLength = BitConverter.ToInt16(ItemNameLength.ToArray(), 0);
                //Console.WriteLine(EntryLength);

                byte[] ItemName = (data.Skip(LeftAt + 2).Take(EntryLength).ToArray());
                byte[] ItemHex = (data.Skip(LeftAt + 3 + EntryLength).Take(3).ToArray());

                object[] outentry = { System.Text.Encoding.Default.GetString(ItemName), BitConverter.ToString(ItemHex).Replace("-", "") };
                entries.Add(outentry);
                LeftAt = LeftAt + 6 + EntryLength;

                i++;
            }
            Console.WriteLine(LeftAt);
            Console.WriteLine(data.Length);
            Console.WriteLine(data.Length - LeftAt);
            extradata.AddRange(data.Skip(LeftAt).Take((data.Length) - LeftAt).ToArray());
        }


        static byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
    }
}
