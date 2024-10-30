using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AliceGiolaSpaceInvaders
{
    // Designer: takes care of placement of images, gifs, buttons and textboxes - Alice Giola
    public class Designer
    {
        public Slot[,] screen;
        public Slot defslot;
        
        public Designer(Slot slot)
        {
            screen = new Slot[16, 9];
            defslot = slot;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    screen[i, j] = defslot;
                    screen[i, j].width = defslot.width;
                    screen[i, j].height = defslot.height;
                    screen[i, j].indexX = i;
                    screen[i, j].indexY = j;
                }
            }
        }

        public int getCenterX()
        {
            int center = screen[0, 0].width * 8;
            return center;
        }

        public int getCenterY()
        {
            double center = screen[0, 0].height * 4.5;
            return (int)center;
        }

        public double getSlotCenterX(Slot slot)
        {
            return (slot.width * (slot.indexX)) + (slot.width / 2);
        }

        public double getSlotCenterY(Slot slot)
        {
            return (slot.height * (slot.indexY)) + (slot.height / 2);
        }

        public int getOneThirdY()
        {
            return screen[0, 0].height * 3;
        }

        public int getLastX()
        {
            return screen[0, 0].width * 14;
        }

        public int getLastY()
        {
            return screen[0, 0].height * 8;
        }
    }
}