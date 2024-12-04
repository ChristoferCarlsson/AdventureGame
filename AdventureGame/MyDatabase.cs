﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class MyDatabase
    {
        [JsonPropertyName("store")]
        public List<Item> StoreItems { get; set; }

        [JsonPropertyName("gold")]
        public int Gold { get; set; }

        [JsonPropertyName("inventory")]
        public List <Inventory> Inventory { get; set; }

        [JsonPropertyName("enemies")]
        public List<Character> Enemies { get; set; }


    }
}
