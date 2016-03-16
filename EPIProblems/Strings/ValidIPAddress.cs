using System;
using System.Collections.Generic;

namespace EPI.Strings
{
	/// <summary>
	/// A decimal string is a string containing digits betweem 0 and 9.
	/// Return all possible valid IP addresses by computing where to put the '.' in the decimal string.
	/// </summary>
	/// <example> decimal string"19216811" results in 9 possible valid IP addresses
	/// { 1.92.168.11, 19.2.168.11, 19.21.68.11, 19.216.8.11, 19.216.81.1, 192.1.68.11, 192.16.8.11, 192.16.81.1, 192.168.1.1 } </example>
	public static class ValidIpAddress
	{
		public static List<string> ComputeAllValidIpAddresses(string decimalString)
		{
			List<string> validIPs = new List<string>();
			if (!string.IsNullOrEmpty(decimalString))
			{
				for (int i = 0; i < 3 && i < decimalString.Length; i++)
				{
					string tuple1 = decimalString.Substring(0, i + 1);
					if (IsValidIpTuple(tuple1))
					{
						for (int j = i + 1; j - i <= 3 && j < decimalString.Length; j++)
						{
							string tuple2 = decimalString.Substring(i + 1, j - i);
							if (IsValidIpTuple(tuple2))
							{
								for (int k = j + 1; k - j <= 3 && k < decimalString.Length; k++)
								{
									string tuple3 = decimalString.Substring(j + 1, k - j);
									string tuple4 = decimalString.Substring(k + 1);
									if (IsValidIpTuple(tuple3) && IsValidIpTuple(tuple4))
									{
										validIPs.Add(tuple1 + "." + tuple2 + "." + tuple3 + "." + tuple4);
									}
								}
							}
						}
					}
				}
			}
			return validIPs;
		}

		public static bool IsValidIpTuple(string decimalString)
		{
			// decimal strings with leading 0s are considered invalid
			// e.g. 00, 01, 010 etc...
			if (decimalString.Length > 1 && decimalString[0] == '0')
			{
				return false;
			}
			int number;
			return Int32.TryParse(decimalString, out number) && number >= 0 && number <= 255;
		}
	}
}
