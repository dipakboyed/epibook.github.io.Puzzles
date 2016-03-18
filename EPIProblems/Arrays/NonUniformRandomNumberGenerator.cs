using System;
using System.Collections.Generic;

namespace EPI.Arrays
{
	/// <summary>
	/// You are given n real numbers {t0, t1, ...tn-1} and probabilities {p0,p1,...pn-1}
	/// which sum up to 1.
	/// Given a Random number generator that produces values in [0,1] uniformly, how would you
	/// generate a number T according to the specific probabilities?
	/// </summary>
	public static class NonUniformRandomNumberGenerator
	{
		internal static Random randomGenerator = new Random();

		public static int GenerateNonUniformRandomNumber(int[] numbers, double[] probabilities)
		{
			int length = probabilities.Length;
			if (length != numbers.Length)
			{
				throw new ArgumentException("Invalid input");
			}
			// Distribute the range of probabilities into n buckets
			// entry at each item represents non-inclusive upper bound
			double[] range = new double[length];
			double sumOfProbabilitiesSoFar = 0;
			for (int i = 0; i < length; i++)
			{
				sumOfProbabilitiesSoFar += probabilities[i];
				range[i] = sumOfProbabilitiesSoFar;
			}

			double randomValue = randomGenerator.NextDouble();
			int index = BinarySearch(randomValue, range, 0, length - 1);
			return numbers[index];
		}

		private static int BinarySearch(double value, double[] range, int low, int high)
		{
			while (low < high - 1)
			{
				int mid = low + ((high - low) / 2);

				 if (value < range[mid])
				{
					high = mid;
				}
				else
				{
					low = mid;
				}
			}
			if (value >= range[low])
			{
				return high;
			}
			else
				return low;
		}
	}
}
