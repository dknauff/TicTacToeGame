using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSet
{
    public class PrintIntro
    {
        public void GreetingAndInstructions(int PlayerName)
        {
            Console.WriteLine("Tic Tac Toe - Console Edition");

            Console.WriteLine("Player 11: X");
            Console.WriteLine("Player 50: O\n");

            Console.WriteLine($"Player {PlayerName} choose your spot 1-9\n");
        }
        public void PrintingBoard()
        {
            Console.WriteLine("  1  |  2  |  3  ");
            Console.WriteLine("-----------------");
            Console.WriteLine("  4  |  5  |  6  ");
            Console.WriteLine("-----------------");
            Console.WriteLine("  7  |  8  |  9  ");
        }
    }
}
