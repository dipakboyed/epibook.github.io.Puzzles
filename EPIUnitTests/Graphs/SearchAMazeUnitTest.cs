using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Graphs;

namespace EPI.UnitTests.Graphs
{
	[TestClass]
	public class SearchAMazeUnitTest
	{
		private int[,] _originalMaze;

		[TestInitialize]
		public void SetupOriginalMaze()
		{
			_originalMaze = new int[10, 10] 
			{
				{1,0,0,0,0,0,1,1,0,0},
				{0,0,1,0,0,0,0,0,0,0},
				{1,0,1,0,0,1,1,0,1,1},
				{0,0,0,1,1,1,0,0,1,0},
				{0,1,1,0,0,0,0,0,0,0},
				{0,1,1,0,0,1,0,1,1,0},
				{0,0,0,0,1,0,0,0,0,0},
				{1,0,1,0,1,0,1,0,0,0},
				{1,0,1,1,0,0,0,1,1,1},
				{0,0,0,0,0,0,0,1,1,0}
			};
		}

		[TestMethod]
		public void SearchMazeDfs()
		{
			// Arrange
			int[,] maze = new int[10, 10];
			Array.Copy(_originalMaze, maze, _originalMaze.Length);
			SearchAMaze.Coordinate start = new SearchAMaze.Coordinate { X = 9, Y = 0 };
			SearchAMaze.Coordinate end = new SearchAMaze.Coordinate { X = 0, Y = 9 };

			// Act
			var path = SearchAMaze.SearchDfs(maze, start, end);

			// Assert
			Assert.IsTrue(path.Count > 2, "path includes more than just start and end points");
			Assert.AreEqual(start, path[0], "Path begins at start point");
			Assert.AreEqual(end, path[path.Count - 1], "Path ends at end point");
			SearchAMaze.Coordinate previousCoordinate = new SearchAMaze.Coordinate { X = start.X - 1, Y = start.Y };
			foreach (var coordinate in path)
			{
				Assert.IsTrue(_originalMaze[coordinate.X, coordinate.Y] == 0, "Each coordinate in the path was an empty cell (white pixel)");
				Assert.IsTrue((Math.Abs(coordinate.X - previousCoordinate.X) + Math.Abs(coordinate.Y - previousCoordinate.Y)) == 1,
					"Each consecutive coordinate in the path is a neighbor of the previous coordinate");
				previousCoordinate = coordinate;
			}
		}

		[TestMethod]
		public void SearchMazeBfs()
		{
			// Arrange
			int[,] maze = new int[10, 10];
			Array.Copy(_originalMaze, maze, _originalMaze.Length);
			SearchAMaze.Coordinate start = new SearchAMaze.Coordinate { X = 9, Y = 0 };
			SearchAMaze.Coordinate end = new SearchAMaze.Coordinate { X = 0, Y = 9 };

			// Act
			var path = SearchAMaze.SearchBfs(maze, start, end);

			// Assert
			Assert.IsTrue(path.Count > 2, "path includes more than just start and end points");
			Assert.AreEqual(start, path[0], "Path begins at start point");
			Assert.AreEqual(end, path[path.Count - 1], "Path ends at end point");
			SearchAMaze.Coordinate previousCoordinate = new SearchAMaze.Coordinate { X = start.X - 1, Y = start.Y };
			foreach (var coordinate in path)
			{
				Assert.IsTrue(_originalMaze[coordinate.X, coordinate.Y] == 0, "Each coordinate in the path was an empty cell (white pixel)");
				Assert.IsTrue((Math.Abs(coordinate.X - previousCoordinate.X) + Math.Abs(coordinate.Y - previousCoordinate.Y)) == 1,
					"Each consecutive coordinate in the path is a neighbor of the previous coordinate");
				previousCoordinate = coordinate;
			}
		}
	}
}
