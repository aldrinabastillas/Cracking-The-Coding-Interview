using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class Graph
	{
		public Dictionary<int, GraphNode<int>> graph { get; set; }

		//constructor
		public Graph()
		{
			graph = new Dictionary<int, GraphNode<int>>();
		}

		//default weight is 0
		public void AddNode(int id, int weight = 0)
		{
			if (!graph.ContainsKey(id))
			{
				graph.Add(id, new GraphNode<int>(id, weight));
			}
		}
		public void AddUndirectedEdge(int parentId, int adjacentId, int weight = 0)
		{
			AddDirectedEdge(parentId, adjacentId, weight);

			//also add a back pointer from adjacent to parent
			graph[adjacentId].AddEdge(graph[parentId]);
		}

		public void AddDirectedEdge(int parentId, int adjacentId, int weight = 0)
		{
			if (!graph.ContainsKey(parentId))
			{
				AddNode(parentId, weight);
			}
			if (!graph.ContainsKey(adjacentId))
			{
				AddNode(adjacentId, weight);
			}

			//pointer from parent to adjacent
			graph[parentId].AddEdge(graph[adjacentId]);
		}
	}
}
