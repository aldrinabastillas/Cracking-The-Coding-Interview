namespace DataStructures
{
	public class BiNode
	{
		public BiNode B1 { get; set; } //if BST, left node; if list, previous node 
		public BiNode B2 { get; set; } //if BST, right node; if list, next node 
		public int Data { get; set; }
		public BiNode(int d)
		{
			Data = d;
		}
	}
}
