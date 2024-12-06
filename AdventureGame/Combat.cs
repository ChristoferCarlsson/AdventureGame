using Spectre.Console;
using System.Text.Json;

namespace AdventureGame
{
    public class Combat
    {
        //Vi sätter upp våran JSON fil
        string dataJSONfilPath = "AdventureData.json";
        JsonFetch JsonFetch = new JsonFetch();
        //Will be used for things that won't change, such as names
        MyDatabase tempDatabase = JsonFetch.fetch();

        //We create a die that we will use for the combat solutions
        RollDie rollDie = new RollDie();

        //We create a loop that keeps us in the combat
        bool combat = true;

        int money = 0;
        public bool Start(Character enemy, MyDatabase myDatabase)
        {

            combat = true;
            var player = myDatabase.Player;
            //We check if the player or the enemy goes first.
            bool playerFirst = Initiative();
            Console.WriteLine((playerFirst) ? "You go first" : "Enemy go first");

            while (combat)
            {

                if (playerFirst)
                {
                    CombatChoice(player, enemy, myDatabase);
                    //If the combat is over after the players turn, then they get rewarded
                    if (combat == false)
                    {
                        Reward(myDatabase);
                        return true;
                    }
                }

                if (playerFirst)
                {
                    Attack(enemy, player, myDatabase);
                    if (combat == false) return false;
                }

                if (!playerFirst)
                {
                    Attack(enemy, player, myDatabase);
                    if (combat == false) return false;
                }

                if (!playerFirst)
                {
                    CombatChoice(player, enemy, myDatabase);
                    if (combat == false)
                    {
                        Reward(myDatabase);
                        return true;
                    }
                }
            }
            return false;
        }

        //We check with a random roll who goes first
        public bool Initiative()
        {
            int playerRoll = rollDie.Roll(20);
            int enemyRoll = rollDie.Roll(20);

            Console.WriteLine($"You rolled {playerRoll}");
            Console.ReadLine();
            Console.WriteLine($"The enemy rolled {enemyRoll}");
            Console.ReadLine();

            if (playerRoll > enemyRoll) return true;
            else if (playerRoll < enemyRoll) return false;
            //If the roll is the same, we reroll
            else { Initiative(); }

            return false;
        }

        public void Attack(Character attacker, Character defender, MyDatabase myDatabase)
        {
            Console.WriteLine($"{attacker.Name} attacks");
            Console.ReadLine();

            int attackRoll = rollDie.Roll(20) + attacker.Attack + attacker.Weapon.Attack;

            Console.WriteLine($"{attacker.Name} rolled {attackRoll} ");

            //If the attack is greater than the defenders defence, then the attack hits
            if (attackRoll >= defender.Defence + defender.Armor.Defence)
            {
                int damageRoll = rollDie.Roll(6) + attacker.Attack;
                defender.Health = defender.Health - damageRoll;
                Console.WriteLine($"The attack hits, dealing {damageRoll} points of damage.");

                //If the health is 0 or lower, aka the defender is dead
                if (defender.Health <= 0)
                {
                    //We show different things depending if it is the player or enemy that has died
                    if (attacker.Name == myDatabase.Player.Name)
                    {
                        Console.WriteLine($"The enemy has fallen.");
                        Console.WriteLine("You are victorious");
                        Console.ReadLine();

                        //We reset the health for the next combat
                        defender.Health = defender.MaxHealth;
                        attacker.Health = attacker.MaxHealth;

                        combat = false;
                    }
                    else
                    {
                        Console.WriteLine($"You have fallen.");
                        Console.WriteLine("You are dead");
                        Console.ReadLine();

                        combat = false;
                    }
                }
            }
            else
            {
                Console.WriteLine($"The attack misses its target");
            }
            return;
        }

