using System;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        private int roll;
        public static bool Testing;
        public int Rolled //encapsulates value.
        {
            get { return roll; }
            set { roll = value; }
        }
        
        private static Random rnd = new Random();
        
        /// <summary>
        /// Produces a random roll 1-6. if (parameter is changed && and num > 6 is rolled) {debug class will flag this.} (not real code)
        /// </summary>
        /// <returns> Returns roll which is a random number 1-6. </returns> 
        public int Roll()
        {
            roll = rnd.Next(1, 7); ///Should be 1-7 as base. Otherwise to check for error handling set to anything.
            if (!Testing) { Statistics.diceRolled += 1; } //Keeps the rolls of the Dice Updated in the Statistics Class.
            return roll;
        }
    }
}
