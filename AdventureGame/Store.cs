using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Store
    {
        public void Shop()
        {
            bool shop = true;

            AnsiConsole.Markup($"\n[green]You are facing a store clerk.[/]\n");
            Thread.Sleep(1000);
            while (shop)
            {
                var combatChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Welcome! What can I get ya?")
                        .AddChoices(new[] {
                                "Two handed sword - 80 gold",
                                "Heavy armor - 100 gold",
                                "Shield - 50 gold",
                                "Leave",
                        }));


                // Handle location logic
                switch (combatChoice)
                {
                    case "Two handed sword - 80 gold":
                        AnsiConsole.Markup("\n[blue]You buy the two handed sword[/]\n");
                        break;
                    case "Heavy armor - 100 gold":
                        AnsiConsole.Markup("\n[blue]You buy the heavy armor[/]\n");
                        break;
                    case "Shield - 50 gold":
                        AnsiConsole.Markup("\n[blue]You buy the Shield[/]\n");
                        break;
                    case "Leave":
                        AnsiConsole.Markup("\n[blue]You leave the store[/]\n");
                        shop = false;
                        break;
                }

            }

        }

    }
}
