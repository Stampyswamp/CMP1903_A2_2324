using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        private static Die dieroll = new Die();

        /// <summary>
        /// Method Calls all other methods to create the loop in which the game runs.
        /// </summary>
        public void GameSevens()
        {
            Console.WriteLine("SevensOut Initiated"); System.Threading.Thread.Sleep(1000); Console.Clear();
            int total = 0;
            int sum;
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Player 1"); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("Press Any Key to Roll"); Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {              
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Player 1"); Console.ForegroundColor = ConsoleColor.White;
                int die1 = dieroll.Roll();
                int die2 = dieroll.Roll();
                sum = die1 + die2;
                if (IsSeven(sum)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSEVEN WAS FOUND"); Console.ForegroundColor = ConsoleColor.White; break; }
                else { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nSEVEN WASNT FOUND"); Console.ForegroundColor = ConsoleColor.White; }
                sum = GetSum(die1, die2);
                total += sum;
                Console.WriteLine("Total: " + total);
            }
            Console.WriteLine($"Player 1 Your Score was: {total}\nType Anything To Continue");
            Console.ReadKey();
            Console.Clear();
            int player1score = total;
            if (player1score > Statistics.SevensP1High) { Statistics.SevensP1High = player1score; }
            total = 0;
            
            bool yesorno = Choice();
            int player2score = getscore(yesorno);
            if (player2score > Statistics.SevensP2High) { Statistics.SevensP2High = player2score; }
            Console.Clear();
            Wincheck(player1score,player2score);
            Console.WriteLine("Press any Key to Continue...");
            Console.ReadKey();
            Console.Clear();
            
        }

        /// <summary>
        /// Uses the Bool Value to decide if the player chose to play against a friend or the computer, and returns the correct score.
        /// </summary>
        /// <param name="yesorno"></param>
        /// <returns></returns>
        public int getscore(bool yesorno) 
        {
            int player2score;
            if (yesorno)
            {
                player2score = friendPlay();
            }
            else
            {
                player2score = CPU();

            }

            return player2score;


        }
        
        /// <summary>
        /// Allows the player to choose if they want to play Against CPU or their Friend after the player has taken their turn.
        /// </summary>
        /// <returns></returns>
        public bool Choice()
        {
            while (true)
            {
                Console.WriteLine("Play against:\n(1)Friend\n(2)CPU");
                string Key = Console.ReadKey().KeyChar.ToString();

                int.TryParse(Key, out int SKey);

                switch (SKey)
                {
                    case 1: Console.Clear(); return true;

                    case 2: Console.Clear(); Statistics.CPUMatches += 1; return false;

                    default: continue;
                }



            }
        }

        /// <summary>
        /// Normal Turn Loop, Cut into method to be interchangable with CPU
        /// </summary>
        /// <returns></returns>
        public int friendPlay()
        {
            int sum;
            int total = 0;
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Player 2"); Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("Press Any Key to Roll"); Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Player 2"); Console.ForegroundColor = ConsoleColor.White;
                int die1 = dieroll.Roll();
                int die2 = dieroll.Roll();
                sum = die1 + die2;
                if (IsSeven(sum)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSEVEN WAS FOUND"); Console.ForegroundColor = ConsoleColor.White; break; }
                else { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nSEVEN WASNT FOUND"); Console.ForegroundColor = ConsoleColor.White; }
                sum = GetSum(die1, die2);
                total += sum;
                Console.WriteLine("Total: " + total);
            }
            Console.WriteLine($"Player 2 Your Score was: {total}");
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
            return total;
        }

        /// <summary>
        /// Normal Turn Loop, Cut into method to be interchangable with friendPlay
        /// </summary>
        /// <returns></returns>
        public int CPU()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("CPU"); Console.ForegroundColor = ConsoleColor.White;
            int sum;
            int total = 0;
            while (true)
            {
                Console.WriteLine("Initiating Rolling Sequence");
                System.Threading.Thread.Sleep(150);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("CPU"); Console.ForegroundColor = ConsoleColor.White;
                int die1 = dieroll.Roll();
                int die2 = dieroll.Roll();
                sum = die1 + die2;
                if (IsSeven(sum)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSEVEN WAS FOUND"); Console.ForegroundColor = ConsoleColor.White; break; }
                else { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nSEVEN WASNT FOUND"); Console.ForegroundColor = ConsoleColor.White; }
                sum = GetSum(die1, die2);
                total += sum;
                Console.WriteLine("Total: " + total);
            }
            Console.WriteLine($"The CPU Scored: {total}");
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
            return total;
        }

        /// <summary>
        /// Checks if the dice is Double, if so returns true, otherwise false.
        /// </summary>
        /// <param name="die1"></param>
        /// <param name="die2"></param>
        /// <returns></returns>
        public bool IsDouble(int die1, int die2)
        {

            if (die1 == die2) { return true; }
            else return false;
        }

        /// <summary>
        /// simple check if the dice rolled 7, will return true or false accordingly.
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool IsSeven(int sum) { if (sum == 7) { return true; } else return false; }

        /// <summary>
        /// calculates the sum of the dice given both dice at once, rewarding respectively the double points for matching numbers, or normal addition for different numbers.
        /// </summary>
        /// <param name="die1"></param>
        /// <param name="die2"></param>
        /// <returns></returns>
        public int GetSum(int die1, int die2)
        {
            int sum = die1 + die2;
            if (IsDouble(die1, die2))
            { sum = (die1 + die2) * 2; }
            else { sum = die1 + die2; }
            Console.WriteLine($"Dice 1: {die1}\nDice 2: {die2}\nSum: {sum}");
            return sum;
        }

        /// <summary>
        /// compares the score of player 1 and player 2/CPU to see who got higher, whoever is higher is pronounced as the winner.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void Wincheck(int p1, int p2)
        {
            Console.WriteLine($"Player 1 Score: {p1}\nPlayer 2/CPU Score: {p2}");
            if (p1 > p2) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"Player 1 Wins!"); Console.ForegroundColor = ConsoleColor.White; }
            else { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"Player 2/CPU Wins!"); Console.ForegroundColor = ConsoleColor.White; }
        }
    }
}
