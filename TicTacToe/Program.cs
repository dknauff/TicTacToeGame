using ClassSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
        PrintIntro intro = new PrintIntro();

            int currentPlayer = -1;

            do
            {
                currentPlayer = GetNextPlayer(currentPlayer);

        //introduction and how to play instructions
            intro.GreetingAndInstructions(currentPlayer);

            //print board
            intro.PrintingBoard();

            //player chooses number
            string playerChoice = Console.ReadLine();

        Console.Clear();
            }
            while (true);

            static int GetNextPlayer(int player)
            {
                if (player.Equals(1))
                {
                    return 2;
                }
                return 1;
            }
        }
    }
}
