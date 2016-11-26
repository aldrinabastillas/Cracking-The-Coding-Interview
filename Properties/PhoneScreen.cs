using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodingInterview
{
	//https://theinterviewhacker.com/2016/02/11/10-phone-screen-questions/
	public class PhoneScreen
	{
		public static void Run()
		{
			//Zocdoc();
			//Groupon();
			//TripAdvisor();
			//Zillow();
			Qualtrics();
			//Snapchat();
			//ZenefitsB();
			//GoogleA();
			//GoogleB();
		}

		public static void Zocdoc()
		{
			Console.WriteLine("Zocdoc");
			int[] nums = { 2, 4, 6, 8 };
			int output = Zocdoc(nums, 2);

			Console.WriteLine(output);

		}

		private static int Zocdoc(int[] nums, int i)
		{
			int output = 1;

			//foreach (int num in nums)
			//{
			//	output *= num;
			//}
			//return output / nums[i];

			for (int j = 0; j < nums.Length; j++)
			{
				if (j != i) { output *= nums[j]; }
			}
			return output;
		}

		public static void Groupon()
		{
			Console.WriteLine("Fortunes");
			Fortunes fortunes = new Fortunes();
			fortunes.AddMessage("a");
			fortunes.AddMessage("b");
			fortunes.AddMessage("c");
			fortunes.AddMessage("d");
			Console.WriteLine(fortunes.RandomMessage());
		}

		public static void LinkedIn()
		{
			//if tree doesn't allow duplicates
			//add all parent nodes of node1 to a set
			//then all parent nodes of node2 to the same set
			//first one that fails is the LCA

			//if duplicate values, add the actual node object
			//memory address will be different, use node1.Equals(node2)
		}

		public static void TripAdvisor()
		{
			Console.WriteLine("Balanced Tree");
			TreeNode<int> root = new TreeNode<int>(1);
			root.AddLeft(2);
			root.left.AddLeft(4);
			root.left.AddRight(5);
			root.AddRight(3);

			Console.WriteLine(IsBalanced(root));
		}

		private static bool IsBalanced(TreeNode<int> root)
		{
			if (root.left == null && root.right == null)
			{
				return true;
			}
			int leftHeight = GetHeight(root.left);
			int rightHeight = GetHeight(root.right);
			if (Math.Abs(leftHeight - rightHeight) > 1)
			{
				return false;
			}
			return IsBalanced(root.left) && IsBalanced(root.right);

		}

		private static int GetHeight(TreeNode<int> root)
		{
			if (root == null)
			{
				return 0;
			}
			return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
		}

		public static void Zillow()
		{
			Console.WriteLine("Find first non-dup item");
			string[] arr = { "a", "a", "b", "c", "d", "b" };
			Console.WriteLine(FirstNonDup(arr));
		}

		private static string FirstNonDup(string[] strings)
		{
			Dictionary<string, int> counts = new Dictionary<string, int>();
			//Queue<string> queue = new Queue<string>();
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

			//while (queue.Count > 0) //don't need a queue, just iterate over array again duh
			//{
			//	string s = queue.Dequeue();
			//	if (counts[s] == 1)
			//	{
			//		return s;
			//	}
			//}
			return "";
		}

		public static void Qualtrics()
		{
			Console.WriteLine("Decreasing path");
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

		public static void Snapchat()
		{
			Console.WriteLine("River Frog");
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
				else if (current + jump < river.Length && river[current + jump]) { 
					current = current + jump; 
				}
				else if (current + jump + 1 < river.Length && river[current + jump + 1]) { 
					current = current + jump + 1;
					jump++;
				}
				else if (current + jump - 1 < river.Length && river[current + jump - 1]) { 
					current = current + jump - 1;
					jump--;
				}
				else {
					return false;
				}
			}
			return true;
		}

		public static void ZenefitsA()
		{
			Console.WriteLine("Parse sum of a/b");
			List<string> list = new List<string>();
			list.Add("1/2");
			list.Add("3/4");

			int a = 0;
			int b = 0;
			foreach (string ab in list)
			{
				string[] temp = ab.Split('/');
				a += Convert.ToInt32(temp[0]);
				b += Convert.ToInt32(temp[1]);
			}
		}

		public static void ZenefitsB()
		{
			Console.WriteLine("Find max diff");
			int[] nums = { 2, 1, 3, 5, 6, 2, 10, 9, 1, -11 };
			Console.WriteLine(MaxDiff(nums));
		}

		private static int MaxDiff(int[] nums)
		{
			int max = nums[0];
			int min  = nums[0];
			for (int i = 1; i < nums.Length; i++)
			{
				min = Math.Min(min, nums[i]);
				max = Math.Max(max, nums[i] - min);
			}
			return max;
		}

		public static void GoogleA()
		{
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

		public static void GoogleB()
		{
			Console.WriteLine("Justify text");
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
	}

	public class Maze{
		public int[,] grid { get; set; }
		public bool[,] visited { get; set; }
		public int endRow { get; set; }
		public int endCol { get; set; }

		public Maze(int[,] grid, int endRow, int endCol)
		{
			this.grid = grid;
			visited = new bool[grid.GetLength(0), grid.GetLength(1)];
			this.endRow = endRow;
			this.endCol = endCol;
		}

		public int GetValue(int row, int col)
		{
			if (row < 0 || col < 0 ||
			   row >= grid.GetLength(0) || col >= grid.GetLength(1))
			{
				return int.MaxValue;
			}
			return grid[row, col];
		}

		public int? MoveLeft(int startRow, int startCol)
		{
			return Move(startRow, startCol - 1);
		}

		public int? MoveRight(int startRow, int startCol)
		{
			return Move(startRow, startCol + 1);
		}

		public int? MoveUp(int startRow, int startCol)
		{
			return Move(startRow - 1, startCol);
		}

		public int? MoveDown(int startRow, int startCol)
		{
			return Move(startRow + 1, startCol);
		}

		private void MarkVisited(int row, int col)
		{
			//mark as visited before moving on
			visited[row, col] = true;
		}

		private int? Move(int row, int col)
		{
			//check bounds
			if (row < 0 || col < 0 ||
			   row >= grid.GetLength(0) || col >= grid.GetLength(1))
			{
				return null;
			}

			//check if visited
			if (visited[row, col] == true)
			{
				return null;
			}

			MarkVisited(row, col);
			return grid[row, col];
		}
	}

	public class Fortunes
	{
		private List<string> messages { get; set; }

		public Fortunes()
		{
			messages = new List<string>();
		}

		public void AddMessage(string m)
		{
			if (messages != null)
			{
				messages.Add(m);
			}
		}

		public string RandomMessage()
		{
			Random rand = new Random();
			return RandomMessage(rand);
		}

		public string RandomMessage(int seed)
		{
			Random rand = new Random(seed);
			return RandomMessage(rand);
		}

		private string RandomMessage(Random rand)
		{
			int num = rand.Next(0, messages.Count - 1);
			return messages[num];
		}
	}
}
