namespace EPI.PrimitiveTypes
{
	/// <summary>
	/// The greatest common divisor (GCD) of positive integers x and y is the largest integer d
	/// such that d divides both x and y evenly. i.e. x mod d = 0 and y mod d = 0
	/// Design efficient algorithms for computing the GCD of two numbers.
	/// Optimal solution should be written without using multiplication, division or the modulus operations
	/// </summary>
	public static class GCD
	{
		public static int EulersApproach(int x, int y)
		{
			if (x  == y)
			{
				return x;
			}
			else if (x > y)
			{
				return EulersApproach(x - y, y);
			}
			else
			{
				return EulersApproach(x, y - x);
			}
		}

		public static int FasterEulersApproach(int x, int y)
		{
			if (x == 0)
			{
				return y;
			}
			if(y == 0)
			{
				return x;
			}
			if (x > y)
			{
				return FasterEulersApproach(x % y, y);
			}
			else
			{
				return FasterEulersApproach(x, y % x);
			}
		}

		public static int OptimalApproach(int x, int y)
		{
			if (x == 0)
			{
				return y;
			}
			else if (y == 0)
			{
				return x;
			}
			else if (IsEven(x) && IsEven(y)) // both numbers are even
			{
				// right shift by 1 is divide by 2
				// left shift by 1 is multiply by 2
				return OptimalApproach(x >> 1, y >> 1) << 1; // GCD(20,10) = 2 * GCD(10, 5);
			}
			else if(IsEven(x) && !IsEven(y)) // x is even, y is odd
			{
				return OptimalApproach(x >> 1, y);  // GCD(10,5) = GCD(10/2,5) = GCD(5,5)
			}
			else if (!IsEven(x) && IsEven(y))// x is odd, y is even
			{
				return OptimalApproach(x, y >> 1); // GCD(7, 80) = GCD(7,80/2) = GCD(7,40)
			}
			else // both are odd
			{
				if ( x > y)
				{
					return OptimalApproach(x - y, y);
				}
				else
				{
					return OptimalApproach(x, y - x);
				}
			}
		}

		private static bool IsEven(int x)
		{
			return ((x & 1) == 0);
		}
	}
}
