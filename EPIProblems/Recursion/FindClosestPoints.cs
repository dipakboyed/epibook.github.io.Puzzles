using System;
using System.Collections.Generic;
using EPI.Sorting;

namespace EPI.Recursion
{
	/// <summary>
	/// You are given a list of points in a 2D cartesian plane. Each point has an
	/// x, y integer coordinates.
	/// How would you find the two closest points?
	/// </summary>
	public static class FindClosestPoints
	{
		public class Point
		{
			public int X;
			public int Y;

			public Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			public static double Distance(Point a, Point b)
			{
				return Math.Sqrt(((a.X - b.X) * (a.X - b.X)) + ((a.Y - b.Y) * (a.Y - b.Y)));
			}
		};

		private class PointWithXComparison : Point, IComparable
		{
			public PointWithXComparison(int x, int y) : base(x,y){}

			public int CompareTo(object obj)
			{
				var other = obj as PointWithXComparison;
				if (null != other)
				{
					return this.X.CompareTo(other.X);
				}
				throw new InvalidOperationException();
			}
		}

		private class PointWithYComparison : Point, IComparable
		{
			public PointWithYComparison(int x, int y) : base(x, y) { }

			public int CompareTo(object obj)
			{
				var other = obj as PointWithYComparison;
				if (null != other)
				{
					return this.Y.CompareTo(other.Y);
				}
				throw new InvalidOperationException();
			}
		}

		private struct Pair
		{
			internal Point a;
			internal Point b;
			internal double distance;
		};

		public static Tuple<Point, Point> FindPointsWithClosestDistance(Point[] points)
		{
			PointWithXComparison[] p = new PointWithXComparison[points.Length];
			for (int i = 0; i < points.Length; i++)
			{
				p[i] = new PointWithXComparison(points[i].X, points[i].Y);
			}
			// sort the points.
			QuickSort<PointWithXComparison>.Sort(p);
			for (int i = 0; i < p.Length; i++)
			{
				points[i] = new Point(p[i].X, p[i].Y);
			}

			var result = FindClosestPointsHelper(points, 0, points.Length);
			return new Tuple<Point, Point>(result.a, result.b);
		}

		private static Pair FindClosestPointsHelper(Point[] points, int start, int end)
		{
			if (end - start <= 3)
			{
				return BruteForce(points, start, end);
			}
			else
			{
				int mid = start + (end - start) / 2;
				// recursively find closest points paritioned around mid
				var leftResults = FindClosestPointsHelper(points, start, mid);
				var rightResults = FindClosestPointsHelper(points, mid, end);
				Pair smallestPair = (leftResults.distance < rightResults.distance) ? leftResults : rightResults;

				// look for closest distance pair in range P[mid +/- smallestdistance]
				List<Point> remaining = new List<Point>();
				foreach (var point in points)
				{
					if (Math.Abs(point.X - points[mid].X) < smallestPair.distance)
					{
						remaining.Add(point);
					}
				}
				var remainingResults = FindClosestPointsInRemain(remaining, smallestPair.distance);
				return (remainingResults.distance < smallestPair.distance) ? remainingResults : smallestPair;
			}
		}

		private static Pair FindClosestPointsInRemain(List<Point> remaining, double distance)
		{
			PointWithYComparison[] p = new PointWithYComparison[remaining.Count];
			for (int i = 0; i < remaining.Count; i++)
			{
				p[i] = new PointWithYComparison(remaining[i].X, remaining[i].Y);
			}
			// sort the points.
			QuickSort<PointWithYComparison>.Sort(p);
			for (int i = 0; i < p.Length; i++)
			{
				remaining[i] = new Point(p[i].X, p[i].Y);
			}

			Pair smallestDistPair = new Pair();
			smallestDistPair.distance = double.MaxValue;
			for (int i = 0; i < remaining.Count; i++)
			{
				for (int j = i + 1; j < remaining.Count && remaining[j].Y - remaining[i].Y < distance; j++)
				{
					double dist = Point.Distance(remaining[i], remaining[j]);
					if (dist < smallestDistPair.distance)
					{
						smallestDistPair.a = remaining[i];
						smallestDistPair.b = remaining[j];
						smallestDistPair.distance = dist;
					}
				}
			}
			return smallestDistPair;
		}

		private static Pair BruteForce(Point[] points, int start, int end)
		{
			Pair smallestDistPair = new Pair();
			smallestDistPair.distance = double.MaxValue;

			for (int i = start; i < end; i++)
			{
				for (int j = i + 1; j < end; j++)
				{
					var dist = Point.Distance(points[i], points[j]);
					if (dist < smallestDistPair.distance)
					{
						smallestDistPair.a = points[i];
						smallestDistPair.b = points[j];
						smallestDistPair.distance = dist;
					}
				}
			}
			return smallestDistPair;
		}
	}
}
