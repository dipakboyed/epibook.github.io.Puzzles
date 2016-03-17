using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class MatrixSpiralOrderUnitTest
	{
		[TestMethod]
		public void WriteInSpiralOrder()
		{
			int[,] matrix1 = new int[1, 1] { { 1 } };
			MatrixSpiralOrder.WriteSpiralOrder(matrix1).Should().ContainInOrder(1);

			int[,] matrix2 = new int[2, 2]
			{
				{ 1, 2 },
				{ 3, 4 }
			};
			MatrixSpiralOrder.WriteSpiralOrder(matrix2).Should().ContainInOrder(1, 2, 4, 3);

			int[,] matrix3 = new int[3, 3]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};
			MatrixSpiralOrder.WriteSpiralOrder(matrix3).Should().ContainInOrder(1, 2, 3, 6, 9, 8, 7, 4, 5);

			int[,] matrix4 = new int[4, 4]
			{
				{ 1 , 2 , 3 , 4  },
				{ 5 , 6 , 7 , 8  },
				{ 9 , 10, 11, 12 },
				{ 13, 14, 15, 16 }
			};
			MatrixSpiralOrder.WriteSpiralOrder(matrix4).Should().ContainInOrder(1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10);

			int[,] matrix5 = new int[5, 5]
			{
				{ 1 , 2 , 3 , 4 , 5  },
				{ 6 , 7 , 8 , 9 , 10 },
				{ 11, 12, 13, 14, 15 },
				{ 16, 17, 18, 19, 20 },
				{ 21, 22, 23, 24, 25 }
			};
			MatrixSpiralOrder.WriteSpiralOrder(matrix5).Should().ContainInOrder(1, 2, 3, 4, 5, 10, 15, 20, 25, 24, 23, 22, 21, 16, 11, 6, 7, 8, 9, 14, 19, 18, 17, 12, 13);
		}
	}
}
