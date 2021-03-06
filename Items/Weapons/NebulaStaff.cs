using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class NebulaStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Crystal Staff");
			Tooltip.SetDefault("'You feel the power of the cosmos'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 88; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 25; //How long it takes for the item to be used
			Item.useAnimation = 25; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			Item.value = 120000; //How much the item is worth
			Item.rare = ItemRarityID.Yellow; //The rarity of the item
			Item.shoot = ProjectileType<Projectiles.NebulaShard>(); //What the item shoots, retains an int value
			Item.shootSpeed = 4f; //How fast the projectile fires
			Item.mana = 14;
			Item.channel = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentNebula, 10)
				.AddIngredient(ItemType<CrystiliumBar>(), 15)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}