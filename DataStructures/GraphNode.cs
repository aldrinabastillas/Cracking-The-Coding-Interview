using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class GraphNode<T>
	{
		//Properties
		public bool visited { get; set; }
		public int weight { get; set; }
		public T data { get; set; }
		public HashSet<GraphNode<T>> adjacent { get; set; }

		//Constructors
		public GraphNode(T value) : this(value, 0)
		{
		}

		public GraphNode(T value, int w)
		{
			visited = false;
			data = value;
			adjacent = new HashSet<GraphNode<T>>();
			weight = w;
		}

		//Methods
		//add node to adjacency set
		public void AddEdge(GraphNode<T> node)
		{
			adjacent.Add(node);
		}
	}
}
