using System;
using System.Collections.Generic;
using DataStructures;

namespace CrackingTheCodingInterview
{
	//https://www.interviewcake.com/all-questions/python
	public class InterviewCake
	{
		#region Stocks
		//https://www.interviewcake.com/question/python/stock-price
		public static void Stocks()
		{
			Console.WriteLine("Given a list of prices, find the maximum profit");
			//int[] prices = { 100, 10, 80, 75 };
			//int[] prices = { 100, 90, 80, 70 };
			int[] prices = { 70, 80, 90, 100 };
			Console.WriteLine(string.Join(" ", prices));

			//keep running track of min stock, and max profit
			int min = prices[0];
			int profit = int.MinValue;
			for (int i = 1; i < prices.Length; i++)
			{
				profit = Math.Max(profit, prices[i] - min);
				min = Math.Min(min, prices[i]);
			}
			Console.WriteLine("Max profit is: {0}", profit);
		}
		#endregion

		#region Product of Other Numbers
		//https://www.interviewcake.com/question/python/product-of-other-numbers
		public static void ProductOtherNumbers()
		{
			Console.WriteLine("For each element, find the product of all other element except at that index");
			//int[] arr = { 1, 2, 6, 5, 9 };
			int[] arr = { 2, 4, 10 };
			Console.WriteLine("start array: {0}", string.Join(" ", arr));

			int[] answers = new int[arr.Length];

			answers[0] = 1; //initialize to 1, or else product will end up 0
			int product = 1;
			//forwards
			for (int i = 0; i < arr.Length - 1; i++)
			{
				product *= arr[i];
				answers[i + 1] = product;
			}

			//Console.WriteLine("answer array: {0}", string.Join(" ", answers));

			//backwards
			product = 1; //reset running product
			for (int i = arr.Length - 1; i > 0; i--)
			{
				product *= arr[i];
				answers[i - 1] *= product;
			}
			Console.WriteLine("answer array: {0}", string.Join(" ", answers));
		}
		#endregion

		#region Highest Product of Three
		//https://www.interviewcake.com/question/python/highest-product-of-3
		public static void HighestProductOfThree()
		{
			Console.WriteLine("Find the largest product using any 3 elements in an array");
			int[] arr = { -1, -100, -2, 0, 2, 6, 7 };

			int highest_prod_3 = arr[0] * arr[1] * arr[2];
			int highest_prod_2 = arr[0] * arr[1];
			int lowest_prod_2 = arr[0] * arr[1];
			int min = Math.Min(arr[0], arr[1]);
			int max = Math.Max(arr[0], arr[1]);

			for (int i = 2; i < arr.Length; i++)
			{
				highest_prod_3 = Math.Max(highest_prod_3,
								 Math.Max(highest_prod_2 * arr[i], lowest_prod_2 * arr[i]));

				highest_prod_2 = Math.Max(highest_prod_2, 
		                         Math.Max(max * arr[i], min * arr[i]));

				lowest_prod_2 = Math.Min(lowest_prod_2,
								Math.Min(max * arr[i], min * arr[i]));

				min = Math.Min(min, arr[i]);
				max = Math.Max(max, arr[i]);

			}

			Console.WriteLine("higest_prod_3: " + highest_prod_3);
			Console.WriteLine("higest_prod_2: " + highest_prod_2);
			Console.WriteLine("lowest_prod_2:" + lowest_prod_2);
			Console.WriteLine("min: " + min);
			Console.WriteLine("max: " + max);
		}
		#endregion

		#region Merge Meeting Ranges
		//https://www.interviewcake.com/question/python/merging-ranges
		public static void MergeMeetings()
		{
			Console.WriteLine("Given a list of start/end time pairs, condense the list");
			var meetings = new List<Meeting>();
			meetings.Add(new Meeting(0, 1));
			meetings.Add(new Meeting(3, 5));
			meetings.Add(new Meeting(4, 8));
			meetings.Add(new Meeting(10, 12));
			meetings.Add(new Meeting(9, 15));

			Meeting[] sorted = meetings.ToArray();
			Array.Sort(sorted, new MeetingComparer());

			var squash = new List<Meeting>();
			int min = sorted[0].start;
			int max = sorted[0].end;
			for (int i = 1; i < sorted.Length; i++)
			{
				if(sorted[i].start <= max) {
					min = Math.Min(min, sorted[i].start);
					max = Math.Max(max, sorted[i].end);
				}
				//if next meeting time is after last, or last meeting in list
				if (sorted[i].start > max || i == sorted.Length - 1)
				{
					//start new list
					squash.Add(new Meeting(min, max));
					min = sorted[i].start;
					max = sorted[i].end;
				}
			}

			foreach (var s in squash)
			{
				Console.WriteLine("({0}, {1})", s.start, s.end);
			}
		}
		#endregion

		#region Making Change
		//https://www.interviewcake.com/question/python/coin
		public static void MakingChange()
		{
			Console.Write("Enter an amount: ");
			int amount = 0;
			while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
			{
				Console.Write("Invalid input, try again: ");
			}

			var coins = new int[]{ 25, 10, 5, 1 };
			var memo = new int[amount + 1, coins.Length + 1];
			int ways = MakingChange(amount, coins, 0, memo);
			Console.WriteLine("{0} ways to make {1}", ways, amount);
		}

		/// <summary>
		/// Recursive/memoized way to making change.
		/// </summary>
		/// <returns>The change.</returns>
		/// <param name="amount">Amount.</param>
		/// <param name="coins">Coins.</param>
		/// <param name="index">Index.</param>
		/// <param name="memo">Memo.</param>
		static int MakingChange(int amount, int[] coins, int index, int[,] memo)
		{
			//check memo table for answer
			if (memo[amount, index] > 0)
			{
				return memo[amount, index];
			}

			if (index >= coins.Length - 1)
			{
				return 1; //last coin
			}
			int ways = 0;
			int coin = coins[index];
			for (int i = 0; i * coin <= amount; i++)
			{
				int amountRemaining = amount - (i * coin);
				ways += MakingChange(amountRemaining, coins, index + 1, memo);
			}
			memo[amount, index] = ways; //save in memo table!
										//building up ways as we go down list of coins
										//only care about the last number in the bottom right corner of memo

			return ways;
		}
		#endregion

	}//end class
}//end namespace
