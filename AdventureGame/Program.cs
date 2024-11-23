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
            Combat combat = new Combat();
            AnsiConsole.Markup("[bold yellow]Welcome to the Spectre Console Adventure Game![/]\n");

            // Start the game
            if (AnsiConsole.Confirm("Are you ready to begin your adventure?", false))
            {
                //StartAdventure();
                //adventure.Start();
                
                //We test the combat system
                combat.Start();
            }
            else
            {
                AnsiConsole.Markup("[red]Goodbye, adventurer![/]");
            }
        }
    }
}
