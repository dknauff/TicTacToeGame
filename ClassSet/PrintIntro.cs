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
        public void PrintingBoard(char[] spaces)
        {
            Console.WriteLine($"  {spaces[0]}  |  {spaces[1]}  |  {spaces[2]}  ");
            Console.WriteLine("-----------------");
            Console.WriteLine($"  {spaces[3]}  |  {spaces[4]}  |  {spaces[5]}  ");
            Console.WriteLine("-----------------");
            Console.WriteLine($"  {spaces[6]}  |  {spaces[7]}  |  {spaces[8]}  ");
        }
    }
}
