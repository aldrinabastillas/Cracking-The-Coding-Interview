using System;
using System.Collections.Generic;
namespace CrackingTheCodingInterview
{
	/// <summary>
	/// Examples from TechInterview.org
	/// </summary>
	public class TechInterview
	{
		//http://www.techinterview.org/post/3233459698/amazon-interview-question-count-negative-integers-in-matrix/
		//matrix is *presorted* for each column and row
		public static void CountMatrixNegatives()
		{
			Console.WriteLine("In a matrix where each column and row is sorted," +
							  "find the number of negative numbers in the matrix");
			var mat = new int[3, 4] { {-3, -2, -1, 1},
									  {-2, 2, 0, 4},
									  {4, 5, 7, 8} };

			int rows = mat.GetLength(0);
			int cols = mat.GetLength(1);
			int negCol = cols - 1;
			int negs = 0;
			for (int i = 0; i < rows; i++)
			{
				while (negCol >= 0 && mat[i, negCol] >= 0)
				{
					negCol--;
				}
				negs += (negCol + 1);
			}
			Console.WriteLine("{0} negative numbers", negs);
		}

		//https://codility.com/programmers/lessons/4-counting_elements/missing_integer/
		public static void MissingInteger()
		{
			Console.WriteLine("Given a number, and an array of numbers, " +
			                  "find the smallest positive missing.");
			int A = 6;
			int[] arr = { -2, -1, 0, 2, 5, 3 };

			//expected numbers
			var expected = new HashSet<int>();
			for (int i = 1; i <= A + 1; i++)
			{
				expected.Add(i);
			}

			//remove what’s actually there
			foreach (int a in arr)
			{
				expected.Remove(a);
			}

			//get min of what’s left
			int missing = int.MaxValue;
			foreach (int a in expected)
			{
				missing = Math.Min(a, missing);
			}

			Console.WriteLine(missing);
		}
		//http://www.techinterview.org/post/3233459618/find-longest-palindrome-in-a-string/
		public static void LongestPalindrome()
		{
			Console.WriteLine("Find the length of the longest palindrome in a string.");
			Console.Write("Enter a string: ");
			string s = Console.ReadLine();
			int maxLength = 0;
			for (int i = 0; i < s.Length - 1; i++)
			{
				int length = 0;
				//even length palindrome check
				if (s[i] == s[i + 1])
				{
					length = PalindromeCheck(s, i, i + 1);
					maxLength = Math.Max(length, maxLength);

				}
				if (i > 1 && s[i - 1] == s[i + 1])
				{
					length = PalindromeCheck(s, i - 1, i + 1);
					maxLength = Math.Max(length, maxLength);
				}
			}
			Console.WriteLine(maxLength);
		}

		private static int PalindromeCheck(string s, int left, int right)
		{
			int length = 0;
			if (right - left == 2)
			{
				length++; //add an extra for odd length palindromes
			}
			while (left >= 0 && right < s.Length && 
			       s[left] == s[right])
			{
				left--;
				right++;
				length += 2;
			}

			//for (int i = left + 1; i < right; i++)
			//{
			//	Console.Write(s[i]);
			//}
			//Console.WriteLine();

			return length;
		}

		//http://www.techinterview.org/post/3233459629/check-if-a-number-is-power-of-two/
		public static void PowerOfTwo()
		{
			int num = 0;
			Console.WriteLine("Check if a number is a power of 2");
			Console.Write("Enter a number: ");
			while (!int.TryParse(Console.ReadLine(), out num))
			{
				Console.Write("Invalid number, try again: ");
			}

			int msb = (int)Math.Sqrt(num);
			if (num - (int)Math.Pow(msb, 2) == 0)
			{
				Console.WriteLine("{0} is a power of two", num);
			}
			else {
				Console.WriteLine("{0} is not a power of two", num);
			}
		}
		//http://www.techinterview.org/post/3233459633/sum-up-a-pair-in-array/
		public static void PairSum()
		{
			int target = 7;
			int[] nums = { 1, 0, 2, 5, 3, 7 };
			var compliments = new HashSet<int>();
			foreach (int n in nums)
			{
				if (compliments.Contains(target - n))
				{
					Console.WriteLine("({0}, {1})", n, target - n);
				}
				compliments.Add(n);
			}

		}

		//http://www.techinterview.org/post/3233459129/building-a-stack-with-a-getmax-function/
		public static void GetStackMax()
		{
			Console.WriteLine("Implement a stack that keeps track of the max element");
			Console.WriteLine("Enter a number to add to stack, q to quit, or p to Pop()");
			int num = 0;
			string line = Console.ReadLine();
			var stack = new Stack<int>();
			var max = new Stack<int>();
			while (line != "q")
			{
				if (line == "p" && stack.Count > 0)
				{
					int popped = stack.Pop();
					Console.WriteLine("\tPopped {0}", popped);
					if (popped == max.Peek())
					{
						max.Pop();
					}
					Console.WriteLine("\tMax is {0}", max.Peek());
				}
				else if (!int.TryParse(line, out num))
				{
					Console.Write("Invalid number, try again: ");
				}
				else {
					stack.Push(num);
					if (max.Count == 0 || max.Peek() <= num)
					{
						max.Push(num);
					}
					Console.WriteLine("\tMax is {0}", max.Peek());
				}
				Console.Write("enter: ");
				line = Console.ReadLine();
			}
		}

		//http://www.techinterview.org/post/3233458616/getting-a-fair-result-with-an-unfair-coin/

		//http://www.techinterview.org/post/526339864/int-atoi-char-pstr/

		//http://www.techinterview.org/post/526332105/palindromes/

		//http://www.techinterview.org/post/526329049/sum-it-up/

	} //end class
} //end namespace
