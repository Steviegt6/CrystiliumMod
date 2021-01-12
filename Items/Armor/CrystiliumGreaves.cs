using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrystiliumGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystilium Greaves");
			Tooltip.SetDefault("+9% magic crit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = ItemRarityID.Yellow;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCrit(DamageClass.Magic) += 9;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<Items.CrystiliumBar>(), 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}