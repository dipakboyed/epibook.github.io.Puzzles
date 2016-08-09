using System.Collections.Generic;
using EPI.Graphs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Graphs
{
	/// <summary>
	/// Summary description for WordPuzzleUnitTest
	/// </summary>
	[TestClass]
	public class WordPuzzleUnitTest
	{
		[TestMethod]
		public void FindAllWordsIn2DPuzzle()
		{
			char[,] maze = new char[5, 5]
			{
				{'h', 'i', 'y', 'a', 'o' },
				{'h', 'e', 'y', 'l', 's' },
				{'b', 'i', 'l', 't', 'o' },
				{'z', 'e', 'y', 'l', 's' },
				{'y', 'i', 'f', 'a', 'o' }
			};
			List<string> words = new List<string>()
			{
				"hello", "sos", "yell", "lib", "libs", "hey", "zumba", "heys", "tall"
			};
			WordPuzzle.FindAllWords(maze, words).ShouldBeEquivalentTo(new List<WordPuzzle.Position>()
			{
				new WordPuzzle.Position() {X = 0, Y = 0 , dir = 6 },
				new WordPuzzle.Position() {X = 1, Y = 4 , dir = 1 },
				new WordPuzzle.Position() {X = 4, Y = 0 , dir = 5 },
				new WordPuzzle.Position() {X = 2, Y = 2 , dir = 3 },
				new WordPuzzle.Position() {X = -1, Y = -1 , dir = -1 },
				new WordPuzzle.Position() {X = 1, Y = 0 , dir = 2 },
				new WordPuzzle.Position() {X = -1, Y = -1 , dir = -1 },
				new WordPuzzle.Position() {X = -1, Y = -1 , dir = -1 },
				new WordPuzzle.Position() {X = -1, Y = -1 , dir = -1 },
			});
		}
	}
}
