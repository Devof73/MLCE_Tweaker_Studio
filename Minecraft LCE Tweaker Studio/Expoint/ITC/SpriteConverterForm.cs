using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minecraft_LCE_Tweaker_Studio;
using System.IO;
using System.Threading;
using Expoint.ITC;
using System.Drawing.Imaging;
using Minecraft_LCE_Tweaker_Studio.Expoint.Better_Forms;
using System.Security.Policy;

namespace Minecraft_LCE_Tweaker_Studio.Expoint.ITC
{
    public partial class SpriteConverterForm : Form
    {
        CompilationLog MLogger = new CompilationLog();
        public SpriteConverterForm()
        {
            InitializeComponent();
            CheckAndWriteAppData();
            TIMER_LOGGER.Start();
            LBX_NeededFiles.Items.Clear(); LBX_NeededFiles.Items.AddRange(obj_names);
            Expoint.InAppUserSettings.Default.S_Ins_SPT++;
        }
        static readonly string ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        // Program Base Program Data Folder Path Variable
        static readonly string str_dirname = ProgramDataPath + @"\" + "LCE_Textures";
        // Java MC Resources Missed Textures File Names
        readonly string[] missedFilenames = { str_dirname + @"\" + "missed_texture_00", str_dirname + @"\" + "missed_texture_01", str_dirname + @"\" + "missed_texture_02" };
        // Internal F.B.D. Variable to instance for folder selection.
        internal static FolderBrowserDialog APP_FBD_Request;
        // Builder user textures folder path variable
        internal static string textureFolderPath = "";
        private readonly string javaMcVersions = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\.minecraft\\versions\\"; 
        // Builder Result Out Path Variable
        internal string fileOutPath = "";
        // User Selected File Names
        internal static string[] selectedFiles = { };
        // Latest user cooked bitmap.
        //internal static Bitmap ltstCookedBmp;
        internal static bool includeAnimFrames = false;
        internal static bool sortFramesToLCE = true;
        internal readonly int[] SheetDimensions = { 16, 32,64};
        internal int PngSheetDimension = 16;

        #region BigRegionNamesArray
        readonly string[] obj_names = { "leather_helmet", "chainmail_helmet", "iron_helmet","diamond_helmet", "golden_helmet", "flint_and_steel", "flint", "coal", "string","wheat_seeds", "apple", "golden_apple", "egg","sugar","snowball","elytra"
        ,"leather_chestplate", "chainmail_chestplate", "iron_chestplate","diamond_chestplate", "golden_chestplate", "bow", "brick","iron_ingot","feather", "wheat", "painting", "sugar_cane", "bone", "cake", "slime_ball", "broken_elytra"
        ,"leather_leggings", "chainmail_leggings", "iron_leggings", "diamond_leggings", "golden_leggings","arrow","end_crystal","gold_ingot","gunpowder","bread","sign","oak_door", "iron_door"
        ,"missed_texture01","fire_charge","chorus_fruit", "leather_boots", "chainmail_boots", "iron_boots"
        ,"diamond_boots", "golden_boots","stick", "compass_00","diamond","redstone","clay_ball"
        ,"paper","book","filled_map","pumpkin_seeds", "melon_seeds","popped_chorus_fruit"
        ,"wooden_sword", "stone_sword", "iron_sword", "diamond_sword", "golden_sword", "fishing_rod","clock_00","bowl","mushroom_stew","glowstone_dust","bucket","water_bucket","lava_bucket","milk_bucket","ink_sac","gray_dye"
        ,"wooden_shovel","stone_shovel","iron_shovel","diamond_shovel","golden_shovel", "fishing_rod_cast"
        ,"repeater","porkchop", "cooked_porkchop","cod","cooked_cod","rotten_flesh","cookie","shears","rose_red","pink_dye"
        ,"wooden_pickaxe","stone_pickaxe","iron_pickaxe","diamond_pickaxe","golden_pickaxe","bow_pulling_0","carrot_on_a_stick",
         "leather", "saddle","beef", "cooked_beef", "ender_pearl","blaze_rod","melon_slice", "cactus_green","lime_dye"
        ,"wooden_axe","stone_axe","iron_axe","diamond_axe","golden_axe", "bow_pulling_1", "baked_potato", "potato", "carrot"
        ,"chicken","cooked_chicken","ghast_tear","gold_nugget","nether_wart","cocoa_beans", "dandelion_yellow"
        ,"wooden_hoe","stone_hoe","iron_hoe","diamond_hoe", "golden_hoe", "bow_pulling_2", "poisonous_potato", "minecart", "oak_boat"
        ,"glistering_melon_slice","fermented_spider_eye","spider_eye","glass_bottle","potion_overlay","lapis_lazuli","cyan_dye"
        ,"leather_helmet_overlay","spectral_arrow","iron_horse_armor","diamond_horse_armor","golden_horse_armor","comparator", "golden_carrot",
         "chest_minecart","pumpkin_pie","spawn_egg","splash_potion","ender_eye","cauldron","blaze_powder","purple_dye","magenta_dye",
         "empty[1]","tipped_arrow_base","dragon_breath","name_tag","lead","nether_brick","tropical_fish","furnace_minecart","charcoal","spawn_egg_overlay"
        ,"missed_texture02","experience_bottle","brewing_stand","magma_cream","cyan_dye","orange_dye","leather_leggings_overlay","tipped_arrow_head","lingering_potion","barrier"
        ,"mutton","rabbit","pufferfish","hopper_minecart","hopper","nether_star","emerald","writable_book","written_book","flower_pot","light_gray_dye","bone_meal"
        ,"leather_boots_overlay","beetroot","beetroot_seeds","beetroot_soup","cooked_mutton","cooked_rabbit","salmon","tnt_minecart","armor_stand","firework_rocket","firework_star","firework_star_overlay"
        ,"quartz","map","item_frame","enchanted_book","acacia_door","birch_door","dark_oak_door","jungle_door","spruce_door","rabbit_stew","cooked_salmon","command_block_minecart","command_block_minecart"
        ,"acacia_boat","birch_boat","dark_oak_boat","jungle_boat","spruce_boat","prismarine_shard","prismarine_crystals","empty[3]","structure_void","filled_map_markings","totem_of_undying","shulker_shell","iron_nugget","rabbit_foot"
        ,"rabbit_hide","empty[5:9]","missed_texture00","music_disc_13","music_disc_cat","music_disc_blocks","music_disc_chirp","music_disc_chirp","music_disc_mall","music_disc_mellohi","music_disc_stal","music_disc_strad","music_disc_ward","music_disc_11"
        ,"music_disc_wait","cod_bucket","salmon_bucket","pufferfish_bucket","tropical_fish_bucket","empty[6:7]","kelp","dried_kelp","sea_pickle","nautilus_shell","heart_of_the_sea","turtle_helmet"
        ,"scute","trident","phantom_membrane"

        };
        #endregion

        /// <summary>
        /// Check if process have textures installed on environment, and installs it.
        /// </summary>
        internal void CheckAndWriteAppData()
        {
            bool mc13exists = Directory.Exists(javaMcVersions) && Directory.Exists(javaMcVersions + "\\1.13.2") && Directory.Exists(javaMcVersions + "\\1.13.2\\assets");
            // Java ver missed this three textures.
            Bitmap[] missed_java_bmps = { ITC_Resources.missed_texture00, ITC_Resources.missed_texture01, ITC_Resources.missed_texture02 };
            if (Directory.Exists(str_dirname) == false)
            {
                Directory.CreateDirectory(str_dirname);
                MLogger.WriteLine("[!] Creating Dir.. ");
                for (int i = 0; i < missed_java_bmps.Length; i++)
                {
                    var filepath = str_dirname + @"\" + "missed_texture_0" + i + ".png";
                    File.Create(filepath).Close();

                    try
                    {
                        if (File.Exists(filepath) == true)
                        {
                            missed_java_bmps[i].Save(filepath);
                            MLogger.WriteLine("[!] === Writing: " + filepath + "... ===");
                        }
                        MLogger.WriteLine("[!] <===== Data Write Operation Ended. =====> ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message + "\rSource: " + ex.Source);
                        MLogger.WriteLine("[*] <===== Data Write Operation Failed. =====> ");
                        MLogger.WriteLine("[*] - Exception Result = MSG: " + ex.Message + " - Source: " + ex.Source);
                    }
                }
            }
            else if (Directory.Exists(str_dirname) == true)
            {
                MLogger.WriteLine("[!] <===== Checker Operation Ended. =====> ");
                MLogger.WriteLine("[!] App resources already installed.");
            }
        }
        internal void App_RequestTextureFolder(bool terrainFiles = false)
        {
            MLogger.WriteLine("[!] Requesting sfd.");
            APP_FBD_Request = new FolderBrowserDialog()
            {
                Description = "Select a folder of a Minecraft 1.13 Java Resource Path, with all needed resources.",
                ShowNewFolderButton = false,
            };
            if (APP_FBD_Request.ShowDialog() == DialogResult.OK)
            {
                MLogger.WriteLine("[!] sfd = ok");
                textureFolderPath = APP_FBD_Request.SelectedPath;
                TB_TextureFolderPath.Text = textureFolderPath;
                LB_Files.Items.Clear();
                ReadTextureDir(LBX_NeededFiles, sortToLCE: sortFramesToLCE, terrain: terrainFiles);
            }
            APP_FBD_Request.Dispose();
        }
        internal bool CheckFoldContainsAll(string path)
        {
            var list = obj_names;
            short okFiles = 0;
            var user113path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\.minecraft\\versions\\1.13.2";
            var has113 = Directory.Exists(user113path);
            var textures113path = user113path + "\\assets\\textures\\items"; 
            for (int i = 0; i < list.Length; i++)
            {
                var fn = path + "\\" + list[i] + ".png";
                bool r = File.Exists(fn) == true;
                var obj = list[i].ToString();
                if (r)
                {
                    MLogger.WriteLine("[SUCCESS] "+fn);
                    okFiles++;
                }
                else if (r == false && list.Contains(obj))
                {
                    
                }
                else
                {
                    if (has113 && Directory.Exists(textures113path))
                    {

                    }
                  

                 
                    MLogger.WriteLine("[*] xx - " + fn);
                }

            }
            if (okFiles == list.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal void ThrowLBTextureException(string message, string description, string targetPath = "", int ErrorIndex = 0, Action specialVoid = null)
        {
            if (specialVoid != null) { specialVoid(); }
            throw new LegacyResourceException(message, description, targetPath, ErrorIndex);
        }
        internal void ReadTextureDir(ListBox lbox, bool sortToLCE = true, bool terrain = false)
        {
            if (terrain is false)
            {
                List<string> dirNotContained = new List<string>(50);
                var fileSelEnum = Directory.EnumerateFiles(textureFolderPath);
                List<string> FileList = new List<string>(fileSelEnum);
                int i_file_count = 0;
                if (sortToLCE is true)
                {
                    CheckFoldContainsAll(textureFolderPath);
                    foreach (string file in lbox.Items)
                    {
                        
                        var Key = textureFolderPath + @"\" + file + ".png";
                        if (FileList.Contains(Key))
                        {
                            LB_Files.Items.Add(Key);
                            i_file_count++;
                           
                        }
                        else if (FileList.Contains(Key) == false && file.Contains("clock_") == false && file.Contains("compass_") == false
                        )
                        {
                            MLogger.WriteLine("[*!*] FLIST not contains following file : "+ Key);
                          
                           
                        }
                    }
                    {

                        MLogger.WriteLine("-p==========");
                        MLogger.WriteLine("=-r=========");
                        MLogger.WriteLine("==-o========");
                        MLogger.WriteLine("===-c=======");
                        MLogger.WriteLine("====-c======");
                        MLogger.WriteLine("=====-e=====");
                        MLogger.WriteLine("======-s====");
                        MLogger.WriteLine("=======-s===");
                        MLogger.WriteLine("========-i==");
                        MLogger.WriteLine("=========-n=");
                        MLogger.WriteLine("==========-g");
                        MLogger.WriteLine("===========-");
                    }
                    if (LB_Files.Items.Contains(TB_TextureFolderPath.Text + @"\iron_door.png") && LB_Files.Items.Contains(TB_TextureFolderPath.Text + @"\rabbit_hide.png") && LB_Files.Items.Contains(TB_TextureFolderPath.Text + @"\spawn_egg_overlay.png"))
                    {
                        MLogger.WriteLine("[!] Checking appear of many internal vars...");

                        var listBox = LB_Files;
                        var indexOfName = LB_Files.Items.IndexOf(TB_TextureFolderPath.Text + @"\iron_door.png");
                        var indexOfName0 = LB_Files.Items.IndexOf(TB_TextureFolderPath.Text + @"\rabbit_hide.png");
                        var indexOfName1 = LB_Files.Items.IndexOf(TB_TextureFolderPath.Text + @"\spawn_egg_overlay.png");
                        var indexOfName2 = LB_Files.Items.IndexOf(TB_TextureFolderPath.Text + @"\tropical_fish_bucket.png");
                        var indexOfName3 = LB_Files.Items.IndexOf(TB_TextureFolderPath.Text + @"\magenta_dye.png");
                        MLogger.WriteLine($"[INFO] INDEXES:\r-1:{indexOfName}\r0:{indexOfName0}\r1:{indexOfName1}\r2:{indexOfName2}");
                        // PUERTA DE HIERRO = CAMA_OVERLAY
                        listBox.Items.Insert(indexOfName + 1, missedFilenames[1] + ".png");
                        MLogger.WriteLine("[!] Inserting matched value: " + missedFilenames[1] + " to index: " + indexOfName);
                        // PIEL DE CONEJO = 8
                        for (int gap = 0; gap < 8; gap++)
                        {
                            listBox.Items.Insert(indexOfName0 + 2, "[EMPTY_SEPARATOR_UNKNOWN_ITEM]");

                        }
                        for (int gap = 0; gap < 7; gap++)
                        {
                            listBox.Items.Insert(indexOfName2 + 11, "[EMPTY_SEPARATOR_UNKNOWN_ITEM]");
                        }
                        listBox.Items.Insert(indexOfName0 + 10, missedFilenames[0] + ".png");
                        listBox.Items.Insert(indexOfName3 + 2, "[EMPTY_SEPARATOR_UNKNOWN_ITEM]");

                        MLogger.WriteLine("[!] Inserting matched value: " + missedFilenames[0] + " to index: " + indexOfName0);
                        // CARCASA DE HUEVO SPAWN = RELLENO DE LA CAMA
                        listBox.Items.Insert(indexOfName1 + 4, missedFilenames[2] + ".png");
                        MLogger.WriteLine("[!] Inserting matched value: " + missedFilenames[2] + " to index: " + indexOfName1);
                       
                    }

                }
                else if (sortToLCE is false)
                {

                    var fseCount = FileList.Count();
                    {

                        MLogger.WriteLine("-p==========");
                        MLogger.WriteLine("=-r=========");
                        MLogger.WriteLine("==-o========");
                        MLogger.WriteLine("===-c=======");
                        MLogger.WriteLine("====-c======");
                        MLogger.WriteLine("=====-e=====");
                        MLogger.WriteLine("======-s====");
                        MLogger.WriteLine("=======-s===");
                        MLogger.WriteLine("========-i==");
                        MLogger.WriteLine("=========-n=");
                        MLogger.WriteLine("==========-g");
                        MLogger.WriteLine("===========-");
                    }
                    for (int pgr = 0; pgr < fseCount; pgr++)
                    {
                        if (FileList[pgr].EndsWith(".png"))
                        {
                            LB_Files.Items.Add(FileList[pgr]);
                            //TST_PBR_CookProgress.Value = Percent(pgr, fseCount);
                        }
                    }
                }
                if (dirNotContained.Count > 0 && CheckFoldContainsAll(textureFolderPath) is false)
                {
                    var ncdir = dirNotContained.Cast<string>();
                    string rslt = "";
                    foreach (string str in ncdir)
                    {
                        rslt = rslt + "\r" + str;
                    }
                    Thread.Sleep(500);

                    MessageBox.Show($"WARNING: {textureFolderPath} Not contains the " +
                        $"following filenames: " + rslt, "Warning.", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }
                
            }
            else if (terrain is true)
            {
                var fileSelEnum = Directory.EnumerateFiles(textureFolderPath).Cast<string>().ToArray();
                var fseCount = fileSelEnum.Count();
                {

                    MLogger.WriteLine("-p==========");
                    MLogger.WriteLine("=-r=========");
                    MLogger.WriteLine("==-o========");
                    MLogger.WriteLine("===-c=======");
                    MLogger.WriteLine("====-c======");
                    MLogger.WriteLine("=====-e=====");
                    MLogger.WriteLine("======-s====");
                    MLogger.WriteLine("=======-s===");
                    MLogger.WriteLine("========-i==");
                    MLogger.WriteLine("=========-n=");
                    MLogger.WriteLine("==========-g");
                    MLogger.WriteLine("===========-");
                }
                for (int pgr = 0; pgr < fseCount; pgr++)
                {
                    if (fileSelEnum[pgr].EndsWith(".png"))
                    {
                        LB_Files.Items.Add(fileSelEnum[pgr]);
                        MLogger.WriteLine("[!] (" + pgr + "/" + fseCount + ") " + fileSelEnum[pgr]);
                        //TST_PBR_CookProgress.Value = Percent(pgr, fseCount);

                    }
                }
            }

        }

        private void BTN_SelectTexFolder_Click(object sender, EventArgs e)
        {
            App_RequestTextureFolder();
        }

        private void SpriteConverterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Expoint.InAppUserSettings.Default.S_Ins_SPT--;
        }
        internal int i_fuicount = 0;
        private void BTN_buildSprite_Click(object sender, EventArgs e)
        {
            App_BuildSprite();
        }
        internal void App_BuildSprite()
        {
            bool fullParams = fileOutPath != string.Empty && Directory.Exists(fileOutPath) == true && LB_Files.Items.Count != 0;
            if (fullParams is true)
            {
                try
                {
                    var outFileName = fileOutPath + @"\items_concaten(" + i_fuicount.ToString() + ").png";
                    i_fuicount++;
                    //MessageBox.Show("var outFileName = " + outFileName);
                    selectedFiles = LB_Files.Items.Cast<string>().ToArray();
                    this.SuspendLayout();
                    Thread.Sleep(1500);
                    CreateResourceFile(outFileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception Ocurred. - " + ex.Source);
                    MessageBox.Show("EX TARGET SITE: " + ex.TargetSite.ToString() + "\r" + "EX STACKTRACE: " + ex.StackTrace);
                }
                this.ResumeLayout();
            }
            else
            {
                MessageBox.Show("Cannot build sprite.\rA parameter is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal Bitmap CreateResourceBmp(int textureCount)
        {
            var dim = PngSheetDimension;
            int width = dim * Math.Min(textureCount, dim);
            int height = dim * ((textureCount + 15) / dim);
            return new Bitmap(width, height, PixelFormat.Format32bppArgb);
        }
        internal void DrawTextures(Bitmap res, string[] textures, int px_size = 16, bool terrain = false)
        {
            using (Graphics graphics = Graphics.FromImage(res))
            {
                for (int i = 0; i < textures.Length; i++)
                {
                    MLogger.WriteLine($"[!] Processing... {i}/{textures.Length}");
                    int x = px_size * (i % px_size);
                    int y = px_size * (i / px_size);
                    #region Draw Texture Normally
                    if (textures[i] == "[EMPTY_SEPARATOR_UNKNOWN_ITEM]" && terrain == false)
                    {
                        using (Image texture = new Bitmap(px_size, px_size))
                        {
                            graphics.DrawImage(texture, x, y, px_size, px_size);
                            texture.Dispose();
                        }
                    }
                    else
                    {
                        MLogger.WriteLine("[!] Texture " + i + " - " + textures[i]);
                        using (Image texture = Bitmap.FromFile(textures[i]))
                        {
                            graphics.DrawImage(texture, x, y, px_size, px_size);
                            texture.Dispose();
                        }
                    }
                    // Console.Read();
                    #endregion
                }
                graphics.Dispose();
                MLogger.WriteLine($"[!] Operation Ended: {LB_Files.Items.Count} added textures of {textures.Length}.");
            }
        }
        internal void CreateResourceFile(string resourcePath)
        {
            using (Bitmap bmp = CreateResourceBmp(selectedFiles.Length))
            {
                DrawTextures(bmp, selectedFiles, PngSheetDimension, false);
                try
                {
                    File.Delete(resourcePath);
                }
                catch { }
                bmp.Save(resourcePath, ImageFormat.Png);
            }
        }

        private void BTN_SelectOutPath_Click(object sender, EventArgs e)
        {
            APP_FBD_Request = new FolderBrowserDialog()
            {
                Description = "Select a folder of to save the result file in there.",
                ShowNewFolderButton = false,
            };
            if (APP_FBD_Request.ShowDialog() == DialogResult.OK)
            {
                fileOutPath = APP_FBD_Request.SelectedPath;
                Tbx_OutFolder.Text = fileOutPath + @"\items_concaten(" + (char)i_fuicount+ ").png";
            }
        }

        private void BTN_buildSprite_Click_1(object sender, EventArgs e)
        {
            App_BuildSprite();
        }

        private void TB_TextureFolderPath_TextChanged(object sender, EventArgs e)
        {
            textureFolderPath = TB_TextureFolderPath.Text;
            TB_TextureFolderPath.Text = textureFolderPath;
            label6.Text = "InputDat: " + textureFolderPath;
        }

        private void Tbx_OutFolder_TextChanged(object sender, EventArgs e)
        {
            
        }
        #region Terrain
        internal string t_selectedTerrainFolderPath = "";
        internal string t_selectedOutPath = "";
        
        const int t_TerrainCountDiscriminator = 566;
        LceTerrain LTerrain = new LceTerrain();
        
        private void btn_tbtf_fsd_Click(object sender, EventArgs e)
        {
            APP_FBD_Request = new FolderBrowserDialog()
            {
                Description = "Select a folder of a Minecraft 1.13 Java Resource Path, with all needed resources.",
                ShowNewFolderButton = false,
            };
            if (APP_FBD_Request.ShowDialog() == DialogResult.OK)
            {
                t_selectedTerrainFolderPath = APP_FBD_Request.SelectedPath;
                tbx_TerrainFolderUrl.Text = t_selectedTerrainFolderPath;
                ReadTerrainDir(APP_FBD_Request.SelectedPath);
            }
            APP_FBD_Request.Dispose();
        }
        private void ReadTerrainDir(string path)
        {
            string[] fns = Directory.EnumerateFiles(path).Cast<string>().ToArray();
            bool flagIsTerrainPath = false;
            int filesEndedInPng = 0;
            for (int i = 0; i < fns.Length; i++)
            {
               if ( fns[i].EndsWith(".png") ) { filesEndedInPng++; }
               if (filesEndedInPng == t_TerrainCountDiscriminator)
               {
                    flagIsTerrainPath = true;
                    break;
               }

            }
            if (flagIsTerrainPath is true)
            {
                string[] order = LTerrain.BlockAppearOrder;
                lbx_TerrainNeededFiles.Items.Clear();
                lbx_totalTerrainFiles.Items.Clear();
                lbx_TerrainNeededFiles.Items.AddRange(order);
                for (int i = 0; i < order.Length; i++)
                {
                    lbx_totalTerrainFiles.Items.Add(path+"\\"+order[i]);
                }
                
            }
        }
        private void btn_odf_sfd_Click(object sender, EventArgs e)
        {
      
            FolderBrowserDialog APP_FBD_Request = new FolderBrowserDialog()
            {
                Description = "Select a folder of to save the result file in there.",
                ShowNewFolderButton = false,
            };
            if (APP_FBD_Request.ShowDialog() == DialogResult.OK)
            {
                t_selectedOutPath = APP_FBD_Request.SelectedPath;
                tbx_TerrainOutputFn.Text = t_selectedOutPath;
            }
            APP_FBD_Request.Dispose();
        }
        private void btn_buildTerrain_Click(object sender, EventArgs e)
        {
            if (LTerrain.Flag_ContainsAllImages(t_selectedTerrainFolderPath))
            {
                pbx_result.Image = LTerrain.BuildTerrain(t_selectedTerrainFolderPath, true, tbx_TerrainOutputFn.Text);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (LTerrain.Flag_ContainsAllImages(t_selectedTerrainFolderPath))
            {
                pbx_result.Image = LTerrain.BuildTerrain(t_selectedTerrainFolderPath, false, "");
            }
        }

        #endregion

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void RBTN_FRM_16_CheckedChanged(object sender, EventArgs e)
        {
            bool c = RBTN_FRM_16.Checked == true;
            if (c) { PngSheetDimension = SheetDimensions[0]; }
        }

        private void RBTN_FRM_32_CheckedChanged(object sender, EventArgs e)
        {
            bool c = RBTN_FRM_32.Checked == true;
            if (c) { PngSheetDimension = SheetDimensions[1]; }
        }

        private void RBTN_FRM_64_CheckedChanged(object sender, EventArgs e)
        {
            bool c = RBTN_FRM_64.Checked == true;
            if (c) { PngSheetDimension = SheetDimensions[2]; }
        }

        private void TIMER_LOGGER_Tick(object sender, EventArgs e)
        {
            if (MLogger.Output != RCHTBX_LOG.Text)
            {
                RCHTBX_LOG.Text = MLogger.Output;
                RCHTBX_LOG.SelectionStart = RCHTBX_LOG.Text.Length - 1;
                RCHTBX_LOG.SelectionLength = RCHTBX_LOG.Text.Length +1;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileOutPath = Tbx_OutFolder.Text;
        }

        private void tbx_TerrainOutputFn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
