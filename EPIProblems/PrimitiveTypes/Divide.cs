namespace EPI.PrimitiveTypes
{
	/// <summary>
	/// Given two positive integers (x and y), compute their quotient (x/y) using
	/// only the addition, subtraction and shifting operators
	/// </summary>
	public static class Divide
	{
		public static int ComputeXDivideByY(int x, int y)
		{
			int quotient = 0;
			if (x > 0 && y > 0)
			{
				while (x >= y)
				{
					x -= y;
					quotient++;
				}
			}
			return quotient;
		}

		public static int ComputeXDivideByYFaster(int x, int y)
		{
			int quotient = 0;
			if (x > 0 && y > 0)
			{
				while (x >= y)
				{
					int power = 1;

					while ((y << power) >= (y << (power - 1)) /* no overflow */ && 
							( y << power) <= x)
					{
						power++;
					}

					quotient += 1 << (power - 1);
					x -= y << (power - 1);
				}
			}
			return quotient;
		}
	}
}
