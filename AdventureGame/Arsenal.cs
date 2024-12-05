using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Arsenal
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public bool TwoHanded { get; set; }
        public string Text { get; set; }

        public Arsenal( string title, int price, int damage, int armor, bool twoHanded, string text)
        {
            Title = title;
            Price = price;
            Damage = damage;
            Armor = armor;
            TwoHanded = twoHanded;
            Text = text;
        }
    }
}
