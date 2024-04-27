using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        private static Die die = new Die();
        /// <summary>
        /// Rolls 3 dice, provides the dice number with its roll, adds them to a list and provides the sum of the list.
        /// </summary>
        public void Gameloop()
        {
            //declare var
            var list = new List<int> { }; ///List is for calculating the sum.

            //Rolls Dice
            //Simple for loop roll the dice x amount of times, reporting and adding each roll to a list.
            for (int i = 1; i < 4; i++)
            {

                int roll = die.Roll();
                Console.WriteLine($"Dice " + i + ": " + roll); // Roll Dice and report Value
                list.Add(roll); //check if the roll is the correct value, if so add to sum list. 
            }

            //Print Sum
            //Each diceroll in the list will be added to the sum.
            int sum = list.Sum();
            Console.WriteLine($"\nSum: {sum}");
        }

        /// <summary>
        /// Simple Test to see if in the statistics the dice roll updates.
        /// </summary>
        public void ThrowThree()
        {
            while (true)
            { //loop forever unless N pressed
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Roll Dice? (Y/N) ");
                Console.ForegroundColor = ConsoleColor.White;
                string RollAgain = Console.ReadKey().KeyChar.ToString();
                RollAgain = RollAgain.ToUpper();
                //Switch is a way of taking in inputs and doing something with them. AKA guard clause (Making Sure the input is what you want, otherwise Handling It.)
                switch (RollAgain)
                {
                    case "Y": ///If Y is Entered, the Object will be created and the Game will be Carried Out.
                        Console.WriteLine("");
                        Game game = new Game();
                        game.Gameloop();
                        continue;
                    case "N": ///If N is Entered, The Object will not be created and the Program will Exit.
                        break;
                    default:
                        Console.WriteLine(""); Console.WriteLine("isn't Valid, please enter Y or N"); //If the wrong character is chosen, the game will not Play or Exit.
                        continue;                                               //Simply make the user aware that this is not a valid response. 
                }
                break;
            }
        }
        

       /// <summary>
       /// Simple GUI Menu that never breaks the loop unless told to. Allows the Player to infinitely play games.
       /// </summary>
        public void GameSelection() 
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMenu Options\n------------\n(1) Sevens Out\n(2) Three Or More\n(3) Statistics\n(4) Tests\n(5) Roll3 [Rolls 3 Dice and reports Sum]\n(6) Exit");
                string Key = Console.ReadKey().KeyChar.ToString();

                int.TryParse(Key, out int SKey);

                switch (SKey) 
                {
                    case 1: Console.Clear(); SevensOut seven = new SevensOut(); seven.GameSevens(); Statistics.SevensOutCompleted += 1; continue;

                    case 2: Console.Clear(); ThreeOrMore three = new ThreeOrMore(); three.GameThree(); Statistics.ThreeOrMoreCompleted += 1; continue;

                    case 3: Console.Clear(); Statistics stats = new Statistics(); stats.GameStatistics(); continue;

                    case 4: Console.Clear(); Testing test = new Testing(); test.TestGames(); continue;

                    case 5: Console.Clear(); ThrowThree(); Statistics.ThrowThreeTested += 1; continue;

                    case 6: Console.Clear(); break;

                    default: continue;
                }
                Console.WriteLine(""); break;






            }

        
        
        }



    }
}
