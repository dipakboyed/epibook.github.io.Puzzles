using System;
using System.Collections.Generic;

namespace EPI.StacksAndQueues
{
	/// <summary>
	/// A straight line program (SLP) for computing x^n is a finite sequence {x, x^i1, x^i2,...,x^n}
	/// where each element after the first is either a product of any previous two elements or square
	/// of some previous element.
	/// Given a positive integer, n, compute a shortest straight line program to evaluate x^n.
	/// </summary>
	public static class ShortestStraightLine
	{
		// Iterate the sequence like BFS (breadth first search) of a graph starting with power 1.
		// Find the first sequence containing the power of n and since we use BFS, it will be
		// guaranteed to be the shortest path from power of 1.
		// Use a queue to manage BFS
		public static List<int> GetShortestStraightLine(int n)
		{
			if (n == 1)
			{
				return new List<int>() { 1 };
			}
			// initialize the queue for BFS traversal with 1
			Queue<List<int>> sequence = new Queue<List<int>>();
			sequence.Enqueue(new List<int>() { 1 });

			while (sequence.Count > 0)
			{
				// read the next sequence to process
				List<int> currentSequence = sequence.Dequeue();
				int lastPower = currentSequence[currentSequence.Count - 1];
				// Iterate all possible children sequences
				foreach (int item in currentSequence)
				{
					// x^i1 + x^in
					int power = item + lastPower;

					if (power > n)
					{
						break;
					}

					List<int> newSequence = new List<int>(currentSequence);
					newSequence.Add(power);

					if (power == n)
					{
						return newSequence;
					}

					sequence.Enqueue(newSequence);
				}
			}

			throw new InvalidOperationException("No solution found");
		}
	}
}
