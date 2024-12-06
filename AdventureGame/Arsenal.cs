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
        public int Attack { get; set; }
        public int Defence { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public Arsenal( string title, int price, int attack, int defence, string text, string type)
        {
            Title = title;
            Price = price;
            Attack = attack;
            Defence = defence;
            Text = text;
            Type = type;
        }
    }
}
