using Spectre.Console;
using System.Text.Json;
using System.Text.RegularExpressions;

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
            Console.WriteLine("What is your name?");
            string Name = Console.ReadLine();

            //If the name is empty or null
            if (Name == "" || Name == null)
            {
                Console.WriteLine("Please enter your name");
                Start();
            }
            //We make the first letter large for consistency
            Name = Regex.Replace(Name, "^[a-z]", c => c.Value.ToUpper());
            Console.WriteLine($"Are you sure that your name is {Name}?");

            if (YesOrNo())
            {
                myDatabase.Player.Name = Name;
                string updatedJSON = JsonSerializer.Serialize(myDatabase, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dataJSONfilPath, updatedJSON);

                while (exploring)
                {
                    CrossRoad();
                }
            }
            else
            {
                Start();
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
                    if (!combat.Start(myDatabase.Enemies[0], myDatabase)) exploring = false;
                    break;
                case "East - The Haunted Swamp":
                    AnsiConsole.Markup("\n[blue]You went to the swamp.[/]\n");
                    break;
                case "West - The Sunlit Grove":
                    AnsiConsole.Markup("\n[blue]You went to the grove.[/]\n");
                    AnsiConsole.Markup("\n[blue]You found a shop!.[/]\n");
                    store.Shop(myDatabase);
                    break;
                case "South - Return Home":
                    AnsiConsole.Markup("\n[blue]You decide to return home, ending your adventure for now.[/]\n");
                    exploring = false;
                    break;
            }

        }

        public bool YesOrNo()
        {
            var purchaseChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(new[] {
                "Yes",
                "No",
            }));

            switch (purchaseChoice)
            {
                case "Yes":
                    return true;

                case "No":
                    return false;
            }
            return false;
        }
    }
}
