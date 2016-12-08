using System;
namespace DataStructures
{
	public class Node<T>
	{
		#region Public Properties
		public Node<T> next { get; set; }
		public T data { get; set; }
		#endregion

		#region Constructors
		public Node(T d)
		{
			data = d;
		}

		public Node()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// Insert data to a new node at the end of the list.
		/// </summary>
		/// <param name="data">Data to insert</param>
		public void Insert(T data)
		{
			Insert(new Node<T>(data));
		}

		/// <summary>
		/// Inserts a given node to the end of the list
		/// </summary>
		/// <param name="node">Node.</param>
		public void Insert(Node<T> newNode)
		{
			Node<T> iter = this;
			while (iter.next != null)
			{
				iter = iter.next;
			}
			iter.next = newNode;
		}

		/// <summary>
		/// Prints data for all nodes in list separated by a space.
		/// </summary>
		public void PrintList()
		{
			Node<T> iter = this;
			do
			{
				Console.Write(iter.data.ToString() + " ");
				iter = iter.next;
			}
			while (iter != null);
			Console.WriteLine();
		}
		#endregion
	}

}
