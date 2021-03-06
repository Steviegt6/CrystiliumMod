using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueDiamondStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Diamond Staff");
			Tooltip.SetDefault("'Rain lightning strikes'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 67; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 75; //How long it takes for the item to be used
			Item.useAnimation = 75; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
			Item.value = 120000; //How much the item is worth
			Item.rare = ItemRarityID.Yellow; //The rarity of the item
			Item.shoot = ProjectileID.VortexLightning; //What the item shoots, retains an int value | *
			Item.shootSpeed = 7f; //How fast the projectile fires
			Item.mana = 20;
			Item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemType<Items.CrystiliumBar>(), 15)
				.AddIngredient(ItemType<Items.Weapons.EnchantedDiamondStaff>())
				.AddIngredient(ItemType<Items.BrokenStaff>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// TODO: GetSoundSlot
			//SoundEngine.PlaySound(SoundLoader.CustomSoundType, player.position, Mod.GetSoundSlot(SoundType.Custom, "Sounds/Thunder"));
			Vector2 vector82 = -Main.LocalPlayer.Center + Main.MouseWorld;
			float ai = Main.rand.Next(100);
			Vector2 vector83 = Vector2.Normalize(vector82) * Item.shootSpeed;
			Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, .49f, player.whoAmI, vector82.ToRotation(), ai);
			return false;
		}
	}
}