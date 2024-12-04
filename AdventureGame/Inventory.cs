using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    //public class Inventory
    //{
    //    public int Gold { get; set; }
    //    public int Treasure { get; set; }

    //    public Inventory( int gold, int treasure )
    //    {
    //        Gold = gold;
    //        Treasure = treasure;
    //    }
    //}

    public class Inventory
    {
        public int Gold { get; set; }
        public List<Treasure> Treasure { get; set; }
        public List<Item> Items { get; set; }

        public Inventory(int gold, List<Treasure> treasure, List<Item> items)
        {
            Gold = gold;
            Treasure = treasure;
            Items = items;
        }
    }
}
