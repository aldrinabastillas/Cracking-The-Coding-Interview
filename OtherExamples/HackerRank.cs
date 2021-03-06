﻿using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
using TextMethods;

namespace CrackingTheCodingInterview
{
    public class HackerRank
	{
		public static void ArrayRotation()
		{
			Console.WriteLine("Array Rotation");
			string[] tokens_n = Console.ReadLine().Split(' ');
			int n = Convert.ToInt32(tokens_n[0]); //length
			int k = Convert.ToInt32(tokens_n[1]); //left shift
			string[] a_temp = Console.ReadLine().Split(' ');
			int[] a = Array.ConvertAll(a_temp, Int32.Parse);
			int[] b = new int[n]; //shift array;

			int right = n - k;
			for (int i = 0; i < n; i++)
			{
				int target = (i + right) % n;
				b[target] = a[i];
			}
			foreach (int i in b)
			{
				Console.Write(i.ToString() + ' ');
			}
		}

		//https://www.hackerrank.com/challenges/making-anagrams
		public static void Anagrams()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/making-anagrams");
			string a = Console.ReadLine();
			string b = Console.ReadLine();
			//create a char[256]
			//loop through a and increment counts
			//loop through b and decrement counts
			//return count != 0
			int count = 0;
			int[] chars = new int[256];
			foreach (char c in a)
			{
				chars[(int)c]++;
			}
			foreach (char c in b)
			{
				chars[(int)c]--;
			}
			foreach (int i in chars)
			{
				if (i != 0)
				{
					count += (int)Math.Abs(i); //watch out for this line!!
				}
			}
			Console.WriteLine(count);
		}

		#region Balanced Brackets
		//https://www.hackerrank.com/challenges/ctci-balanced-brackets
		public static void BalancedBrackets()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-balanced-brackets");
			var expressions = new List<string>();
			expressions.Add("}][}}(}][))]"); //no
			expressions.Add("[](){()}"); //yes
			expressions.Add("()"); //yes
			expressions.Add("([]{})"); //yes
			expressions.Add("({}([][]))[]()"); //yes
			expressions.Add(")[](}]}]}))}(())("); //no

