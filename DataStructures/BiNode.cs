using System;

namespace DataStructures
{
	public class BiNode
	{
		public BiNode b1 { get; set; } //if BST, left node; if list, previous node 
		public BiNode b2 { get; set; } //if BST, right node; if list, next node 
		public int data { get; set; }
		public BiNode(int d)
		{
			data = d;
		}
	}
}
