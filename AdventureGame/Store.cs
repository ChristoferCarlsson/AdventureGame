using Spectre.Console;

namespace AdventureGame
{
    public class Store
    {
        int money = 150;

        List<string> bought = new List<string>();

        public void Shop()
        {
            bool shop = true;

            AnsiConsole.Markup($"\n[green]You are facing a store clerk.[/]\n");
            AnsiConsole.Markup($"Welcome!");
            Thread.Sleep(1000);
            while (shop)
            {
                var combatChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What can I get ya?")
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
                        AnsiConsole.Markup("\n[blue]Ah, you have a fine eye. This sword was handcrafted by my old man.[/]\n");
                        AnsiConsole.Markup("\n[blue]80 gold[/]\n");
                        AnsiConsole.Markup("\n[blue]Attack + 6[/]\n");

                        Purchase(80, "Two Handed Sword");

                        break;
                    case "Heavy armor - 100 gold":
                        AnsiConsole.Markup("\n[blue]My fines work yet. I made sure to put my premium gloves on for this one.[/]\n");
                        AnsiConsole.Markup("\n[blue]10 gold[/]\n");
                        AnsiConsole.Markup("\n[blue]Defence + 4[/]\n");

                        Purchase(100, "Heavy Armor");
                        break;
                    case "Shield - 50 gold":
                        AnsiConsole.Markup("\n[blue]My son actually made that one. But don't let it fool ya, it can take a beating.[/]\n");
                        AnsiConsole.Markup("\n[blue]Can only be used with a One handed weapon[/]\n");
                        AnsiConsole.Markup("\n[blue]50 gold[/]\n");
                        AnsiConsole.Markup("\n[blue]Defence +2[/]\n");

                        Purchase(50, "Shield");
                        break;
                    case "Leave":
                        AnsiConsole.Markup("\n[blue]Have a nice day![/]\n");
                        AnsiConsole.Markup("\n[blue]You leave the store[/]\n");
                        Console.WriteLine(money);
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
                        AnsiConsole.Markup("\n[blue]You buy it[/]\n");
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

    }
}
