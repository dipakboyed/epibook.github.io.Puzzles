using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// Design a hash function for chess game states.
	/// It should take as input the current state, the hash code of the current state and a move.
	/// And efficiently compute the hash code of the update move
	/// </summary>
	public class ZobristHashingForChess
	{
		// A Chess board has 64 squares (a-h, 1-8).
		// Each square can have 13 possible values, say:
		//	{blank},
		//	wP, wR, wN, wB, wQ, wK,
		//	bP, bR, bN, bB, bQ, bK
		//	 where w=white piece, b=black piece. 
		//	 where P=pawn, R=rook, N=knight, B=bishop, Q=queen, K=king
		public enum SquareState: int
		{
			Blank = 0,
			wP = 1,
			wR = 2,
			wN = 3,
			wB = 4,
			wQ = 5,
			wK = 6,
			bP = 7,
			bR = 8,
			bN = 9,
			bB = 10,
			bQ = 11,
			bK = 12
		};

		// The current state of the game can be represented by 13 x 64 = 832 distinct values.
		// We can code these 832 distinct values representing the current state of the game as constants in our program.
		// There can be a one-time initialization cost of populating these constant values.
		// This is also known as Zobrist hashing
		private static int[,] chessBoardStates = new int[64, 13];
		private static bool isIntiatilized = false;
		private static void InitializeState()
		{
			if (!isIntiatilized)
			{
				Random rand = new Random();
				for (int i = 0; i < chessBoardStates.GetLength(0); i++)
				{
					for (int j = 0; j < chessBoardStates.GetLength(1); j++)
					{
						chessBoardStates[i, j] = rand.Next();
					}
				}
			}
			isIntiatilized = true;
		}

		public SquareState[] board;
		public ZobristHashingForChess()
		{
			InitializeState();
			board = new SquareState[64];
		}

		// The current hash code for the chess board can then be just the XOR of the code for each square.
		// e.g. chessBoardState[i0,j] ^ chessBoardState[i1,j] ....
		public override int GetHashCode()
		{
			int hash = 0;
			for(int i = 0; i < board.Length; i++)
			{
				hash ^= chessBoardStates[i, (int)board[i]];
			}
			return hash;
		}

		// We can make it a rolling hash function to compute the incremental move's hash code by:
		// XOR-ing out the pieces that moved/got removed from their original position to blank values.
		// and XOR-ing in the new value at the destination position.
		// for e.g. if the next move entails wP moving from a2 to a4.
		// currentHashCode ^ (current value at a2 //remove wP) ^ (blank at a2 //add) ^ (current at a4 //remove current piece) ^ (wP at a4 //add)
		public static int GetNextMoveHashCode(SquareState[] currentBoard, int currentHashCode, Dictionary<int, SquareState> squaresChangedInNextMove)
		{
			InitializeState();

			int result = currentHashCode;
			// squaresChangedInNextMove : the keys are squares which will change, values are the code representing the new state of those squares
			// for now I assume the keys come in pairs of 2.
			// for e.g. a move constituting a bP moving from a2 to a3 will contain:
			// {a2, {blank}}, {a3, bP}
			foreach (int squareIndex in squaresChangedInNextMove.Keys)
			{
				result ^= chessBoardStates[squareIndex, (int)currentBoard[squareIndex]];
				result ^= chessBoardStates[squareIndex, (int)squaresChangedInNextMove[squareIndex]];
				 
			}
			return result;
		}
	}
}
