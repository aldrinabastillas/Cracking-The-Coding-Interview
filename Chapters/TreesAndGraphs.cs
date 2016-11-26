using System;
using System.Collections.Generic;
using DataStructures;

namespace CrackingTheCodingInterview
{
	public class TreesAndGraphs
	{
		public static void Run()
		{
			//Q4_5();
			//FindTreeMax();
			//FindBSTMax();
			//TreeHeight();
			LCA();
		}

		//Check if a binary tree is balanced
		//Practice this one again!
		public static void Q4_1()
		{
			var root = new TreeNode<int>(3);
			root.AddLeft(2);
			root.left.AddRight(4);
			root.left.right.AddLeft(1);

			root.AddRight(6);

			Console.WriteLine(IsBalanced(root).ToString());
		}

		private static bool IsBalanced(TreeNode<int> root)
		{
			int leftHeight = 0, rightHeight = 0;
			if (root.left != null)
			{
				leftHeight = GetHeight(root.left);
			}
			if (root.right != null)
			{
				rightHeight = GetHeight(root.right);
			}
			if (Math.Abs(leftHeight - rightHeight) <= 1)
			{
				return false;
			}
			else {
				return IsBalanced(root.right) && IsBalanced(root.left);
			}
		}

		private static int GetHeight(TreeNode<int> root)
		{
			if (root == null) { return 0; }
			else {
				return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
			}
		}

		public static void Q4_2()
		{
			HackerRankTraversals.BFSReach();
		}

		//https://www.hackerrank.com/challenges/is-binary-search-tree
		//Check if a binary tree is a binary search tree
		public static void Q4_5()
		{
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.left.AddRight(4);
			root.left.AddLeft(1);

			root.AddRight(6);

			Console.WriteLine(checkBST(root).ToString());
		}

		//just do inorder traversal
		private static int last = -1;
		private static bool checkBST(TreeNode<int> root)
		{
			if (root == null) { return true; }

			if (!checkBST(root.left)) { return false; }

			if (root.data <= last) { return false; }
			else {
				last = root.data;
			}

			if (!checkBST(root.right)) { return false; }

			return true;
		}

		//find the max element in a tree
		//not a binary search tree
		//page 129 in algo book
		public static void FindTreeMax()
		{
			Console.WriteLine("Find Tree Max");
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.left.AddRight(6);
			root.left.AddLeft(1);

			root.AddRight(4);

			Console.WriteLine("Max (Recur) is : {0}", FindTreeMax(root));
			Console.WriteLine("Max (Iter) is : {0}", FindTreeMaxIter(root));
		}

		private static int FindTreeMax(TreeNode<int> root)
		{
			int max = int.MinValue;
			if (root != null)
			{
				max = Math.Max(max, root.data);
				max = Math.Max(max, FindTreeMax(root.left));
				max = Math.Max(max, FindTreeMax(root.right));
			}
			return max;
		}

		//do it iteratively without recursion
		private static int FindTreeMaxIter(TreeNode<int> root)
		{
			int max = int.MinValue;
			var q = new Queue<TreeNode<int>>();
			q.Enqueue(root);
			while (q.Count > 0)
			{
				var node = q.Dequeue();
				max = Math.Max(max, node.data);
				if (node.left != null) { q.Enqueue(node.left); }
				if (node.right != null) { q.Enqueue(node.right); }
			}

			return max;
		}

		//find the max element in a binary search tree
		//page 161 in algo book
		public static void FindBSTMax()
		{
			Console.WriteLine("Find BST Max");
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.left.AddRight(4);
			root.left.AddLeft(1);

			root.AddRight(6);
			root.right.AddRight(8);

			Console.WriteLine("Max is (recur): {0}", FindBSTMax(root));
			Console.WriteLine("Max is (iter): {0}", FindBSTMaxIter(root));
		}

		private static int FindBSTMax(TreeNode<int> root)
		{
			int max = int.MinValue;
			if (root != null)
			{
				max = root.data;
				max = Math.Max(max, FindBSTMax(root.right));
			}
			return max;
		}

		//without recursion
		private static int FindBSTMaxIter(TreeNode<int> root)
		{
			int max = int.MinValue;
			if (root != null)
			{
				var s = new Stack<int>();
				s.Push(root.data);
				while (root.right != null)
				{
					s.Push(root.right.data);
					root = root.right; //iterate down
				}
				max = Math.Max(max, s.Pop());
			}

			return max;
		}

		//Problem 6, page 131
		public static void TreeSize()
		{
			Console.WriteLine("Get Tree Size");
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.left.AddRight(4);
			root.left.AddLeft(1);

			root.AddRight(6);
			root.right.AddRight(8);

			Console.WriteLine("Tree Size (recur): {0}", TreeSize(root));
		}

		//count number of nodes recursively
		private static int TreeSize(TreeNode<int> root)
		{
			if (root == null)
			{
				return 0;
			}
			return TreeSize(root.left) + TreeSize(root.right) + 1;
		}

		//Problem 10, page 132
		public static void TreeHeight()
		{
			Console.WriteLine("Get Tree Height");
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.AddRight(6);
			root.right.AddRight(8);
			root.right.right.AddRight(9); //height is 3
			root.right.right.right.AddRight(10); //height is 4

			Console.WriteLine("Tree Height (recur): {0}", TreeHeight(root));
		}

		private static int TreeHeight(TreeNode<int> root)
		{
			if (root == null)
			{
				return -1;
			}

			int	left = TreeHeight(root.left);
			int	right = TreeHeight(root.right);

			return Math.Max(left, right) + 1;
		}

		//https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor
		public static void LCA()
		{
			Console.WriteLine("Least Common Ancestor");
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.left.AddRight(4);
			root.left.AddLeft(1);

			root.AddRight(6);
			root.right.AddRight(8);

			Console.WriteLine("LCA: {0}", LCA(root, 1, 8));
		}

		private static int LCA(TreeNode<int> root, int a, int b)
		{
			if (a <= root.data && root.data <= b)
			{
				return root.data;
			}
			else if (a > root.data)
			{
				return LCA(root.right, a, b);
			}
			else {
				return LCA(root.left, a, b);
			}
		}

		public static void Q4_8()
		{
			//T1 is a tree with millions of nodes
			//T2 is a tree with hundreds of nodes
			//decide if T2 is a subtree of T1

			//T2 is a subtree of T1 if there is a node in T1 such that the subtree 
			//of n is identical to T2
			//Naive algorithm is to look at each node of T1 then compare to root of T2
			//and go through each node and see if equal

			//start at root of T1, then search for T2
			//return Search(t1.left, t2) || Search(t1.right, t2) 
			//now compare each node of that subtree to T2
		}

		public static void Q4_9()
		{
			//print all paths in a tree that sum to a given value
			//where a path can start/end anywhere in the tree


		}

		//private static List<int> TreeSum(List<int> list, TreeNode<int> node, int runSum, int sum){
		//	if (node == null)
		//	{
		//		return list;
		//	}
		//	if (runSum + node.data == sum)
		//	{
		//		list.Add(node.data);
		//	}
		//	else {
		//		runSum += node.data;
		//		TreeSum(list, node.left, runSum, sum);
		//		TreeSum(list, node.right, runSum, sum);
		//	}
		//	return list;
		//}
	}		
}
