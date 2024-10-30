using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // InvaderProjectile: class for projectiles shot by invaders - Alice Giola
    public class InvaderProjectile : Projectile
    {
        public const int ProjectileWidth = 5;
        public const int ProjectileHeight = 5;
        public bool greenprojectile = false;
        public InvaderProjectile(int x, int y) : base(x, y)
        {
            ProjectilePicture = new PictureBox();
            ProjectilePicture.Location = new Point(x, y);
            ProjectilePicture.Image = Image.FromFile("InvaderProjectile.jpg");
            ProjectilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            ProjectilePicture.Size = new Size(ProjectileWidth, ProjectileHeight);
        }
        
        public void Move()
        {
            ProjectilePicture.Top += ProjectileSpeed;
        }

        // Differentiates green projectiles from normal invader projectiles
        public void isGreen()
        {
            greenprojectile = true;
            ProjectilePicture.Image = Image.FromFile("ProjectileGreen.jpeg");
        }
    }
}