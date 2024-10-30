using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliceGiolaSpaceInvaders
{
    // Scoreboard: lets different players keep track of their own record - Alice Giola
    public class Scoreboard
    {
        public List<Player> players;
        public List<Player> scoreboard;

        public Scoreboard(List<Player> p)
        {
            players = new List<Player>();
            
            if (p.Count <= 5)
            {
                players = p;
                scoreboard = p.OrderByDescending(o=>o.record).ToList();
            }
            else
            {
                players = p.OrderByDescending(o=>o.record).ToList();

                for (int i = 0; i < 5; i++)
                {
                    scoreboard.Add(players[i]);
                }
            }
        }

        public List<Player> getScoreboard() 
        {
            return scoreboard;
        }
    }
}