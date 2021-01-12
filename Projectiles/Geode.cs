using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class Geode : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodYoyo);
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.penetrate <= 1)
			{
				for (int h = 0; h < 15; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;

					int projType = 0;
					switch (Main.rand.Next(0, 3))
					{
						case 0:
							projType = ProjectileType<Shatter1>();
							break;
						case 1:
							projType = ProjectileType<Shatter2>();
							break;
						case 2:
							projType = ProjectileType<Shatter3>();
							break;
					}

					Projectile.NewProjectile((projectile.Center.X - 30) + Main.rand.Next(60), (projectile.Center.Y - 30) + Main.rand.Next(60), vel.X, vel.Y, projType, projectile.damage - 8, 0, Main.myPlayer);
				}
			}
		}
	}
}