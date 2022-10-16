using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
namespace Minecraft_LCE_Tweaker_Studio.Expoint.ITC
{
    internal class LceTerrain
    {
        const short x16sWidth = 256;
        const short x16sHeight = 544;
        const int x16 = 16;
        public readonly string[] BlockAppearOrder = //Blocks Appearing In Items.PNG
        {
            "grass_block_top.png",
            "stone.png",
            "dirt.png",
            "grass_block_side.png",
            "oak_planks.png",
            "stone_slab_top.png",
            "stone_slab_top.png",
            "bricks.png",
            "tnt_side.png",
            "tnt_top.png",
            "tnt_bottom.png",
            "cobweb.png",
            "poppy.png",
            "dandelion.png",
            "water_overlay.png",
            // Row 2
            "cobblestone.png",
            "bedrock.png",
            "sand.png",
            "gravel.png",
            "oak_log.png",
            "oak_log_top.png",
            "iron_block.png",
            "gold_block.png",
            "diamond_block.png",
            "emerald_block.png",
            "redstone_block.png",
            "dropper_front.png",
            "red_mushroom.png",
            "brown_mushroom.png",
            "jungle_sapling.png",
            /// Row 3
            "debug.png",
            "gold_ore.png",
            "iron_ore.png",
            "coal_ore.png",
            "bookshelf.png",
            "mossy_cobblestone.png",
            "obsidian.png",
            "grass_block_side_overlay.png",
            "grass.png",
            "dispenser_front_vertical.png",
            "beacon.png",
            "dropper_front_vertical.png",
            "crafting_table_top.png",
            "furnace_front.png",
            "furnace_side.png",
            "dispenser_front.png",
            "debug2.png",
            // Row 4
            "sponge.png",
            "glass.png",
            "diamond_ore.png",
            "redstone_ore.png",
            "oak_leaves.png",
            "birch_leaves.png",
            "stone_bricks.png",
            "dead_bush.png",
            "fern.png",
            "daylight_detector_top.png",
            "daylight_detector_side.png",
            "crafting_table_side.png",
            "crafting_table_front.png",
            "furnace_front_on.png",
            "furnace_top.png",
            "spruce_sapling.png",
            // Row 5
            "white_wool.png",
            "spawner.png"
           ,"snow.png",
            "ice.png",
            "grass_block_snow.png",
            "cactus_top.png",
            "cactus_side.png",
            "cactus_bottom",
            "clay.png",
            "sugar_cane.png",
            "jukebox_side.png",
            "jukebox_top.png",
            "lily_pad.png",
            "mycelium_side.png",
            "mycelium_top.png",
            "birch_sapling.png",
            // Row 6 / 35
            "torch.png",
            "oak_door_top.png",
            "iron_door_top.png",
            "ladder.png",
            "oak_trapdoor.png",
            "iron_bars.png",
            "farmland_moist.png",
            "farmland.png",
            "wheat_stage0.png",
            "wheat_stage2.png",
            "wheat_stage3.png",
            "wheat_stage4.png",
            "wheat_stage5.png",
            "wheat_stage6.png",
            "wheat_stage7.png",
            // Row 8
            "lever.png",
            "oak_door_bottom.png",
            "iron_door_bottom.png",
            "redstone_torch.png",
            "mossy_stone_bricks.png",
            "cracked_stone_bricks.png",
            "pumpkin_top.png",
            "netherrack.png",
            "soul_sand.png",
            "glowstone.png",
            "piston_top_sticky.png",
            "piston_top.png",
            "piston_side.png",
            "piston_bottom.png",
            "piston_inner.png",
            "melon_stem.png",
            // Row 9 
            "rail_corner.png",
            "black_wool.png",
            "gray_wool.png",
            "redstone_torch_off.png",
            "dark_oak_log.png",
            "birch_log.png",
            "pumpkin_side.png",
            "carved_pumpkin.png",
            "jack_o_lantern.png",
            "cake_top.png",
            "cake_side.png",
            "cake_inner.png",
            "cake_bottom.png",
            "red_mushroom_block.png",
            "brown_mushroom_block.png",
            "attached_melon_stem.png",
            // Row 10
            "rail.png",
            "red_wool.png",
            "pink_wool.png",
            "repeater.png",
            "spruce_leaves.png",
            "spruce_leaves.png",
            "conduit.png",
            "turtle_egg.png",
            "melon_side.png",
            "melon_top.png",
            "cauldron_top.png",
            "cauldron_inner.png",
            "wet_sponge.png",
            "mushroom_stem.png",
            "mushroom_block_inside.png",
            "leaves.png",
            // Row 11
            "lapis_block.png",
            "green_wool.png",
            "lime_wool.png",
            "repeater_on.png",
            "glass_pane_top.png",
              "CHEST_TOP",
              "ENDERCHEST_TOP",
            "turtle_egg_slightly_cracked.png",
            "turtle_egg_very_cracked.png",
            "jungle_log.png",
            "cauldron_side.png",
            "cauldron_bottom.png",
            "brewing_stand_base.png",
            "brewing_stand.png",
            "end_portal_frame_top.png",
            "end_portal_frame_side.png",
            // Row 12
            "lapis_ore.png",
            "brown_wool.png",
            "yellow_wool.png",
            "powered_rail.png",
            "redstone_dust_dot.png",
            "redstone_dust_dot_line0.png",
            "enchanting_table_top.png",
            "enchanting_table_bottom.png",
            "cocoa_stage2.png",
            "cocoa_stage1.png",
            "cocoa_stage0.png",
            "emerald_ore.png",
            "tripwire_hook.png",
             "EMPTY",
            "end_portal_frame_eye.png",
            "end_stone.png",
            // Row 13
            "sandstone_top.png",
            "blue_wool.png",
            "light_blue_wool.png",
            "powered_rail_on.png",
             "EMPTY",
             "EMPTY",
            "enchanting_table_side.png",
            "enchanting_table_bottom.png",
            "light_blue_stained_glass.png",
            "flower_pot.png",
            "item_frame.png",
            "comparator.png",
            "comparator_on.png",
            "activator_rail.png",
            "activator_rail_on.png",
            "nether_quartz_ore.png",
            // Row 14
            "sandstone.png",
            "purple_wool.png",
            "detector_rail.png",
            "jungle_leaves.png",
            "jungle_leaves.png",
            "spruce_planks.png",
            "jungle_planks.png",
            "carrots_stage0",
            "carrots_stage1.png",
            "carrots_stage2.png",
            "carrots_stage3.png",
            "slime_block.png",
            "water_overlay.png",
            "water_overlay.png",
            "water_overlay.png",
            // Row 15
            "sandstone_bottom.png",
            "cyan_wool.png",
            "orange_wool.png",
            "redstone_lamp.png",
            "redstone_lamp_on.png",
            "chiseled_stone_bricks.png",
            "birch_planks.png",
            "anvil.png",
            "damaged_anvil_top.png",
            "quartz_block_bottom.png",
            "quartz_pillar_top.png",
            "quartz_block_side.png",
            "hopper_outside.png",
            "detector_rail_on.png",
            "water_overlay.png",
            "water_overlay.png",
            // Row 16
            "nether_bricks.png",
            "gray_wool.png",
            "nether_wart_stage0.png",
            "nether_wart_stage1.png",
            "nether_wart_stage2.png",
            "chiseled_sandstone.png",
            "cut_sandstone.png",
            "anvil_top.png",
            "chipped_anvil_top.png",
            "chiseled_quartz_block.png",
            "quartz_pillar.png",
            "quartz_block_side.png",
            "hopper_inside.png",
                "MISSED_LAVA",
                "MISSED_LAVA",
                "MISSED_LAVA",
            // Row 16 
            "destroy_stage_0.png",
            "destroy_stage_1.png",
            "destroy_stage_2.png",
            "destroy_stage_3.png",
            "destroy_stage_4.png",
            "destroy_stage_5.png",
            "destroy_stage_6.png",
            "destroy_stage_7.png",
            "destroy_stage_8.png",
            "destroy_stage_9.png",
            "hay_block_side.png",
            "quartz_block_bottom.png",
            "hopper_top.png",
            "hay_block_top.png",
                "MISSED_LAVA",
                "MISSED_LAVA",
            // Row 17
            "coal_block.png",
            "terracotta.png",
            "note_block.png",
            "andesite.png",
            "polished_andesite.png",
            "diorite.png",
            "polished_diorite.png",
            "granite.png",
            "polished_granite.png",
            "potatoes_stage0.png",
            "potatoes_stage1.png",
            "potatoes_stage2.png",
            "potatoes_stage3.png",
            "spruce_log_top.png",
            "jungle_log_top.png",
            "birch_log_top.png",
            // Row 18
            "black_terracotta.png",
            "blue_terracotta.png",
            "brown_terracotta.png",
            "gray_terracotta.png",
            "brown_terracotta.png",
            "cyan_terracotta.png",
            "green_terracotta.png",
            "purple_terracotta.png",
            "light_blue_terracotta",
            "lime_terracotta.png",
            "orange_terracotta.png",
            "pink_terracotta.png",
            "magenta_terracota.png",
            "red_terracotta.png",
            "light_gray_terracotta.png",
            "white_terracotta.png",
            "yellow_terracotta.png",
            // Row 19
            // Contributor Fernz

        };
        public Bitmap BuildTerrain(string workingPath, bool writing = false, string filename = "")
        {
            if (filename.Length == 0 || writing == false)
            {
                return TexDrawAllPath(workingPath, false, "");
            }
            return TexDrawAllPath(workingPath, writing, filename);
        }

