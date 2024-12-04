using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Treasure
    {
        public string Title { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }

        public Treasure(string title, int value, string text)
        {
            Title = title;
            Value = value;
            Text = text;
        }
    }
}
