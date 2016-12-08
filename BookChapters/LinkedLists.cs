using System;
using System.Collections.Generic;
using DataStructures;

namespace CrackingTheCodingInterview
{
	public class LinkedLists
	{
		#region Remove Duplicates
		//remove duplicates from an unsorted linked list
		public static void RemoveDuplicates()
		{
			Console.WriteLine("Remove duplicates");
			var list = new Node<string>("a");
			list.Insert("b");
			list.Insert("c");
			list.Insert("a");
			list.Insert("e");

			Q2_1a(list);
			list.PrintList();

			Q2_1b(list);
			list.PrintList();
		}

		//use a hash table
		//O(n) extra space, O(n) time
		private static void Q2_1a<T>(Node<T> node)
		{
			var set = new HashSet<object>();
			set.Add(node.data);
			while (node.next != null)
			{
				bool added = set.Add(node.next.data);
				if (!added)
				{
					node.next = node.next.next;
				}
				node = node.next;
			}
		}

		//compare every node to every other node
		//O(n^2) time, no extra space
		private static void Q2_1b(Node<string> node)
		{
			Node<string> iterSlow = node;

			while (iterSlow.next != null)
			{
				Node<string> iterFast = iterSlow.next;
				if (iterFast.data == iterSlow.data) //check node you're on
				{
					iterSlow.next = iterFast.next;
					iterSlow = iterSlow.next;
					continue;
				}
				while (iterFast.next != null) //then iterate through rest
				{
					if (iterFast.next.data == iterSlow.data) //have to check next.data as we have no back pointers
					{
						iterFast.next = iterFast.next.next;
						break;
					}
					iterFast = iterFast.next;
				}
				iterSlow = iterSlow.next;
			}
		}
		#endregion

		#region Find kth to last Element
		//find kth to last element of singly linked list
		//have a slow iter and a fast iter that is k steps ahead
		//when fast gets to end, return slow
		public static void KtoLastElement()
		{
			Console.WriteLine("Find kth to last Element");
			var list = new Node<string>("a");
			list.Insert("b");
			list.Insert("c");
			list.Insert("a");
			list.Insert("e");
			Q2_2(list, 2);
			list.PrintList();
		}

		private static void Q2_2<T>(Node<T> list, int k)
		{
			Node<T> slow = list;
			Node<T> fast = list;
			for (int i = 0; i < k; i++)
			{
				fast = fast.next;
			}

			while (fast.next != null)
			{
				fast = fast.next;
				slow = slow.next;
			}
			Console.WriteLine(slow.data.ToString()); 
		}
		#endregion

		#region Delete node from middle
		public static void DeleteMiddleNode()
		{
			Console.WriteLine("Delete middle node");
			var list = new Node<string>("a");
			list.Insert("b");
			list.Insert("c");
			list.Insert("a");
			list.Insert("e");
			Q2_3(list.next.next);
			list.PrintList();
		}


		//delete a node in the middle of a singly-list, given only access to that node
		//don't worry about the fact you can't access nodes before it.
		//just copy next's data to the current node, then cut out next since it's now a duplicate
		private static void Q2_3<T>(Node<T> node)
		{
			if (node.next != null)
			{
				node.data = node.next.data;
				node.next = node.next.next;
			}
		}
		#endregion

		#region Partition List
		public static void PartitionList()
		{
			var list2 = new Node<int>(6);
			list2.Insert(4);
			list2.Insert(2);
			list2.Insert(1);
			list2.Insert(3);
			Q2_4(list2, 3);
			list2.PrintList();
		}

		//partition a linked list around a value x, such that all nodes less than x
		//come before all nodes greater than or equal to x
		private static Node<int> Q2_4(Node<int> head, int x)
		{
			Node<int> iter = head.next;
			while (iter.next != null)
			{
				if ((int)iter.next.data < x)
				{
					Node<int> temp = iter.next; //save node to cut out
					iter.next = iter.next.next; //cut out node

					temp.next = head; //put cutout node before head
					head = temp;//make the cutout node the new head
				}//don't iterate forward since cutting out already did that
				else {
					iter = iter.next; //iterate forward
				}
			}
			return head;
		}
		#endregion

