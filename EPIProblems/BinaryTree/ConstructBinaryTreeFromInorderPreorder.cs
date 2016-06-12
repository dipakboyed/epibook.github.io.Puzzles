using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Given an inorder and preorder traversal sequence of a binary tree, write
	/// a function to reconstruct the tree.
	/// Assume each node has a unique key
	/// </summary>
	public static class ConstructBinaryTreeFromInorderPreorder<T>
	{

		public static BinaryTreeNode<T> ReconstructTreeFromInorderAndPreorderData(List<T> inorderData, List<T> preorderData)
		{
			// store the index of the given node data from inorder traversal
			Dictionary<T, int> inorderNodeIndex = new Dictionary<T, int>();
			for (int i = 0; i < inorderData.Count; i++)
			{
				inorderNodeIndex.Add(inorderData[i], i);
			}

			return BuildTreeFromInorderAndPreOrderHelper(preorderData, 0, preorderData.Count - 1, 0, inorderData.Count - 1, inorderNodeIndex);
		}

		private static BinaryTreeNode<T> BuildTreeFromInorderAndPreOrderHelper(
			List<T> preorderData,
			int preStart, int preEnd,
			int inStart, int inEnd,
			Dictionary<T, int> inorderNodeIndex)
		{
			if (preStart >= preEnd || inStart >= inEnd)
			{
				return null; // base case
			}

			int currentNodeInorderIndex = inorderNodeIndex[preorderData[preStart]];
			int leftSubtreeSize = currentNodeInorderIndex - inStart;

			return new BinaryTreeNode<T>(preorderData[preStart])
			{
				Left = BuildTreeFromInorderAndPreOrderHelper(
							preorderData,
							preStart + 1, preStart + 1 + leftSubtreeSize,
							inStart, currentNodeInorderIndex,
							inorderNodeIndex),
				Right = BuildTreeFromInorderAndPreOrderHelper(
							preorderData,
							preStart + 1+ leftSubtreeSize, preEnd,
							currentNodeInorderIndex + 1, inEnd,
							inorderNodeIndex)
			};
		}
	}
}
