using DataStructures;
using System;
using System.Linq;
using System.Collections;

namespace CrackingTheCodingInterview
{
    public class SortingSearching
	{
		#region Merge Two Sorted Arrays
		public static void MergedTwoSortedArrays()
		{
			//have 2 sorted arrays, A and B
			//A has enough buffer to hold B
			//merge B into A in sorted order
			Console.WriteLine("Q11.1: Merge two sorted arrays");
			int[] A = { 2, 4, 6, 8, int.MinValue, int.MinValue, int.MinValue, int.MinValue };
			int[] B = { 1, 3, 5, 7 };

			//right most index of both A and B
			int a = A.Length - B.Length - 1; //8 - 4 - 1 = 3
			int b = B.Length - 1;

			//insert into right side of A
			for (int i = A.Length - 1; i >= 0; i--)
			{
				//choose the bigger of the right most elements from A and B
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
		#endregion

		#region Sort Anagram Array
		public static void SortAnagramArray()
		{
			Console.WriteLine("Q11.2: Sort anagram array");
			Console.WriteLine("Sort an array of strings so that all anagrams are next to each other");
			string[] s = { "arc", "bab", "rca", "bba", "car" };
			for (int i = 0; i < s.Length - 1; i++)
			{
				int toInsert = i + 1;
				//simple bubble type sort
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

		/// <summary>
		/// Checks if 2 strings have the same letter counts
		/// </summary>
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
		#endregion

		#region Find Index in Rotated/Sorted Array
		public static void FindRotatedArrayElement()
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

		/// <summary>
		/// Binary search that returns the index of the element to search for
		/// </summary>
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
		#endregion

		#region Sort 20GB File
		private static void Q11_4()
		{
			//sort a 20GB file that has one string per line

			//Solution A: external bucket sort
			//create a hashtable with a bucket for each letter
			//flush these buckets to file every so often
			//now sort each bucket, using something like quicksort
			//read each bucket file then write to a new file to
			//reconstruct original file

			//Solution B: external merge sort
			//split file into chunks based on amount of available memory
			//sort each chunk and save
			//once each chunk is sorted, mergesort each chunk

		}
		#endregion

		#region Sort Sparse Array
		private static void Q11_5()
		{
			//given an array of sorted strings with random empty elements,
			//find the index of a given string
			//string[] s = { "at", "", "", "", "ball", "", "", "car", "", "", "dad" };

			//brute-force O(n) look at every index in the array

			//faster: use some kind of modified Binary Search
			//after finding middle, expand out from left and right until you find a non-empty string
		}
		#endregion

		#region Find Element in Sorted Matrix
		private static void Q11_6()
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
		#endregion

		#region Circus Tower
		public static void CircusTower()
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
		#endregion

		#region Sorted Search, No Size
		/// <summary>
		/// Question 10.4 in 6th edition
		/// </summary>
		public static void SortedSearchNoSize()
		{
			Console.WriteLine("Find the index of an element in a sorted array of unknown size");
			int[] arr = { 0, 1, 2, 6, 8, 10, 12, 14, 19 };
			int toFind = 9;
			Console.WriteLine(OneSidedBinary(toFind, 0, 1, arr));
		}

		/// <summary>
		/// Doubles search space each time. If searched too far, then do normal binary searchs
		/// </summary>
		private static int OneSidedBinary(int toFind, int left, int right, int[] arr)
		{
			if (arr[right] == toFind)
			{
				return right;
			}
			if (arr[right] < toFind) //not big enough, keep searching
			{
				return OneSidedBinary(toFind, right, right * 2, arr);
			}
			//too big, do binary search in current window
			return BinarySearch(toFind, left, right - 1, arr);
		}

		/// <summary>
		/// Normal binary search, returns index of item to find
		/// </summary>
		private static int BinarySearch(int toFind, int left, int right, int[] arr)
		{
			while (left <= right)
			{
				int midInd = (left + right) / 2;
				int midVal = arr[midInd];
				if (midVal == toFind)
				{
					return midInd;
				}
				if (midVal > toFind)
				{
					right = midInd - 1; //mid too big, search left
				}
				else {
					//mid too small, search right
					left = midInd + 1;
				}
			}
			return -1; //not found
		}
		#endregion

		#region Missing Int
		private static void MissingInt()
		{
			//Question 10.7 in 6th edition
			//Given an input file with 4 billion non-negative integers, provide an algorithm to
			//generate an integer that is not contained in the file
			//Assume you have 1 GB of memory.

			//1GB = 8 billion bits available
			//create a BitArray 4 billion long (essentially a boolean array, but less space) (boolean is 1 byte, or 8 bits)
			//go through all numbers in file and mark off
			//go through BitArray and find first one that isn't marked off

			//Now assume you have only 10 MB of memory, that the values are distinct, and only 
			//have 1 billion non-negative integers

			//divide up integers up to a billion into buckets
			//since numbers are unique, we know that the count of each bucket should equal 
			//the range of each bucket
			//use the first approach to find the missing number in the bucket
		}
		#endregion

		#region Find Duplicates 
		private static void FindDuplicates(int[] arr)
		{
			//Question 10.8 in 6th Edition
			//given an array with al the numbers from 1 to N, where N is at most 32,000, 
			//print all duplicate entries. You do not know what N is, and you only have 4KB memory.
			BitArray bitArray = new BitArray(32000);
			foreach (int a in arr)
			{
				if (bitArray[a] == true)
				{
					Console.WriteLine(a); //print duplicate
				}
				else {
					bitArray[a] = true;
				}
			}
		}
		#endregion
	}
}
