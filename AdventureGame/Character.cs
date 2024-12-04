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
        public int Health { get; set; }
        public int Attack {  get; set; }
        public int Defence { get; set; }

        public Character(string name, int health, int attack, int defence)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defence = defence;
        }
    }
}