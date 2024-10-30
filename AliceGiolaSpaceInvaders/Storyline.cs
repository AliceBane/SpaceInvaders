using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // Storyline: creates a storyline to display to new players - Alice Giola
    public class Storyline
    {
        public List<string> storyline;
        public string name = "";

        public Storyline()
        {
            storyline = new List<string>();
            storyline.Add("Milky Way, Year 3092");
            storyline.Add("From the darkerst corner of the galaxy,\na new menace emerged");
            storyline.Add("An armada of extraterrestial invaders\ndescended upon the Milky Way");
            storyline.Add("Galactic civilizations quivered in fear\nas the alien enemy strode forward");
            storyline.Add("taking planet after planet");
            storyline.Add("destroying everything in its path");
            storyline.Add("After years of relentless onslaught,\nthe invaders finally reached the Earth");
            storyline.Add("But men were not caught unprepared");
            storyline.Add("An army of young pilots had been waiting for them,\neager to protect their planet and restore peace in the galaxy");
            storyline.Add("After hours of battle, it seemed nothing\ncould stop the evil aliens");
            storyline.Add("The human soldiers had been decimated");
            storyline.Add("All hope was lost");
            storyline.Add("When admist the chaos,\na young cadet emerged");
            storyline.Add("The last human soldier standing");
            storyline.Add("Eager to put an end to the slaughter,\nthe pilot stood their ground");
            storyline.Add("Ready to face the space invaders on their own,\n whatever the outcome would be");
            storyline.Add("The fate of humanity is in your hands, " + name + "...");
            storyline.Add("You are our only hope");
        }

        public void setName(string n)
        {
            name = n;
            updateSl(name);
        }

        public void updateSl(string n)
        {
            storyline.RemoveAt(16);
            storyline.Insert(16, "The fate of humanity is in your hands, " + n + "...");
        }
    }
}