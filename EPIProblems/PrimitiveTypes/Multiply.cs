using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.PrimitiveTypes
{
	/// <summary>
	/// Multiply two non negative integers using only bitwise and assignment operators
	/// </summary>
	public static class Multiply
	{
		public static int MultiplyXandY(int x, int y)
		{
			int result = 0;
			while ( y > 0)
			{
				if ((y & 1) == 1)
				{
					result = UpdateResult(result, x);
				}
				y >>= 1;
				x <<= 1;
			}

			return result;
		}

		private static int UpdateResult(int a, int b)
		{
			int result = 0;
			int carryin = 0;
			int k = 1;
			int tempa = a;
			int tempb = b;
			while ( tempa > 0 || tempb > 0)
			{
				int ak = (a & k);
				int bk = (b & k);
				int carryout = (ak & bk) | (ak & carryin) | (bk & carryin);
				result |= (ak ^ bk ^ carryin);

				carryin = carryout << 1;
				k <<= 1;
				tempb >>= 1;
				tempa >>= 1;
			}

			return result | carryin;
		}
	}
}
