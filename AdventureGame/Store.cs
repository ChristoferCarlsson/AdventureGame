using Spectre.Console;

namespace AdventureGame
{
    public class Store
    {
        //Vi sätter upp våran JSON fil
        string dataJSONfilPath = "AdventureData.json";
        JsonFetch JsonFetch = new JsonFetch();
        MyDatabase myDatabase = JsonFetch.fetch();

        List<string> bought = new List<string>();

        int money = 0;
        public void Shop()
        {
            List<Inventory> inventory = myDatabase.Inventory;
            bool shop = true;
            money = inventory[0].Gold;

            AnsiConsole.Markup($"\n[green]You are facing a store clerk.[/]\n");
            AnsiConsole.Markup("\n[blue]Welcome![/]\n");


            Thread.Sleep(1000);
            Console.Clear();
            while (shop)
            {
                AnsiConsole.Markup("\n[blue]What can I get ya?[/]\n");
                Console.WriteLine($"You have {money} gold");
                var combatChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("")
                        .AddChoices(new[] {
                            "Shortsword - 50 gold",
                            "Longsword - 80 gold",
                            "Greatsword - 100 gold",
                            "Shield - 50 gold",
                            "Leave",
                        }));


                // Handle location logic
                switch (combatChoice)
                {
                    case "Shortsword - 50 gold":
                        AnsiConsole.Markup("\n[blue]Ah, you have a fine eye. My boy made this the other week.[/]\n");
                        Item("A short sword", 50, 2, 0, false);
                        Purchase(50, "Shortsword");
                        break;

                    case "Longsword - 80 gold":
                        AnsiConsole.Markup("\n[blue]Ah, you have a fine eye. This was handcrafted by my old man.[/]\n");
                        Item("A long sword", 80, 3, 0, false);
                        Purchase(80, "Longsword");
                        break;

                    case "Greatsword - 100 gold":
                        AnsiConsole.Markup("\n[blue]Ah, you have a fine eye. This was handcrafted by my old man.[/]\n");
                        Item("A great sword", 100, 5, 0, true);
                        Purchase(100, "Greatsword");
                        break;

                    case "Shield - 50 gold":
                        AnsiConsole.Markup("\n[blue]Ah, you have a fine eye. This was handcrafted by my old man.[/]\n");
                        Item("A Shield, need one hand free hands", 50, 0, 2, false);
                        Purchase(50, "Shield");
                        break;

                    case "Leave":
                        AnsiConsole.Markup("\n[blue]Have a nice day![/]\n");
                        AnsiConsole.Markup("\n[blue]You leave the store[/]\n");
                        inventory[0].Gold = money;


                        foreach (var item in bought)
                        {
                            Console.WriteLine(item);
                        }
                        
                        shop = false;
                        break;
                }

            }

        }

        public void Purchase(int price, string item)
        {
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
                        bought.Add(item);
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                    } else
                    {
                        AnsiConsole.Markup("\nSorry bud, you don't have enough money\n");
                        Thread.Sleep(2000);
                        Console.Clear();
                        return;
                    }

                case "No":
                    AnsiConsole.Markup("\n[blue]You don't buy it[/]\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }

        public void Item(string text, int gold, int attack, int defence, bool twoHanded)
        {
            Console.WriteLine($"{text}");
            Console.WriteLine($"{gold} gold");
            if (twoHanded) Console.WriteLine($"{"It needs to be used by both hands"}");
            if (attack > 0) Console.WriteLine($"Attack + {attack}");
            if (defence > 0) Console.WriteLine($"Defence + {defence}");
            Console.WriteLine();
        }

    }
}
