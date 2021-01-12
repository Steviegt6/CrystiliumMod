using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrystalLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Leggings");
			Tooltip.SetDefault("7% increased magic and summon crit chance"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCrit(DamageClass.Magic) += 7;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<RadiantPrism>(), 10)
				.AddIngredient(ItemType<ShinyGemstone>(), 10)
				.AddTile(Terraria.ID.TileID.Anvils)
				.Register();
		}
	}
}