namespace EPI.BinaryTree
{
    /// <summary>
    /// Design an algorithm that efficiently finds the kth node appearing in an inorder traversal.
    /// Assume that each node also stores the number of nodes in the subtree rooted at the node
    /// </summary>
    public static class FindKthNodeInOrderTraversal<I>
	{
		public class BinaryTreeNodeWithSize<T>
		{
			public T Value;
			public BinaryTreeNodeWithSize<T> Left;
			public BinaryTreeNodeWithSize<T> Right;
			public int SubtreeSize;

			public BinaryTreeNodeWithSize(T val)
			{
				Value = val;
				Left = null;
				Right = null;
				SubtreeSize = 0;
			}
		}

		public static BinaryTreeNodeWithSize<I> FindKthNode(int k, BinaryTreeNodeWithSize<I> root)
		{
			while(root != null)
			{
				int leftSubtreeSize = (root.Left == null) ? 0 : root.Left.SubtreeSize;
				if (k == leftSubtreeSize + 1) // current node is the k-th
				{
					return root;
				}
				else if (k <= leftSubtreeSize) // kth node is in the left subtree
				{
					root = root.Left;
				}
				else //kth node is in the right subtree
				{
					k -= (leftSubtreeSize + 1);
					root = root.Right;
				}
			}

			return null; //kth node was not found
		}
	}
}