        //We give the player a choice during combat
        public void CombatChoice(Character player, Character enemy, MyDatabase myDatabase)
        {
            //We create a loop to let the user take their turn
            bool turn = true;

            AnsiConsole.Markup($"\n[green]You are facing a {enemy.Name}.[/]\n");
            Thread.Sleep(500);
            Console.WriteLine($"Armor: {player.Armor.Defence + player.Defence}");
            Console.WriteLine($"Player health: {player.Health}");
            Console.WriteLine($"Enemy health: {enemy.Health}");
            while (turn)
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
                        Attack(player, enemy, myDatabase);
                        turn = false;
                        break;

                    case "Item":
                        if (useItem(player, enemy, myDatabase)) turn = false;
                        break;

                    case "Run":

                        //We check if the player can run away
                        int runAway = rollDie.Roll(20);
                        Console.WriteLine($"You rolled {runAway}");
                        Thread.Sleep(500);

                        if (enemy.Name == "Dragon")
                        {
                            Console.WriteLine("You cannot get away from a dragon!");
                            Console.ReadLine();
                            combat = false;
                            turn = false;
                        }

                        if (runAway > 10)
                        {
                            Console.WriteLine("You manage to get away.");
                            Console.ReadLine();
                            combat = false;
                            turn = false;
                        }
                        else
                        {
                            Console.WriteLine("You cannot get away!");
                            Console.ReadLine();
                        }

                        break;
                }
            }
        }

        public bool useItem(Character player, Character enemy, MyDatabase myDatabase)
        {
            List<Item> items = myDatabase.Inventory.Items;

            // Build the prompt
            var prompt = new SelectionPrompt<string>()
                .Title("What do you want to choose");
            foreach (var item in items)
            {
                prompt.AddChoice(item.Title);
            }

            // Show the prompt
            var selectedItem = AnsiConsole.Prompt(prompt);
            var foundItem = items.Where(n => n.Title == selectedItem).ToList();

            switch (selectedItem)
            {
                case "Healing Potion":
                    Console.WriteLine("You take out a Healing Potion!");
                    Console.WriteLine($"They heal {foundItem[0].Healing}");
                    Console.WriteLine($"You have {foundItem[0].Amount} left");

                    if (checkIfYes())
                    {
                        player.Health = player.Health + 10;
                        if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;

                        Console.WriteLine("You drink the potion.");
                        Thread.Sleep(500);
                        Console.WriteLine("You can feel your health being restored.");
                        Thread.Sleep(500);
                        Console.WriteLine($"You regain your health to {player.Health}");
                        Thread.Sleep(500);

                        removeItem(foundItem[0], myDatabase);
                        return true;
                    }
                    else Console.WriteLine("You put the item away");
                    return false;

                case "Bomb":
                    Console.WriteLine("You take out a Bomb!");
                    Console.WriteLine($"They deal {foundItem[0].Damage}");
                    Console.WriteLine($"You have {foundItem[0].Amount} left");

                    if (checkIfYes())
                    {
                        enemy.Health = enemy.Health - foundItem[0].Damage;
                        if (enemy.Health <= 0) combat = false;

                        Console.WriteLine("You light the bomb and throw it.");
                        Thread.Sleep(500);
                        Console.WriteLine("The explosion catched the enemy off guard!");
                        Thread.Sleep(500);
                        Console.WriteLine($"They take {foundItem[0].Damage}");
                        Thread.Sleep(500);

                        removeItem(foundItem[0], myDatabase);
                        return true;
                    }
                    else Console.WriteLine("You put the item away");
                    return false;

                case "Black Bomb":
                    Console.WriteLine("You take out a Black Bomb!");
                    Console.WriteLine($"They deal {foundItem[0].Damage}");
                    Console.WriteLine($"You have {foundItem[0].Amount} left");

                    if (checkIfYes())
                    {
                        enemy.Health = enemy.Health - foundItem[0].Damage;
                        if (enemy.Health <= 0) combat = false;

                        Console.WriteLine("You light the black bomb and throw it.");
                        Thread.Sleep(500);
                        Console.WriteLine("The explosion catched the enemy off guard!");
                        Thread.Sleep(500);
                        Console.WriteLine($"They take {foundItem[0].Damage}");
                        Thread.Sleep(500);

                        removeItem(foundItem[0], myDatabase);
                        return true;
                    }
                    else Console.WriteLine("You put the item away");
                    return false;
            }
            return false;
        }

        public bool checkIfYes()
        {
            //We check if the user wants to use the item
            var useChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .Title("Would you like to use this item?")
           .AddChoices(new[] {
                "Yes",
                "No",
            }));

            switch (useChoice)
            {
                case "Yes":
                    return true;

                case "No":
                    return false;
            }

            return false;
        }

        public void removeItem(Item item, MyDatabase myDatabase)
        {
            if (item.Amount <= 1)
            {
                List<Item> items = myDatabase.Inventory.Items;
                items.RemoveAll(x => x.Title == item.Title);

            }
            else
            {
                item.Amount = item.Amount - 1;
            }

        }

        public void Reward(MyDatabase myDatabase)
        {
            //We make a random list of rewards
            List<int> reward = new List<int>
            {
                3,3,4,5,5,8,10,12,15,16,14
            };

            int rewardRoll = rollDie.Roll(reward.Count - 1);

            money = myDatabase.Inventory.Gold;
            Console.WriteLine(money);

            money = money + 15;

            Console.WriteLine($"You are rewarded {reward[rewardRoll]} gold");
            myDatabase.Inventory.Gold = money;

            string updatedJSON = JsonSerializer.Serialize(myDatabase, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataJSONfilPath, updatedJSON);

            Console.ReadLine();
        }

    }
}
