using System;
using System.IO;
using System.Collections.Generic;

namespace CrackingTheCodingInterview
{
	public class HackerRank
	{
		public static void Run()
		{
			//ArrayRotation();
			//Anagrams();
			//IceCream();
			//StackBrackets();
			//QueueQuestion();
			//Inversions();
			//RansomNote();
			//BubbleSort();
			//Sherlock();
			//Sherlock2();
			//MissingNumbers();
			TimeInWords();
		}

		public static void ArrayRotation()
		{
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
		static void Anagrams()
		{
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

		static void IceCream()
		{
			StreamReader f = new StreamReader("../input02.txt");
			int t = Convert.ToInt32(f.ReadLine());
			//int t = 1;
			for (int a0 = 0; a0 < t; a0++)
			{
				int m = Convert.ToInt32(f.ReadLine()); //dollars
													   //int m = 4;
				int n = Convert.ToInt32(f.ReadLine()); //number of ice cream, length of array
													   //int n = 5;
				string[] a_temp = f.ReadLine().Split(' ');
				int[] a = Array.ConvertAll(a_temp, Int32.Parse);
				var indices = new Dictionary<int, List<int>>();
				for (int i = 0; i < n; i++)
				{
					if (!indices.ContainsKey(a[i]))
					{
						indices.Add(a[i], new List<int>() { i });
					}
					else {
						indices[a[i]].Add(i);
					}
				}

				//int[] a = new int[] { 1, 4, 5, 3, 2 };
				int[] b = new int[n];
				Array.Copy(a, b, n);
				Array.Sort(b); // 1 2 3 4 5
				for (int i = 0; i < n; i++)
				{
					int buy1 = b[i];
					int buy2 = m - buy1;
					int targetIndex = binarySearchRec(b, buy2, i + 1, n - 1);
					if (targetIndex != -1)
					{
						int[] ans = new int[2];
						ans[0] = indices[buy1][0] + 1;
						if (indices[buy1].Count == 1)
						{
							ans[1] = indices[buy2][0] + 1;
						}
						else {
							ans[1] = indices[buy1][1] + 1;
						}
						Array.Sort(ans);
						Console.WriteLine(ans[0] + " " + ans[1]);
						//int buy1Index = binarySearchIter(a, buy1, 0, n - 1);
						//int buy2Index = binarySearchIter(a, buy2, buy1Index + 1, n - 1);
						//Console.WriteLine(buy1Index.ToString() + " " + buy2Index.ToString());
						break;
					}
				}
			}
		}

		//returns index of x on a *sorted* array
		public static int binarySearchRec(int[] arr, int x, int left, int right)
		{
			if (left > right)
			{
				return -1;
			}
			int mid = (left + right) / 2;
			if (arr[mid] == x)
			{
				return mid;
			}
			else if (x < arr[mid])
			{
				return binarySearchRec(arr, x, left, mid - 1);
			}
			else {
				return binarySearchRec(arr, x, mid + 1, right);
			}
		}

		//returns index of x on a *sorted* array
		public static int binarySearchIter(int[] arr, int x, int left, int right)
		{
			while (left <= right)
			{
				int mid = (left + right) / 2;
				if (arr[mid] == x)
				{
					return mid;
				}
				else if (x < arr[mid])
				{
					right = mid - 1;
				}
				else {
					left = mid + 1;
				}
			}
			return -1;
		}

		//https://www.hackerrank.com/challenges/ctci-balanced-brackets
		public static void StackBrackets()
		{
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

		//https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks
		public static void QueueQuestion()
		{
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

		//https://www.hackerrank.com/challenges/ctci-merge-sort
		public static void Inversions()
		{
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

		public static int mergesort(int[] array, int[] temp, int leftStart, int rightEnd, int inversions)
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

		public static int mergeHalvesCountInversions(int[] array, int[] temp, int leftStart, 
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

		//https://www.hackerrank.com/challenges/ctci-ransom-note
		public static void RansomNote()
		{
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

		public static void Sherlock()
		{
			string[] line1 = "1 2 3 3".Split(' ');
			int[] arr = Array.ConvertAll(line1, Int32.Parse);

			Console.WriteLine(BinarySearchSum(arr, 0, arr.Length - 1));
		}

		static int BinarySearchSum(int[] arr, int low, int high)
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

		static int SumHalf(int[] arr, int low, int high)
		{
			int sum = 0;
			for (int i = low; i <= high; i++)
			{
				sum += arr[i];
			}
			return sum;
		}

		//https://www.hackerrank.com/challenges/sherlock-and-array
		static void Sherlock2()
		{
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

		static void MissingNumbers()
		{
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

		//https://www.hackerrank.com/challenges/the-time-in-words
		static string[] ones = {"one", "two", "three", "four", "five",
						 "six", "seven", "eight", "nine", "ten"};

		static string[] teens = {"eleven", "twelve", "thirteen",
						 "fourteen","fifteen", "sixteen",
						 "seventeen", "eighteen", "nineteen"};

		static string[] tens = { "ten", "twenty" };
		public static void TimeInWords()
		{
			int h = Convert.ToInt32(Console.ReadLine());
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

	} //end class
} //end namespace
