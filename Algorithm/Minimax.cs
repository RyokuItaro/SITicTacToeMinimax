using SIprojTicTacToe.Models;
using System;

namespace SIprojTicTacToe.Algorithm
{
    public static class Minimax
    {
		public static Move findBestMove(char[,] board)
		{
			int bestVal = -1000;
			Move bestMove = new Move();
			bestMove.y = -1;
			bestMove.x = -1;

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					if (board[y, x] == '_')
					{
						board[y, x] = Players.ai;

						int moveVal = minimax(board, false);

						board[y, x] = '_';

						if (moveVal > bestVal)
						{
							bestMove.y = y;
							bestMove.x = x;
							bestVal = moveVal;
						}
					}
				}
			}

			return bestMove;
		}

		public static int evaluateBestPossibility(char[,] board)
		{
			//Sprawdzamy poziomo
			for (int y = 0; y < 3; y++)
			{
				if (board[y, 0] == board[y, 1] &&
					board[y, 1] == board[y, 2])
				{
					if (board[y, 0] == Players.ai)
						return +1;
					else if (board[y, 0] == Players.player)
						return -1;
				}
			}

			//Sprawdzamy pionowo
			for (int x = 0; x < 3; x++)
			{
				if (board[0, x] == board[1, x] &&
					board[1, x] == board[2, x])
				{
					if (board[0, x] == Players.ai)
						return +1;

					else if (board[0, x] == Players.player)
						return -1;
				}
			}

			//Sprawdzamy przekatna 1
			if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
			{
				if (board[0, 0] == Players.ai)
					return +1;
				else if (board[0, 0] == Players.player)
					return -1;
			}

			//Sprawdzamy przekatna 2
			if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
			{
				if (board[0, 2] == Players.ai)
					return +1;
				else if (board[0, 2] == Players.player)
					return -1;
			}

			return 0;
		}

		public static int minimax(char[,] board, bool isMax)
		{
			int rank = evaluateBestPossibility(board);

			if (rank == 1)
				return rank;

			if (rank == -1)
				return rank;

			if (!Board.checkIfAnyMovesLeft(board))
				return rank;

			if (isMax)
			{
				int best = -1000;

				for (int y = 0; y < 3; y++)
				{
					for (int x = 0; x < 3; x++)
					{
						if (board[y, x] == '_')
						{
							board[y, x] = Players.ai;

							best = Math.Max(best, minimax(board, !isMax));

							board[y, x] = '_';
						}
					}
				}
				return best;
			}
			else
			{
				int best = 1000;

				for (int y = 0; y < 3; y++)
				{
					for (int x = 0; x < 3; x++)
					{
						if (board[y, x] == '_')
						{
							board[y, x] = Players.player;

							best = Math.Min(best, minimax(board, !isMax));

							board[y, x] = '_';
						}
					}
				}
				return best;
			}
		}
	}
}
