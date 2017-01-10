using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using DataStructures;
using TextMethods;

namespace CrackingTheCodingInterview
{
	//Chapter 17 in CTCI
	public class Medium
	{
		#region Swap Numbers
		public static void SwapNumbers()
		{
			Q17_1(20, 9);
		}

		private static void Q17_1(int a, int b)
		{
			a = b - a;
			b = b - a;
			a = a + b;
			Console.WriteLine("a: " + a);
			Console.WriteLine("b: " + b);
		}
		#endregion

		#region Tic Tac Toe
		//see if someone has won tic-tac-toe
		public static void TicTacToe(){
			Console.WriteLine(Q17_2());
		}

		private static bool Q17_2()
		{
			Console.WriteLine("Tic-tac-toe");

			//should have made a new class/struct here
			//constructor for size, x, o, empty
			char[,] board = { {'x', 'o', 'o'},
							  {'o', '_', '_'},
							  {'x', 'o', 'x'}};
			int columns = board.GetLength(1);
			int rows = board.GetLength(0);

			//check columns
			for (int i = 0; i < columns; i++)
			{
				var column = new char[columns];
				for (int j = 0; j < rows; j++)
				{
					column[j] = board[j, i];
				}
				if (IsWinner(column)) { return true; }
			}

			//check rows
			for (int j = 0; j < rows; j++)
			{
				var row = new char[rows];
				for (int i = 0; i < columns; i++)
				{
					row[i] = board[j, i];
				}
				if (IsWinner(row)) { return true; }
			}

			//check diagonals
			var diagForward = new char[columns];
			var diagBack = new char[columns];
			for (int i = 0; i < columns; i++)
			{
				diagForward[i] = board[i, i];
				diagBack[i] = board[i, columns - 1 - i];
			}
			if (IsWinner(diagForward)) { return true; }
			if (IsWinner(diagBack)) { return true; }

			return false;
		}

		private static bool IsWinner(char[] column)
		{
			char target = column[0];
			if (!target.Equals('x') || !target.Equals('o'))
			{
				return false;
			}	
			for (int i = 1; i < column.Length; i++)
			{
				if (!column[i].Equals(target)) { return false;}
			}
			return true;
		}
		#endregion

		#region Verify Factorial
		public static void VerifyFactorial()
		{
			Console.WriteLine("Number of trailing zeros in n!");
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Expected answer: " + (n / 5));
			Console.WriteLine("Actual answer: " + Q17_3(n));
		}

		//brute force
		private static int Q17_3(int n)
		{
			long factorial = 1;
			for (int i = 1; i <= n; i++)
			{
				factorial *= i;
			}
			int zeros = 0;
			string s = factorial.ToString();
			for (int i = s.Length - 1; i >= 0; i--)
			{
				if (s[i].Equals('0')) { zeros++; }
				else { break; }
			}
			return zeros;
		}
		#endregion

		#region Get Max
		public static void GetMax()
		{
			//Don't use if-else statements or comparison operators
			Console.WriteLine("Max of 2 numbers");
			int a = Convert.ToInt32(Console.ReadLine());
			int b = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(Q17_4(a, b));
		}

		private static int Q17_4(int a, int b)
		{
			int diff = a - b;
			int sign = ((diff >> 31) & 1) ^ 1; //1 for positive, 0 for negative
			int flip = sign ^ 1;

			return a * sign + b * flip;

		}
		#endregion

		#region Sorted Sub Array
		public static void SortedSubArray()
		{
			//edit insertion sort
			//save lowest and highest index that an element
			//was inserted into
			Console.WriteLine("Sorted sub array");
			//int[] arr = { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
			//int[] arr = { 1, 2, 3, 4};
			int[] arr = { 4, 3, 2, 1};
			Q17_6(arr);
		}

		private static void Q17_6(int[] arr)
		{
			int min = Int32.MaxValue;
			int max = Int32.MinValue;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				int j = i;
				while (j >= 0 && arr[j] > arr[j + 1])
				{
					max = i + 1;
					int temp = arr[j + 1];
					arr[j + 1] = arr[j];
					arr[j] = temp;
					min = Math.Min(min, j);
					j--;
				}
			}
			Console.WriteLine("{0} {1}", min, max);
		}
		#endregion

		#region Largest Subarray Sum
		public static void LargestSubarraySum()
		{
			Console.WriteLine("Q17.7: Largest Contiguous Subarray Sum");
			int[] arr = {2, -8, 3, -2, 4, -10};
			//int[] arr = { -3, -1, -4 };
			Console.WriteLine(Kadanes(arr));
		}

