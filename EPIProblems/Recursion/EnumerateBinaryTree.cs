using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPI.BinaryTree;

namespace EPI.Recursion
{
	/// <summary>
	/// Write a function that takes a positive integer n and returns all distinct binary trees with n nodes
	/// </summary>
	public static class EnumerateBinaryTree<T>
	{
		public static List<BinaryTreeNode<T>> FindAllBinaryTrees(int n)
		{
			if (n <= 0)
			{
				return null;
			}
			List<BinaryTreeNode<T>> result = ListAllBinaryTreeHelper(1, n);
			return result;
		}

		private static List<BinaryTreeNode<T>> ListAllBinaryTreeHelper(int start, int end)
		{
			List<BinaryTreeNode<T>> result = new List<BinaryTreeNode<T>>();
			// base case: add tree by iterating current node;'s parent to result
			if (start > end)
			{
				result.Add(null);
				return result;
			}
			else
			{
				for (int i = start; i <= end; i++)
				{
					var leftTreeResults = ListAllBinaryTreeHelper(start, i - 1);
					var rightTreeResults = ListAllBinaryTreeHelper(i + 1, end);
					foreach (var left in leftTreeResults)
					{
						foreach (var right in rightTreeResults)
						{
							result.Add(new BinaryTreeNode<T>(default(T)) { Left = left, Right = right });
						}
					}
				}
				return result;
			}
		}
	}
}
