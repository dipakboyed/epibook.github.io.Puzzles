using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class RookAttackUnitTest
	{

		[TestMethod]
		public void IdentifyAllAttackablePositions()
		{
			bool[,] chessBoard = new bool[8, 8]
			{
				{true,  false, true,  true,  true,  true,  true,  true},
				{true,  true,  true,  true,  true,  true,  true,  true},
				{true,  true,  true,  true,  true,  true,  true,  true},
				{true,  true,  true,  true,  true,  false, true,  true},
				{true,  true,  true,  false, true,  true,  true,  true},
				{true,  true,  true,  true,  true,  true,  true,  true},
				{false, true,  true,  true,  true,  false, true,  true},
				{true,  true,  true,  true,  true,  true,  true,  true}
			};

			bool[,] expectedResult = new bool[8, 8]
			{
				{false, false, false, false, false, false, false, false},
				{false, false, true,  false, true,  false, true,  true},
				{false, false, true,  false, true,  false, true,  true},
				{false, false, false, false, false, false, false, false},
				{false, false, false, false, false, false, false, false},
				{false, false, true,  false, true,  false, true,  true},
				{false, false, false, false, false, false, false, false},
				{false, false, true,  false, true,  false, true,  true}
			};
			RookAttack.IdentifyRookAttackPositions(chessBoard);
			chessBoard.Should().Equal(expectedResult);
		}
	}
}
