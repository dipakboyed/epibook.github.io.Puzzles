using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Given a preorder traversal sequence of a binary tree which includes null to mark empty children, write
	/// a function to reconstruct the tree.
	/// Assume each node has a unique key
	/// </summary>
	public static class ConstructBinaryTreeFromPreorderWithNull<T>
	{

		public static BinaryTreeNode<T> ReconstructTreeFromPreorderDataWithNull(List<T> preorderData)
		{
			int index = 0;
			return ReconstructTreeHelper(preorderData, ref index);
		}

		private static BinaryTreeNode<T> ReconstructTreeHelper(List<T> preorderData, ref int i)
		{
			T current = preorderData[i++];
			if (current == null)
			{
				return null;
			}

			// first built the left subtree
			var leftSubTree = ReconstructTreeHelper(preorderData, ref i);
			// next build the right subtree
			var rightSubTree = ReconstructTreeHelper(preorderData, ref i);

			return new BinaryTreeNode<T>(current)
			{
				Left = leftSubTree,
				Right = rightSubTree
			};
		}
	}
}
