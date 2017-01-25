using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
namespace CrackingTheCodingInterview
{
	//Chapter 9 in CTCI
	public class RecursionDP
	{
		#region Fibonacci Numbers
		//https://www.hackerrank.com/challenges/fibonacci-modified
		public static void FibMod()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/fibonacci-modified");
			int[] line1 = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
			Console.WriteLine(FibModHelper(line1[0], line1[1], line1[2]));
		}

		private static BigInteger FibModHelper(int t0, int t1, int n)
		{
			//t1 = 0
			//t2 = 1
			//t3 = t1 + (t2)^2
			BigInteger back2 = t0;
			BigInteger back1 = t1;
			BigInteger ans = 0;
			if (n == 0)
			{
				return back2;
			}
			for (int i = 2; i < n; i++)
			{
				ans = back2 + BigInteger.Pow(back1, 2);
				back2 = back1;
				back1 = ans;
			}
			return ans;
		}
		#endregion

		#region Hopping Steps
		//child running up n steps can hop either 1, 2, or 3 steps
		//count possible ways to run up stairs
		public static void Steps()
		{
			//n = 4: {3, 1}, {1, 3} , {sub answers 3, 1} , {1, sub answers 3} **7**

			//n = 3: {3}, {2, 1}, {1, 2}, {1, 1, 1} **4**

			//n = 2: {2}, {1, 1} **2**

			//n = 1: {1} **1**
			Console.WriteLine("Question 9.1");
			Console.WriteLine("count possible ways to run up stairs");
			int n = Convert.ToInt32(Console.ReadLine());
			BigInteger[] ans = new BigInteger[n];

			//fill memo table
			ans[n - 1] = Q9_1(n - 1, ans);

			Console.WriteLine(ans[n-1]);
		}

		private static BigInteger Q9_1(int stairs, BigInteger[] ans)
		{
			//Base Cases
			if (stairs < 0) { return 0; }
			if (stairs == 0) { return 1; }

			//Used previously cached result
			if (ans[stairs - 1] != default(BigInteger)) { return ans[stairs - 1]; }

			//Compute then cache result
			ans[stairs-1] = Q9_1(stairs - 1, ans) + Q9_1(stairs - 2, ans) + 
				            Q9_1(stairs - 3, ans);
			return ans[stairs - 1]; //return cached result
		}
		#endregion

		#region Robot Grid
		//number of paths to go from (0, 0) to (x, y)
		//in a grid of size x by y, if
		//robot can only move to the right and down
		public static void RobotGrid()
		{
			Console.WriteLine("Question 9.2 - Robot Grid");
			string[] line1 = Console.ReadLine().Split(' ');
			int x = Convert.ToInt32(line1[0]);
			int y = Convert.ToInt32(line1[1]);
			int[,] grid = new int[x, y];

			Q9_2(0, 0, x, y, grid);
			int ans = grid[x-1, y-1];
			Console.WriteLine(ans);
		}

		private static void Q9_2(int currX, int currY, int endX, int endY, int[,] grid)
		{
			if (currX >= endX || currY >= endY)
			{
				return;
			}
			//increment current spot
			grid[currX, currY]++;
			//move right
			Q9_2(currX + 1, currY, endX, endY, grid);

			//move down
			Q9_2(currX, currY + 1, endX, endY, grid);
		}
		#endregion

		#region Magic Array Index
		//given an sorted array, find magic index, where A[i] = i, if it exists
		private static void Q9_3()
		{
			Console.WriteLine("Question 9.3 - Magic Array Index");
			//int[] arr = { -1, 0, 1, 2, 4 };
			//do a modified binary search
			//new left start is Math.Min(mid value, mid index - 1);
			//new right start is Math.Max(mid value, mid index + 1);
		}
		#endregion

		#region All Subsets of a Set
		//return all subsets of a set
		private static void Q9_4()
		{
			PowerSet();
		}
		#endregion

		#region Maximum Subarray
		//https://www.hackerrank.com/challenges/maxsubarray
		public static void MaximumSubarrays()
		{
			Console.WriteLine("Maximum Sub Array");
			int T = Convert.ToInt32(Console.ReadLine());
			for (int t = 0; t < T; t++)
			{
				//int n = Convert.ToInt32(Console.ReadLine());
				int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
				MaximumSubarrays(arr);
			}
		}

