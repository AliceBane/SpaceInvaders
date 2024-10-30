using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // InvaderG: class for green invaders
    public class InvaderG : Invader
    {
        public InvaderG(int x, int y, InvaderArmy a) : base(x, y, a)
        {
            points = 30;
            InvaderPicture = new PictureBox();
            InvaderPicture.SizeMode = PictureBoxSizeMode.Zoom;
            InvaderPicture.Image = Image.FromFile("InvaderG.GIF");
            InvaderPicture.Location = new Point(x, y);
            InvaderPicture.Size = new Size(InvaderWidth, InvaderHeight);
        }
    }
}