using System;

namespace CrackingTheCodingInterview
{
	public class CustomEvent<T> : EventArgs
	{
		public T Message { get; set; }
		public CustomEvent(T message)
		{
			Message = message;
		}
	}

	public class Publisher<T>
	{
		public event EventHandler<CustomEvent<T>> OnChange;
		public delegate void EventHandler(object publisher, CustomEvent<T> e);
		private object _aLock = new object();

		//Calling raises the OnChange event
		public void RaiseEvent(T message)
		{
			lock (_aLock)
			{
				if (OnChange != null)
				{
					OnChange(this, new CustomEvent<T>(message));
				}
			}
		}
	}

	public abstract class Subscriber<T>
	{
		public void Subscribe(Publisher<T> publisher)
		{
			publisher.OnChange += CustomAction;
		}

		public void Unsubscribe(Publisher<T> publisher)
		{
			publisher.OnChange -= CustomAction;
		}

		public abstract void CustomAction(object publisher, CustomEvent<T> e);
	}

	public class PrintSubscriber<T> : Subscriber<T>
	{
		public override void CustomAction(object publisher, CustomEvent<T> e)
		{
			Console.WriteLine("PrintSubscriber: " + e.Message);
		}
	}

	public class OtherSubscriber<T> : Subscriber<T>
	{
		public override void CustomAction(object publisher, CustomEvent<T> e)
		{
			Console.WriteLine("OtherSubscriber: " + e.Message);
		}
	}

	public class Client
	{
		public static void Run()
		{
			var pub = new Publisher<string>();

			var printSub = new PrintSubscriber<string>();
			printSub.Subscribe(pub);

			var otherSub = new OtherSubscriber<string>();
			otherSub.Subscribe(pub);

			pub.RaiseEvent("Something changed!");
		}
	}

}
