using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // InvaderP: class for pink invaders
    public class InvaderP : Invader
    { 
        public InvaderP(int x, int y, InvaderArmy a) : base(x, y, a)
        {
            candie = false;
            InvaderPicture = new PictureBox();
            InvaderPicture.SizeMode = PictureBoxSizeMode.Zoom;
            InvaderPicture.Image = Image.FromFile("InvaderP.GIF");
            InvaderPicture.Location = new Point(x, y);
            InvaderPicture.Size = new Size(InvaderWidth, InvaderHeight);
            points = 50;
        }
    }
}