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
        Story story = new Story();

        bool narrow = false;
        bool goblin = false;

        RollDie rollDie = new RollDie();
        bool exploring = true;
        public bool Start()
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

                Console.WriteLine("Press enter for next line!");

                story.Start();
                CrossRoad();
            }
            else
            {
                Start();
            }

            return false;
        }

        public void CrossRoad()
        {
            while (exploring)
            {
                // Show location choices
                var location = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Which direction would you like to go?")
                    .PageSize(4)
                    .AddChoices(new[] {
                            "North - The Misty Mountains",
                            "East - The Goblin Woods",
                            "West - The Sunlit Grove",
                            "South - Return Home",
                    }));

                // Handle location logic
                switch (location)
                {
                    case "North - The Misty Mountains":
                        story.MountainStart();
                        if (YesOrNo())
                        {
                            story.MountainReady();
                            Cave();
                        }
                        else
                        {
                            story.MountainNotReady();
                        }
                        break;
                    case "East - The Goblin Woods":
                        //If this is the first time the player goes here
                        if (!goblin)
                        {
                            story.GoblinWoods();
                            goblin = true;
                        }
                        //Otherwise we will show different text.
                        else story.GoblinWoodsAgain();

                        //If the player dies
                        if (!combat.Start(myDatabase.Enemies[0], myDatabase))
                        {
                            story.Dead();
                            exploring = false;
                        }
                        //We tell what happens after the combat
                        story.AfterGoblin();
                        break;
                    case "West - The Sunlit Grove":
                        story.SunlitGrove();
                        store.Shop(myDatabase);
                        break;
                    case "South - Return Home":
                        story.GoHome();
                        exploring = false;
                        break;
                }

            }

        }

        public void Cave()
        {
            while (exploring)
            {
                var location = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(new[] {
                   "Large Path",
                   "Narrow Path",
                   "Leave",
            }));

                // Handle location logic
                switch (location)
                {
                    case "Large Path":
                        LargePath();
                        break;

                    case "Narrow Path":
                        if (!narrow)
                        {
                            story.NarrowPath();
                            narrow = true;
                            //We give the player a new item
                            List<Item> allItems = myDatabase.Inventory.Items;
                            allItems.Add(new Item(allItems.Count, "Black Bomb", 1, 999, 0, 20, "A black and dangerous bomb"));
                            string updatedJSON = JsonSerializer.Serialize(myDatabase, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(dataJSONfilPath, updatedJSON);
                        }
                        else
                        {
                            story.NarrowPathAgain();
                        }
                        break;

                    case "Leave":
                        story.GoHome();
                        exploring = false;
                        break;
                }
            }
        }

        public void LargePath()
        {
            story.LargePath();
            var location = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(new[] {
                   "Talk",
                   "Fight",
                   "Run!",
            }));

            // Handle location logic
            switch (location)
            {
                case "Talk":
                    story.LargePathTalk();
                    story.End();
                    exploring = false;
                    break;
                case "Fight":
                    story.LargePathFight();
                    if (!combat.Start(myDatabase.Enemies[1], myDatabase))
                    {
                        story.Dead();
                        exploring = false;
                    }
                    else
                    {
                        story.End();
                        exploring = false;
                    }
                    break;
                case "Run":
                    story.GoHome();
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
