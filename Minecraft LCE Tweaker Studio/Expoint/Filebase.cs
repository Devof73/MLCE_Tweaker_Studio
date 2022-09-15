using System;
using System.IO;

namespace ARC_Studio.Workers
{

    public enum Endianness
    {
        Little = 0,
        Big = 1
    }

    public abstract class FileBase
    {
        public abstract Endianness Endian { get; set; }


        public abstract void Read(string filename);
        public abstract byte[] Rebuild();

        public void Save(string filename)
        {
            var Data = Rebuild();
            if (Data.Length <= 0)
                throw new Exception("Warning: Data was empty!");

            File.WriteAllBytes(filename, Data);
        }
    }
}
