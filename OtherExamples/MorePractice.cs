using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace CrackingTheCodingInterview
{
	public class MorePractice
	{
		#region Fizz Buzz
		public static void FizzBuzz()
		{
			Console.WriteLine("FizzBuzz Problem");
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
		#endregion

		#region First Non Dup Item
		public static void FirstNonDupItem()
		{
			Console.WriteLine("Find first non-dup item");
			string[] arr = { "a", "a", "b", "c", "d", "b" };
			Console.WriteLine(FirstNonDup(arr));
		}

		private static string FirstNonDup(string[] strings)
		{
			Dictionary<string, int> counts = new Dictionary<string, int>();
			foreach (string s in strings)
			{
				if (!counts.ContainsKey(s))
				{
					counts.Add(s, 1);
				}
				else {
					counts[s]++;
				}
				//queue.Enqueue(a);
			}

			foreach (string s in strings)
			{
				if (counts[s] == 1)
				{
					return s;
				}
			}
			return "";
		}
		#endregion

		#region Decreasing Path in Maze
		public static void DecreasingMazePath()
		{
			Console.WriteLine("Decreasing path in maze");
			int[,] grid = {{ 100, 40, 20 },
						   {80, 30, 10},
						   {100, 101, 0}};
			int startRow = 0;
			int startCol = 0;
			int endRow = 2;
			int endCol = 2;

			Maze maze = new Maze(grid, endRow, endCol);

			Console.WriteLine(PathExists(maze, startRow, startCol, int.MaxValue));

		}

		private static bool PathExists(Maze maze, int startRow, int startCol, int parent)
		{
			//check bounds
			if (startRow < 0 || startCol < 0 ||
			   startRow >= maze.grid.GetLength(0) || startCol >= maze.grid.GetLength(1))
			{
				return false;
			}

			//check if visited (not necessary, as we'll eventually find end)
			//if (maze.visited[startRow, startCol] == true)
			//{
			//	return false;
			//}

			//check if value is decreasing
			int currentValue = maze.GetValue(startRow, startCol);
			if (currentValue >= parent)
			{
				return false;
			}

			//check if destination
			if (startRow == maze.endRow && startCol == maze.endCol)
			{
				return true;
			}

			//mark visited
			maze.visited[startRow, startCol] = true;

			//move 
			bool left = PathExists(maze, startRow, startCol - 1, currentValue);
			bool right = PathExists(maze, startRow, startCol + 1, currentValue);
			bool up = PathExists(maze, startRow - 1, startCol, currentValue);
			bool down = PathExists(maze, startRow + 1, startCol, currentValue);
			return left || right || up || down;
		}
		#endregion

		#region Cross River
		public static void RiverCrossing()
		{
			Console.WriteLine("If frog can cross river");
			bool[] river = {false, false, true, false, false, true,
				false, false, false, true, false, false, true, false, false, false, true};
			Console.WriteLine(CrossRiver(river));
		}

		private static bool CrossRiver(bool[] river)
		{
			int jump = 0;
			for (int i = 0; i < river.Length; i++)
			{
				if (river[i])
				{
					jump = i;
					break;
				}
			}

			int current = jump;
			while (current < river.Length)
			{
				if (current == river.Length - 1)
				{
					return true;
				}
				else if (current + jump < river.Length && river[current + jump])
				{
					current = current + jump;
				}
				else if (current + jump + 1 < river.Length && river[current + jump + 1])
				{
					current = current + jump + 1;
					jump++;
				}
				else if (current + jump - 1 < river.Length && river[current + jump - 1])
				{
					current = current + jump - 1;
					jump--;
				}
				else {
					return false;
				}
			}
			return true;
		}
		#endregion
	
		#region Find Max Diff
		public static void FindMaxDiff()
		{
			Console.WriteLine("Find max diff of pairs in an array");
			int[] nums = { 2, 1, 3, 5, 6, 2, 10, 9, 1, -11 };
			Console.WriteLine(MaxDiff(nums));
		}

		private static int MaxDiff(int[] nums)
		{
			int max = nums[0];
			int min = nums[0];
			for (int i = 1; i < nums.Length; i++)
			{
				min = Math.Min(min, nums[i]); //find min in array
				max = Math.Max(max, nums[i] - min); //subtract from min
			}
			return max;
		}
		#endregion

		#region 3 Num Sum
		public static void ThreeNumbersToSum()
		{
			Console.WriteLine("Find any 3 numbers that sum to a given number");
			//trivial answer = t, -t, t
			int target = -10;
			FindSum(target);
		}

		private static void FindSum(int target)
		{
			int a = target / 3;
			int b = (target - a) / 2;
			int c = ((target - a) % 2) + b;
			Console.WriteLine("{0} {1} {2}", a, b, c);
		}
		#endregion

		#region Justify Text
		public static void JustifyText()
		{
			Console.WriteLine("Justify text to a given length");
			string[] strings = {"This", "is", "an",
				"example", "of", "text", "justification"};

			int length = 16;
			string[] justified = Justify(strings, length);
			foreach (var j in justified)
			{
				Console.WriteLine(j);
			}
		}

		private static string[] Justify(string[] strings, int length)
		{
			List<string> justify = new List<string>();
			StringBuilder line = new StringBuilder();

			foreach (var s in strings)
			{
				if (line.Length + s.Length <= length)
				{
					line.Append(s);
				}
				else {
					justify.Add(line.ToString()); //add to list
					line.Clear(); //clear and start new line buffer
					line.Append(s);
				}
				if (line.Length < length)
				{
					line.Append(" "); //append a space if there's room
				}
			}
			justify.Add(line.ToString());

			return justify.ToArray();
		}
		#endregion
	
		#region Place Digits
		public static void PlaceDigits()
		{
			Console.WriteLine("Write digit in each place.");
			Console.Write("Enter n: ");
			int n = 0;
			while (!Int32.TryParse(Console.ReadLine(), out n))
			{
				Console.Write("Invalid input, try again: ");
			}
			Console.WriteLine(PlaceDigits(n));

		}

		//using math!!
		private static string PlaceDigits(int n)
		{
			var digits = new StringBuilder();

			int place = 1;
			//iterate until power of 10 is larger than n
			while (place * 10 <= n)
			{
				place *= 10; 
			}

			while (place >= 1)
			{
				int digit = n / place;
				digits.Append(digit.ToString() + " ");

				//iterate by ten
				n %= place;
				place /= 10;
			}
			return digits.ToString();
		}
		#endregion
	
	}
}
