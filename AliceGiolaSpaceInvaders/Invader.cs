using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AliceGiolaSpaceInvaders
{
    // Invader: controls everything related to an invader
    public class Invader
    {
        
        public const int InvaderSpeed = 2;
        public PictureBox InvaderPicture;
        public InvaderArmy army;
        public static int InvaderWidth = 40;
        public static int InvaderHeight { get; } = 40;
        public bool IsDestroyed { get; private set; }
        public bool pinklife1 = false;
        public bool candie = true;
        public int points = 10;

        public Invader(int x, int y, InvaderArmy a) 
        {
            army = a;
        }

        public void Move()
        {
            // Move invader left or right
            if (army.moveRight && InvaderPicture.Right < InvaderPicture.Parent.ClientSize.Width)
            {
                InvaderPicture.Left += InvaderSpeed;
            }
            else if (!army.moveRight && InvaderPicture.Left > 0)
            {
                InvaderPicture.Left -= InvaderSpeed;
            }

            // Move invader down and change direction
            if (InvaderPicture.Right >= InvaderPicture.Parent.ClientSize.Width || InvaderPicture.Left <= 0)
            {
                //InvaderPicture.Top += InvaderHeight;
                army.moveRight = !army.moveRight;
                army.moveArmy();
                army.alignArmy();
            }
        }

        public void Destroy()
        {
            IsDestroyed = true;
            InvaderPicture.Visible = false;
        }
    }
}