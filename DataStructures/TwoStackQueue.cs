using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class TwoStackQueue<T>
	{
		private Stack<T> newestOnTop; //regular stack
		private Stack<T> oldestOnTop; //queue!

		public TwoStackQueue()
		{
			newestOnTop = new Stack<T>();
			oldestOnTop = new Stack<T>();
		}

		public void Enqueue(T obj)
		{
			newestOnTop.Push(obj);
		}

		public T Peek()
		{
			shiftStacks();
			return oldestOnTop.Peek();
		}

		public T Dequeue()
		{
			shiftStacks();
			return oldestOnTop.Pop();
		}

		private void shiftStacks()
		{
			if (oldestOnTop.Count == 0)
			{
				while (newestOnTop.Count > 0)
				{
					oldestOnTop.Push(newestOnTop.Pop());
				}
			}
		}
	}
}
