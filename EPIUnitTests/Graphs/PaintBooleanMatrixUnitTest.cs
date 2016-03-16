using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Graphs;

using FluentAssertions;

namespace EPI.UnitTests.Graphs
{
	[TestClass]
	public class PaintBooleanMatrixUnitTest
	{
		static bool[,] originalMatrix = new bool[10, 10] 
		{
			{true,  false, true,  false, false, false, true,  true,  true,  true},
			{false, false, true,  false, false, true,  false, false, true,  true},
			{true,  true,  true,  false, false, true,  true,  false, true,  true},
			{false, true,  false, true,  true,  true,  true,  false, true,  false},
			{true,  false, true,  false, false, false, false, true,  false, false},
			{true,  false, true,  false, false, true,  false, true,  true,  true},
			{false, false, false, false, true,  false, true,  false, false, true},
			{true,  false, true,  false, true,  false, true,  false, false, false},
			{true,  false, true,  true,  false, false, false, true,  true,  true},
			{false, false, false, false, false, false, false, true,  true,  false}
		};
		const int x = 5;
		const int y = 4;

		static bool[,] expectedResultAfterFlipping5x4 = new bool[10, 10]
		{
			{true,  false, true,  false, false, false, true,  true,  true,  true},
			{false, false, true,  false, false, true,  false, false, true,  true},
			{true,  true,  true,  false, false, true,  true,  false, true,  true},
			{false, true,  false, true,  true,  true,  true,  false, true,  false},
			{true,  true,  true,  true,  true,  true,  true,  true,  false, false},
			{true,  true,  true,  true,  true,  true,  true,  true,  true,  true},
			{true,  true,  true,  true,  true,  true,  true,  false, false, true},
			{true,  true,  true,  true,  true,  true,  true,  false, false, false},
			{true,  true,  true,  true,  true,  true,  true,  true,  true,  true},
			{true,  true,  true,  true,  true,  true,  true,  true,  true,  false}
		};

		static bool[,] expectedResultAfterFlipping3x6 = new bool[10, 10]
		{
			{true,  false, false, false, false, false, true,  true,  true,  true},
			{false, false, false, false, false, false, false, false, true,  true},
			{false, false, false, false, false, false, false, false, true,  true},
			{false, false, false, false, false, false, false, false, true,  false},
			{false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false}
		};

		[TestMethod]
		public void FlipColor()
		{
			// Arrange
			bool[,] A = new bool[10, 10];
			Array.Copy(originalMatrix, A, originalMatrix.Length);

			// Act
			PaintBooleanMatrix.FlipColor(A, x, y);

			// Assert
			A.Should().Equal(expectedResultAfterFlipping5x4);

			// Arange
			Array.Copy(expectedResultAfterFlipping5x4, A, expectedResultAfterFlipping5x4.Length);

			// Act
			PaintBooleanMatrix.FlipColor(A, 3, 6);

			// Assert
			A.Should().Equal(expectedResultAfterFlipping3x6);
		}

		[TestMethod]
		public void FlipColorDFS()
		{
			// Arrange
			bool[,] A = new bool[10, 10];
			Array.Copy(originalMatrix, A, originalMatrix.Length);

			// Act
			PaintBooleanMatrix.FlipColorDFS(A, x, y);

			// Assert
			A.Should().Equal(expectedResultAfterFlipping5x4);

			// Arange
			Array.Copy(expectedResultAfterFlipping5x4, A, expectedResultAfterFlipping5x4.Length);

			// Act
			PaintBooleanMatrix.FlipColorDFS(A, 3, 6);

			// Assert
			A.Should().Equal(expectedResultAfterFlipping3x6);
		}
	}
}
