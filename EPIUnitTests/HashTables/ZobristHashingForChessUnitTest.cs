using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using State = EPI.HashTables.ZobristHashingForChess.SquareState;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class ZobristHashingForChessUnitTest
	{
		[TestMethod]
		public void ZobristHashComputeForNextMove()
		{
			ZobristHashingForChess chess = new ZobristHashingForChess();
			chess.board = new ZobristHashingForChess.SquareState[]
			{
				State.bR, State.bN, State.bB, State.bQ, State.bK, State.bB, State.bN, State.bR,
				State.bP, State.bP, State.bP, State.bP, State.bP, State.bP, State.bP, State.bP,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.wP, State.wP, State.wP, State.wP, State.wP, State.wP, State.wP, State.wP,
				State.wR, State.wN, State.wB, State.wQ, State.wK, State.wB, State.wN, State.wR
			};

			int nextHash = ZobristHashingForChess.GetNextMoveHashCode(chess.board, chess.GetHashCode(), new Dictionary<int, State>(){
				{8, State.Blank},
				{16, State.bP }
			});

			// expected board state
			chess.board = new[] 
			{
				State.bR, State.bN, State.bB, State.bQ, State.bK, State.bB, State.bN, State.bR,
				State.Blank, State.bP, State.bP, State.bP, State.bP, State.bP, State.bP, State.bP,
				State.bP, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank, State.Blank,
				State.wP, State.wP, State.wP, State.wP, State.wP, State.wP, State.wP, State.wP,
				State.wR, State.wN, State.wB, State.wQ, State.wK, State.wB, State.wN, State.wR
			};
			nextHash.Should().Be(chess.GetHashCode());
		}
	}
}
