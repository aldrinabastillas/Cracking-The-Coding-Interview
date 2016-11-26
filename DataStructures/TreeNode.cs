using System;
namespace DataStructures
{
	internal class TreeNode<T>
	{
		public T data { get; set; }
		public TreeNode<T> left { get; set; }
		public TreeNode<T> right { get; set; }

		public TreeNode(T obj)
		{
			data = obj;
		}

		public void AddLeft(T obj)
		{
			left = new TreeNode<T>(obj);
		}

		public void AddRight(T obj)
		{
			right = new TreeNode<T>(obj);
		}
	}
}
