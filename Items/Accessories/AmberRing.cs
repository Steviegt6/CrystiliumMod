using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class AmberRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Ring");
			Tooltip.SetDefault("Slightly increases life regen");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 2;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 6;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FossilOre, 4)
				.AddIngredient(ItemID.Amber, 3)
				.Register();
		}
	}
}