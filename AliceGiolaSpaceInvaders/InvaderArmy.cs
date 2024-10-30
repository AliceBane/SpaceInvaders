using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // InvaderArmy: controls everything related to the army of invaders - Alice Giola
    public class InvaderArmy
    {
        public bool moveRight = true;
        public List<Invader> invaders = new List<Invader>();

        public InvaderArmy()
        {

        }

        public void setInvaders(List<Invader> i)
        {
            invaders = i;
        }

        public void moveArmy()
        {
            foreach (Invader i in invaders) 
            {
                i.InvaderPicture.Top += Invader.InvaderHeight;
            }
        }

        public void alignArmy()
        {
            Invader rightmost = invaders.MaxBy(o => o.InvaderPicture.Location.X);
            foreach (Invader i in invaders)
            {
                if (i.InvaderPicture.Location.X < rightmost.InvaderPicture.Location.X - 450)
                {
                    i.InvaderPicture.Location = new Point(rightmost.InvaderPicture.Location.X - 450, i.InvaderPicture.Location.Y);
                }
            }
        }
    }
}