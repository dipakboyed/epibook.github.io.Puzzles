using System;

namespace EPI.Sorting
{
	/// <summary>
	/// Naive O(n^2) sorting algorithm.
	/// Don't use this in real life! There are much better O(nlogn) sorting algorithms.
	/// </summary>
	public static class BubbleSort<T> where T : IComparable
	{
		// The algorithm is called 'bubble sort' because with each iteration, the
		// next highest number bubbles to the top (or right end of the array)
		public static void Sort(T[] array)
		{
			bool swapsDone;
			int end = array.Length;
			do
			{
				swapsDone = false;
				// swap higheat number to the right in each iteration
				for (int i= 1; i < end; i++)
				{
					int comparison = array[i].CompareTo(array[i - 1]);
					if (comparison < 0) // array[i] < array[i-1]
					{
						// swap
						T temp = array[i];
						array[i] = array[i - 1];
						array[i - 1] = temp;

						swapsDone = true;
					}
				}
				--end;
			}
			while (swapsDone); // stop when no swaps are performed in an iteration
		}
	}
}
