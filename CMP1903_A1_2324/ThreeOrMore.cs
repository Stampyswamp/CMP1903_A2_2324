using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore
    {
        //Declare Object + var.
        private static Random rnd = new Random();
        Die dieroll = new Die();
        int player1score;
        int player2score;

        /// <summary>
        /// The Method GameThree holds the two while loops of the game, one version against a friend, the other version against CPU, and gives an option at the start to choose which one.
        /// </summary>
        public void GameThree() 
        {
            Console.WriteLine("ThreeOrMore Initiated");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to Play with a friend or against CPU?\n(1)Friend\n(2)CPU");
                string Key = Console.ReadKey().KeyChar.ToString();

                int.TryParse(Key, out int SKey);
                switch (SKey)
                {
                    case 1: //Against Friend.
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("Player 1:");
                            Console.ReadKey();
                            int num = InitThrow();
                            p1Score(num);
                            Console.WriteLine($"Player 1 Score: {player1score}");
                            Console.ReadKey();
                            if (!EndCheck(player1score, player2score)) { break; }
                            Console.Clear();
                            Console.WriteLine("Player 2:");
                            Console.ReadKey();
                            num = InitThrow();
                            p2Score(num);
                            Console.WriteLine($"Player 2 Score: {player2score}");
                        if (!EndCheck(player1score, player2score)) { break; }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        Console.Clear();
                        WinText();
                        Console.ReadKey();
                        break;


                    case 2: //Against CPU. 
                        Statistics.CPUMatches += 1;
                        Console.Clear();
                        Console.WriteLine(
                            "The CPU will auto-make their turn and decision (reroll 2/5)." +
                            "\nPlease do not Press a key for them or it will use your turn." +
                            "\nThe CPU will leave a 1 second gap after making its turn to allow you to read." +
                            "\n\nPress Any Key to Continue..."); Console.ReadKey();
                        
                        while(true)
                        {
                            Console.Clear();
                            Console.WriteLine("Player 1:");
                            Console.ReadKey();
                            int num = InitThrow();
                            p1Score(num);
                            Console.WriteLine($"Player 1 Score: {player1score}");
                            Console.ReadKey();
                            if (! EndCheck(player1score, player2score)) { break; }
                            Console.Clear();
                            Console.WriteLine("CPU: ");
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine("Rolling...");
                            System.Threading.Thread.Sleep(200);
                            Console.Clear();
                            Console.WriteLine("CPU: ");
                            num = InitThrow();
                            CPUScore(num);
                            Console.WriteLine($"CPU Score: {player2score}");
                            System.Threading.Thread.Sleep(700);
                            if (!EndCheck(player1score, player2score)) { break; }
                        }
                        Console.Clear();
                        WinTextCPU();
                        Console.ReadKey();
                        break;

                    default: Console.WriteLine("False Input Given."); continue;


                }
                break;
            }
        }


        /// <summary>
        /// Init Throw rolls 5 dice, adds them to a list.
        /// .Distinct() to find the distinct numbers in the list
        /// .Count() to see how many distinct numbers there are
        /// </summary>
        /// <returns>The Amount of Distinct Numbers</returns>
        public int InitThrow() 
        {
            List<int> rolls = new List<int>();
            int i = 5;
            while (i > 0)
            {
                int l = dieroll.Roll();
                rolls.Add(l);
                i--;
            }
            Console.WriteLine("Rolls:");
            foreach (int j in rolls) { System.Threading.Thread.Sleep(50); Console.Write($"{j},"); }
            int unique = rolls.Distinct().Count();
            Console.WriteLine();
            Console.WriteLine($"Unique Numbers:{unique}");
            return unique;
        }

        /// <summary>
        /// Takes the amount of unique numbers
        /// uses a switch case to reward score accordingly,
        /// and recurses itself if a 2 is parsed multiple times.
        /// </summary>
        /// <param name="num"></param>
        public int p1Score(int num)
        {
            switch (num)
            {
                case 2: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("2 Unique Numbers, You May Re-Roll the 3 remainding dice, or all 5."); Console.ForegroundColor = ConsoleColor.White;
                    int choice = AmountToRoll();
                    int score = RerolledDie(choice);
                    p1Score(score);
                    return 0; 
                case 3: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("3 Unique, 3 Points Rewarded."); player1score += 3; Console.ForegroundColor = ConsoleColor.White; return 3;
                case 4: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("4 Unique, 6 Points Rewarded."); player1score += 6; Console.ForegroundColor = ConsoleColor.White; return 6;
                case 5: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("5 Unique, 12 Points Rewarded."); player1score += 12; Console.ForegroundColor = ConsoleColor.White; return 12;
                default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Roll Not High Enough, No Score Given."); Console.ForegroundColor = ConsoleColor.White; return 0;

            }
        }
        
        /// <summary>
        /// CPU score has a different case 2 to the other methods, this allows the CPU to choose what to roll on its own.
        /// </summary>
        /// <param name="num"></param>
        public void CPUScore(int num) 
        {
            switch (num)
            {
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("2 Unique Numbers, You May Re-Roll the 3 remainding dice, or all 5."); Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("How Many Dice Would you Like to Reroll?\n(2) 2 Die\n(5) 5 Die");
                    int choice = rnd.Next(1, 3);
                    if (choice == 1) { choice = 2; }
                    else { choice = 5; }
                    Console.WriteLine(choice);
                    System.Threading.Thread.Sleep(700);
                    int score = RerolledDie(choice);
                    CPUScore(score);
                    break;
                case 3: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("3 Unique, 3 Points Rewarded."); player2score += 3; Console.ForegroundColor = ConsoleColor.White; break;
                case 4: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("4 Unique, 6 Points Rewarded."); player2score += 6; Console.ForegroundColor = ConsoleColor.White; break;
                case 5: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("5 Unique, 12 Points Rewarded."); player2score += 12; Console.ForegroundColor = ConsoleColor.White; break;
                default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Roll Not High Enough, No Score Given."); Console.ForegroundColor = ConsoleColor.White; break;

            }
        }

        /// <summary>
        /// The same as P1Score but for player 2.
        /// </summary>
        /// <param name="num"></param>
        public void p2Score(int num)
        {
            switch (num)
            {
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("2 Unique Numbers, You May Re-Roll the 3 remainding dice, or all 5."); Console.ForegroundColor = ConsoleColor.White;
                    int choice = AmountToRoll();
                    int score = RerolledDie(choice);
                    p2Score(score);
                    break;
                case 3: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("3 Unique, 3 Points Rewarded."); player2score += 3; Console.ForegroundColor = ConsoleColor.White; break;
                case 4: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("4 Unique, 6 Points Rewarded."); player2score += 6; Console.ForegroundColor = ConsoleColor.White; break;
                case 5: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("5 Unique, 12 Points Rewarded."); player2score += 12; Console.ForegroundColor = ConsoleColor.White; break;
                default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Roll Not High Enough, No Score Given."); Console.ForegroundColor = ConsoleColor.White; break;

            }
        }

        /// <summary>
        /// Checks if one score is above 20, if it is, it ends the while loop.
        /// </summary>
        /// <returns></returns>
        public bool EndCheck(int player1score, int player2score)
        { if (player1score > 20 || player2score > 20) { return false; }
            else return true;
        }
        
        /// <summary>
        /// Checks who has a higher score, player 1 or 2 and using this determines the winner (first to reach 20+)
        /// </summary>
        public void WinText() {
            if (player1score > player2score) { Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("Player 1"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" Was First to reach Above 20.\n"); }
            else { Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("Player 2"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" Was First to reach Above 20.\n");
            }
        }

        /// <summary>
        /// Checks who has a higher score, player 1 or CPU and using this determines the winner (first to reach 20+)
        /// </summary>
        public void WinTextCPU()
        {
            if (player1score > player2score) { Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("Player 1"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" Was First to reach Above 20.\n"); }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("CPU"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" Was First to reach Above 20.\n");
            }

        }
                    
        /// <summary>
        /// Simple prompt allowing the player to choose how many dice to reroll.
        /// </summary>
        /// <returns></returns>
        public int AmountToRoll()
        {
            while (true) 
            { Console.WriteLine("How Many Dice Would you Like to Reroll?\n(2) 3 Die\n(5) 5 Die"); 
                string Key = Console.ReadKey().KeyChar.ToString();

                int.TryParse(Key, out int SKey);
                switch (SKey)
                {
                    case 2: return 2;

                    case 5: return 5;

                    default: continue;

                }
            }
        }

        /// <summary>
        /// Uses the result of the Prompt to either roll 2 or 5 dice accordingly.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int RerolledDie(int num)
        { if (num == 2)
            {
                Console.Clear();
                Console.WriteLine("Rolling 3 Dice");
                List<int> rolls = new List<int>();
                int i = 3;
                while (i > 0)
                {
                    int l = dieroll.Roll();
                    rolls.Add(l);
                    i--;
                }
                Console.WriteLine("Rolls:");
                foreach (int j in rolls) { System.Threading.Thread.Sleep(50); Console.Write($"{j},"); }
                int unique = rolls.Distinct().Count();
                Console.WriteLine();
                Console.WriteLine($"Unique Numbers:{unique}");
                return unique;

            }
            else if (num == 5)
            {
                Console.Clear();
                Console.WriteLine("Rolling 5 Dice");
                List<int> rolls = new List<int>();
                int i = 5;
                while (i > 0)
                {
                    int l = dieroll.Roll();
                    rolls.Add(l);
                    i--;
                }
                Console.WriteLine("Rolls:");
                foreach (int j in rolls) { System.Threading.Thread.Sleep(50); Console.Write($"{j},"); }
                int unique = rolls.Distinct().Count();
                Console.WriteLine();
                Console.WriteLine($"Unique Numbers:{unique}");
                return unique;
            }
            else { Console.WriteLine("Somehow the wrong number was Parsed, No Points Awarded."); return 0; }
        }

        

    }
}
