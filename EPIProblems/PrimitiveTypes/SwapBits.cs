using System;

namespace EPI.PrimitiveTypes
{
	public static class SwapBits
	{
		public static Int64 Swap(Int64 number, int i, int j)
		{
			if ( i >= 0 && i <=63 && j >=0 && j<= 63 && ((number >> i) & 1) != ((number >> j) & 1))
			{
				number ^= (1 << i) | (i << j);
			}
			return number;
		}
	}
}
