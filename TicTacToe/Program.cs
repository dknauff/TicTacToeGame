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
                Console.Clear();
                Console.WriteLine($"{currentPlayer} won!!!");
                Console.ReadKey();
            }

            if (gameStatus.Equals(2))
            {
                Console.Clear();
                Console.WriteLine("It is a draw...");
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
            if (IsGameDraw(spaces))
            {
                return 2;
            }

            if (IsGameWinner(spaces))
            {
                return 1;
            }

            return 0;
        }

        private static bool IsGameDraw(char[] spaces)
        {
            return spaces[0] != '1' && spaces[1] != '2' && spaces[2] != '3' && spaces[3] != '4' && spaces[4] != '5' && spaces[5] != '6' && spaces[6] != '7' && spaces[7] != '8' && spaces[8] != '9';
        }

        private static bool IsGameWinner(char[] spaces)
        {
            if (AreSpacesTheSame(spaces, 0, 1, 2))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 3, 4, 5))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 6, 7, 8))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 0, 3, 6))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 1, 4, 7))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 2, 5, 8))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 0, 4, 8))
            {
                return true;
            }
            if (AreSpacesTheSame(spaces, 2, 4, 6))
            {
                return true;
            }
            return false;
        }

        private static bool AreSpacesTheSame(char[] testSpaces, int pos1, int pos2, int pos3)
        {
            return testSpaces[pos1].Equals(testSpaces[pos2]) && testSpaces[pos2].Equals(testSpaces[pos3]);
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
