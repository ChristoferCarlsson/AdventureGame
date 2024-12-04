using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{

    public class Adventure
    {
        //Vi sätter upp våran JSON fil
        string dataJSONfilPath = "AdventureData.json";
        JsonFetch JsonFetch = new JsonFetch();
        MyDatabase myDatabase = JsonFetch.fetch();

        Combat combat = new Combat();
        Store store = new Store();


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
                    AnsiConsole.Markup("\n[blue]You are attacked by a goblin![/]\n");

                    var enemy = myDatabase.Enemies[0];
                    Character player = new Character("John", 15, 2, 13);
                    combat.Start(player, enemy);
                    break;
                case "East - The Haunted Swamp":
                    AnsiConsole.Markup("\n[blue]You went to the swamp.[/]\n");
                    break;
                case "West - The Sunlit Grove":
                    AnsiConsole.Markup("\n[blue]You went to the grove.[/]\n");
                    AnsiConsole.Markup("\n[blue]You found a shop!.[/]\n");
                    store.Shop();
                    break;
                case "South - Return Home":
                    AnsiConsole.Markup("\n[blue]You decide to return home, ending your adventure for now.[/]\n");
                    exploring = false;
                    break;
            }

        }
    }
}
