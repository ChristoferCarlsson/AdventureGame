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
        public int MaxHealth { get; set; }
        public int Attack {  get; set; }
        public int Defence { get; set; }
        public Arsenal Weapon { get; set; }
        public Arsenal Armor { get; set; }
        public Arsenal Shield { get; set; }
        public Character(string name, int health, int maxHealth, int attack, int defence,  Arsenal weapon, Arsenal armor, Arsenal shield)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            Attack = attack;
            Defence = defence;
            Weapon = weapon;
            Armor = armor;
            Shield = shield;
        }
    }
}