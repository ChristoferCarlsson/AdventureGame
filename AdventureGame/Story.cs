using Spectre.Console;
using System.Text.Json;

namespace AdventureGame
{
    public class Story
    {
        //Vi sätter upp våran JSON fil
        JsonFetch JsonFetch = new JsonFetch();
        MyDatabase DataBase = JsonFetch.fetch();

        //We create a die that we will use for the combat solutions
        RollDie rollDie = new RollDie();
        public void Start()
        {
            Console.Clear();
            Text("The soft but still chilly wind washes over you as you snap back to reality.");
            Text("For how long had you been spacing out for?");
            Text("You think about why you had left the comfort of your village in the first place.");
            Text("After a series of hurricanes had passed through the area, taking out buildings and crops alike, there wasn't much anyone could do to save the village anymore.");
            Text("But before everyone had given up, you volunteered to follow a rumor that had been passed on by a charismatic adventurer.");
            Text("That a dragon had taken refuge in the mountains, and had taken a part of its greater horde with it.");
            Text("That horde would definitely include a treasure great enough to save the village.");
            Text("So armed with the small amount of gear you had in your house, you took off adventuring.");
            Text("As you come to, you realize that you are standing in the middle of a crossroad, with signs showing where the paths take you.");
        }

        public void GoblinWoods()
        {
            Console.Clear();
            Text("You take a detour toward the woods, maybe there could be something of value there.");
            Text("I mean, there is no obvious reason why it would be called \"The Goblin Woods\" right?");
            Text("It doesn't take long before you hear rustling in the bushes.");
            Text("A Goblin appears!");
        }

        public void GoblinWoodsAgain()
        {
            Console.Clear();
            Text("You decide to fight the goblins again.");
            Text("A Goblin appears!");
        }

        public void AfterGoblin()
        {
            Console.Clear();
            Text("You take a deep breath to gather yourself.");
            Text("And then you walk back to the crossroads");
        }

        public void SunlitGrove()
        {
            Console.Clear();
            Text("You take a detour towards the sunlit grove, it does sound quite pleasant.");
            Text("It doesn't take long until you see a large tent with a sign outside.");
            Text("\"For all your adventuring needs!!\"");
            Text("Well, that is quite convenient, isn't it?");
            Text("You pull aside the curtain and are greeted by a large man with a big beard.");

            TextTalking("Welcome!", "blue");

        }

        public void GoHome()
        {
            Console.Clear();
            Text("You decide that the adventuring life is not for you.");
            Text("Maybe you can find a different way to earn money for the village.");
            Text("You become lost in thought as you begin to wander home.");
            Text("The end.");
        }

        public void MountainStart()
        {
            Console.Clear();
            Text("You steele yourself.");
            Text("This is it.. you have to slay a dragon.");
            Text("You ready your weapon and begin to walk towards the mountain.");
            Text("You hope that you have brought the best gear for the job.");
            Text("Are you sure that you are ready for this?");
        }

        public void MountainNotReady()
        {
            Console.Clear();
            Text("No..");
            Text("You decide that you need some more time.");
            Text("Or some better gear.");
            Text("I think there was supposed to be a shop by the grove.");
        }

        public void MountainReady()
        {
            Console.Clear();
            Text("You begin to travel towards the great mountain.");
            Text("Its size towering over you like a great beast.");
            Text("But that wasn't the \"beast\" that you were worried about.");
            Text("Hopefully, you still have some of those potions you brought along.");
            Text("Before you know it you stand at the entrance of a great cave.");
            Text("If the dragon was here, it would most definitely stay here.");
            Text("Looking inside you can see that there are two paths.");
            Text("One narrow-looking one, and one large and almost man(or beast) made");
            Text("Where do you go?");
        }

        public void NarrowPath()
        {
            Console.Clear();
            Text("You decide to be cautious and take the narrow path.");
            Text("Because such a huge beast could never go down here, right?");
            Text("You begin to explore the dark cave, looking for anything useful.");
            Text("Right before you are about to give up, you find a small chest.");
            Text("Opening it up you find a fully black bomb of sorts, small enough for you to carry.");
            Text("Maybe it will be useful.");
            Text("Putting the black bomb in your trusty bag, you begin to walk back to the entrance.");
        }