		private static void MaximumSubarrays(int[] arr)
		{
			int curr_max = arr[0];
			int contig_max = arr[0];

			int nonContig_max = arr[0];
			for (int i = 1; i < arr.Length; i++)
			{
				if (curr_max < 0) { curr_max = arr[i]; }
				else { curr_max += arr[i]; }
				contig_max = Math.Max(curr_max, contig_max);

				//both negative
				if (nonContig_max < 0 && arr[i] < 0) 
				{
					nonContig_max = Math.Max(nonContig_max, arr[i]);
				}
				//curr is positive
				else if (nonContig_max < 0 && arr[i] >= 0)
				{
					nonContig_max = arr[i];
				}
				//both positive, increment
				else if (nonContig_max > 0 && arr[i] > 0){
					nonContig_max += arr[i];
				}

			}

			Console.WriteLine("{0} {1}", contig_max, nonContig_max);
		}
		#endregion

		#region Factorial
		//non recursive
		public static void Factorial()
		{
			Console.WriteLine("Factorial");
			int x = 5;
			int fact = 1;
			for (int i = x; i > 1; i--)
			{
				fact *= i;
			}
			Console.WriteLine(fact);
		}
		#endregion

		#region Permutations
		//output is all same length
		//http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
		public static void Permutations()
		{
			Console.WriteLine("Permutations");
			Console.Write("Enter a string: ");
			string s = Console.ReadLine();

			Permutations(s.ToCharArray(), 0);
		}

		private static void Permutations(char[] s, int start)
		{
			if (start == s.Length)
			{
				Console.WriteLine(s);
			}
			else {
				for (int i = start; i < s.Length; i++)
				{
					s = Swap(s, start, i);
					Permutations(s, start + 1);
					s = Swap(s, start, i);
				}
			}
		}

		private static string Swap(string s, int a, int b)
		{
			char[] c = s.ToCharArray();
			c = Swap(c, a, b);
			return string.Join("", c);
		}

		private static char[] Swap(char[] s, int a, int b)
		{
			char temp = s[a];
			s[a] = s[b];
			s[b] = temp;
			return s;
		}

		//page 352 in Algorithms book
		//public static void PermAna()
		//{
		//	Console.WriteLine("Perm Ana");
		//	string s = "abcd";
		//	PermAna(s.ToCharArray(), 0, 1);
		//}

		//private static void PermAna(char[] orig, int start, int end)
		//{
		//	for (int i = start; i < end; i++)
		//	{
		//		Console.Write(orig[i]);
		//	}
		//	Console.WriteLine();
		//	for (int i = 1; i < orig.Length; i++)
		//	{

		//		orig = Swap(orig, start, i);
		//		PermAna(orig, start, i);
		//		orig = Swap(orig, start, i); //backtrack
		//	}
		//}
		#endregion

		#region Knapsack
		public static void KnapsackProblem()
		{
			int T = Convert.ToInt32(Console.ReadLine());
			for (int t = 0; t < T; t++)
			{
				Console.WriteLine(Knapsack());
			}
		}

		private static int Knapsack()
		{
			string[] line1 = Console.ReadLine().Split(' ');
			int n = Convert.ToInt32(line1[0]);
			int k = Convert.ToInt32(line1[1]);
			int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

			int mult = GreedyMultiple(k, n, A);
			return mult;
		}

		private static int GreedyMultiple(int k, int n, int[] A)
		{
			int[] memo = new int[n + 1];
			for (int i = 1; i <= n; i++)
			{
				memo[i] = memo[i - 1];
				while (memo[i] + A[i - 1] <= k)
				{
					memo[i] += A[i - 1];
				}
				if (memo[i] > k)
				{
					return 0;
				}
				if (memo[i] == k)
				{
					return memo[i];
				}
			}
			return memo[n];
		}

		private static int GreedyOne(int k, int n, int[] A)
		{
			int[] memo = new int[n + 1];
			for (int i = 1; i <= n; i++)
			{
				memo[i] = memo[i - 1];
				if (memo[i] > k)
				{
					return 0;
				}
				if (memo[i] == k)
				{
					return memo[i];
				}
			}
			return memo[n];
		}
		#endregion

