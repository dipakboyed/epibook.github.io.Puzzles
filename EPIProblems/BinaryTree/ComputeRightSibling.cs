namespace EPI.BinaryTree
{
    public class BinaryTreeNodeWithNext<U>
	{
		public BinaryTreeNodeWithNext<U> Next;
		public BinaryTreeNodeWithNext<U> Left;
		public BinaryTreeNodeWithNext<U> Right;
		public U Val;
		public BinaryTreeNodeWithNext(U value)
		{
			Val = value;
			Left = null;
			Right = null;
			Next = null;
		}
	}

	/// <summary>
	/// Write a function that takes a perfect binary tree and sets each node's next field to the
	/// node on its right, if one exists
	/// </summary>
	public static class ComputeRightSibling<T>
	{
		public static void SetRightSibling(BinaryTreeNodeWithNext<T> root)
		{
			while (root != null)
			{
				SetNextFieldInChildren(root);
				root = root.Left;
			}
		}

		private static void SetNextFieldInChildren(BinaryTreeNodeWithNext<T> node)
		{
			while (node != null && node.Left != null)
			{
				node.Left.Next = node.Right;
				if (node.Next != null)
				{
					node.Right.Next = node.Next.Left;
				}
				node = node.Next;
			}
		}
	}
}
