using System.Collections.Generic;
using System.Linq;

namespace EPI.Recursion
{
	/// <summary>
	/// Write a function that takes a positive integer n and returns a list of all
	/// distinct, non-attacking placements of n queens in an n x n chessboard.
	/// </summary>
	/// <remarks>
	/// A nonattacking queen placement is one in which no two queens are in the same
	/// row, column or diagonal.
	/// It can be represented as an array of n strings, one per row, each string containing
	/// Q where a queen is placed and a . for empty space.
	/// </remarks>
	public static class NQueens
	{
		public static List<string[]> FindAllNonAttackingNQueensPlacement(int n)
		{
			List<string[]> result = new List<string[]>();
			string[] currentBoard = new string[n];
			NQueensHelper(0, n, currentBoard, result);
			return result;
		}

		private static void NQueensHelper(int currentRow, int n, string[] currentBoard, List<string[]> result)
		{
			string[] board = new string[n];
			currentBoard.CopyTo(board, 0);

			// base case for recursion
			if (currentRow == n)
			{
				// we've iterated through all n rows and still found valid placements,
				// add current board to the result list
				result.Add(board);
			}

			// permute each possible placement of queen in current row
			for (int i = 0; i < n; i++)
			{
				char[] row = Enumerable.Repeat('.', n).ToArray();
				row[i] = 'Q'; // add Q at ith position in currentRow (this also ensures we never have >1 Q in the same row)

				// check is current row placement is valid in the current board
				if (CheckCurrentRowIsValid(n, board, currentRow, i))
				{
					// proceed further if this placement is still valid
					board[currentRow] = new string(row);
					NQueensHelper(currentRow + 1, n, board, result);
				}
			}
		}

		private static bool CheckCurrentRowIsValid(int n, string[] currentBoard, int currentRow, int position)
		{
			for (int i = 0; i < currentRow; i++)
			{
				int leftToRightDiagonal = position - (currentRow - i);
				int rightToLeftDiagonal = position + (currentRow - i);
				if (currentBoard[i][position] == 'Q' /* another Q is in same column*/ || 
					(leftToRightDiagonal >= 0 && currentBoard[i][leftToRightDiagonal] == 'Q') || /* diagonals check */
					(rightToLeftDiagonal < n && currentBoard[i][rightToLeftDiagonal] == 'Q'))
				{
					return false;
				}
			}
			return true;
		}
	}
}
