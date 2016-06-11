using System;

namespace EPI.BinaryTree
{
	/// <summary>
	/// A binary tree is considered balanced if for each node in the tree, the difference in height between the 
	/// left subtree and right subtree is atmost 1.
	/// Write a function that takes as input the root of the binary tree and checks if the tree is balanced.
	/// </summary>
	public static class IsBalancedBinaryTree<T>
	{
		public static bool IsBinaryTreeBalanced(BinaryTreeNode<T> root)
		{
			return CheckBalanced(root).Item1;
		}

		///Store the current subtree's balanced state and height in the return value tuple
		/// Height is set correctly only when the tree is balanced
		private static Tuple<bool, int> CheckBalanced(BinaryTreeNode<T> node)
		{
			if (node == null) // base case
			{
				return new Tuple<bool, int>(true, -1);
			}

			var leftSubTree = CheckBalanced(node.Left);
			if (!leftSubTree.Item1)
			{
				return new Tuple<bool, int>(false, 0); // left subtree is not balanced
			}
			var rightSubTree = CheckBalanced(node.Right);
			if (!rightSubTree.Item1)
			{
				return new Tuple<bool, int>(false, 0); // right subtree is not balanced
			}

			bool isBalanced = Math.Abs(leftSubTree.Item2 - rightSubTree.Item2) <= 1;
			int height = Math.Max(leftSubTree.Item2, rightSubTree.Item2) + 1;
			return new Tuple<bool, int>(isBalanced, height);
		}
	}
}
