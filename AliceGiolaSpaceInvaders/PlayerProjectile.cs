using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // PlayerProjectile: class for projectiles shot by the player - Alice Giola
    public class PlayerProjectile : Projectile
    {
        public const int ProjectileWidth = 6;
        public const int ProjectileHeight = 6;
        public PlayerProjectile(int x, int y) : base(x, y)
        {
            ProjectilePicture = new PictureBox();
            ProjectilePicture.Location = new Point(x, y);
            ProjectilePicture.Image = Image.FromFile("PlayerProjectile.jpg");
            ProjectilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            ProjectilePicture.Size = new Size(ProjectileWidth, ProjectileHeight);
        }
        public void Move()
        {
            ProjectilePicture.Top -= ProjectileSpeed;
        }
    }
}