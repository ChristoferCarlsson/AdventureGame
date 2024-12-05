using System;
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
        public List<Arsenal> StoreItems { get; set; }

        [JsonPropertyName("player")]
        public Character Player { get; set; }

        [JsonPropertyName("test")]
        public Arsenal Test { get; set; }

        [JsonPropertyName("inventory")]
        public Inventory Inventory { get; set; }

        [JsonPropertyName("enemies")]
        public List<Character> Enemies { get; set; }


    }
}
