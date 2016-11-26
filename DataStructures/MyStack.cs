using System;

namespace DataStructures
{
	public class MyStack<T>
	{
		private Node<T> top;

		public MyStack(params T[] values)
		{
			foreach (T o in values)
			{
				this.Push(o);
			}
		}

		public T Pop()
		{
			if (top != null)
			{
				T data = top.data;
				top = top.next;
				return data;
			}
			return default(T);
		}

		public T Peek()
		{
			return top.data;
		}

		public void Push(T data)
		{
			Node<T> t = new Node<T>(data);
			t.next = top;
			top = t;
		}

		public bool IsEmpty()
		{
			return top == null;
		}

		public void PrintStack()
		{
			if (top != null)
			{
				top.PrintList();
			}
			else {
				Console.WriteLine("<empty>");
			}
		}
	}
}
