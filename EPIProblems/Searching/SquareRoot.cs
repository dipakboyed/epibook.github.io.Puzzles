namespace EPI.Searching
{
	public static class SquareRoot
	{
		/// <summary>
		/// Write a function that takes a non-negative integer key and returns the largest
		/// integer whose square is less than equal to the key.
		/// </summary>
		/// <example>
		/// If input key is 16, returns 4.
		/// If input key is 300, returns 17 since 17^2= 289 < 300 and 18^2 = 324 > 300
		/// </example>
		public static int IntegerSquareRoot(int key)
		{
			int left = 0;
			int right = key;
			while (left <= right)
			{
				int mid = left + (right - left)/ 2;
				int mid_squared = mid * mid;
				if (mid_squared > key)
				{
					right = mid - 1;
				}
				else // mid_squared <= key
				{
					left = mid + 1;
				}
			}

			return left - 1;
		}

		/// <summary>
		/// Write a function that takes a floating point key and returns it's square root
		/// </summary>
		public static double DoubleSquareRoot(double key)
		{
			// set bounds
			double left, right;
			if (key < 1.0)
			{
				// For numbers < 1.0, the square root of x can be larger than x ( sqrt(1/4) == 1/2)
				left = key;
				right = 1.0;
			}
			else
			{
				left = 1.0;
				right = key;
			}

			// normalize comparison to epsilon to avoid precision problem
			while (Compare(left, right) == Order.Smaller)
			{
				double mid = left + (right - left) / 2;
				double mid_squared = mid * mid;
				if (Compare(mid_squared, key) == Order.Equal)
				{
					return mid;
				}
				else if (Compare(mid_squared, key) == Order.Larger)
				{
					right = mid;
				}
				else
				{
					left = mid;
				}
			}
			return left;
		}

		enum Order
		{
			Smaller,
			Equal,
			Larger
		};

		private static Order Compare(double a, double b)
		{
			double diff = (a - b) / b;
			return (diff < (-1 * double.Epsilon)) ? Order.Smaller : ((diff > double.Epsilon) ? Order.Larger : Order.Equal);
		}
	}
}
