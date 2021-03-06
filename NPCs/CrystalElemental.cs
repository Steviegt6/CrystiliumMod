using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.NPCs
{
	public class CrystalElemental : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Elemental");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Wraith];
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 50;
			NPC.damage = 21;
			NPC.defense = 9;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.lifeMax = 90;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 300f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 22;
			aiType = NPCID.Wraith;
			animationType = NPCID.Wraith;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX), (int)(spawnInfo.spawnTileY)].type == TileType<Tiles.CrystalBlock>() ? 4f : 0f;
		}

		// TODO: GetGoreSlot
		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				//spawn shard gores (6 of them, 3 of each)
				for (int i = 0; i < 3; i++)
				{
					Gore.NewGore(NPC.position, NPC.velocity, Find<ModGore>("CrystiliumMod/Crystal_Element_Gore_1").Type);
					Gore.NewGore(NPC.position, NPC.velocity, Find<ModGore>("CrystiliumMod/Crystal_Element_Gore_2").Type);
				}
				//spawn core gore
				Gore.NewGore(NPC.position, NPC.velocity, Find<ModGore>("CrystiliumMod/Crystal_Element_Gore_3").Type);
			}
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(new CommonDrop(ItemType<Items.ShinyGemstone>(), 2));
		}

		public override void AI()
		{
			Vector3 RGB = new Vector3(2.0f, 0.75f, 1.5f);
			NPC.TargetClosest();
			float multiplier = 1;
			float max = 2.25f;
			float min = 1.0f;
			RGB *= multiplier;
			if (RGB.X > max)
			{
				multiplier = 0.5f;
			}
			if (RGB.X < min)
			{
				multiplier = 1.5f;
			}
			Lighting.AddLight(NPC.position, RGB.X, RGB.Y, RGB.Z);
			if (Main.rand.Next(500) == 5)
			{
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(NPC.position, NPC.width - (Main.rand.Next(NPC.width)), NPC.height - (Main.rand.Next(NPC.height)), DustType<Dusts.CrystalDust>(), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
				do
				{  //Keep teleporting if too close to player
					NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
					NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
				} while (NPC.Distance(Main.player[NPC.target].position) < 40);
				for (int i = 0; i < 20; i++)
				{
					Dust.NewDust(NPC.position, NPC.width - (Main.rand.Next(NPC.width)), NPC.height - (Main.rand.Next(NPC.height)), DustType<Dusts.CrystalDust>(), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			}
		}
	}
}