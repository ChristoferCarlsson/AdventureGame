using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public int Value { get; set; }
        public int Healing { get; set; }
        public int Damage { get; set; }
        public string Text { get; set; }

        public Item(int id, string title, int amount, int value, int healing, int damage, string text)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Value = value;
            Healing = healing;
            Damage = damage;
            Text = text;
        }
    }
}
