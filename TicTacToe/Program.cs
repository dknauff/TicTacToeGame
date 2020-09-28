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
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] spaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);

        //introduction and how to play instructions
            intro.GreetingAndInstructions(currentPlayer);

            //print board
            intro.PrintingBoard(spaces);

                //game logic
                GameLogic(spaces, currentPlayer);

                gameStatus = CheckWinner(spaces);
            }
            while (gameStatus.Equals(0));

            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"{currentPlayer} won!!!");
                Console.ReadKey();
            }

            static int GetNextPlayer(int player)
            {
                if (player.Equals(1))
                {
                    return 2;
                }
                return 1;
            }
        }

        private static int CheckWinner(char[] spaces)
        {
            if (spaces[0].Equals(spaces[1]) && spaces[1].Equals(spaces[2]))
            {
                return 1;
            }
            return 0;
        }

        private static void GameLogic(char[] spaces, int currentPlayer)
        {
            bool notAllowedMove = true;
            do
            {
                string userChoice = Console.ReadLine();

                if (!string.IsNullOrEmpty(userChoice) &&
                    (userChoice.Equals("1") || userChoice.Equals("2") || userChoice.Equals("3") || userChoice.Equals("4") || userChoice.Equals("5") || userChoice.Equals("6") || userChoice.Equals("7") || userChoice.Equals("8") || userChoice.Equals("9")))
                {

                    int.TryParse(userChoice, out var gameSpaces);

                    char currentSpace = spaces[gameSpaces - 1];

                    if (currentSpace.Equals('X') || currentSpace.Equals('0'))
                    {
                        Console.WriteLine("Spot's taken bud");
                    }
                    else
                    {
                        spaces[gameSpaces - 1] = GetPlayerMarker(currentPlayer);

                        notAllowedMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please choose between 1-9");
                }
            }
            while (notAllowedMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player / 2 == 0)
            {
                return 'X';
            }
            return 'O';
        }
    }
}
