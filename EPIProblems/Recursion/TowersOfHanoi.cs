using System.Collections;
using System.Collections.Generic;

namespace EPI.Recursion
{
	/// <summary>
	/// You are given n rings. The i-th ring has diameter i. The rings are sorted in a peg P1
	/// with the largest ring at the bottom. Transfer these rings to peg P3 which is initially empty.
	/// You have an intermediate peg P2 which is also empty. The only operation allowed is to take the
	/// top most ring from a peg and placing it on top of another peg. You can never place a bigger ring
	/// above a smaller ring.
	/// </summary>
	public static class TowersOfHanoi
	{
		internal static List<Stack> pegs;

		public static void TransferPegs(int n)
		{
			pegs = new List<Stack>()
			{
				new Stack(),
				new Stack(),
				new Stack()
			};
			for (int i=n; i > 0; i--)
			{
				pegs[0].Push(i);
			}

			MovePegs(n, 0, 2, 1);
		}

		private static void MovePegs(int n, int from, int to, int intermediate)
		{
			if (n > 0)
			{
				MovePegs(n - 1, from, intermediate, to);
				pegs[to].Push(pegs[from].Pop());
				MovePegs(n - 1, intermediate, to, from);
			}
		}
	}
}
