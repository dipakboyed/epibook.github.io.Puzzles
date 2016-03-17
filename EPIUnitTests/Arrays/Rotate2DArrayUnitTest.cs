using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class Rotate2DArrayUnitTest
	{
		[TestMethod]
		public void Rotate2DMatrixTest()
		{
			int[,] matrix1 = new int[1, 1] { { 1 } };
			Rotate2DArray.Rotate(matrix1);
			matrix1.Should().Equal(new int[1, 1] { { 1 } });

			int[,] matrix2 = new int[2, 2]
			{
				{ 1, 2 },
				{ 3, 4 }
			};
			Rotate2DArray.Rotate(matrix2);
			matrix2.Should().Equal(new int[2, 2] { { 3, 1 }, { 4, 2 } });

			int[,] matrix3 = new int[3, 3]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};
			Rotate2DArray.Rotate(matrix3);
			matrix3.Should().Equal(new int[3, 3] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } });

			int[,] matrix4 = new int[4, 4]
			{
				{ 1 , 2 , 3 , 4  },
				{ 5 , 6 , 7 , 8  },
				{ 9 , 10, 11, 12 },
				{ 13, 14, 15, 16 }
			};
			Rotate2DArray.Rotate(matrix4);
			matrix4.Should().Equal(new int[4, 4] { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } });

			int[,] matrix5 = new int[5, 5]
			{
				{ 1 , 2 , 3 , 4 , 5  },
				{ 6 , 7 , 8 , 9 , 10 },
				{ 11, 12, 13, 14, 15 },
				{ 16, 17, 18, 19, 20 },
				{ 21, 22, 23, 24, 25 }
			};
			Rotate2DArray.Rotate(matrix5);
			matrix5.Should().Equal(new int[5, 5] {
				{ 21, 16, 11, 6 ,  1 },
				{ 22, 17, 12, 7 ,  2 },
				{ 23, 18, 13, 8 ,  3 },
				{ 24, 19, 14, 9 ,  4 },
				{ 25, 20, 15, 10,  5 }
			});
		}
	}
}
