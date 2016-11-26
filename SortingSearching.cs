using System;
using System.Collections;
using System.Linq;
namespace CrackingTheCodingInterview
{
	public class SortingSearching
	{
		public static void Run()
		{
			//Q11_1();
			//Q11_2();
			//Q11_3();
			Q11_7();
		}

		public static void Q11_1()
		{
			//have 2 sorted arrays, A and B
			//A has enough buffer to hold B
			//merge B into A in sorted order
			Console.WriteLine("Merge two sorted arrays");
			int[] A = { 2, 4, 6, 8, int.MinValue, int.MinValue, int.MinValue, int.MinValue };
			int[] B = { 1, 3, 5, 7 };

			int a = 3; //would have to walk array to find this index
			int b = B.Length - 1;
			for (int i = A.Length - 1; i >= 0; i--)
			{
				if (a >= 0 && A[a] > B[b])
				{
					A[i] = A[a];
					a--;
				}
				else if (b >= 0){
					A[i] = B[b];
					b--;
				}
			}

			//check answer
			Console.WriteLine(string.Join(" ", A));
		}

		public static void Q11_2()
		{
			Console.WriteLine("Sort anagram array");
			//sort an array of strings so that all anagrams are next to each other
			string[] s = { "arc", "bab", "rca", "bba", "car" };
			for (int i = 0; i < s.Length - 1; i++)
			{
				int toInsert = i + 1;
				for (int j = i + 1; j < s.Length; j++)
				{
					if (IsAnagram(s[i], s[j])){
						Switch(s, toInsert, j);
						toInsert++;
					}
				}
			}

			//Check Answer
			Console.WriteLine(string.Join(" ", s));

		}

		private static bool IsAnagram(string A, string B)
		{
			if (A.Length != B.Length)
			{
				return false;
			}
			else {
				int[] chars = new int[256];
				foreach (char a in A)
				{
					chars[(int)a]++;
				}
				foreach (char b in B)
				{
					if (--chars[(int)b] < 0)
					{
						return false;
					}

				}
				return true;
			}
		}

		private static void Switch(string[] s, int a, int b)
		{
			var temp = s[a];
			s[a] = s[b];
			s[b] = temp;
		}

		public static void Q11_3()
		{
			//given a sorted array that has been rotated an unknown amount
			//find the index of an element in the array
			Console.WriteLine("Find element in rotated array");
			int[] arr = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
			Console.WriteLine(FindRotated(arr, 5)); //should return 8
		}

		private static int FindRotated(int[] arr, int toFind)
		{
			int split = 0;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				if (arr[i] > arr[i + 1])
				{
					split = i;
					break;
				}
			}

			int index = FindIndex(arr, toFind, split + 1, arr.Length - 1);
			if (index == -1)
			{
				index = FindIndex(arr, toFind, 0, split);
			}
			return index;
		}

		private static int FindIndex(int[] arr, int toFind, int start, int end)
		{
			if (start > end)
			{
				return -1; //base case, not in array
			}
			int mid = (start + end) / 2;
			if (arr[mid] == toFind)
			{
				return mid;
			}
			else if (arr[mid] < toFind)
			{
				return FindIndex(arr, toFind, mid + 1, end);
			}
			else {
				return FindIndex(arr, toFind, start, mid - 1);
			}

		}

		public static void Q11_4()
		{
			//sort a 20GB file that has one string per line

			//create a hashtable with a bucket for each letter
			//flush these buckets to file every so often
			//now sort each bucket, using something like quicksort
			//read each bucket file then write to a new file to
			//reconstruct original file
		}

		public static void Q11_5()
		{
			//given an array of sorted strings with random empty elements,
			//find the index of a given string
			//string[] s = { "at", "", "", "", "ball", "", "", "car", "", "", "dad" };

			//brute-force O(n) delete all empty elements first

			//faster: use some kind of modified Binary Search
			//move out from middle until you find a non-empty string

		}

		public static void Q11_6()
		{
			//given an M x N matrix in which each row and each column is sorted, 
			//write a method to find an element

			int[,] arr = { {2,  3,  6},
						   {4,  5,  8},
			       	       {14, 16, 18},
				           {20, 22, 24} };

			Console.WriteLine(FindElement(arr, 16));
			
		}

		private static bool FindElement(int[,] arr, int toFind)
		{
			bool found = false;
			//can do a binary search on each row
			//can also check the min and max of each row first

			return found;
		}

		public static void Q11_7()
		{
			Console.WriteLine("Circus Tower");
			//sort by height
			//then count if weights are out of order
			//if equal to length of array, quit

			//repeat except sort by weight first

			Person[] circus = { new Person(65, 100), new Person(70, 150), new Person(56, 90),
				                new Person(75, 190), new Person(60, 95),  new Person(68, 110) };

			circus = circus.OrderBy(a => a.height).ToArray();
			int heightMax = 1;
			for (int i = 0; i < circus.Length - 1; i++)
			{
				if (circus[i].weight < circus[i + 1].weight)
				{
					heightMax++;
				}
			}

			circus = circus.OrderBy(a => a.weight).ToArray();
			int weightMax = 1;
			for (int i = 0; i < circus.Length - 1; i++)
			{
				if (circus[i].height < circus[i + 1].height)
				{
					weightMax++;
				}
			}

			Console.WriteLine("Height first: " + heightMax);
			Console.WriteLine("Weight first: " + weightMax);
		}

		internal class Person
		{
			public int height { get; set; }
			public int weight { get; set; }
			public Person(int ht, int wt)
			{
				height = ht;
				weight = wt;
			}
		}

		public static void Q11_8()
		{
		}
	}
}
