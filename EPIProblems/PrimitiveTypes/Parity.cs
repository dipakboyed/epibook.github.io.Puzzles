using System;

namespace EPI.PrimitiveTypes
{
	/// <summary>
	/// Compute the parity of a very large 64-bit number
	/// </summary>
	/// <example>
	/// 1011 has a parity of 1
	/// 10001000 has a parity of 0
	/// </example>
	public static class Parity
	{
		public static bool ComputeParity(Int64 word)
		{
			bool result = false;
			while ( word > 0)
			{
				if ((word & 1) == 1) // lsb is 1
				{
					result ^= true;
				}
				word >>= 1;
			}
			return result;
		}
	}
}