		#region Recursive Multiply
		/// <summary>
		/// Exercise 8.5 in 6th edition
		/// </summary>
		public static void RecursiveMultiply()
		{
			Console.WriteLine("Recursively multiply two positive integers only using +, -, and bit shifts");

			Console.Write("Enter a: ");
			int a = 0;
			while (!Int32.TryParse(Console.ReadLine(), out a)){
				Console.Write("Invalid value, enter a: ");	
			}

			Console.Write("Enter b: ");
			int b = 0;
			while (!Int32.TryParse(Console.ReadLine(), out b))
			{
				Console.Write("Invalid value, enter b: ");
			}

			Console.WriteLine("Recursive: " + RecurisveMultiply(a, b));
			Console.WriteLine("Test: " + (a * b));

		}

		private static int RecurisveMultiply(int a, int b)
		{
			//11 x 10
			int max = Math.Max(a, b);
			int min = Math.Min(a, b);
			//base cases;
			if (min == 1)
			{
				return max; 
			}
			else if (min == 0)
			{
				return 0;
			}

			// Example:
			// For the smaller number, decompose into all the 1 bits
			// thus 10 = 1000 + 10 = 8 + 2.
			// Now (max * 8) + (max * 2), where
			// max * 8 == max << 3
			string minBits = Convert.ToString(min, 2); //get binary representation
			//3
			int shift = minBits.Length - 1; //position of MSB
			// 10 - 2^3 = 10-8 = 2
			int remaining = min - (int)Math.Pow(shift, 2);

			//11 << 3 == 11*2^3 = 11*8
			int shifted = max << shift;

			//88 + RecursiveMultiply(11, 2) = 11*10 = (11*8) + (11*2)
			return shifted + RecurisveMultiply(max, remaining);

		}
		#endregion

		#region Power Set
		/// <summary>
		/// Exercise 8.4 in 6th edition
		/// </summary>
		public static void PowerSet()
		{
			Console.WriteLine("Return all subsets of a set");
			Console.Write("Enter list of items separated by a space: ");
			string[] items = Console.ReadLine().Split(' ');

			PowerSet("", items);
			foreach (var set in sets)
			{
				Console.WriteLine(set);
			}
		}

		private static List<string> sets = new List<string>();
		private static void PowerSet(string prefix, string[] left)
		{
			int length = left.Length;
			for (int i = 0; i < length; i++)
			{
				//append string to prefix
				string set = prefix + left[i];
				sets.Add(set);

				if (length > 1)
				{
					left = Swap(left, 0, i);
					string[] newLeft = new string[length - 1];
					Array.Copy(left, 1, newLeft, 0, length - 1);
					PowerSet(set, newLeft);
					left = Swap(left, 0, i); //backtrack     
				}   
			}
		}

		private static string[] Swap(string[] set, int a, int b)
		{
			string temp = set[a];
			set[a] = set[b];
			set[b] = temp;
			return set;
		}
		#endregion

		#region Parentheses
		/// <summary>
		/// Exercise 8.9 in 6th edition
		/// </summary>
		public static void Parentheses()
		{
			Console.WriteLine("Print all valid cominbations of parentheses, given a number of pairs");
			int n = 0;
			Console.Write("Enter number of pairs: ");
			while (!Int32.TryParse(Console.ReadLine(), out n))
			{
				Console.Write("Invalid number, try again: ");
			}

			parens = new HashSet<string>[n];
			Parentheses(0);
			for (int i = 0; i < n; i++)
			{
				Console.WriteLine((i + 1) + ": " + string.Join(" ", parens[i]));
			}
		}

		private static HashSet<string>[] parens;
		private static void Parentheses(int n)
		{
			if (n == parens.Length)
			{
				return; //base case
			}

			var set = new HashSet<string>();
			if (n == 0)
			{
				set.Add("()");
			}
			else {
				foreach (var paren in parens[n - 1])
				{
					Surround(set, paren);
					Inserts(set, paren);
				}
			}

			parens[n] = set; //save
			Parentheses(n + 1); //recurse
		}

		private static void Surround(HashSet<string> set, string paren)
		{
			set.Add("(" + paren + ")");
		}

		private static void Inserts(HashSet<string> set, string paren)
		{
			for (int i = 0; i < paren.Length; i++)
			{
				string left = paren.Substring(0, i);
				string right = paren.Substring(i, paren.Length - i);
				set.Add(left + "()" + right);
			}
		}
		#endregion
	}

}
