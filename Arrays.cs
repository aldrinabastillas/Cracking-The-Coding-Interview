using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodingInterview
{
	public class Arrays
	{
		public static void Run()
		{
			//Console.WriteLine(Q1_1c("orange"));
			//Console.WriteLine(Q1_1a("apple")); //should be false
			//Console.WriteLine(Q1_1a("orange"));//true

			//Console.WriteLine(Q1_1b("apple")); //false
			//Console.WriteLine(Q1_1b("orange"));//true

			//Console.WriteLine(Q1_2(new char[] { 'a', 'b', 'c', 'd', 'e' }));
			//Console.WriteLine(Q1_2(new char[] { 'a', 'b', 'c', 'd' }));

			//Console.WriteLine(Q1_3a("dog", "god"));
			//Console.WriteLine(Q1_3a("dog", "car"));

			//Console.WriteLine(Q1_3b("dog", "god"));
			//Console.WriteLine(Q1_3b("dog", "car"));

			//Console.WriteLine(Q1_4(new char[] { 'M', 'r', ' ', 'X', ' ', 'J', 'r', ' ', ' ', ' ', ' ' }, 7));

			//Q1_5();

			Q1_6();
		}

		//implement an algorithm to determine if a string has all unique chars
		//O(n) time and space
		public static bool Q1_1a(string str)
		{
			var set = new HashSet<char>();
			foreach (char c in str)
			{
				bool added = set.Add(c);
				if (!added) { return false; }
			}
			return true;
		}

		//do it without additional data structures
		//O(1) space and O(n^2) time 
		//simple exhaustive search
		public static bool Q1_1b(string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				for (int j = i + 1; j < str.Length; j++)
				{
					if (str[i] == str[j]) { return false; }
				}
			}
			return true;
		}

		//use an array of size 256
		//O(n) space, and O(n) time
		public static bool Q1_1c(string str)
		{
			bool[] chars = new bool[256]; //chars in ASCII extended char set
			foreach (char c in str)
			{
				if (chars[(int)c] == false)
				{
					chars[(int)c] = true;
				}
				else {
					return false;
				}
			}
			return true;
		}

		//write a function to reverse a string
		public static char[] Q1_2(char[] str)
		{
			for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
			{
				char temp = str[i];
				str[i] = str[j];
				str[j] = temp;
			}
			return str;
		}

		//given 2 strings, decide if one is a permuation of the other
		//sort strings and see if they're equal
		public static bool Q1_3a(string a, string b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}

			char[] a_sort = a.ToCharArray();
			Array.Sort(a_sort);

			char[] b_sort = b.ToCharArray();
			Array.Sort(b_sort);

			for (int i = 0; i < a_sort.Length; i++)
			{
				if (a_sort[i] != b_sort[i])
				{
					return false;
				}
			}
			return true;
		}

		//count of each character should be the same
		//increment counts for a
		//decrement counts for b, should not go below 0
		public static bool Q1_3b(string a, string b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}

			var counts = new int[256]; //256 ASCII characters
			foreach (char c in a)
			{
				counts[(int)c]++;
			}
			foreach (char c in b)
			{
				counts[(int)c]--;
				if (counts[(int)c] < 0) { return false; }

				//short-hand in one line is to just do
				//if (--counts[(int)c] < 0) { return false; }
			}
			return true;
		}

		//replace all spaces with '%20' 
		//str has extra space to hold new extra characters
		//do the replacement in place
		public static char[] Q1_4(char[] str, int length)
		{
			int count = 0;
			for (int i = 0; i < length; i++)
			{
				if (str[i] == ' ') { count++; }
			}
			if (count == 0) { return str; }

			int newLength = length + count * 2;
			for (int i = length - 1; i >= 0; i--)
			{
				if (str[i] == ' ')
				{
					str[newLength - 1] = '0';
					str[newLength - 2] = '2';
					str[newLength - 3] = '%';
					newLength = newLength - 3; //decrease buffer space 
				}
				else {
					str[newLength - 1] = str[i];
					newLength = newLength - 1; //decrease buffer space
				}
			}
			return str;
		}

		//string compression
		//aabcccccaaa -> a2b1c5a3
		//abc -> abc //compression doesn't get smaller
		public static void Q1_5()
		{
			Console.WriteLine("String Compression");
			//string s = "aabcccccaaa";
			string s = "abc";
			Console.WriteLine(Compress(s));
		}

		private static string Compress(string s)
		{
			var compress = new StringBuilder();
			var chars = s.ToCharArray();

			for (int i = 0; i < s.Length - 1; i++)
			{
				int j = i + 1;
				int count = 1;
				while (j < s.Length && chars[i].Equals(chars[j]))
				{
					count++;
					j++;
				}
				i = j - 1;
				compress.Append(chars[i]);
				compress.Append(count);
			}

			if (compress.Length < s.Length)
			{
				return compress.ToString();
			}
			else {
				return s;
			}
		}

		public static void Q1_6()
		{
			Console.WriteLine("Image rotation");
			int[,] image = { {1, 1, 1},
							 {2, 2, 2},
				             {3, 3, 3} };
			int length = image.GetLength(0);
			for (int i = 0; i < length / 2; i++)
			{
				int first = i;
				int last = length - 1 - i;
				for (int j = first; j < last; j++)
				{
					int offset = j - first;
					int top = image[first,j];

					image[first, j] = image[last - offset, first];
					image[last - offset, first] = image[last, last - offset];
					image[last, last - offset] = image[j, last];
					image[j, last] = top;
				}

			}

			//Print result
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length; j++)
				{
					Console.Write(image[i, j] + " ");
				}
				Console.WriteLine();
			}
		}

		//if an element in an MxN matrix is 0, it's entire row and column are set to 0
		public static void Q1_7()
		{
			//iterate through all cells in matrix
			//if you find a 0, flag the row and column 

			//iterate through the matrix again
			//check the flag if row or column was flagged
		}

		public static void Q1_8()
		{
			//have isSubstring which determines if a is a substring of b
			//check if s2 is a rotation of s1 using *only 1 call* to isSubstring
			//"waterbottle" is a rotation of "erbottlewat"

			/* Think outside the box!!!! 
			 * No limitaiton on just using isSubstring(s1, s2)!! */
			//isSubstring(s1+s1, s2)
			//isSubstring("waterbottlewaterbottle, "erbottlewat")
		}
	}
}
