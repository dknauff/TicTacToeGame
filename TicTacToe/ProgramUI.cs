using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ProgramUI
    {
        public void Run()
        {
            MainInfo();
        }
        private void GreetingAndInstructions(int PlayerName)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.SetWindowSize(30, 11);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Tic Tac Toe - Console Edition");

            Console.WriteLine("Player 11: X");
            Console.WriteLine("Player 50: O\n");

            Console.WriteLine($"Player {PlayerName} choose your spot 1-9\n");
        }
        private void PrintingBoard(char[] spaces)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"  {spaces[0]}  |  {spaces[1]}  |  {spaces[2]}  ");
            Console.WriteLine("-----------------");
            Console.WriteLine($"  {spaces[3]}  |  {spaces[4]}  |  {spaces[5]}  ");
            Console.WriteLine("-----------------");
            Console.WriteLine($"  {spaces[6]}  |  {spaces[7]}  |  {spaces[8]}  ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        private int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            return 1;
        }
        private void MainInfo()
        {
            ProgramUI programUI = new ProgramUI();
            int gameStatus;
            int currentPlayer = 0;
            char[] spaces = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            {
                Console.Clear();
                currentPlayer = programUI.GetNextPlayer(currentPlayer);

                //introduction and how to play instructions
                programUI.GreetingAndInstructions(currentPlayer);

                //print board
                programUI.PrintingBoard(spaces);

                //game logic
                GameLogic(spaces, currentPlayer);
                //checking for winner
                gameStatus = CheckWinner(spaces);
            }
            while (gameStatus.Equals(0));

            if (gameStatus.Equals(1))
            {
                Console.Clear();
                Console.SetWindowSize(160, 3);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"I, player {currentPlayer}, hearby accept this honor as supreme champion of Tic Tac Toe!  Clearly, you were no match for me, and probably shouldn't even try to beat me again.  But, I will humor it if you really, really, REALLY want to lose again.");
                Console.ReadKey();
            }

            if (gameStatus.Equals(2))
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("It is a draw...");
                Console.ReadKey();
            }

            programUI.GetNextPlayer(1);
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

                    if (currentSpace.Equals('X') || currentSpace.Equals('O'))
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
