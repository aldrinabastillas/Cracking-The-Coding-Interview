using System;
using System.Collections.Generic;
namespace DataStructures
{
	internal class RandomTree<T>
	{
		public List<T> nodes { get; set; }
		public TreeNode<T> root { get; set; }
		private Random rand {get; set;}

		public RandomTree(T data)
		{
			root = new TreeNode<T>(data);
			nodes = new List<T>();
			nodes.Add(data);
			rand = new Random();
		}

		public void Insert(T data)
		{
			if (root == null)
			{
				root = new TreeNode<T>(data);
				return;
			}
			else {
				Insert(root, data);
			}

		}

		/// <summary>
		/// Fills left subtree
		/// </summary>
		/// <param name="root">Root.</param>
		/// <param name="data">Data.</param>
		private void Insert(TreeNode<T> root, T data)
		{
			if (root.left == null)
			{
				root.left = new TreeNode<T>(data);
				nodes.Add(data);
				return;
			}
			else if (root.right == null)
			{
				root.right = new TreeNode<T>(data);
				nodes.Add(data);
				return;
			}
			else {
				Insert(root.left, data); //move left
			}

		}

		/// <summary>
		/// Returns a random node
		/// </summary>
		/// <returns>The node.</returns>
		public T RandomNode()
		{
			int index = rand.Next(0, nodes.Count + 1);
			return nodes[index];
		}
	}
}
