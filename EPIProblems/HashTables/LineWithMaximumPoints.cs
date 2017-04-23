using System;
using System.Collections.Generic;
using EPI.PrimitiveTypes;

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
			// since x ^ y == y ^ x, we dont want collisions for hash of (1,2) and (2,1)
			// use left shift and wrap on x before xor-ing
			public override int GetHashCode()
			{
				int wrappedBits = X >> 30;
				int leftShifted = X << 2;

				return (leftShifted & wrappedBits).GetHashCode() ^ Y.GetHashCode();
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

		// to avoid precision loss with doubles use a rational number object
		private struct RationalNumber
		{
			public int numerator;
			public int denominator;

			/// <summary>
			/// We normalize so that 20/10 and 2/1 return the same hash
			/// Use divide by GCD to get 2/1 from 20/10.
			/// Similarly, we want -2/1 and 1/-2 to return the same hash
			/// Always store the negative sign in the numerator.
			/// Also -2/-1 and 2/1 should be equal
			/// </summary>
			public RationalNumber(int n, int d)
			{
				int gcd = GCD.OptimalApproach(Math.Abs(n), Math.Abs(d));
				n = n / gcd;
				d = d / gcd;
				if (d < 0)
				{
					numerator = -n;
					denominator = -d;
				}
				else
				{
					numerator = n;
					denominator = d;
				}
			}

			public override int GetHashCode()
			{
				int wrappedBits = numerator >> 30;
				int leftShifted = numerator << 2;
				return (leftShifted & wrappedBits).GetHashCode() ^ denominator.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (obj is RationalNumber)
				{
					RationalNumber number = (RationalNumber)obj;
					return numerator.Equals(number.numerator) && denominator.Equals(number.denominator);
				}
				return false;
			}
		}

		/// <summary>
		/// A slope can be declared using the slope-intercept formula: y = mx + b
		/// where m is the slope of the line and b is the y-intercept.
		/// For two points (x1,y1) and (x2,y2) that are part of the line
		/// m = y2 - y1 / x2 - x1 and b = x2y1 - x1y2 / x2 - x1.
		/// 
		/// An exception are lines parallel to the y-axis which have no y-intercept.
		/// For those cases, store the x-intercept and set slope as 1/0
		/// </summary>
		public class Line
		{
			private RationalNumber slope;
			private RationalNumber intercept;

			public Line(Point a, Point b)
			{
				slope = (a.X != b.X) ? new RationalNumber(b.Y - a.Y, b.X - a.X) : new RationalNumber(1, 0);
				intercept = (a.X != b.X) ? new RationalNumber(b.X * a.Y - a.X * b.Y, b.X - a.X) : new RationalNumber(a.X, 1);
			}

			public override int GetHashCode()
			{
				return slope.GetHashCode() ^ intercept.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (obj is Line)
				{
					Line l = (Line)obj;
					return slope.Equals(l.slope) && intercept.Equals(l.intercept);
				}
				return false;
			}
		}


		public static Line FindLineWithMostPoints(Point[] points)
		{
			Dictionary<Line, HashSet<Point>> table = new Dictionary<Line, HashSet<Point>>();
			for (int i = 0; i < points.Length; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					Line line = new Line(points[i], points[j]);
					if (!table.ContainsKey(line))
					{
						table.Add(line, new HashSet<Point>());
					}
					if (!table[line].Contains(points[i]))
					{
						table[line].Add(points[i]);
					}
					if (!table[line].Contains(points[j]))
					{
						table[line].Add(points[j]);
					}
				}
			}

			int maxSet = 0;
			Line lineWithMostPoints = null;
			foreach (Line line in table.Keys)
			{
				if (table[line].Count > maxSet)
				{
					maxSet = table[line].Count;
					lineWithMostPoints = line;
				}
			}
			return lineWithMostPoints;
		}
	}
}
