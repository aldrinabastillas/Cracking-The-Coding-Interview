using System;
using System.Collections.Generic;
using DataStructures;

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
			Console.WriteLine("Given an integer, and an array of integer, " +
			                  "find the smallest positive missing integer.");
			int A = 6;
			int[] arr = { -2, -1, 0, 2, 5, 3 };

			////expected numbers
			//var expected = new HashSet<int>();
			//for (int i = 1; i <= A + 1; i++)
			//{
			//	expected.Add(i);
			//}

			////remove what’s actually there
			//foreach (int a in arr)
			//{
			//	expected.Remove(a);
			//}

			////get min of what’s left
			//int missing = int.MaxValue;
			//foreach (int a in expected)
			//{
			//	missing = Math.Min(a, missing);
			//}

			//more efficient, create a bool array and mark off all positive integers there
			bool[] positives = new bool[A + 1];
			foreach (int a in arr)
			{
				if (a > 0)
				{
					positives[a] = true;
				}
			}

			//return the first one that wasn't marked off
			int missing = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				if (positives[i] == false)
				{
					missing = i;
					break;
				}
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
				//odd length palindrome check.  i is the center, and surrounding letters match
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
			//keep expanding from center
			while (left >= 0 && right < s.Length && 
			       s[left] == s[right])
			{
				left--;
				right++;
				length += 2;
			}

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

			//take the square root, and then square it again.
			int msb = (int)Math.Sqrt(num);
			if (num == (int)Math.Pow(msb, 2))
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

		#region Unfair Coin
		//http://www.techinterview.org/post/3233458616/getting-a-fair-result-with-an-unfair-coin/
		public static void FairResultUnfairCoin()
		{
			UnfairCoin coin = new UnfairCoin(0.6);
		}

		//Let a and b be the results of 2 tosses of the unfair coin. (Where true is heads, false is tails).
		//Now a is true with a probability of p, a is false with a probability of(1-p) (and the same with b).

		//          | b = true | b = false
		//a = true  | p* p     | p*(1-p)
		//a = false | p*(1-p)  | (1-p)(1-p)

		//Two of these probabilities are equal/fair, a && !b, and !a && b
		static bool BetterFlip(UnfairCoin coin)
		{
			bool a = coin.Flip();
			bool b = coin.Flip();

			if (a && !b)
			{
				return true;
			}
			if(!a && b){
				return false;
			}
			//retry, one of the other 2 unfair possibilities
			return BetterFlip(coin);	        
		}
		#endregion

		#region Parse String To Int
		//http://www.techinterview.org/post/526339864/int-atoi-char-pstr/
		public static void ParseStringToInt()
		{
			Console.WriteLine("Given a string, convert it to an int");
			Console.WriteLine("Example: \"123A\" -> 123");
			string str = Console.ReadLine();
			Console.WriteLine("Parsed int: {0}", ParseStringToInt(str));

		}

		//cleaner parse function
		static int ParseStringToInt(string str)
		{
			int parsed = 0;
			int i = 0;
			while (i < str.Length && str[i] >= '0' && str[i] <= '9')
			{
				//move current value to left by multiplying by 10
				//then add (ascii value - '0' which is 48)
				parsed = (parsed * 10) + (str[i] - '0');
				i++;
			}
			return parsed;
		}

		//inefficient solution
		//cast char to int
		//assume all chars are valid ints, then if not, remove remainder
		static int ParseStringToInt_old(string str)
		{
			int parsed = 0;
			for (int i = 0; i < str.Length; i++)
			{
				int ascii = str[i];
				if (ascii < 48 || ascii > 57)
				{
					//remove 0's from end
					parsed /= (int)Math.Pow(10, str.Length - i + 1);
					return parsed;
				}
				else {
					int num = ascii - 48; // 0 is 48 in ascii;
					parsed += num * (int)Math.Pow(10, str.Length - i);
				}
			}
			return parsed;
		}
		#endregion

		//http://www.techinterview.org/post/526332105/palindromes/
		static void YearPalindrome()
		{
			// '10/02/2001' is a palindrome, find the palindrome year that last occurred

			//answer is 08/31/1380
			//09/31/1390 doesn't work because september has 30 days

			//first 2 digits of year has to be 13
			//last 2 digits of year starts at 90 to - 10
		}

		//http://www.techinterview.org/post/526329049/sum-it-up/
		// Problem: You are given a sequence of numbers from 1 to n-1 
		// with one of the numbers repeating only once. (example: 1 2 3 3 4 5). 
		// How can you find the repeating number? 
		// What if you can’t use a dynamic amount of memory)? 
		// What if there are two repeating numbers and the same memory constraint?
		public static void SumItUp()
		{
			int[] arr_one = { 1, 2, 3, 3, 4, 5 };
			int[] arr_mult = { 1, 2, 2, 3, 3, 5 };
			//Problem 1
			//idea 1: use a hash set
			//idea 2: find expected sum and the actual sum
			OneRepeat(arr_one);
			MultipleRepeat(arr_mult);
		}

		static void OneRepeat(int[] arr)
		{
			int expectedSum = 0;
			int actualSum = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				actualSum += arr[i];
				expectedSum += (i + 1);
			}

			Console.WriteLine("One missing int is: {0}", expectedSum - actualSum);
		}

		// 1 2 2 3 3 5; 
		static void MultipleRepeat(int[] arr)
		{
			int expectedSum = 0;
			int actualSum = 0;
			int duplicates = 0;
			Console.Write("Missing ints are: ");
			for (int i = 0; i < arr.Length; i++)
			{
				actualSum += arr[i];
				expectedSum += (i + 1) - duplicates;

				if (actualSum != expectedSum)
				{
					Console.Write("{0} ", arr[i]);
					//reset counters
					actualSum = expectedSum = 0;
					duplicates = 1;
				}
			}
		}
	} //end class
} //end namespace
