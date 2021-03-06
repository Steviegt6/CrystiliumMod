using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class CrystalPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Potion");
			Tooltip.SetDefault("Makes shards of crystals damage nearby enemies.");
		}

		public override void SetDefaults()
		{
			Item.UseSound = SoundID.Item3;
			Item.useStyle = 2;
			Item.useTurn = true;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.value = 3000;
			Item.rare = 0;
			Item.buffType = BuffType<Buffs.CrystalLeak>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<CrystalBottleWater>())
				.AddIngredient(ItemType<ShinyGemstone>())
				.AddIngredient(ItemID.Moonglow)
				.AddIngredient(ItemID.Diamond)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}