using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataStructures;

namespace CrackingTheCodingInterview
{
	public class HackerRankTraversals
	{
		#region Largest Region in Grid
		//https://www.hackerrank.com/challenges/ctci-connected-cell-in-a-grid
		public static void DFSCellGrid()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-connected-cell-in-a-grid");
			//int n = Convert.ToInt32(Console.ReadLine());
			//int m = Convert.ToInt32(Console.ReadLine());
			int n = 4, m = 4;
			int[][] grid = new int[n][];
			grid[0] = Array.ConvertAll("1 1 0 0".Split(' '), Int32.Parse);
			grid[1] = Array.ConvertAll("0 1 1 0".Split(' '), Int32.Parse);
			grid[2] = Array.ConvertAll("0 0 1 0".Split(' '), Int32.Parse);
			grid[3] = Array.ConvertAll("1 0 0 0".Split(' '), Int32.Parse);

			int maxRegion = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (grid[i][j] != 0)
					{
						int[][] copy = CopyGrid(grid, n, m);
						int region = getRegion(copy, i, j, n, m);
						maxRegion = Math.Max(region, maxRegion);
					}
				}
			}
			Console.WriteLine(maxRegion);
		}

		private static int[][] CopyGrid(int[][] grid, int rows, int columns)
		{
			int[][] copy = new int[rows][];
			for (int i = 0; i < rows; i++)
			{
				int[] row = new int[columns];
				Array.Copy(grid[i], row, columns);
				copy[i] = row;
			}
			return copy;
		}

		private static int getRegion(int[][] grid, int i, int j, int n, int m)
		{
			int region = 0;
			if (i < 0 || i >= n || //check bounds
				j < 0 || j >= m ||
				grid[i][j] <= 0) //check if visited
			{
				return region;
			}

			region++; //increment path length 
			grid[i][j]--; //mark cell as visited before moving on!

			//move all directions, DFS!
			region += getRegion(grid, i, j - 1, n, m); //move west
			region += getRegion(grid, i, j + 1, n, m); //move east
			region += getRegion(grid, i + 1, j, n, m); //move north
			region += getRegion(grid, i - 1, j, n, m); //move south

			region += getRegion(grid, i + 1, j - 1, n, m); //move north west
			region += getRegion(grid, i + 1, j + 1, n, m); //move north east
			region += getRegion(grid, i - 1, j + 1, n, m); //move south east
			region += getRegion(grid, i - 1, j - 1, n, m); //move south west

			return region;
		}
		#endregion

		#region Is Binary Search Tree
		//https://www.hackerrank.com/challenges/ctci-is-binary-search-tree
		public static void BalancedTree()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-is-binary-search-tree");
			var root = new TreeNode<int>(5);
			root.AddLeft(2);
			root.left.AddLeft(1);
			root.left.AddRight(3);

			root.AddRight(6);
			root.right.AddLeft(4);
			root.right.AddRight(7);

			Console.WriteLine(checkBST(root, -1).ToString());
		}

		private static Boolean checkBST(TreeNode<int> root, int stack)
		{
			bool left = true, right = true;
			if (root.left != null)
			{
				left = checkBST(root.left, stack);
			}
			if (!left)
			{
				return false;
			}

			Console.WriteLine("Root:  " + root.data);
			if (stack >= root.data)
			{
				Console.WriteLine("False!!");
				return false;
			}
			stack = root.data;


			if (root.right != null)
			{
				right = checkBST(root.right, stack);
			}
			if (!right)
			{
				return false;
			}
			return true;
		}
		#endregion

		#region Djikstra's Algorithm
		//https://www.hackerrank.com/challenges/ctci-bfs-shortest-reach
		//https://www.hackerrank.com/domains/algorithms/graph-theory
		public static void ShortestPath()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-bfs-shortest-reach");
			//StreamReader f = new StreamReader("../input05.txt");
			int q = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < q; i++)
			{
				string[] line1 = Console.ReadLine().Split(' ');
				int nodes = Convert.ToInt32(line1[0]);
				int edges = Convert.ToInt32(line1[1]);
				var graph = new Graph<int>();

				//int nodes = 5, edges = 3;
				//int[][] edgeList = new int[edges][];
				//edgeList[0] = new int[2] { 1, 2 };
				//edgeList[1] = new int[2] { 1, 3 };
				//edgeList[2] = new int[2] { 3, 4 };

				//populate graph
				for (int j = 0; j < edges; j++)
				{
					int[] edge = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
					//	int[] edge = edgeList[j];
					graph.AddUndirectedEdge(edge[0], edge[1], 6);
				}

				//traverse graph
				int start = Convert.ToInt32(Console.ReadLine());
				StringBuilder ans = new StringBuilder();
				for (int j = 1; j <= nodes; j++)
				{
					if (j != start)
					{
						ans.Append(FindShortestRoute(graph, nodes, start, j).ToString() + " ");
					}
				}
				Console.WriteLine(ans.ToString());

			}
		}

		private static int FindShortestRoute(Graph<int> graph, int nodes, int start, int end)
		{
			var toVisit = new Queue<GraphNode<int>>();
			//var visited = new Dictionary<int, int>(); //key is id, value is path length
			var visited = new int[nodes]; //index is node number, value is path length

			if (graph.nodes.ContainsKey(start))
			{
				toVisit.Enqueue(graph.nodes[start]);
				//visited.Add(start, 0); //add root
				visited[start - 1] = 0;
			}
			else {
				return -1;
			}

			while (toVisit.Count > 0)
			{
				var parent = toVisit.Dequeue();
				if (parent.data == end) //found destination!
				{
					return visited[parent.data - 1];	//return cumulative path length
				}

				foreach (var adj in parent.adjacent)
				{
					int next = adj.data - 1;
					int length = adj.weight + visited[parent.data - 1];
					if (visited[next] == 0)
					{
						//if (!visited.ContainsKey(adj.GetData())) {
						visited[adj.data - 1] = length;
						toVisit.Enqueue(adj);
					}
					else {
						//increment path length
						//current weight + length to get to parent
						//Save the shorter one
						visited[adj.data - 1] = Math.Min(length, visited[adj.data - 1]);
					}
				}
			}
			return -1;
		}
		#endregion


		//https://www.hackerrank.com/challenges/journey-to-the-moon
		public static void Astronauts()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/journey-to-the-moon");
			string[] line1 = Console.ReadLine().Split(' ');
			//int n = Convert.ToInt32(line1[0]);
			int pairs = Convert.ToInt32(line1[1]);

			var astronauts = new Graph<int>();
			for (int i = 0; i < pairs; i++)
			{
				int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
				astronauts.AddNode(temp[0]);
				astronauts.AddNode(temp[1]);
			}
		}
	}
}
