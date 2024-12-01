﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{

    public class Adventure
    {
        RollDie rollDie = new RollDie();
        bool exploring = true;
        public void Start()
        {
            while (exploring)
            {
                CrossRoad();
            }
        }

        public void CrossRoad()
        {
            AnsiConsole.Markup("\n[green]You find yourself in a dark forest. You can barely make out paths leading in different directions.[/]\n");
            // Show location choices
            var location = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Which direction would you like to go?")
                    .PageSize(4)
                    .AddChoices(new[] {
                            "North - The Misty Mountains",
                            "East - The Haunted Swamp",
                            "West - The Sunlit Grove",
                            "South - Return Home",
                    }));

            // Handle location logic
            switch (location)
            {
                case "North - The Misty Mountains":
                    AnsiConsole.Markup("\n[blue]You went to the mountains.[/]\n");
                    break;
                case "East - The Haunted Swamp":
                    AnsiConsole.Markup("\n[blue]You went to the swamp.[/]\n");
                    break;
                case "West - The Sunlit Grove":
                    AnsiConsole.Markup("\n[blue]You went to the grove.[/]\n");
                    break;
                case "South - Return Home":
                    AnsiConsole.Markup("\n[blue]You decide to return home, ending your adventure for now.[/]\n");
                    exploring = false;
                    break;
            }

        }
    }
}
