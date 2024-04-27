using System;
using System.Diagnostics;
using System.Xml.Schema;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        public int score3;
        public int score4;
        public int score5;
        private static Die die = new Die();
        private static SevensOut sevens = new SevensOut();
        private static ThreeOrMore three = new ThreeOrMore();

        /// <summary>
        /// Testing Function, will run a set amount of tests using Debug.Assert and if a problem is found, it is reported to the user via pop-up.
        /// </summary>
        public void TestGames() 
        {
            Die.Testing = true; /// Die.Testing is a bool which allows me to not record testing as part of statistics.
            Console.WriteLine("Testing Dice 1000x to see if roll is between 1 & 6"); //Tests to see if dice is between 1&6, by rolling the dice 1000x
            int i = 0;
            Console.WriteLine("If An Error is found, it will show on screen.");
            while (i <= 1000)    
            { 
                int roll = die.Roll();
                Debug.Assert(roll >= 1 && roll <= 6, "Roll is not between 1 and 6");
                i++;
            }
            Console.WriteLine("\nTest Completed. Press Any Key to Continue and Run More Tests.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Testing 1000x to see if the game will end provided a 7 is found, And if the sum is added up correctly.");
            Console.WriteLine("If An Error is found, it will show on screen.");
            i = 0;
            while (i <= 1000)
            {
                int die1 = die.Roll();
                int die2 = die.Roll();
                int sum = die1 + die2;
                Debug.Assert(sum == die1 + die2,"Sum Is Not Added Correctly.");
                Debug.Assert(sevens.IsSeven(7),"7 Was input however it wasnt updated Correctly.");
                i++;
            }
            Console.WriteLine("\nTest Completed. Press Any Key to Continue and Run More Tests.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Testing 1000x to see if the correct score is rewarded, and if score is correctly updated.");
            Console.WriteLine("If An Error is found, it will show on screen.");
            System.Threading.Thread.Sleep(1200);
            i = 0;
            
            while (i < 1000)
            {
                int input3 = three.p1Score(3);
                Debug.Assert(input3 == 3, "Score was incorrectly rewarded");
                score3 += input3; //same method used to track player score during ThreeOrMore
                i++;
            }
            Debug.Assert(score3 == 3000, "Score was not correctly updated.");
            i = 0;
            while (i < 1000)
            {
                int input4 = three.p1Score(4);
                Debug.Assert(input4 == 6, "Score was incorrectly rewarded");
                score4 += input4; //same method used to track player score during ThreeOrMore
                i++;
            }
            Debug.Assert(score4 == 6000, "Score was not correctly updated.");
            i = 0;
            while (i < 1000)
            {
                int input5 = three.p1Score(5);
                Debug.Assert(input5 == 12, "Score was incorrectly rewarded");
                score5 += input5; //same method used to track player score during ThreeOrMore
                i++;
            }
            Debug.Assert(score5 == 12000, "Score was not correctly updated.");
            Console.WriteLine("\nTest Completed. Press Any Key to Continue and Run More Tests.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Testing 1000x to see if the game will end upon a player reaching above 20 score.");
            Console.WriteLine("This Could Take some time, it is testing 3 scenarios: " +
                "\n\nwhen one player has over 20, when the other has over 20, and when both players have over 20." +
                "\nthis means calling the method 3000x (1000x each)");
            Console.WriteLine("\n\nIf An Error is found, it will show on screen.");
            i = 0;
            while (i < 1000)
            {
                Debug.Assert(!three.EndCheck(21, 19), "Game Didnt End as Expected");
                Debug.Assert(!three.EndCheck(19, 21), "Game Didnt End as Expected");
                Debug.Assert(!three.EndCheck(21, 21), "Game Didnt End as Expected");
                i++;
            }
            Console.WriteLine("\nTest Completed. End Of Tests.");
            Console.ReadKey();
            Die.Testing = false; ///Disable the Testing Bool





        }
    }
}
