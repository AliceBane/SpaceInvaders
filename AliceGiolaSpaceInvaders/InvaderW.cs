using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // InvaderW: class for white invaders
    public class InvaderW : Invader
    {
        public InvaderW(int x, int y, InvaderArmy a) : base(x, y, a)
        {
            InvaderPicture = new PictureBox();
            InvaderPicture.SizeMode = PictureBoxSizeMode.Zoom;
            InvaderPicture.Image = Image.FromFile("Alien1.GIF");
            InvaderPicture.Location = new Point(x, y);
            InvaderPicture.Size = new Size(InvaderWidth, InvaderHeight);
        }
    }
}