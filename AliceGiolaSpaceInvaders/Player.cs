using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // Player: controls everything related to the player (spaceship) - Alice Giola
    public class Player : PictureBox
    {
        public string name;
        public int record = 0;
        private const int PlayerSpeed = 6;
        public PictureBox PlayerPicture;

        public Player(string n, int x, int y) 
        {
            name = n;
            PlayerPicture = new PictureBox();
            PlayerPicture.Image = Image.FromFile("SpaceShip2.png");
            PlayerPicture.Location = new Point(x, y);
            PlayerPicture.SizeMode = PictureBoxSizeMode.Zoom;
            PlayerPicture.Size = new Size(60, 60);
        }

        public void setRecord(int score)
        {
            if ((record != null && score > record) || record == null)
            {
                record = score;
            }
        }

        public void MoveLeft()
        {
            if (PlayerPicture.Left > 0)
            {
                PlayerPicture.Left -= PlayerSpeed;
            }
        }

        public void MoveRight()
        {
            if (PlayerPicture.Right < PlayerPicture.Parent.ClientSize.Width)
            {
                PlayerPicture.Left += PlayerSpeed;
            }
        }
    }
}