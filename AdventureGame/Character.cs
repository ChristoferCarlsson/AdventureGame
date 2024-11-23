using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Character
    {
        public string Name { get; set; }
        public int Attack {  get; set; }
        public int Health { get; set; }
        public int Defence { get; set; }

        public Character(string name, int attack, int health, int defence)
        {
            Name = name;
            Attack = attack;
            Health = health;
            Defence = defence;
        }
    }
}