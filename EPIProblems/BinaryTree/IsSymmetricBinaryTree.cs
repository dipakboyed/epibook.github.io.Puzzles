namespace EPI.BinaryTree
{
	/// <summary>
	/// A binary tree is symmetric if the left subtree is the mirror image of the right subtree.
	/// Write a function that checks whether the given binary tree is symmetric or not
	/// </summary>
	public static class IsSymmetricBinaryTree<T>
	{
		public static bool IsBinaryTreeSymmetric(BinaryTreeNode<T> root)
		{
			return (root == null) || CheckSymmetric(root.Left, root.Right);
		}

		private static bool CheckSymmetric(BinaryTreeNode<T> left, BinaryTreeNode<T> right)
		{
			if (left == null && right == null)
			{
				return true;
			}

			return (left != null && right != null &&		// both child are not null
				left.Value.Equals(right.Value) &&			// both have same values
				CheckSymmetric(left.Left, right.Right) &&	// left and right side are symmetric
				CheckSymmetric(left.Right, right.Left));	// right and left side are symmetrics
		}
	}
}
