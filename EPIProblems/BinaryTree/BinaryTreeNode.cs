﻿namespace EPI.BinaryTree
{
	public class BinaryTreeNode<T>
	{
		private T value;
		private BinaryTreeNode<T> left;
		private BinaryTreeNode<T> right;
		private BinaryTreeNode<T> parent;

		public BinaryTreeNode(T val)
		{
			value = val;
			left = null;
			right = null;
			parent = null;
		}

		public T Value
		{
			get
			{
				return value;
			}
		}

		public BinaryTreeNode<T> Left
		{
			get
			{
				return left;
			}
			set
			{
				left = value;
				left.Parent = this;
			}
		}

		public BinaryTreeNode<T> Right
		{
			get
			{
				return right;
			}
			set
			{
				right = value;
				right.Parent = this;
			}
		}

		public BinaryTreeNode<T> Parent
		{
			get
			{
				return parent;
			}
			set
			{
				parent = value;
			}
		}
	}
}