		private static int Kadanes(int[] arr)
		{
			int local = arr[0];
			int global = arr[0];
			for (int i = 1; i < arr.Length; i++)
			{
				if (local < 0)
				{
					local = arr[i];
				}
				else {
					local += arr[i];
				}
				global = Math.Max(global, local);
			}

			return global;
		}
		#endregion

		private static void Q17_9()
		{
			Console.WriteLine("Word Frequencies in a Book");
			//given a word, find the frequency it shows up in a book
			//create hash table, then increment frequencies
		}

		private static void Q17_11()
		{
			Console.WriteLine("TODO: Random Numbers");
		}

		#region Search Pair Sums
		public static void SearchPairSums()
		{
			Console.WriteLine("Search for pairs that sum to a given number");
			//find all pairs in an array that sum to a given number
			int[] arr = { 2, 5, 3, 4, 10, -3, -13, 20 };
			HashPairSums(arr, 7);
			Q17_12(arr, 7);
		}

		private static void Q17_12(int[] arr, int n)
		{
			Array.Sort(arr); //O(nlogn)
			foreach (var i in arr) //O(nlogn)
			{
				int compliment = n - i;
				if (BinarySearch(arr, compliment, 0,  arr.Length - 1)){
					Console.WriteLine("{0} {1}", i, compliment);
				}
			}
		}

		private static bool BinarySearch(int[] arr, int n, int low, int high)
		{
			if (low > high)
			{
				return false;
			}

			int mid = (low + high) / 2;
			if (arr[mid] == n)
			{
				return true;
			}
			else if (arr[mid] > n)
			{
				return BinarySearch(arr, n, low, mid - 1);
			}
			else {
				return BinarySearch(arr, n, mid + 1, high);
			}
		}

		//simpler solution, but O(n) is slower than O(nlogn)
		private static void HashPairSums(int[] arr, int n)
		{
			var pairs = new Dictionary<int, int>();
			foreach (var a in arr) //O(n)
			{
				int compliment = n - a;
				if (!pairs.ContainsKey(compliment))
				{
					pairs.Add(a, compliment);
				}
				else {
					Console.WriteLine("{0} {1}", a, compliment);
				}
			}
		}
		#endregion

		#region Convert BST to a doubly linked list
		//keep items in order, and do in place
		private static Queue<BiNode> q = new Queue<BiNode>();
		public static void BSTtoDLL()
		{
			Console.WriteLine("Convert BST to a doubly linked list.");
			var root = new BiNode(4);
			root.b1 = new BiNode(2);
			root.b1.b1 = new BiNode(1);
			root.b1.b2 = new BiNode(3);

			root.b2 = new BiNode(6);
			root.b2.b1 = new BiNode(5);

			ToQueue(root);
			BiNode head = ToList(q);

			BiNode iter = head;
			BiNode tail = head;
			Console.Write("Forwards: ");
			while (iter != null)
			{
				Console.Write(iter.data + " ");
				tail = iter;
				iter = iter.b2;
			}

			Console.WriteLine();
			Console.Write("Reverse: ");
			iter = tail;
			while (iter != null)
			{
				Console.Write(iter.data + " ");
				iter = iter.b1;
			}
		}

		private static void ToQueue(BiNode root)
		{
			if (root == null)
			{
				return;
			}
				
			ToQueue(root.b1);
			q.Enqueue(root);
			ToQueue(root.b2);
		}

		private static BiNode ToList(Queue<BiNode> list)
		{
			BiNode head = q.Dequeue();

			BiNode last = null;
			BiNode iter = head;
			while (q.Count > 0)
			{
				iter.b1 = last;
				iter.b2 = q.Dequeue();

				last = iter;
				iter = iter.b2;
			}
			return head;
		}
		#endregion