		#region Add Linked Lists
		//numbers stored as linked list in reverse
		//add two numbers
		// 7->1->6 + 5->9->2 = 617+295
		public static void AddLists()
		{
			var a = new Node<int>(7);
			a.next = new Node<int>(1); 
			a.next.next = new Node<int>(6);

			var b = new Node<int>(5);
			b.next = new Node<int>(9);
			//b.next.next = new Node<int>(2);

			var c = Add(a, b);
			c.PrintList();
		}

		private static Node<int> Add(Node<int> a, Node<int> b)
		{
			var head = new Node<int>();

			Node<int> iter = head;
			int carry = 0;

			while (a != null || b != null)
			{
				int aData = 0, bData = 0;
				if (a != null)
				{
					aData = a.data;
				}
				if (b != null)
				{
					bData = b.data;
				}

				int add = aData + bData + carry;
				if (add >= 10)
				{
					carry = add / 10;
					add = add % 10;
				}
				iter.data = add;
				iter.next = new Node<int>();

				//iterate forward
				iter = iter.next;
				if (a != null)
				{
					a = a.next;
				}
				if (b != null)
				{
					b = b.next;
				}
			}


			return head;
		}
		#endregion

		#region Find Loop
		//find the node at the beginning of a circular linked list
		public static void FindLoop()
		{
			Console.WriteLine("Find loop");
			var head = new Node<char>('a');
			head.Insert('b');
			head.Insert('c');
			head.Insert('d');
			head.Insert('e');
			head.next.next.next.next.next = head.next.next; //e.next loops back to c

			Console.WriteLine(Q2_6(head));
		}

		private static T Q2_6<T>(Node<T> head)
		{
			var slow = head;
			var fast = head.next;
			while (!slow.data.Equals(fast.data))
			{
				slow = slow.next;
				fast = fast.next.next;
			}
			return slow.data;

		}
		#endregion

		#region Palindrome Check
		private static void Q2_7()
		{
			Console.WriteLine("Palindrome Check");
			var head = new Node<char>('r');
			head.Insert('a');
			head.Insert('c');
			head.Insert('e');
			head.Insert('c');
			head.Insert('a');
			head.Insert('r');
			//use fast runner stepping x2
			//and slow runner adding to stack
			//when fast gets to end, slow will be at middle
			//now pop off stack and compare to slow, which moves forward

		}
		#endregion

		#region Reverse linked list
		public static void Reverse()
		{
			Console.WriteLine("TODO: Reverse a Linked List in Place");
			var head = new Node<int>(1);
			head.Insert(2);
			head.Insert(3);
			head.Insert(4);

			Reverse(head);
			head.PrintList();
		}

		private static void Reverse<T>(Node<T> head)
		{
			var iter = head;
			while (iter != null)
			{
				
				iter = iter.next;
			}
		}
		#endregion

		#region Intersection
		/// <summary>
		/// Exercise 2.7 in 6th edition
		/// </summary>
		public static void Intersection()
		{
			Console.WriteLine("Given 2 lists determine if they intersect");
			var listA = new Node<string>("a");
			var listB = new Node<string>("a");

			var copy = new Node<string>("copy");

			listA.Insert("b");
			listA.Insert("c");
			listA.Insert(copy);
			listA.Insert("d");

			listB.Insert("b");
			listB.Insert("c");
			listB.Insert("d");
			listB.Insert(copy);
			Console.WriteLine(Intersection(listA, listB));
		}
		#endregion

		private static bool Intersection<T>(Node<T> listA, Node<T> listB)
		{
			var set = new HashSet<Node<T>>();
			var iter = listA;
			while (iter != null)
			{
				set.Add(iter);
				iter = iter.next;
			}

			iter = listB;
			while (iter != null)
			{
				if (set.Contains(iter))
				{
					return true;
				}
				iter = iter.next;
			}

			return false;
		}

	}
}


