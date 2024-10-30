using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // Slot: figures out how big a slot has to be to evenly distribute 16 : 9 on the user screen - Alice Giola
    public class Slot
    {
        public int width;
        public int height;
        public int indexX;
        public int indexY;

        public Slot(int wid, int hei)
        {
            width = wid / 16;
            height = hei / 9;
        }
    }
}