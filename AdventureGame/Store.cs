using Spectre.Console;
using System.Text.Json;

namespace AdventureGame
{
    public class Store
    {
        //Vi sätter upp våran JSON fil
        string dataJSONfilPath = "AdventureData.json";

        int money = 0;
        public void Shop(MyDatabase myDatabase)
        {
            bool shop = true;
            money = myDatabase.Inventory.Gold;

            Thread.Sleep(1000);
            while (shop)
            {
                AnsiConsole.Markup("\n[blue]What can I get ya?[/]\n");
                //We show how much money you have
                Console.WriteLine($"You have {money} gold");
                var storeChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("")
                        .AddChoices(new[] {
                            "Shortsword - 50 gold",
                            "Longsword - 80 gold",
                            "Greatsword - 150 gold",
                            "Shield - 50 gold",
                            "Hide armor - 80 gold",
                            "Plate armor - 150 gold",
                            "Leave",
                        }));

                switch (storeChoice)
                {
                    case "Shortsword - 50 gold":
                        AnsiConsole.Markup("\n[blue]Ah, you have a fine eye. My boy made this the other week.[/]\n");
                        Item("Shortsword", 50, 2, 0, "A short sword", "Weapon", myDatabase);
                        break;

                    case "Longsword - 80 gold":
                        AnsiConsole.Markup("\n[blue]Ah, good eye. I made this just the other day.[/]\n");
                        Item("Longsword", 50, 3, 0, "A Long sword", "Weapon", myDatabase);
                        break;

                    case "Greatsword - 150 gold":
                        AnsiConsole.Markup("\n[blue]You have a sense for quality I see. This was handcrafted by my old man.[/]\n");
                        Item("Greatsword", 50, 6, 0, "A Greatsword", "Weapon", myDatabase);
                        break;

                    case "Shield - 50 gold":
                        AnsiConsole.Markup("\n[blue]It might not do much, but it will protect you in a pinch.[/]\n");
                        Item("Shield", 50, 0, 3, "A Shield", "Shield", myDatabase);
                        break;

                    case "Hide armor - 80 gold":
                        AnsiConsole.Markup("\n[blue]We are not really in the tanning busniess, but my nephew is. And I have to say, it is pretty sturdy.[/]\n");
                        Item("Hide Armor", 80, 0, 8, "An armor made out of Hide", "Armor", myDatabase);
                        break;

                    case "Plate armor - 150 gold":
                        AnsiConsole.Markup("\n[blue]Now this is a fine creation. It took everyone here to make it, but it is the best darn armor we have ever made.[/]\n");
                        Item("Hide Armor", 150, 0, 10, "An armor expertly crafted out of steel", "Armor", myDatabase);
                        break;

                    case "Leave":
                        AnsiConsole.Markup("\n[blue]Have a nice day![/]\n");
                        Console.WriteLine("You leave the store and go back to the crossroads.");
                        Console.ReadLine();
                        myDatabase.Inventory.Gold = money;

                        string updatedJSON = JsonSerializer.Serialize(myDatabase, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(dataJSONfilPath, updatedJSON);

                        shop = false;
                        break;
                }
            }
        }

        public void Item(string title, int price, int attack, int defence, string text, string type, MyDatabase myDatabase)
        {
            Console.WriteLine($"{text}");
            Console.WriteLine($"{price} gold");

            //If it gives attack or defence, or if it is a shield it will display different things.
            if (attack > 0)
            {
                Console.WriteLine($"+{attack} Damage");
                Console.WriteLine($"Your current weapon gives +{myDatabase.Player.Weapon.Attack} Damage");
                Console.WriteLine($"It would set your total attack to +{attack + myDatabase.Player.Attack} Damage");
            }

            else if (defence > 0 && title != "Shield")
            {
                Console.WriteLine($"+{defence} Defence");
                Console.WriteLine($"Your current armor gives +{myDatabase.Player.Armor.Defence} Defence");
                Console.WriteLine($"It would set your total defence to +{myDatabase.Player.Shield.Defence + myDatabase.Player.Defence + defence} Defence");
            }

            else if (title == "Shield")
            {
                Console.WriteLine($"+{defence} Defence");
                Console.WriteLine($"Your current defence is +{myDatabase.Player.Armor.Defence + myDatabase.Player.Defence} Defence");
                Console.WriteLine($"It would set your total defence to +{myDatabase.Player.Armor.Defence + myDatabase.Player.Defence + defence} Defence");
            }
            Console.WriteLine();

            //We check if the user wants to buy the item
            var purchaseChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .Title("Would you like to purchase this?")
           .AddChoices(new[] {
                "Yes",
                "No",
            }));

            switch (purchaseChoice)
            {
                case "Yes":

                    if (money >= price)
                    {
                        AnsiConsole.Markup("\n[blue]Thanks for your business[/]\n");
                        money = money - price;
                        Arsenal newEquipped = new Arsenal(title, price, attack, defence, text, type);
                        //We add it to the right equipment slot
                        if (type == "Weapon") myDatabase.Player.Weapon = newEquipped;
                        if (type == "Armor") myDatabase.Player.Armor = newEquipped;
                        if (type == "Shield") myDatabase.Player.Shield = newEquipped;

                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        AnsiConsole.Markup("\n[blue]Sorry bud, you don't have enough money[/]\n");
                        Thread.Sleep(2000);
                        Console.Clear();
                        return;
                    }

                case "No":
                    AnsiConsole.Markup("\n[green]You don't buy it[/]\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }
    }
}
