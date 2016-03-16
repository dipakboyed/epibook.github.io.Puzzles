namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes as input a 2D array of 1s and 0s
	/// where the 0s represent the position of rooks on a n x m chess board.
	/// Update the array to contain 0s for all locatons which can be attacked
	/// by those rooks
	/// </summary>
	public static class RookAttack
	{
		public static void IdentifyRookAttackPositions(bool[,] chessBoard)
		{
			// Time complexity will be O(nm) as we need to be iterate the entire chess board
			// Let's to try implement a solution which uses the least amount of space and can have O(1) space complexity
			// Instead of using any new variables, we can use the first entry in each row and column to represent if that entire row/column should be set to 0s

			int rows = chessBoard.GetLength(0);
			int cols = chessBoard.GetLength(1);
			// Before using the entry check if any of the first row/column entry already has a rook
			bool firstRowHasRook = false;
			for (int j = 0; j < cols; j++)
			{
				if (!chessBoard[0,j])
				{
					firstRowHasRook = true;
					break;
				}
			}
			bool firstColHasRook = false;
			for (int i = 0; i < rows; i++)
			{
				if (!chessBoard[i, 0])
				{
					firstColHasRook = true;
					break;
				}
			}

			// iterate the rest of the board
			// set first row/col entry to 0 if a position contains a rook
			for (int  i = 1; i < rows; i++)
			{
				for (int j = 1; j <cols; j++)
				{
					if (!chessBoard[i,j])
					{
						chessBoard[i, 0] = false;
						chessBoard[0, j] = false;
					}
				}
			}

			// mark all attackable positions as 0
			for (int i = 1; i < rows; i++)
			{
				if (!chessBoard[i, 0])
				{
					for (int j = 1; j < cols; j++)
					{
						chessBoard[i, j] = false;
					}
				}
			}
			for (int j = 1; j < cols; j++)
			{
				if (!chessBoard[0, j])
				{
					for (int i = 1; i < rows; i++)
					{
						chessBoard[i, j] = false;
					}
				}
			}

			// now set chessBoard[0,j] and [i,0] if we had previously found a rook
			// in the first row or col
			if (firstRowHasRook)
			{
				for (int j = 0; j < cols; j++)
				{
					chessBoard[0, j] = false;
				}
			}
			if (firstColHasRook)
			{
				for (int i = 0; i < rows; i++)
				{
					chessBoard[i, 0] = false;
				}
			}
		}
	}
}
