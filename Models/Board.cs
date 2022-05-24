using System;

namespace SIprojTicTacToe.Models
{
    public static class Board
    {
        public static bool checkIfAnyMovesLeft(char[,] board)
        {
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    if (board[y, x] == '_')
                        return true;
            return false;
        }

        public static void showBoard(char[,] board)
        {
            Console.WriteLine($"{board[0, 0]}{board[0, 1]}{board[0, 2]}");
            Console.WriteLine($"{board[1, 0]}{board[1, 1]}{board[1, 2]}");
            Console.WriteLine($"{board[2, 0]}{board[2, 1]}{board[2, 2]}");
        }

        public static string checkIfEnded(char[,] board)
        {
            for (int y = 0; y < 3; y++)
            {
                if (board[y, 0] == board[y, 1] && board[y, 1] == board[y, 2])
                {
                    if (board[y, 0] == 'x' || board[y, 0] == 'o')
                    {
                        return "win";
                    }
                }
            }

            for (int x = 0; x < 3; x++)
            {
                if (board[0, x] == board[1, x] && board[1, x] == board[2, x])
                {
                    if (board[0, x] == 'x' || board[0, x] == 'o')
                    {
                        return "win";
                    }
                }
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                if (board[0, 0] == 'x' || board[0, 0] == 'o')
                {
                    return "win";
                }
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                if (board[0, 2] == 'x' || board[0, 2] == 'o')
                {
                    return "win";
                }
            }

            if (!checkIfAnyMovesLeft(board))
            {
                return "tie";
            }

            return "err";
        }

        public static bool checkIfValidMove(char[,] board, int x, int y)
        {
            if (board[y, x] != '_')
            {
                Console.WriteLine("Niedozwolony ruch");
                return false;
            }
            return true;
        }
    }
}
