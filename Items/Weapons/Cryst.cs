using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Cryst : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryst");
			Tooltip.SetDefault("Summons sharp crystals to orbit you");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 67;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 17;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.CrystProj>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//Remove all previous Cryst projectiles - creates "reset" behavior
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == Item.shoot && p.owner == player.whoAmI)
				{
					p.active = false;
				}
			}

			//get degrees from direction vector
			int dir = (int)(new Vector2(speedX, speedY).ToRotation() / (Math.PI / 180));
			int dir2 = dir + 120;
			int dir3 = dir - 120;

			//spawn the new projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Item.shoot, damage, knockBack, player.whoAmI, 0, dir);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Item.shoot, damage, knockBack, player.whoAmI, 0, dir2);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Item.shoot, damage, knockBack, player.whoAmI, 0, dir3);
			return false;
		}
	}
}