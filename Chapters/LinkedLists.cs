using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures;

namespace CrackingTheCodingInterview
{
	public class LinkedLists
	{
		public static void Run()
		{
			//var list = new Node("a");
			//list.Insert("b");
			//list.Insert("c");
			//list.Insert("a");
			//list.Insert("e");

			//Q2_1a(list);
			//list.Print();

			//Q2_1b(list);
			//list.Print();

			//Q2_2(list, 2);
			//Q2_3(list.next.next); //only give it c
			//list.Print();

			//var list2 = new Node<int>(6);
			//list2.Insert(4);
			//list2.Insert(2);
			//list2.Insert(1);
			//list2.Insert(3);
			//Q2_4(list2, 3).Print();

			//Q2_5();
			Q2_6();

		}

		//remove duplicates from an unsorted linked list
		//use a hash table
		//O(n) extra space, O(n) time
		public static void Q2_1a(Node<int> node)
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
		public static void Q2_1b(Node<int> node)
		{
			Node<int> iterSlow = node;

			while (iterSlow.next != null)
			{
				Node<int> iterFast = iterSlow.next;
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

		//find kth to last element of singly linked list
		//have a slow iter and a fast iter that is k steps ahead
		//when fast gets to end, return slow
		public static void Q2_2(Node<int> list, int k)
		{
			Node<int> slow = list;
			Node<int> fast = list;
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

		//delete a node in the middle of a singly-list, given only access to that node
		//don't worry about the fact you can't access nodes before it.
		//just copy next's data to the current node, then cut out next since it's now a duplicate
		public static void Q2_3(Node<int> node)
		{
			if (node.next != null)
			{
				node.data = node.next.data;
				node.next = node.next.next;
			}
		}

		//partition a linked list around a value x, such that all nodes less than x
		//come before all nodes greater than or equal to x
		public static Node<int> Q2_4(Node<int> head, int x)
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

		//numbers stored as linked list in reverse
		//add two numbers
		// 7->1->6 + 5->9->2 = 617+295
		public static void Q2_5()
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

		public static Node<int> Add(Node<int> a, Node<int> b)
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

		//find the node at the beginning of a circular linked list
		public static void Q2_6()
		{
			Console.WriteLine("Find loop");
			var head = new Node<char>('a');
			head.Insert('b');
			head.Insert('c');
			head.Insert('d');
			head.Insert('e');
			head.next.next.next.next.next = head.next.next; //e.next loops back to c

			Console.WriteLine(FindLoop(head));
		}

		public static T FindLoop<T>(Node<T> head)
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

		public static void Q2_7()
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

		public static void Reverse()
		{
			Console.WriteLine("Reverse a Linked List in Place");
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

	}
}


