using System;
using System.Collections.Generic;

namespace EPI.Sorting
{
	/// <summary>
	/// Consider the problem of scheduling tasks to workers. Each worker must be assigned two independent tasks.
	/// The goal is to minimize how long it takes for all tasks to be completed.
	/// Design an algorithm that takes as input an array of numbers (task duration) and computes the set of pairs of tasks
	/// such that the maximum pair sum is minimized.
	/// </summary>
	/// <example>
	/// If durations are {5,2,1,6,4,4} then the pairs (2,5),(1,6),(4,4) is an optimum assignment
	/// </example>
	public static class TaskAssignment
	{
		public static List<Tuple<int, int>> MinimizeTaskPairs(int[] taskDurations)
		{

			List<Tuple<int, int>> optimumAssignment = new List<Tuple<int, int>>();
			QuickSort<int>.Sort(taskDurations);
			//assume total tasks are even number
			for (int i = 0; i < taskDurations.Length / 2; i++)
			{
				// pair up the smallest and largest durations
				optimumAssignment.Add(new Tuple<int, int>(taskDurations[i], taskDurations[taskDurations.Length - i - 1]));
			}
			return optimumAssignment;
		}
	}
}
