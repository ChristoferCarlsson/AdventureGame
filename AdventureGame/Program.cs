using System;
using System.Numerics;
using Figgle;
using Spectre.Console;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RollDie die = new RollDie();
            Adventure adventure = new Adventure();
            Console.WriteLine(
            FiggleFonts.Standard.Render("Welcome Adventurer"));

            var startSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Are you ready to begin your adventure?")
                .AddChoices(new[] {
                "Yes",
                "No",
             }));

            switch (startSelection)
            {
                case "Yes":
                    adventure.Start();
                    break;
                case "No":
                    AnsiConsole.Markup("[red]Goodbye, adventurer![/]");
                    break;
            }
        }
    }
}
