﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdventureGame
{
     class JsonFetch
    {
        public static MyDatabase fetch()
        {
            string dataJSONfilPath = "AdventureData.json";
            if (File.Exists(dataJSONfilPath))
            {
                string allaDataSomJSONType = File.ReadAllText(dataJSONfilPath);
                MyDatabase myDatabase = JsonSerializer.Deserialize<MyDatabase>(allaDataSomJSONType)!;

                return myDatabase;
            } else
            {
                Console.WriteLine("Oj, det verkar som att JSON filen inte finns! Var vänlig att dubbel kolla om den är kvar.");
                Console.WriteLine("Var vänlig och avsluta programmet, och dubbel kolla om filen är kvar.");
                return null;
            }

        }
    }
}
