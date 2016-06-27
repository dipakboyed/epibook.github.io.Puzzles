namespace EPI.BinaryTree
{
	/// <summary>
	/// Design an API for setting the state of nodes in a binary tree to lock or unlock.
	/// A node cannot be set to lock if any of its descendants or ancestors are in lock.
	/// Changing a node's state to lock does not change the state of any other node.
	/// Assume that each node has a Parent field.`
	/// </summary>
	public static class BinaryTreeLocking<T>
	{
		public static bool IsNodeLocked(BinaryTreeNodeWithLock<T> node)
		{
			return node.isLocked;
		}

		public static bool LockNode(BinaryTreeNodeWithLock<T> node)
		{
			if (node.noOfLockedDescendants > 0 || node.isLocked)
			{
				return false;
			}
			var current = node.Parent;
			while (current != null)
			{
				if (current.isLocked)
				{
					return false;
				}
				current = current.Parent;
			}

			node.isLocked = true;
			while (node.Parent != null)
			{
				node.Parent.noOfLockedDescendants++;
				node = node.Parent;
			}
			return true;
		}

		public static void UnlockNode(BinaryTreeNodeWithLock<T> node)
		{
			if (IsNodeLocked(node))
			{
				node.isLocked = false;
				while (node.Parent != null)
				{
					node.Parent.noOfLockedDescendants--;
					node = node.Parent;
				}
			}
		}
	}

	public class BinaryTreeNodeWithLock<U>
	{
		public int noOfLockedDescendants;
		public bool isLocked;
		private U value;
		private BinaryTreeNodeWithLock<U> left;
		private BinaryTreeNodeWithLock<U> right;
		public BinaryTreeNodeWithLock<U> Parent;

		public BinaryTreeNodeWithLock(U val)
		{
			noOfLockedDescendants = 0;
			isLocked = false;
			value = val;
			left = null;
			right = null;
			Parent = null;
		}

		public U Value
		{
			get
			{
				return value;
			}
		}

		public BinaryTreeNodeWithLock<U> Left
		{
			get
			{
				return left;
			}
			set
			{
				left = value;
				if (left != null)
				{
					left.Parent = this;
				}
			}
		}

		public BinaryTreeNodeWithLock<U> Right
		{
			get
			{
				return right;
			}
			set
			{
				right = value;
				if (right != null)
				{
					right.Parent = this;
				}
			}
		}
	}
}
