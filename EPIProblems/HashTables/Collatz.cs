using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.HashTables
{
	/// <summary>
	/// Test the Collatz conjecture for the first n positive integers.
	/// Collatz conjecture: Take any natural number. If it's odd, tripe it and add one.
	/// If it's even, halve it. Repeat. No matter what number you choose, the sequence
	/// will converge to 1.
	/// NOTE: The conjecture has either been proved or disproved.
	/// </summary>
	/// <example>
	/// 11 follows the sequence: {11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1}
	/// </example>
	public static class Collatz
	{
		// We test the conjecture on n by starting from 1 upto n.
		// The test fails if our sequence hits a loop. (circular reference)
		// The test throws (does not succeed) if we overflow.
		// To optimize:
		// When analyzing n for the Collatz conjecture, all <n numbers have already been evaluated.
		// We store any smaller that we know converges to 1 and if we hit those numbers, we stop.
		// Store only odd converged numbers < n.
		public static bool DoesNumberConvergeToOne(int n)
		{
			// store any previous numbers that we've processed
			HashSet<Int64> processedNumbers = new HashSet<Int64>();
			processedNumbers.Add(1);
			// iterate from  up to n and test the collatz conjecture on each number
			for (int i = 2; i <= n; i++)
			{
				HashSet<Int64> visited = new HashSet<Int64>();
				Int64 current = Convert.ToInt64(i);
				while (current >= i) // stop if we reach a number below current (since those have already been processed and we haven't failed yet)
				{
					if (visited.Contains(current))
					{
						// we entered a loop : hit a number that has already been visited in current sequence
						return false; //Collatz conjecture failed
					}
					visited.Add(current); // mark as visited

					if ((current & 1) == 1) // Odd number
					{
						if (processedNumbers.Contains(current))
						{
							// current has already been processed (dont repeat work)
							break;
						}
						processedNumbers.Add(current); // mark as processed
						Int64 next = (3 * current) + 1; // next number
						if (next <= current)
						{
							// we expected a larger next number but didnt see it
							// this means we overflowed
							throw new OverflowException("Overflow");
						}
						current = next;
					}
					else //even number
					{
						current /= 2;
					}
				}
			}

			// test hasn't failed and completed, return pass
			return true;
		}
	}
}