			foreach (string expression in expressions)
			{
				if (IsBalanced(expression))
				{
					Console.WriteLine("YES");
				}
				else {
					Console.WriteLine("NO");
				}
			}
		}

		private static bool IsBalanced(string expression)
		{
			if (expression.Length % 2 != 0)
			{
				return false;
			}

			var right = new Stack<char>();
			foreach (char c in expression)
			{
				if (c == '{') right.Push('}');
				else if (c == '(') right.Push(')');
				else if (c == '[') right.Push(']');
				else {
					if (right.Count == 0 || c != right.Pop())
					{
						return false;
					}
				}
			}
			return right.Count == 0; //if we got this far, should be empty
		}
		#endregion

		//https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks
		public static void TwoStackQueue()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks");
			int q = Convert.ToInt32(Console.ReadLine());
			var queue = new TwoStackQueue<int>();

			for (int i = 0; i < q; i++)
			{
				string[] line = Console.ReadLine().Split(' ');
				int[] action = Array.ConvertAll(line, Int32.Parse);

				switch (action[0])
				{
					//Enqueue element x into the end of the queue
					case 1: {
						queue.Enqueue(action[1]);	
						break;
					}
					//Dequeue the element at the front of the queue
					case 2: {
						queue.Dequeue();
						break;
					}
					//Print the element at the front of the queue
					case 3: {
						Console.WriteLine(queue.Peek().ToString());
						break;
					}
					default:
						break;
				}
			}
		}

		#region Count Inversions
		//https://www.hackerrank.com/challenges/ctci-merge-sort
		public static void CountInversions()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-merge-sort");
			int[] arr = new int[] { 2, 1, 3, 200, 100 };
			int[] temp = new int[arr.Length];
			Array.Copy(arr, temp, arr.Length);

			int inversions = mergesort(arr, temp, 0, arr.Length - 1, 0);

			foreach (int i in temp)
			{
				Console.Write(i.ToString() + " ");
			}
			Console.WriteLine("Total Inversions: " + inversions);
		}

		private static int mergesort(int[] array, int[] temp, int leftStart, int rightEnd, int inversions)
		{
			if (leftStart >= rightEnd)
			{
				return inversions;
			}
			int mid = (leftStart + rightEnd) / 2;
			int inversionsLeft = mergesort(array, temp, leftStart, mid, inversions);
			int inversionsRight = mergesort(array, temp, mid + 1, rightEnd, inversionsLeft);
			return mergeHalvesCountInversions(array, temp, leftStart, 
			                                  rightEnd, inversionsLeft + inversionsRight);
		}

		private static int mergeHalvesCountInversions(int[] array, int[] temp, int leftStart, 
		                                             int rightEnd, int inversions)
		{
			int leftEnd = (leftStart + rightEnd) / 2;
			int rightStart = leftEnd + 1;
			int size = rightEnd - leftStart + 1;

			int leftIndex = leftStart;
			int rightIndex = rightStart;
			int i = leftStart;

			while (leftIndex <= leftEnd && rightIndex <= rightEnd) //keep going until bounds are reached
			{
				if (array[leftIndex] < array[rightEnd])
				{
					temp[i] = array[leftIndex];
					//inversions += leftIndex - i;
					leftIndex++;
				}
				else {
					temp[i] = array[rightIndex];
					inversions += (leftEnd - i + 1);
					Console.WriteLine("Inversions: " + inversions);
					rightIndex++;
				}
				i++;
			}

			Array.Copy(array, rightIndex, temp, i, rightEnd - rightIndex + 1);
			Array.Copy(array, leftIndex, temp, i, leftEnd - leftIndex + 1);
			Array.Copy(temp, leftStart, array, leftStart, size);

			return inversions;
		}
		#endregion

		//https://www.hackerrank.com/challenges/ctci-ransom-note
		public static void RansomNote()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/ctci-ransom-note");
			//int m = 6; //# of words in magazine
			//int n = 4; //# of words in ransom note
			string line1 = "give me one grand today night night";
			string line2 = "give one grand today today";
			string[] magazine = line1.Split(' ');
			string[] ransom = line2.Split(' ');

			var words = new Dictionary<string, int>();
			foreach (string word in magazine)
			{
				if (!words.ContainsKey(word))
				{
					words.Add(word, 1);
				}
				else {
					words[word]++;
				}
			}
			foreach (string word in ransom)
			{
				if (!words.ContainsKey(word) || words[word] == 0)
				{
					Console.WriteLine("No");
					return;
				}
				else { //key exists and decrement counter
					words[word]--;
				}
			}
			Console.WriteLine("Yes");
		}

		public static void BubbleSort()
		{
			Console.WriteLine("Bubble Sort");
			//int n = Convert.ToInt32(Console.ReadLine());
			string[] a_temp = "3 2 1".Split(' ');
			int n = a_temp.Length;
			int[] a = Array.ConvertAll(a_temp, Int32.Parse);

			int numSwaps = 0;
			for (int i = 0; i < n; i++)
			{
				int numOfPassSwaps = 0;
				for (int j = 0; j < n - 1; j++)
				{
					if (a[j] > a[j + 1])
					{
						int temp = a[j];
						a[j] = a[j + 1];
						a[j + 1] = temp;
						numOfPassSwaps++;
					}
				}
				numSwaps += numOfPassSwaps;
				//if no elements were swapped, array is sorted
				if (numOfPassSwaps == 0)
				{
					break;
				}
			}

			Console.WriteLine("Array is sorted in {0} swaps.", numSwaps);
			Console.WriteLine("First Element: " + a[0]);
			Console.WriteLine("Last Element: " + a[n - 1]);
		}

		#region SumHalves
		public static void SumHalves()
		{
			Console.WriteLine("Find index where both halves' sums are equal");
			string[] line1 = "1 2 3 3".Split(' ');
			int[] arr = Array.ConvertAll(line1, Int32.Parse);

			Console.WriteLine(BinarySearchSum(arr, 0, arr.Length - 1));
		}

		private static int BinarySearchSum(int[] arr, int low, int high)
		{
			if (low > high)
			{ //ran past each other
				return 0; //not found
			}

			int mid = (low + high) / 2;
			int sumLeft = SumHalf(arr, 0, mid - 1);
			if (sumLeft == arr[mid])
			{
				int sumRight = SumHalf(arr, mid + 1, arr.Length - 1);
				if (sumRight == arr[mid])
				{
					return mid; //sum of both halves == mid  
				}
			}
			if (arr[mid] < sumLeft)
			{ //search on left side
				return BinarySearchSum(arr, low, mid - 1);
			}
			else { //search on right
				return BinarySearchSum(arr, mid + 1, high);
			}
		}

		private static int SumHalf(int[] arr, int low, int high)
		{
			int sum = 0;
			for (int i = low; i <= high; i++)
			{
				sum += arr[i];
			}
			return sum;
		}
		#endregion

		//https://www.hackerrank.com/challenges/sherlock-and-array
		public static void SherlockAndArray()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/sherlock-and-array");
			int[] arr = new int[4] { 1, 2, 3, 3 };
			int left = 0;
			int right = arr.Length - 1;

			int leftSum = arr[left], rightSum = arr[right];
			while (right - left > 2)
			{
				if (leftSum < rightSum)
				{
					left++;
					leftSum += arr[left];
				}
				else {
					right--;
					rightSum += arr[right];
				}
			}

			if (leftSum == rightSum)
			{
				Console.WriteLine("YES");
			}
			else {
				Console.WriteLine("NO");
			}
		}

		//https://www.hackerrank.com/challenges/missing-numbers
		public static void MissingNumbers()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/missing-numbers");
			int[] A = new int[3] { 1, 2, 3 };
			int[] B = new int[6] { 1, 2, 4, 3, 3, 4 };
			var counts = new Dictionary<int, int>();
			var ans = new HashSet<int>();
			foreach (int a in A)
			{
				if (!counts.ContainsKey(a))
				{
					counts.Add(a, 1);
				}
				else {
					counts[a]++;
				}
			}

			foreach (int b in B)
			{
				if (!counts.ContainsKey(b))
				{
					ans.Add(b);
				}
				else {
					if (counts[b] == 1)
					{
						counts.Remove(b);
					}
					else {
						counts[b]--;
					}
				}
			}

			int[] sortedAns = new int[ans.Count];
			ans.CopyTo(sortedAns);
			Array.Sort(sortedAns);
			Console.WriteLine(string.Join(" ", sortedAns));
		}

		#region Time indexer Words
		//https://www.hackerrank.com/challenges/the-time-in-words
		static string[] ones = {"one", "two", "three", "four", "five",
						 "six", "seven", "eight", "nine", "ten"};

		static string[] teens = {"eleven", "twelve", "thirteen",
						 "fourteen","fifteen", "sixteen",
						 "seventeen", "eighteen", "nineteen"};

		static string[] tens = { "ten", "twenty" };
		public static void TimeInWords()
		{
			Console.Write("Enter hours: ");
			int h = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter minutes: ");
			int m = Convert.ToInt32(Console.ReadLine());

			string minutes = "";
			string hour = "";

			if (m == 0)
			{
				hour = (h < 11) ? ones[h - 1] : teens[h - 11];
				Console.WriteLine("{0} o' clock", hour);
			}
			else if (m <= 30)
			{
				minutes = ConvertMinute(m);
				hour = (h < 11) ? ones[h - 1] : teens[h - 11];
				Console.WriteLine("{0} past {1}", minutes, hour);
			}
			else {
				minutes = ConvertMinute(60 - m);
				hour = (h + 1 < 11) ? ones[h] : teens[h - 10];
				Console.WriteLine("{0} to {1}", minutes, hour);
			}
		}

		private static string ConvertMinute(int m)
		{
			string minutes = "";
			if (m == 1) { minutes = "one minute"; }
			else if (m <= 10) { minutes = ones[m - 1] + " minutes"; }
			else if (m == 15) { minutes = "quarter";}
			else if (m < 20) { minutes = teens[m - 11] + " minutes"; }
			else if (m < 30) { minutes = tens[1] + " " + ones[m - 20 - 1] + " minutes"; }
			else if (m == 30) { minutes = "half"; }
			return minutes;
		}
		#endregion

		public static void ArmyGame()
		{
			Console.WriteLine("https://www.hackerrank.com/contests/w26/challenges/game-with-cells");
			string[] tokens_n = Console.ReadLine().Split(' ');
			int n = Convert.ToInt32(tokens_n[0]);
			int m = Convert.ToInt32(tokens_n[1]);

			int longer = Math.Max(n, m);
			int shorter = Math.Min(n, m);

			int rows = (int)Math.Ceiling(longer / 2d);
			int cols = 0;
			if (shorter > 2)
			{
				cols = (int)Math.Ceiling(shorter / 2d);
			}
			Console.WriteLine("Rows: " + rows);
			Console.WriteLine("Cols: " + cols);
		}

		#region BestDivisor
		public static void BestDivisor()
		{
			Console.WriteLine("https://www.hackerrank.com/contests/w26/challenges/best-divisor");
			Console.Write("Enter n: ");
			int n = Convert.ToInt32(Console.ReadLine());

			HashSet<int> divisors = GetDivisors(n);

			int maxSum = 1; //sum of digits of divisor
			int maxDivisor = 1;

			List<int> sums = new List<int>();
			foreach (var div in divisors)
			{
				int sum = GetSum(div);
				sums.Add(sum);
				if (sum > maxSum)
				{
					maxSum = sum;
					maxDivisor = div;
				}
				else if (sum == maxSum && div < maxDivisor)
				{
					maxDivisor = div;
				}

			}

			Console.WriteLine(maxDivisor);
		}

		private static HashSet<int> GetDivisors(int n)
		{
			var divisors = new HashSet<int>(); //ensure no duplicates

			for (int i = 1; i < n / 2; i++)
			{
				if (n % i == 0)
				{
					divisors.Add(i);
					divisors.Add(n / i);
				}
			}
			return divisors; 
		}

		private static int GetSum(int n)
		{
			//int sum = n % 10; //ones place
			//int place = 10;  //start at tens place
			//while ((n / place) % 10 != 0)
			//{
			//	sum += n / place;
			//	place *= 10;
			//}
			//return sum;

			int sum = 0;
			string s = n.ToString();
			foreach (char c in s)
			{
				//int num = int.Parse(c.ToString());
				sum += (int)Char.GetNumericValue(c);
			}

			return sum;
		}

		#endregion

		#region Music on the Street
		public static void StreetMusic()
		{
			Console.WriteLine("https://www.hackerrank.com/contests/w26/challenges/street-parade-1");
			int B = Convert.ToInt32(Console.ReadLine());
			int[] borders = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
			string[] line3 = Console.ReadLine().Split(' ');
			int miles = Convert.ToInt32(line3[0]);
			int hMin = Convert.ToInt32(line3[1]);
			int hMax = Convert.ToInt32(line3[2]);

			//find length of border segments
			int[] diffs = new int[B - 1];
			for (int i = 0; i <= diffs.Length - 1; i++)
			{
				diffs[i] = borders[i + 1] - borders[i];
			}

			int start = borders[0];
			int sum = 0;
			for (int i = 0; i < diffs.Length; i++)
			{
				if (sum + diffs[0] > miles || //check bounds
				   diffs[0] > hMax || diffs[0] < hMin)
				{
					sum = 0; //reset counters
					start = borders[i + 1];
				}
				else if (sum + diffs[0] <= miles)
				{
					sum += diffs[0];
				}
				else if (sum == miles)
				{
					break;
				}
			}

			if (sum < miles){
				start = start - ((miles - sum) / 2);
			}
			Console.WriteLine(start);
		}
		#endregion

		#region
		/// <summary>
		/// Uses the Kutakka equation
		/// https://en.wikipedia.org/wiki/Ku%E1%B9%AD%E1%B9%ADaka
		/// </summary>
		public static void SatisfactoryPairs()
		{
			Console.WriteLine("https://www.hackerrank.com/contests/w26/challenges/pairs-again");
			Console.WriteLine("solve ax + by = c, given c");
			Console.Write("Enter c: ");
			int c = Convert.ToInt32(Console.ReadLine());

			int numPairs = 0;
			var pairs = new List<string>();
			for (int a = 1; a < c - 1; a++)
			{
				for (int b = 2; b < c; b++)
				{
					//check bounds
					if (a != b && a + b <= c)
					{
						int gcd = GCD(a, b);
						if (c % gcd == 0)
						{
							numPairs++;
							pairs.Add("(" + a + ", " + b + ")");
						}
					}
				}
			}

			Console.WriteLine(numPairs);
			foreach (var pair in pairs)
			{
				Console.WriteLine(pair);
			}
		}

		/// <summary>
		/// Greatest common divisor using Euclid's algorithm
		/// Default is 1 if none greater than 1 exists
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		private static int GCD(int x, int y)
		{
			int a = Math.Max(x, y);
			int b = Math.Min(x, y);
			while (b > 0 && a % b != 0)
			{
				a = b;
				b = a % b;
			}

			return (b > 0) ? b : 1;
		}
		#endregion

        #region Smith Numbers
        //https://www.hackerrank.com/challenges/identify-smith-numbers
        public static void SmithNumbers()
        {
            Console.WriteLine("https://www.hackerrank.com/challenges/identify-smith-numbers");
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SmithNumbers(n));
        }
       
        /// <summary>
        /// Return 1 if sum of n's digits equals sum of n's prime factors
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int SmithNumbers(int n)
        {
            int digitSum = SumOfDigits(n);
            int factorSum = SumOfPrimeFactors(n);
            return (digitSum == factorSum) ? 1 : 0;
        }

        /// <summary>
        /// Return the sum of the digits in each place of n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int SumOfDigits(int n)
        {
            if(n >= 0 && n < 10)
            {
                return n;
            }

            string s = n.ToString();
            int digitSum = 0;
            foreach (char c in s)
            {
                digitSum += (int)Char.GetNumericValue(c);
            }
            return digitSum;
        }

        /// <summary>
        /// Return the sum of n's prime factors, excluding 1
        /// 378 = 2 x 3 x 3 x 3 x 7 
        /// return 2 + 3 + 3 + 3 + 7
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int SumOfPrimeFactors(int n)
        {
            if(n == 1)
            {
                return 0;
            }

            int sum = 0;
            var factors = new List<int>(); //for debugging
            int i = 2;
            int toFactor = n;
            while(i <= (int)Math.Sqrt(toFactor))
            {
                if (toFactor % i == 0)
                {
                    factors.Add(i);
                    toFactor = toFactor / i; //change the number to factor
                    sum += SumOfDigits(i);
                    i = 2; //reset iterator back to 2
                }
                else
                {
                    i++;
                }
            }
            sum += SumOfDigits(toFactor); //sum up digits of what ever is remaining

            return sum;
        }
		#endregion

		#region Great XOR
		//https://www.hackerrank.com/contests/w28/challenges/the-great-xor
		public static void GreatXOR(String[] args)
		{
			Console.WriteLine("Find all a where x^a > x and a < x");
			int x = TextGui.IntegerPrompt("Enter x");
			GreatXOR_Log(x);
		}

		/// <summary>
		/// O(logn), counts all the 0 bits
		/// </summary>
		private static void GreatXOR_Log(int x)
		{
			int count = 0;
			string bits = Convert.ToString(x, 2);
			for (int i = bits.Length - 1, j = 0; i >= 1; i--, j++)
			{
				//count all the 0 bits
				if (bits[i] == '0')
				{
					//and add their value
					count += (int)Math.Pow(2, j);
				}
			}
			Console.WriteLine("{0} a's exist", count);
		}

		/// <summary>
		/// O(n) Checks if x^a > x for every a less than x  
		/// </summary>
		private static void GreatXORLinear(int x)
		{
			int count = 0;
			for (int a = 1; a < x; a++)
			{
				if ((x ^ a) > x)
				{
					count++;
				}
			}
			Console.WriteLine(count);
		}
		#endregion

		#region Lucky Number Eight
		//https://www.hackerrank.com/contests/w28/challenges/lucky-number-eight
		/// <summary>
		/// Count all subsequences of n that are divisble by 8
		/// subsequences of 12345: 1, 12, 13, 14, 15, 123, 124, 125, etc
		/// </summary>
		private static int eights = 0;
		public static void LuckyNumberEight()
		{
			Console.WriteLine("Count all subsequences of n that are divisble by 8");
			Console.Write("Enter n: ");
			string number = Console.ReadLine();
			Permutation("", number);
		}

		private static void Permutation(string prefix, string suffix)
		{
			for (int i = 0; i < suffix.Length; i++)
			{
				string newPrefix = new StringBuilder(prefix + suffix[i]).ToString();
				string newSuffix = suffix.Substring(i + 1, suffix.Length - 1 - i);
				Console.WriteLine("newPrefix: {0}, newSuffix: {1}", newPrefix, newSuffix);
				if (Convert.ToInt32(newPrefix) % 8 == 0)
				{
					eights++;
				}
				Permutation(newPrefix, newSuffix); //recurse
			}
		}
		#endregion
    } //end class
} //end namespace
