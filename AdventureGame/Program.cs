using System;
using Spectre.Console;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RollDie die = new RollDie();

            Adventure adventure = new Adventure();
            AnsiConsole.Markup("[bold yellow]Welcome to the Spectre Console Adventure Game![/]\n");

            // Start the game
            if (AnsiConsole.Confirm("Are you ready to begin your adventure?", false))
            {
                //StartAdventure();
                adventure.Start();
            }
            else
            {
                AnsiConsole.Markup("[red]Goodbye, adventurer![/]");
            }
        }

        static void VisitMistyMountains()
        {
            AnsiConsole.Markup("\n[gray]You arrive at the base of the Misty Mountains. The air is cold, and a faint glow comes from a cave nearby.[/]\n");

            // Option to explore or leave
            if (AnsiConsole.Confirm("Would you like to enter the cave?"))
            {
                AnsiConsole.Markup("[bold red]Inside, you find a treasure guarded by a sleeping dragon![/]\n");

                // Battle or Flee
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What will you do?")
                        .AddChoices("Fight the dragon", "Quietly steal the treasure", "Run away"));

                if (choice == "Fight the dragon")
                {
                    AnsiConsole.Markup("[red bold]The dragon awakens and breathes fire![/]\n");

                    if (RollDice() > 3)
                    {
                        AnsiConsole.Markup("[bold green]You slay the dragon and take the treasure![/]\n");
                    }
                    else
                    {
                        AnsiConsole.Markup("[bold red]The dragon defeats you![/]\n");
                    }
                }
                else if (choice == "Quietly steal the treasure")
                {
                    if (RollDice() > 4)
                    {
                        AnsiConsole.Markup("[green]You successfully steal the treasure without waking the dragon![/]\n");
                    }
                    else
                    {
                        AnsiConsole.Markup("[red]The dragon wakes up and you flee empty-handed![/]\n");
                    }
                }
                else
                {
                    AnsiConsole.Markup("[blue]You run out of the cave, barely escaping with your life![/]\n");
                }
            }
            else
            {
                AnsiConsole.Markup("[gray]You decide to avoid the dangers of the cave and head back.[/]\n");
            }
        }

        static void VisitHauntedSwamp()
        {
            AnsiConsole.Markup("\n[green]The swamp is dark and eerie. Shadows move among the mist, and you hear strange whispers.[/]\n");

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("You see a strange amulet on the ground. Will you pick it up?")
                    .AddChoices("Pick it up", "Leave it and move on"));

            if (choice == "Pick it up")
            {
                AnsiConsole.Markup("[bold purple]As you pick up the amulet, you feel a surge of energy![/]\n");

                if (RollDice() > 3)
                {
                    AnsiConsole.Markup("[green]The amulet grants you a protective aura![/]\n");
                }
                else
                {
                    AnsiConsole.Markup("[red]The amulet is cursed! You feel weakened and decide to drop it.[/]\n");
                }
            }
            else
            {
                AnsiConsole.Markup("[gray]You decide not to touch the strange object and continue your way through the swamp.[/]\n");
            }
        }

        static void VisitSunlitGrove()
        {
            AnsiConsole.Markup("\n[yellow]You enter a bright and peaceful grove. Sunlight filters through the trees, and you feel at ease.[/]\n");

            if (AnsiConsole.Confirm("Do you want to rest here?", true))
            {
                AnsiConsole.Markup("[green]You rest in the grove and regain your strength.[/]\n");
            }
            else
            {
                AnsiConsole.Markup("[gray]You decide not to linger and move on.[/]\n");
            }
        }

        // Roll a six-sided die to determine random outcomes
        static int RollDice()
        {
            var random = new Random();
            int rng = random.Next(1, 7);
            Console.WriteLine($"You rolled a {rng}");
            return rng;
        }
    }
}
