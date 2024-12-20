﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Inventory
    {
        public int Gold { get; set; }
        public List<Item> Items { get; set; }
        public List<Treasure> Treasure { get; set; }

        public Inventory(int gold, List<Item> items, List<Treasure> treasure)
        {
            Gold = gold;
            Items = items;
            Treasure = treasure;
        }
    }
}
