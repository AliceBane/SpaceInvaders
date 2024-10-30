using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // DisplayScoreboard: displays the scoreboard created by the Scoreboard class - Alice Giola
     public class DisplayScoreboard
    {
        public string sbformatted;

        public DisplayScoreboard(List<Player> scoreboard)
        {
            int playern = 0;

            foreach (Player player in scoreboard)
            {
                playern++;
                sbformatted += String.Format("{0,-4} {1,-13} {2,6}\n", playern.ToString()+".", player.name, player.record.ToString());
            }
        }

        public string getScoreboard()
        {
            return sbformatted;
        }
    }
}