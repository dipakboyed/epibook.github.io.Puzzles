using System;
using EPI.Strings;

namespace EPI.Recursion
{
    /// <summary>
    /// Write a recursive function that takes as input two strings representing large integers
    /// and returns their product
    /// </summary>
    /// <example>
    /// "123" x "456" returns "56088"
    /// </example>
    /// <remarks>https://youtu.be/JCbZayFr9RE?list=PLXFMmlk03Dt7Q0xr1PIAriY5623cKiH7V</remarks>
    public static class KaratsubaMultiplication
	{
		public static long Multiply(string x, string y)
		{
            // base case : multiply when we are down to single digits
            if (x.Length == 1 || y.Length == 1)
            {
                return StringIntInterConvert.StringToInt(x) * StringIntInterConvert.StringToInt(y);
            }

            // divide each number into components x = 10^n1 . a + b, y = 10^n2 . c + d
            // Karatsuba x * y = (10^n1 . a + b) . (10^n2 . c + d)
            //                 = (10^(n1+n2) . ac) + (10^n1(ad) + 10^n2.bc) + bd
            // if n1==n2,      = 10^2n.ac + 10^n(ad + bc) + bd
            //                 = 10^2n.ac + 10^n ((a+b).(c+d) - ac - bd) +  bd

            int n = Math.Min(x.Length, y.Length) / 2;
            string a = x.Substring(0, x.Length - n);
            string b = x.Substring(x.Length - n, n);
            string c = y.Substring(0, y.Length - n);
            string d = y.Substring(y.Length - n, n);

            int shift = (int) Math.Pow(10, n);
            long ac = Multiply(a,c);
            long bd = Multiply(b,d);
            long aPlusbAndcPlusd = Multiply(StringIntInterConvert.IntToString(StringIntInterConvert.StringToInt(a) + Strings.StringIntInterConvert.StringToInt(b)),
                                           StringIntInterConvert.IntToString(StringIntInterConvert.StringToInt(c) + Strings.StringIntInterConvert.StringToInt(d)));

            return (shift * shift * ac) + (shift * (aPlusbAndcPlusd - ac -bd)) + bd;
        }
    }
}