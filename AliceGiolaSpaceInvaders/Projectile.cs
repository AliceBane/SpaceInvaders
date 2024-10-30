using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // Projectile: creates a blueprint for all projectiles in the game - Alice Giola
    public class Projectile
    {
        
        public const int ProjectileSpeed = 5;
        public PictureBox ProjectilePicture;
        public Projectile(int x, int y)
        {

        }

        public void Destroy()
        {
            ProjectilePicture.Visible = false;
            ProjectilePicture.Enabled = false;
        }
    }
}