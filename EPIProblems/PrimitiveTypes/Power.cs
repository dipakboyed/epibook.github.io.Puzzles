namespace EPI.PrimitiveTypes
{
	/// <summary>
	/// Write a function that takes a double x and an integer y and returns x^y.
	/// Assume addition, multiplication and division take constant time.
	/// Ignore overflow/underflow exceptions
	/// </summary>
	public static class Power
	{
		public static double XPowerY(double x, int y)
		{
			double result = 1;
			if ( y < 0)
			{
				x = 1 / x;
				y = -y;
			}
			while (y > 0)
			{
				// iterate through each bit of y

				if ((y & 1) == 1) // LSB ends with 1
				{
					result *= x; // current x value counts towards the final result
				}
				x *= x; // double the x value with each iteration
				y >>= 1; // shift to next bit
			}

			return result;
		}
	}
}
