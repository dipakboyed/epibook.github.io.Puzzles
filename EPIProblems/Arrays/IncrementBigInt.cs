using System.Linq;

namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes as input an array A of digits encoding a decimal number D
	/// and updates A to represent the number D + 1
	/// </summary>
	/// <example>
	/// If A = [1, 2, 9] then you should update A to [1, 3, 0]
	/// </example>
	public static class IncrementBigInt
	{
		public static void Increment(ref int[] Number)
		{
			if (null != Number)
			{
				// increment the last digit
				Number[Number.Length - 1]++;

				// carry over the extra digit as long as we see Number[i] == 10
				for (int i = Number.Length - 1; i > 0 && Number[i] == 10; i--)
				{
					Number[i] = 0;
					Number[i - 1]++;
				}

				// if the first digit is 10, we need to insert a new item to the array
				if (Number[0] == 10)
				{
					var list = Number.ToList();
					list[0] = 0;
					list.Insert(0, 1);
					Number = list.ToArray();
				}
			}
		}
	}
}
