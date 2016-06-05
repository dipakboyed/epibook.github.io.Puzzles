namespace EPI.Sorting
{
	/// <summary>
	/// Design an algorithm for computing the salary cap given existing salaries and the target payroll budget.
	/// Salaries less than equal to the cap remain unchanged while salaries greater than the cap are well capped.
	/// </summary>
	/// <example>
	/// If existing salaries are: {90, 40, 20, 100, 30} and the payroll budget is 210, then the salary cap
	/// </example>
	public static class SalaryCap
	{
		public static double FindSalaryCap(double[] salaries, double budget)
		{
			// sort the salaries
			QuickSort<double>.Sort(salaries);
			double sumSoFar = 0;
			double remainingSumCappedAtCurrentSalary = 0;
			for (int i = 0; i < salaries.Length; i++)
			{
				remainingSumCappedAtCurrentSalary = salaries[i] * (salaries.Length - i);

				if (sumSoFar + remainingSumCappedAtCurrentSalary >= budget)
				{
					// this the smallest salary where we are exceeding the cap
					// cap is the average of the budget - sumSoFar
					return (budget - sumSoFar) / (salaries.Length - i);
				}
				sumSoFar += salaries[i];
			}

			return -1; // no solution exists
		}
	}
}
