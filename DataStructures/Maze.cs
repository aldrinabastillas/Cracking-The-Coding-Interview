using System;
namespace DataStructures
{
	public class Maze
	{
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
}
