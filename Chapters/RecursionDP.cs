using System;
using System.Numerics;
namespace CrackingTheCodingInterview
{
	//Chapter 9 in CTCI
	public class RecursionDP
	{
		public static void Run()
		{
			//FibMod();
			//Q9_1();
			//Q9_2();
			//MaximumSubarrays();
			//Factorial();
			//Permutations();
			//PermAna();
			KnapsackMain();
		}

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

		//child running up n steps can hop either 1, 2, or 3 steps
		//count possible ways to run up stairs
		public static void Q9_1()
		{
			//n = 4: {3, 1}, {1, 3} , {sub answers 3, 1} , {1, sub answers 3} **7**

			//n = 3: {3}, {2, 1}, {1, 2}, {1, 1, 1} **4**

			//n = 2: {2}, {1, 1} **2**

			//n = 1: {1} **1**
			Console.WriteLine("Question 9.1");
			int n = Convert.ToInt32(Console.ReadLine());
			BigInteger[] ans = new BigInteger[n];
			for (int i = 1; i <= n; i++)
			{
				ans[i - 1] = Steps(i, ans);
			}
			Console.WriteLine(ans[n-1]);
		}

		private static BigInteger Steps(int stairs, BigInteger[] ans)
		{
			//Base Cases
			if (stairs < 0) { return 0; }
			if (stairs == 0) { return 1; }

			//Used previously cached result
			if (ans[stairs - 1] != default(BigInteger)) { return ans[stairs - 1]; }

			//Compute then cache result
			ans[stairs-1] = Steps(stairs - 1, ans) + Steps(stairs - 2, ans) + Steps(stairs - 3, ans);
			return ans[stairs - 1]; //return cached result
		}

		//number of paths to go from (0, 0) to (x, y)
		//in a grid of size x by y, if
		//robot can only move to the right and down
		public static void Q9_2()
		{
			Console.WriteLine("Question 9.2 - Robot Grid");
			string[] line1 = Console.ReadLine().Split(' ');
			int x = Convert.ToInt32(line1[0]);
			int y = Convert.ToInt32(line1[1]);
			int[,] grid = new int[x, y];

			Robot(0, 0, x, y, grid);
			int ans = grid[x-1, y-1];
			Console.WriteLine(ans);
		}

		private static void Robot(int currX, int currY, int endX, int endY, int[,] grid)
		{
			if (currX >= endX || currY >= endY)
			{
				return;
			}
			//increment current spot
			grid[currX, currY]++;
			//move right
			Robot(currX + 1, currY, endX, endY, grid);

			//move down
			Robot(currX, currY + 1, endX, endY, grid);
		}

		//given an sorted array, find magic index, where A[i] = i, if it exists
		public static void Q9_3()
		{
			Console.WriteLine("Question 9.3 - Magic Array Index");
			//int[] arr = { -1, 0, 1, 2, 4 };
			//do a modified binary search
			//new left start is Math.Min(mid value, mid index - 1);
			//new right start is Math.Max(mid value, mid index + 1);
		}

		//return all subsets of a set
		public static void Q9_4()
		{
			Console.WriteLine("Question 9.4 - Subsets");
		//	int[] arr = { 0, 1, 2, 3 };
		}

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

				if (nonContig_max < 0 && arr[i] < 0) 
				{
					nonContig_max = Math.Max(nonContig_max, arr[i]);
				}
				else if (nonContig_max < 0 && arr[i] >= 0)
				{
					nonContig_max = arr[i];
				}
				else if (nonContig_max > 0 && arr[i] > 0){
					nonContig_max += arr[i];
				}

			}

			Console.WriteLine("{0} {1}", contig_max, nonContig_max);
		}

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

		//output is all same length
		//http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
		public static void Permutations()
		{
			Console.WriteLine("Permutations");
			string s = "abc";

			Permutations(s.ToCharArray(), 0);

			//for (int i = 0; i < s.Length; i++)
			//{
				
			//	for (int j = i + 1; j <= s.Length; j++)
			//	{
			//		s = Swap(s, i, j);
			//		string substring = s.Substring(i, j);
			//		Permutations(substring.ToCharArray(), 0);
			//		s = Swap(s, i, j);
			//	}

			//}

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

		public static void KnapsackMain()
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
	}

}
