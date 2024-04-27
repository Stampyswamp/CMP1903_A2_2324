using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        public static int diceRolled;
        public static int SevensOutCompleted;
        public static int ThreeOrMoreCompleted;
        public static int CPUMatches;
        public static int ThrowThreeTested;
        public int MatchesTotal = SevensOutCompleted + ThreeOrMoreCompleted + ThrowThreeTested;
        public static int SevensP1High;
        public static int SevensP2High;
        
        /// <summary>
        /// Displays all of the Recorded Statistics inside of the console, using static integers.
        /// </summary>
        public void GameStatistics() { Console.WriteLine(
            $"Statistics (Doesnt Include Testing)\n\n" +
            $"Match Stats:\n" +
            $"------------\n" +
            $"Total Matches:       {MatchesTotal}\n" +
            $"SevensOut Matches:   {SevensOutCompleted}\n" +
            $"ThreeOrMore Matches: {ThreeOrMoreCompleted}\n" +
            $"ThrowThree Matches:  {ThrowThreeTested}\n\n" +
            $"In-Game Stats:\n" +
            $"--------------\n" +
            $"Dice Rolled:       {diceRolled}\n" +
            $"Times Against CPU: {CPUMatches}\n\n" +
            $"High Scores:\n" +
            $"------------\n" +
            $"SevensOut: Player 1:     {SevensP1High}\n" +
            $"SevensOut: Player 2/CPU: {SevensP2High}\n"); Console.ReadKey(); }

      
    }
}