        public void NarrowPathAgain()
        {
            Console.Clear();
            Text("You have already found everything you could find down there.");

        }

        public void LargePath()
        {
            Console.Clear();
            Text("You decide to be brave and take the large path.");
            Text("I mean, you would come face-to-face with the beast sooner or later, right?");
            Text("So you begin to wander down the dank path, the echoing of your footsteps keeping you alarmed.");
            Text("As you come to an opening of a bigger part of the cave, you see something bright up ahead.");
            Text("Gold..");
            Text("Not only gold, but trinkets, treasures, and other valuables.");
            Text("But of course..");
            Text("On top of the pile lays a great beast.");
            Text("A huge dark red Dragon.. looking right at you with tired eyes.");
            Text("Before you have a chance to ready your weapon, a voice echoes through the cave.");
            TextTalking("Oh hello there, I suppose you too are here for the \"Treasure\"", "red");
            Text("Did.. the dragon just speak??");
        }
        public void LargePathTalk()
        {
            Console.Clear();
            Text("You decide to talk to it.");
            Text("If it wasn't attacking and sentient enough to have a conversation, maybe it would be capable of compassion.");
            Text("You give a formal greeting, bowing while giving your name.");

            TextTalking("Oh? Such a formal behavior from a human. I haven't seen manners like that for years.", "red");
            TextTalking("Honestly, you are the first human I have seen for at least a hundred years that hasn't attacked me on sight.", "red");
            TextTalking("So, what is your story for wanting the \"Treasure\"?", "red");
            TextTalking("Do you want to be rich and famous?", "red");

            Text("You explain what happened to your village, sparing no details about how much your people have suffered.");
            TextTalking("So, you were willing to fight a monster like myself to save your village?", "red");
            Text("The dragon lets out a loud laugh, shaking the cave a bit.");
            TextTalking("Very well, I like you, kid.", "red");
            TextTalking("Here~", "red");
            Text("The dragon picks up a crystalized gem, bigger than your entire head, and tosses it to you.");
            Text("You almost get decapitated, but manage to catch the huge stone.");
            TextTalking("This should sell for enough to get your village back on its feet.", "red");
            TextTalking("Just don't spread any rumors that I give away charity.", "red");
            TextTalking("I do like company now and then, but I'd rather not become a reversed publican.", "red");
            Text("You make a mental note to look up that word after you get home.");
            Text("You spend some time at the dragon's cave, talking about your village and the journey the dragon had gone on. Apparently leaving its own village hundreds of years ago for adventure, but decided that it was too much of a hassle and these days just spend the day sleeping and taking it easy.");
            Text("As you leave the cave you hear the voice of the dragon.");
            TextTalking("Don't be a stranger now, and take care on the way home.", "red");
            Text("\n[blue]Don't be a stranger now, and take care on the way home.[/]\n");
        }

        public void LargePathFight()
        {
            Console.Clear();
            Text("You decide to attack!");
            Text("You grip your sword and run to combat.");
            Text("The dragon sighs.");
            TextTalking("Humans really are brutes.. very well.", "red");
            TextTalking("Have at thee.", "red");
            Text("The dragon attacks.");
        }

        public void SlayDragon()
        {
            Console.Clear();
            Text("You have slain the dragon, and thus the horde is all yours.");
            Text("You manage to pack as much as you can, before leaving and starting the journey home.");

        }

        public void End()
        {
            Console.Clear();
            Text("You begin to wander home, your loot being more than enough to save the village.");
            Text("You cannot help but to imagine all the turns this adventure could have taken, and how lucky you are to be alive.");
            Text("You are treated as a hero when you finally arrive.");
            Text("The faces that have only been full of misery, are now filled with joy and hope.");
            Text("Is this the end of your adventuring days? Who knows.");
            Text("But at least you and many others can sleep soundly tonight.");
            Text("The end!");

        }

        public void Dead()
        {
            Console.Clear();
            Text("Your journey has come to an end.");
            Text("Because you failed your village will never recover.");
            Text("But, maybe you could restart and try again.");
            Text("Game Over.");
        }

        public void Text(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }
        public void TextTalking(string text, string color)
        {
            AnsiConsole.Markup($"\n[{color}]{text}[/]\n");
            Console.ReadLine();
        }

    }
}
