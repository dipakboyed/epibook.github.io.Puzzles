using System;
using System.Collections.Generic;

namespace EPI.Recursion
{
	/// <summary>
	/// Enumerate the power set of an array with distinct elements
	/// </summary>
	/// <example>
	/// {A,B,C} results in { {}, {A}, {B}, {C}, {A,B}, {B,C}, {A,C} {A,B,C} }
	/// </example>
	public static class EnumeratePowerSet
	{
		public static List<List<char>> ListPowerSet(char[] array)
		{
			List<List<char>> result = new List<List<char>>();
			result.Add(new List<char>());
			PowerSetHelper(array, 0, result);
			return result;
		}

		private static void PowerSetHelper(char[] array, int index, List<List<char>> result)
		{
			// base case: if we've reached the end of the array
			if (index < array.Length)
			{
				int resultLength = result.Count;
				for (int i = 0; i < resultLength; i++)
				{
					List<char> newSubSet = new List<char>(result[i]);
					newSubSet.Add(array[index]);
					result.Add(newSubSet);
				}
				PowerSetHelper(array, index + 1, result);
			}
		}


		public static List<List<char>> ListPowerSetViaBitManipulation(char[] array)
		{
			if (array.Length > 64)
			{
				throw new ArgumentException("we can only support arrays upto length 64");
			}
			List<List<char>> result = new List<List<char>>();
			long length = Convert.ToInt64(Math.Pow(2, array.Length));
			for (int i = 0; i < length; i++)
			{
				List<char> subSet = new List<char>();
				int itemIndex = 0;
				int number = i;
				while (number > 0)
				{
					if ((number & 1) == 1) //LSB is 1
					{
						subSet.Add(array[itemIndex]);
					}
					number >>= 1;
					itemIndex++;
				}
				result.Add(subSet);
			}

			return result;
		}
	}
}
