using Spectre.Console;
using System.Numerics;

namespace AdventureGame
{
    public class Combat
    {

        //We create a die
        RollDie rollDie = new RollDie();

        public void Start(Character player, Character enemy)
        {
            bool playerFirst = Initiative();
            Thread.Sleep(1000);
            Console.WriteLine((playerFirst) ? "You go first" : "Enemy go first");

            bool fight = true;

            while (fight) 
            {
                //if the player goes first, their function runs.
                if (playerFirst) if (CheckIfDead("player", CombatChoice(player,enemy)))
                {
                    fight = false;
                    break;
                }

                if (playerFirst) if (CheckIfDead("enemy", Attack(enemy, player))) 
                {
                    fight = false; 
                    break;
                } 

                if (!playerFirst) if (CheckIfDead("enemy", Attack(enemy, player)))
                {
                    fight = false;
                    break;
                }

                if (!playerFirst) if (CheckIfDead("player", CombatChoice(player, enemy)))
                {
                    fight = false;
                    break;
                }

            }
        }

        //We check with a random roll who goes first
        public bool Initiative()
        {
            int playerRoll = rollDie.Roll(20);
            int enemyRoll = rollDie.Roll(20);

            Thread.Sleep(500);
            Console.WriteLine($"You rolled {playerRoll}");
            Thread.Sleep(500);
            Console.WriteLine($"The enemy rolled {enemyRoll}");

            if (playerRoll > enemyRoll) return true;
            else if (playerRoll < enemyRoll) return false;
            //If the roll is the same, we reroll
            else { Initiative(); }

            return false;
        }

        public bool Attack(Character attacker, Character defender)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"{attacker.Name} attacks");
            Thread.Sleep(1000);

            int attackRoll = rollDie.Roll(20) + attacker.Attack;

            if (attackRoll >= defender.Defence)
            {
                int damageRoll = rollDie.Roll(6) + attacker.Attack;
                defender.Health = defender.Health - damageRoll;
                Console.WriteLine($"The attack hits, dealing {damageRoll} points of damage.");
                if (defender.Health <= 0)
                {
                    return true;
                } else
                {
                    return false;
                }

            } else
            {
                Console.WriteLine($"The attack misses its target");
                return false;
            }

        }
        //We check if the damage killed the defender
        public bool CheckIfDead(string character, bool dead)
        {
            if (dead == true && character == "player" )
            {
                Console.WriteLine($"The enemy has fallen.");
                Console.WriteLine("You are victorious");
                return true;
            } else if (dead == true && character == "enemy" )
            {
                Console.WriteLine($"You have fallen.");
                Console.WriteLine("You are dead");
                return true;
            } else
            {
                return false;
            }
        }
        //We give the player a choice during combat
        public bool CombatChoice(Character player, Character enemy )
        {
            bool dead = false;
            bool attack = true;

            AnsiConsole.Markup($"\n[green]You are facing a {enemy.Name}.[/]\n");
            Thread.Sleep(1000);
            while (attack)
            {
                var combatChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What do you want to do?")
                        .AddChoices(new[] {
                                "Attack",
                                "Item",
                                "Run",
                        }));


                // Handle location logic
                switch (combatChoice)
                {
                    case "Attack":
                        dead = Attack(player, enemy);
                        attack = false;
                        break;
                    case "Item":
                        AnsiConsole.Markup("\n[blue]You forgot your backpack.[/]\n");
                        break;
                    case "Run":
                        AnsiConsole.Markup("\n[blue]You cannot run away.[/]\n");
                        break;
                }

            }
            return dead;
        }

    }
}
