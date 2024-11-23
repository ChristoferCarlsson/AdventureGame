using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class RollDie
    {
        public int Roll(int die)
        {
            var random = new Random();
            int rng = random.Next(1, die + 1);
            return rng;
        }
    }
}
