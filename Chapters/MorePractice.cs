using System;
namespace CrackingTheCodingInterview
{
	public class MorePractice
	{
		public static void FizzBuzz()
		{
			for (int i = 1; i <= 100; i++)
			{
				bool printNum = true;
				if (i % 3 == 0)
				{
					Console.Write("Fizz");
					printNum = false;
				}
				if (i % 5 == 0)
				{ //don't put an else here!!
					Console.Write("Buzz");
					printNum = false;
				}
				else if (printNum)
				{
					Console.Write(i);
				}
				Console.Write(" ");
			}
		}
	}
}
