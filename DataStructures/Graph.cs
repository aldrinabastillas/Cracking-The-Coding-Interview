using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class Graph<T>
	{
		public Dictionary<int, GraphNode<T>> nodes { get; set; }

		//constructor
		public Graph()
		{
			nodes = new Dictionary<int, GraphNode<T>>();
		}

		/// <summary>
		/// Adds a node where data is the same as the id
		/// </summary>
		public void AddNode(int id, int weight = 0)
		{
			AddNode(id, (T)Convert.ChangeType(id, typeof(T)), weight);
		}

		//default weight is 0
		public void AddNode(int id, T data, int weight = 0)
		{
			if (!nodes.ContainsKey(id))
			{
				nodes.Add(id, new GraphNode<T>(data, weight));
			}
		}
		public void AddUndirectedEdge(int parentId, int adjacentId, int weight = 0)
		{
			AddDirectedEdge(parentId, adjacentId, weight);

			//also add a back pointer from adjacent to parent
			nodes[adjacentId].AddEdge(nodes[parentId]);
		}

		public void AddDirectedEdge(int parentId, int adjacentId, int weight = 0)
		{
			if (!nodes.ContainsKey(parentId))
			{
				AddNode(parentId, weight);
			}
			if (!nodes.ContainsKey(adjacentId))
			{
				AddNode(adjacentId, weight);
			}

			//pointer from parent to adjacent
			nodes[parentId].AddEdge(nodes[adjacentId]);
		}
	}
}