		#region Intersecting Lines
		/// <summary>
		/// Question 16.3 in 6th edition
		/// </summary>
		private static void IntersectingLines()
		{
			Console.WriteLine("given 2 line segments, find their intersection, if any");
			int startx1 = TextGui.IntegerPrompt("Enter line 1, start x");
			int starty1 = TextGui.IntegerPrompt("Enter line 1, start y");
			int endx1 = TextGui.IntegerPrompt("Enter line 1, end x");
			int endy1 = TextGui.IntegerPrompt("Enter line 1, end y");

			int startx2 = TextGui.IntegerPrompt("Enter line 2, start x");
			int starty2 = TextGui.IntegerPrompt("Enter line 2, start y");
			int endx2 = TextGui.IntegerPrompt("Enter line 2, end x");
			int endy2 = TextGui.IntegerPrompt("Enter line 2, end y");

			var line1 = new Line(new Point(startx1, starty1), new Point(endx1, endy1));
			var line2 = new Line(new Point(startx2, starty2), new Point(endx2, endy2));

			var intersection = Line.Intersection(line1, line2);
			Console.WriteLine("{0}, {1}", intersection.x, intersection.y);
		}


		#endregion

		#region Smallest Difference
		public static void SmallestDifference()
		{
			Console.WriteLine("Find the smallest non-neg difference between one value in each array");
			int[] A = { 1, 3, 15, 11, 2 };
			int[] B = { 23, 127, 235, 19, 8 };

			//O(AlogA + BlogB);
			Array.Sort(A);
			Array.Sort(B);
			int a = 0, b = 0;
			int min = int.MaxValue;
			while (a < A.Length && b < B.Length)
			{
				min = Math.Min(min, Math.Abs(A[a] - B[b]));
				if (A[a] < B[b])
				{
					a++;
				}
				else{
					b++;
				}
			}

			Console.WriteLine(min);
		}
		#endregion

		#region Operations
		public static void Operations()
		{
			Console.WriteLine("Implement *, /, - only using addition");
			int a = TextGui.IntegerPrompt("Enter integer 1: ");
			int b = TextGui.IntegerPrompt("Enter integer 2: ");
			Console.WriteLine("{0} x {1} = {2}", a, b, Multiply(a, b));
			Console.WriteLine("{0} / {1} = {2}", a, b, Divide(a, b));
			Console.WriteLine("{0} - {1} = {2}", a, b, Subtract(a, b));
		}

		/// <summary>
		/// Multiply a by b only using +.
		/// </summary>
		private static int Multiply(int a, int b)
		{
			int product = 0;
			if (a == 0 || b == 0)
			{
				return 0;
			}
			int larger = Math.Max(Math.Abs(a), Math.Abs(b)); 
			int smaller = Math.Min(Math.Abs(a), Math.Abs(b));

			for (int i = 1; i <= smaller; i++)
			{
				product += larger;
			}

			if ((a < 0 && b < 0) ||
			   (a > 0 && b > 0))
			{
				return product;
			}
			else {
				return Negate(product);
			}
		}

		/// <summary>
		/// Integer divide a by b only using +
		/// </summary>
		private static int Divide(int a, int b)
		{
			if (b == 0)
			{
				return int.MinValue;
			}
			if (b == 1)
			{
				return a;
			}

			int product = 0;
			int i = 0;

			int absA = Math.Abs(a);
			int absB = Math.Abs(b);
			while (product + absB <= absA)
			{
				product += absB;
				i++;
			}

			if ((a < 0 && b < 0) ||
			   (a > 0 && b > 0))
			{
				return i;
			}
			else {
				return Negate(i);
			}
		}

		/// <summary>
		/// Subtract b from a only using +
		/// </summary>
		private static int Subtract(int a, int b)
		{
			return a + Negate(b);
		}

		private static int Negate(int a)
		{
			int neg = 0;
			int newSign = (a > 0) ? -1 : 1;
			while (a != 0)
			{
				neg += newSign;
				a += newSign;
			}
			return neg;
		}
		#endregion

		#region Diving Board
		static int maxK, shorter, longer;
		static HashSet<int> boards = new HashSet<int>();
		public static void DivingBoard()
		{
			Console.WriteLine("Given short and long planks, you must use k plans.");
			Console.WriteLine("Find all possible lengths for the diving board.");
			maxK = TextGui.IntegerPrompt("Enter k: ");
			shorter = TextGui.IntegerPrompt("Enter shorter: ");
			longer = TextGui.IntegerPrompt("Enter longer: ");
			BoardPerms(0, 0);
			foreach (var b in boards)
			{
				Console.WriteLine(b);
			}
		}

		private static void BoardPerms(int length, int k)
		{
			if (k == maxK)
			{
				boards.Add(length);
			}
			else {
				BoardPerms(length + shorter, k + 1);
				BoardPerms(length + longer, k + 1);
			}
		}
		#endregion
	}
}
