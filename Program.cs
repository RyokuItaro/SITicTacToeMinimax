using SIprojTicTacToe.Models;
using System;
using SIprojTicTacToe.Algorithm;

class Program
{
	public static void Main(String[] args)
    {
        int x, y;
        bool successfullyParsed = true;
        char[,] board = {{ '_', '_', '_' },
                         { '_', '_', '_' },
                         { '_', '_', '_' }};

        while (true)
        {
			Board.showBoard(board);

            Console.WriteLine("RUCH GRACZA - PODAJ KOORDYNATY");
			do
			{
				do
				{
					Console.WriteLine("X = ??");
					successfullyParsed = Int32.TryParse(Console.ReadLine(), out x);
				} while (x > 3 || x < 1);

				do
				{
					Console.WriteLine("Y = ??");
					successfullyParsed = Int32.TryParse(Console.ReadLine(), out y);
				} while (y > 3 || y < 1);
			} while (!Board.checkIfValidMove(board, x - 1, y - 1));

            board[y - 1, x - 1] = 'o';

            if (Board.checkIfEnded(board) == "win")
            {
                Console.WriteLine("Gracz wygral");
				Board.showBoard(board);
				break;
            }
			else if (Board.checkIfEnded(board) == "tie")
			{
				Console.WriteLine("Remis");
				Board.showBoard(board);
				break;
			}

			Move bestMove = Minimax.findBestMove(board);
			board[bestMove.y, bestMove.x] = 'x';

			if (Board.checkIfEnded(board) == "win")
			{
				Console.WriteLine("AI wygral");
				Board.showBoard(board);
				break;
			}
			else if (Board.checkIfEnded(board) == "tie")
			{
				Console.WriteLine("Remis");
				Board.showBoard(board);
				break;
			}
		}
    }
}
