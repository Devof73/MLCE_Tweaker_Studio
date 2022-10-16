
using FuiEditor;
using Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.FJUI.Forms
{
    internal class MinecraftLegacyConsoleRE
    {

        private const string TypeGraphics = "skinGraphics";
        private const string TypeGraphicsInGame = "skinGraphicsInGame";
        private const string TypeGraphicsPS3 = "skinPS3";
        private const string TypeHUDskin = "skinGraphicsHUD";

        public static readonly string[] SkinTypes = { TypeGraphics, TypeGraphicsInGame, TypeGraphicsPS3, TypeHUDskin };
        public readonly string[] SkinTypesR = { TypeGraphics, TypeGraphicsInGame, TypeGraphicsPS3, TypeHUDskin };

        /// <summary>
        /// .FUI File Reader Tools
        /// </summary>
        internal class GameFile_FUI
        {
            public class F_UI_Graphics : IMinecraftLceGraphicsType
            {

                private int Data_Count = 0;
                private string S_Type = "Unknown";
                private List<byte[]> S_Data = null;
                public string GraphicalTypeName
                {
                    get { return S_Type; }
                }
                public int Length
                {
                    get { return GetTotalSize(); }
                }

                public F_UI_Graphics(GameFile_FUI file)
                {
                    S_Data = file.ImagesData;
                    Data_Count = file.ImagesData.Count;
                    S_Type = GetType();
                }
                public int GetDataCount()
                {
                    return Data_Count;
                }
                public Bitmap Graph(GameFile_FUI fi)
                {
                    return (new SkinGraphicsPreviewDrawer()).RenderPreview(fi);
                }
                private int GetTotalSize()
                {
                    int bytes = 0;
                    foreach (byte[] dataArray in S_Data)
                    {
                        bytes += dataArray.Length;
                    }
                    return
                    bytes;
                }
                new public string GetType()
                {
                    if (Data_Count == 317) return SkinTypes[0];
                    else if (Data_Count == 227) return SkinTypes[1];
                    else if (Data_Count == 111) return SkinTypes[2];
                    else if (Data_Count == 224) return SkinTypes[3];
                    else return "unknown";
                }

            }
            public interface IMinecraftLceGraphicsType
            {
                int GetDataCount();
                Bitmap Graph(GameFile_FUI fi);
                string GetType();
            }
            public interface IMinecraftLceGraphicsCustomizer 
            {
                GameFile_FUI Restore();
                void New(GameFile_FUI file);
                GameFile_FUI Update();

            }
            internal class SkinGraphicsPreviewDrawer
            {
                // GRAPHICS

                private static int[] sgBorders1 = { 298, 297, 296, 295, 294, 293, 292, 291, 290 };
                private static int[] sgBorders2 = { 280, 272 };
                private static int[] sgBorders3 = { 307, 299 };
                private static int[] sgSlider = { 148, 147 };
                private static int[] sgInvSlot = { 171, 170 };
                private static int[] sgSaveIcon = { 185, 186 };
                private static int sgEndBg = 185;
                private static int[] sgScrollIndicators = { 235, 234, 233, 232, 231, 230 };
                private static int[] sgWideHtplayGraphics = { 308, 311 };
                private static int[] sgHtplayGraphics = { 310, 309, 313 };
                private static int[] sgHtplayGraphics2 = { 314, 315, 316 };

                public Bitmap RenderPreview(GameFile_FUI file)
                {
                    var t = file.GraphicalType.GetType();
                    if (t == "skinGraphics")
                    {
                        return DrawCommonGraphics(file.ImagesData, sgBorders1);
                    }
                    else
                    {
                        return null;
                    }
                }
                private Bitmap DrawCommonGraphics(List<byte[]> dat, int[] sgBordersIndexes1, bool First = true, int limit = 48, int area = 16, int initialxPos = 0)
                {
                    try
                    {
                        Bitmap @base =
                        Utils.ImageUtils.ReverseColorRB(FillBmpBg(new Bitmap(600, 600), (Bitmap)Bitmap.FromStream(new MemoryStream(dat[228]))));

                        Graphics grp = Graphics.FromImage(@base);
                        {
                            var M = limit; // limit
                            var f = area; // area
                            int multiplier = 0, position = initialxPos;
                            foreach (int i in sgBordersIndexes1)
                            {

                                DebugDrawOver(grp, dat[i], position, multiplier);

                                position = position + f;
                                Console.WriteLine("p: {0}, m: {1}", position, multiplier);
                                CWRITEBOOL(position > @base.Size.Width);
                                CWRITEBOOL(position > @base.Size.Height);
                                if (position == limit)
                                {
                                    Console.WriteLine("---++");
                                    multiplier = multiplier + f;
                                    position = initialxPos;
                                }
                                if (multiplier == M && position == limit)
                                {
                                    Console.WriteLine("---true");

                                }
                            }
                            if (First)
                            {
                                var sgBordersPreview2 = DrawCommonBorders(dat, sgBorders2, true, 8, 3);
                                grp.DrawImage(sgBordersPreview2, 50, 0);
                                DebugDrawOver(grp, dat[sgSaveIcon[0]], 0, 50);
                                DebugDrawOver(grp, dat[sgSaveIcon[1]], 60, 55);
                                DebugDrawOver(grp, dat[sgSlider[0]], 0, 120);
                                DebugDrawOver(grp, dat[sgSlider[1]], 10, 120);
                                DebugDrawOver(grp, dat[135], 18, 177);
                                DebugDrawOver(grp, dat[136], 43, 177);
                                DebugDrawOver(grp, dat[137], 65, 177);
                                DebugDrawOver(grp, dat[205], 0, 460);
                                DebugDrawOver(grp, dat[204], 40, 460);
                                DebugDrawOver(grp, dat[203], 80, 460);
                                DebugDrawOver(grp, dat[202], 120, 460);
                                DebugDrawOver(grp, dat[201], 170, 460);
                                DebugDrawOver(grp, dat[199], 210, 460);
                                DebugDrawOver(grp, dat[198], 250, 460);
                                DebugDrawOver(grp, dat[155], 9, 247);
                                DebugDrawOver(grp, dat[157], 9, 290);
                                DebugDrawOver(grp, dat[105], 370, 350);
                                DebugDrawOver(grp, dat[104], 251, 350);
                                DebugDrawOver(grp, dat[152], 9, 339);
                                DebugDrawOver(grp, dat[154], 9, 383);
                                var borders3 = DrawCommonBorders(dat, sgBorders3);
                                DebugDrawOver(grp, borders3, 465, 10);

                                Console.WriteLine("GRP scale = {0}", grp.PageScale);
                                Console.WriteLine("GRP != null = {0}", (grp != null).ToString());
                                Console.WriteLine("Finished! - {0}", nameof(RenderPreview));
                            }



                            return (@base.Clone() as Bitmap);

                            // FuiEditor.Forms.PicViewer pc = new FuiEditor.Forms.PicViewer(new Bitmap(48, 48, grp));
                            // pc.ShowDialog();
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("*ERR* : {0}, ST : {1}, {2}", err.Message, err.StackTrace, err.Source);
                        MessageBox.Show(String.Format("*ERR* : {0}, ST : {1}, {2}", err.Message, err.StackTrace, err.Source), "ERROR", buttons: MessageBoxButtons.OK
                        , icon: MessageBoxIcon.Error);
                        throw;
                    }
                }
                private Bitmap DrawCommonBorders(List<byte[]> dat, int[] sgBordersIndexes, bool arrayIsCountDown = true, int size = 32, int hRowsMax = 3)
                {
                    Bitmap @base = new Bitmap(100, 100);
                    int limit = sgBordersIndexes[1];
                    int initial = sgBordersIndexes[0];
                    Graphics grp = Graphics.FromImage(@base);
                    {
                        int position = 0;
                        int multiplier = 0;

                        if (arrayIsCountDown)
                        {
                            for (int i = initial; i > limit - 1; i--)
                            {
                                var lm = size * hRowsMax;
                                DebugDrawOver(grp, dat[i], position, multiplier);
                                position += size;
                                if (position == lm)
                                {
                                    multiplier += size;
                                    position = 0;
                                }
                                if (position == lm && multiplier == lm)
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            for (int i = initial; i > limit + 1; i++)
                            {
                                var lm = size * hRowsMax;
                                DebugDrawOver(grp, dat[i], position, multiplier);
                                position += size;
                                if (position == lm)
                                {
                                    multiplier += size;
                                    position = 0;
                                }
                                if (position == lm && multiplier == lm)
                                {
                                    break;
                                }

                            }
                        }

                    }
                    return @base;
                }

                private Bitmap FillBmpBg(Bitmap Base, Bitmap BG)
                {
                    var h = Base.Size.Height;
                    var w = Base.Size.Width;

                    var h2 = BG.Height;
                    var w2 = BG.Width;
                    using (Graphics g = Graphics.FromImage(Base))
                    {
                        for (int x = 0; x < w; x = x + h2)
                        {
                            for (int y = 0; y < h; y = y + w2)
                            {
                                if (x >= w && y >= h)
                                {
                                    break;
                                }
                                g.DrawImage(BG, x, y);
                            }

                        }
                    }
                    return Base;
                }
                internal void DebugDrawOver(Graphics @base, byte[] data, int x, int y)
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        @base.DrawImage(Utils.ImageUtils.ReverseColorRB((Bitmap)Image.FromStream(ms)), x, y);
                        ms.Dispose();
                    }
                    return;
                }
                internal void DebugDrawOver(Graphics @base, Bitmap img, int x, int y)
                {
                    @base.DrawImage(img, x, y);
                    return;
                }
                private void CWRITEBOOL(bool value)
                {
                    Console.WriteLine("-> {0}", value.ToString());
                }
                public byte[] BitmapToByteArray(Bitmap bmp)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, format: System.Drawing.Imaging.ImageFormat.Png);
                        return ms.ToArray();
                    }
                }

            }
            internal class Customizer
            {
                internal class SG : IMinecraftLceGraphicsCustomizer
                {
                    List<byte[]> Data = null;
                    List<byte[]> DataLegit = null;
                    BEND_CUSTOMIZER BEC = new BEND_CUSTOMIZER();
                    public void New(GameFile_FUI file) {  Data = DataLegit = file.ImagesData;  }
                   
                    public GameFile_FUI Update()
                    {
                        return new GameFile_FUI(Data);
                    }
                    public GameFile_FUI Restore()
                    {
                        Data = DataLegit;
                        return new GameFile_FUI(Data);
                    }
                    internal void GraphButtons(string javaWidgetsPngPath)
                    {
                        Bitmap[] bmps = BEC.SG_MAKE_BUTTONS(javaWidgetsPngPath);
                        BEC.Set(Data, new Bitmap(bmps[2], 400, 40), 155);
                        BEC.Set(Data, new Bitmap(bmps[0], 400, 40), 157);
                    }
                    internal void GraphWindow(string javaWindowPngPath, int dim = 32)
                    {
                        Bitmap[] corners = BEC.SG_MAKE_GUI_WINDOW(javaWindowPngPath, dim);
                        BEC.SetRange(Data, corners, 307, 299, true);
                        
                    }
                }
                internal class BEND_CUSTOMIZER
                {
                    internal void SetRange(List<byte[]> data, Bitmap[] bmps, int index, int count)
                    {
                        for (int i = index; index < count; i++)
                        {
                            ReplaceData(data, bmps[i], i);
                        }
                    }
                    internal void SetRange(List<byte[]> data, Bitmap[] bmps, int index, int count, bool dec)
                    {
                        if (dec is false)
                        {
                            SetRange(data, bmps, index, count);
                        }
                        else
                        {
                            for (var i = index; i > count; i--)
                            {
                                ReplaceData(data, bmps[i], i);
                            }

                        }
                    }
                    internal void ReplaceData(List<byte[]> data, Bitmap bmp, int index)
                    {
                        data[index] = BitmapToByteArray(bmp);
                    }
                    internal void Set(List<byte[]> data, Bitmap bmp, int index)
                    {
                        data[index] = BitmapToByteArray(bmp);
                    }
                    internal byte[] BitmapToByteArray(Bitmap bmp)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, bmp.RawFormat);
                            return ms.ToArray();
                        }

                    }
                    private Bitmap BMP_CROP(Bitmap BITMAP, Rectangle CROP_AREA)
                    {
                        Bitmap bmpImage = new Bitmap(BITMAP);
                        Console.WriteLine("w:{0}h:{1} - gw:{2}gh:{3}", BITMAP.Width, BITMAP.Height, CROP_AREA.Width, CROP_AREA.Height);
                        Console.WriteLine("|w:{0}h:{1} - gx:{2}gy:{3}", BITMAP.Width, BITMAP.Height, CROP_AREA.X, CROP_AREA.Y);

                        return bmpImage.Clone(CROP_AREA, bmpImage.PixelFormat);
                    }
                    /// <summary>
                    /// Reqs a 512x512 window texture.
                    /// </summary>
                    /// <returns></returns>
                    public Bitmap[] SG_MAKE_GUI_WINDOW(string windowPng, int dim = 32)
                    {
                        var img = (Bitmap)Bitmap.FromFile(windowPng);
                        Rectangle leftUp = new Rectangle(new Point(0, 0), new Size(dim, dim));
                        Rectangle RightUp = new Rectangle(new Point(473, 0), new Size(dim, dim));

                        Rectangle leftD = new Rectangle(new Point(0, 248), new Size(dim, dim));
                        Rectangle RightD = new Rectangle(new Point(473, 248), new Size(dim, dim));

                        Rectangle L = new Rectangle(new Point(0, 120), new Size(dim, dim));
                        Rectangle R = new Rectangle(new Point(473, 120), new Size(dim, dim));

                        Rectangle up = new Rectangle(new Point(127, 0), new Size(dim, dim));
                        Rectangle down = new Rectangle(new Point(127, 248), new Size(dim, dim));

                        Rectangle[] sides = { leftUp, up, RightUp, L, down, R, leftD, Rectangle.Empty, RightD };

                        Bitmap[] Result = new Bitmap[sides.Length + 1];
                        int x = 10, y = 10;
                        Color center = img.GetPixel(x, y);

                        var bmp = new Bitmap(dim, dim);
                        var g = Graphics.FromImage(bmp);
                        g.Clear(center);
                        bmp = new Bitmap(dim, dim);

                        for (int i = 0; i < sides.Length; i++)
                        {
                            if (sides[i] != Rectangle.Empty)
                            {
                                Result[i] = BMP_CROP(img, sides[i]);
                            }

                        }
                        Result[7] = bmp;

                        return Result;
                    }
                    public Bitmap[] SG_MAKE_BUTTONS(string widgetsPng)
                    {
                        var @base = (Bitmap)Bitmap.FromFile(widgetsPng);
                        var buttons = BMP_CROP(@base, new Rectangle(0, 46, 200, 60));
                        //200*20
                        var v1 = BMP_CROP(buttons, new Rectangle(0, 0, 200, 20));
                        var v2 = BMP_CROP(buttons, new Rectangle(0, 20, 200, 20));
                        var v3 = BMP_CROP(buttons, new Rectangle(0, 40, 200, 20));

                        Thread.Sleep(1500);
                        return new Bitmap[] {v1, v2, v3};
                    }
                }
            }
            private static readonly byte[] PngStartPattern =
     {
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A
        };
            private string fName = "";
            private List<byte[]> FuiDatas = null;
            private List<byte[]> LegitData = null;
            private F_UI_Graphics gtype = null;
            public string Name { get { return fName; } }
            public List<byte[]> ImagesData { get { return FuiDatas; } }
            public F_UI_Graphics GraphicalType { get { return gtype; } }
            FuiImageInfo[] FuiImageInfos = null;
            public FuiImageInfo[] ImagesInfos { get { return FuiImageInfos; } }
            public GameFile_FUI(string filename)
            {
                FuiDatas = new List<byte[]>();
                LegitData = new List<byte[]>();

                byte[] filedata = File.ReadAllBytes(filename);
                int pngIndex = ArrayUtils.SearchBytes(filedata, 0, PngStartPattern);
                if (pngIndex < 0)
                {
                    return;
                }
                fName = Path.GetFileNameWithoutExtension(filename);
                FuiImageInfo[] imageInfo = FuiUtils.GetImageInfo(filedata, pngIndex);
                List<byte[]> imagesData = FuiUtils.GetImagesData(filedata, pngIndex, imageInfo);
                FuiDatas.AddRange(imagesData);
                LegitData.AddRange(imagesData);
                FuiImageInfos = imageInfo;
                gtype = new F_UI_Graphics(this);
                FullCheckToConsole();
            }
            public GameFile_FUI( List<byte[]> Data)
            {  
                FuiDatas = Data; // Read/Write
                LegitData = Data; // Backup
                gtype = new F_UI_Graphics(this);
                FullCheckToConsole();

            }
            public GameFile_FUI(byte[] filedata)
            {
                FuiDatas = new List<byte[]>();
                LegitData = new List<byte[]>();
                int pngIndex = ArrayUtils.SearchBytes(filedata, 0, PngStartPattern);
                if (pngIndex < 0)
                {
                    return;
                }
                FuiImageInfo[] imageInfo = FuiUtils.GetImageInfo(filedata, pngIndex);
                List<byte[]> imagesData = FuiUtils.GetImagesData(filedata, pngIndex, imageInfo);
                FuiDatas.AddRange(imagesData);
                LegitData.AddRange(imagesData);
                FuiImageInfos = imageInfo;
                gtype = new F_UI_Graphics(this);
                fName = Path.GetFileNameWithoutExtension(gtype.GraphicalTypeName);

                FullCheckToConsole();

            }


            /// <summary>
            /// Returns a image from the container at the provided index.
            /// </summary>
            /// <param name="index">The data index to extract of the container.</param>
            /// <returns></returns>
            public Bitmap GetBitmapAtIndex(int index)
            {
                return (Bitmap)Image.FromStream(new MemoryStream(FuiDatas[index]));
            }
            public void SetBitmapAtIndex(int index, Bitmap bmp)
            {
                FuiDatas[index] = BitmapToByteArray(bmp);
            }
            public byte[] BitmapToByteArray(Bitmap bmp)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, format: System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            new private bool Equals(object obj)
            {
                return this == obj;
            }
            public void RestoreAllChangesToDefault() => FuiDatas = LegitData;
            private void FullCheckToConsole()
            {
                Console.WriteLine("Fname is {0}", fName);
                Console.WriteLine("Data collection is loaded: {0}", (FuiDatas.Count > 0).ToString());
                Console.WriteLine("GTYPE is different of null: {0}", (gtype != null).ToString());
                Console.WriteLine("PNGSP : {0}", PngStartPattern[0].ToString());
                Console.WriteLine("GTYPE: {0}", gtype.GetType().ToString());
                for (int i = 0; i < FuiDatas.Count; i++)
                {
                    Console.WriteLine("I.Length == {0}", FuiDatas[i].Length);
                }
            }
        }
        /// <summary>
        /// .ARC Resource Package Tools
        /// </summary>
        internal class GameFile_ARC
        { 
            /// <summary>
            /// Creates a new Resource Package to MLCE.
            /// </summary>
            /// <param name="datapath">Input data folder path.</param>
            /// <param name="outFileName">Output filename to store all resources.</param>
            public void Create(string datapath, string outFileName)
            {
                ARC_Studio.Workers.PS3ARCWorker wk = new ARC_Studio.Workers.PS3ARCWorker();
                wk.BuildArchive(outFileName, datapath);
            }
            /// <summary>
            /// Decompress provided package filename into data folder.
            /// </summary>
            /// <param name="inputFileName">Filepath for descompression.</param>
            /// <param name="outDataPath">Data folder path.</param>
            public void Decompress(string inputFileName,string outDataPath)
            {
                ARC_Studio.Workers.PS3ARCWorker wk = new ARC_Studio.Workers.PS3ARCWorker();
                wk.ExtractArchive(inputFileName, outDataPath);
            }
        }
        /// <summary>
        /// .BINKA Sound Tools
        /// </summary>
        internal class GameFile_BINKA
        {

        }
        /// <summary>
        /// .PCK Content Package Tools
        /// </summary>
        internal class GameFile_PCK
        {

        }
        /// <summary>
        /// .LOC Localization Content Tools
        /// </summary>
        internal class GameFile_LOC { }
        /// <summary>
        /// .COL Env Coloration Tools
        /// </summary>
        internal class GameFile_COL { }
        private bool Equals(object o)
        {
            return this == o;
        }
     
    }
  
    
}


