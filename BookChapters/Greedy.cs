using System;
namespace CrackingTheCodingInterview
{
	public class Greedy
	{
		//https://www.hackerrank.com/challenges/two-arrays
		public static void TwoArrays()
		{
			int q = Convert.ToInt32(Console.ReadLine());
			for (int x = 0; x < q; x++)
			{
				string[] line1 = Console.ReadLine().Split(' ');
				int size = Convert.ToInt32(line1[0]);
				int k = Convert.ToInt32(line1[1]);

				int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
				int[] B = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

				if (TwoArraysHelper(A, B, size, k))
				{
					Console.WriteLine("YES");
				}
				else {
					Console.WriteLine("NO");
				}

			}
		}

		private static bool TwoArraysHelper(int[] A, int[] B, int size, int k)
		{
			Array.Sort(A);
			Array.Sort(B);

			for (int i = 0, j = size - 1; i < size; i++, j--)
			{
				if (A[i] + B[j] < k)
				{
					return false;
				}
			}
			return true;
		}

		public static void PriyankaToys()
		{
			int n = Convert.ToInt32(Console.ReadLine());
			int[] w = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
			Array.Sort(w);

			int max = 0;
			for (int i = 0; i < n-1; i++)
			{
				int j = i + 1;
				while (j < n && w[j] <= w[i] + 4)
				{
					j++;
				}
				max = Math.Max(max, j - i - 1);
			}

			Console.WriteLine(n - max);
		}

	}
}