        private Bitmap TexDrawAllPath(string workingPath, bool write, string filename)
        {
            bool shouldwrite = write == true && filename != null == true && filename.Length > 5;
            int x_multiplier = 1;
            int y_multiplier = 1;
            string[] FileNames = Directory.EnumerateFiles(workingPath).Cast<string>().ToArray();
            if (Flag_ContainsAllImages(workingPath) is false)
            {
                return null;
            }
            else if (Flag_ContainsAllImages(workingPath) is true && FileNames.Length == 566)
            {
                Bitmap result;
                Graphics space = Graphics.FromImage(new Bitmap((int)x16sWidth, (int)x16sHeight));
                for (int i = 0; i < 566; i++)
                {
                    using (Bitmap bmp = (Bitmap)Image.FromFile(FileNames[i]))
                    {
                        var x = x16 * x_multiplier;
                        int yi = 0;
                        if (x16 * x_multiplier == x16sWidth)
                        {
                            y_multiplier++;
                            x_multiplier = 0;
                            yi = 16;
                        }
                        space.DrawImage(bmp, x, yi * y_multiplier);
                        x_multiplier++;
                        if (16 * y_multiplier == x16sHeight && i == 566)
                        {
                            break;
                        }
                    }

                }
                result = new Bitmap(x16sWidth, x16sHeight, space);
                if (shouldwrite)
                {
                    result.Save(filename);
                }
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Counts files and return false if selected dir not contain some.
        /// </summary>
        /// <param name="workingPath"></param>
        /// <returns></returns>
        internal bool Flag_ContainsAllImages(string workingPath)
        {
            short flagMax = (short)BlockAppearOrder.Length;
            int flagValue = 0;
            foreach (string image in BlockAppearOrder)
            {
                if (File.Exists(workingPath + @"\" + image))
                {
                    flagValue++;
                }
            }
            if (flagValue == flagMax)
            {
                return true;
            }
            else if (flagValue != flagMax)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        internal bool Flag_ContainsAllImages(string workingPath, out string NotContainingValue)
        {
            short flagMax = (short)BlockAppearOrder.Length;
            int flagValue = 0;
            var outvaluencv = "";
            foreach (string image in BlockAppearOrder)
            {
                if (File.Exists(workingPath + @"\" + image))
                {
                    NotContainingValue = "";
                    outvaluencv = image;
                    flagValue++;
                }
                else if (File.Exists(workingPath + @"\" + image))
                {
                    outvaluencv = image;
                    NotContainingValue = image;
                }
            }
            if (flagValue == flagMax)
            {
                NotContainingValue = outvaluencv;
                return true;
            }
            else if (flagValue != flagMax)
            {
                NotContainingValue = "";
                return false;
            }
            else
            {
                NotContainingValue = "";
                return false;
            }
        }
        /// <summary>
        /// SortsElements
        /// </summary>
        /// <param name="RequiredFileNames"></param>
        /// <param name="workingPath"></param>
        /// <returns></returns>
        internal List<string> OnBuildSort(string[] RequiredFileNames, string workingPath)
        {

            if (Directory.Exists(workingPath))
            {
                List<string> ReqFnsList = new List<string>();
                ReqFnsList.AddRange(RequiredFileNames);
                List<string> output = new List<string>();
                string[] data = Directory.EnumerateFiles(workingPath).Cast<string>().ToArray();
                foreach (string fn in RequiredFileNames)
                {
                    if (data.Contains(fn))
                    {
                        output.Insert(ReqFnsList.IndexOf(fn), workingPath + @"\" + fn);
                    }
                }
                return output;
            }
            else
            {
                return null;
            }
        }
    }
}
