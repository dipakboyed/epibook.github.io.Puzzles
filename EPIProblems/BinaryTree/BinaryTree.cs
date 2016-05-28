namespace EPI.BinaryTree
{
	public class BinaryTree<T>
	{
		private BinaryTreeNode<T> root;

		public BinaryTree()
		{
			root = null;
		}

		public virtual void Clear()
		{
			root = null;
		}

		public BinaryTreeNode<T> Root
		{
			get
			{
				return root;
			}
			set
			{
				root = value;
				root.Parent = null;
			}
		}
	}
}
