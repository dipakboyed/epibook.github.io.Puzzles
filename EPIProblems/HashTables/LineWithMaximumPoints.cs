using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.HashTables
{
	/// <summary>
	/// You are given a set of points in a plane.
	/// Each point has integer x, y coordinates.
	/// Design an algorithm for computing a line that contains the maximum number of
	/// points in the set
	/// </summary>
	public static class LineWithMaximumPoints
	{
		public struct Point
		{
			public int X;
			public int Y;

			public Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			// For hashing
			public override int GetHashCode()
			{
				return X.GetHashCode() ^ Y.GetHashCode();
			}

			// for comparing
			public override bool Equals(object obj)
			{
				if (obj is Point)
				{
					Point p = (Point)obj;
					return X.Equals(p.X) && Y.Equals(p.Y);
				}
				return false;
			}
		}

		private struct RationalNumber
		{
			public int numerator;
			public int denominator;
			public RationalNumber(int n, int d)
			{
				numerator = n; denominator = d;
			}
		}

		private static RationalNumber Normalize(int n, int b)
		{
			return new RationalNumber(1, 1);
		}
		public class Line
		{
			
		}
	}
}
