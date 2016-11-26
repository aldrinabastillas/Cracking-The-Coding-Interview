using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview
{
	public class Strings
	{
		//https://www.hackerrank.com/challenges/making-anagrams
		public static void MakingAnagrams()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/making-anagrams");
			string a = Console.ReadLine();
			string b = Console.ReadLine();

			var chars = new Dictionary<char, int>();
			foreach (char c in a)
			{
				if (!chars.ContainsKey(c))
				{
					chars.Add(c, 1);
				}
				else {
					chars[c]++;
				}
			}
			foreach (char c in b)
			{
				if (!chars.ContainsKey(c))
				{
					chars.Add(c, -1);
				}
				else {
					chars[c]--;
				}
			}

			int ans = 0;
			foreach (char c in chars.Keys)
			{
				if (chars[c] != 0)
				{
					ans += Math.Abs(chars[c]);
				}
			}
			Console.WriteLine(ans);
		}

		//https://www.hackerrank.com/challenges/alternating-characters
		public static void AlternatingChars()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/alternating-characters");
			int t = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < t; i++)
			{
				string s = Console.ReadLine();
				int count = 0;
				for (int j = 0; j < s.Length - 1; j++)
				{
					if ((s[j] == 'A' && s[j + 1] != 'B') ||
					    (s[j] == 'B' && s[j + 1] != 'A')){
						count++;
					}
				}
				Console.WriteLine(count);

			}
		}

		//https://www.hackerrank.com/challenges/palindrome-index
		public static void Palindrome()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/palindrome-index");
			int t = Convert.ToInt32(Console.ReadLine());
			for (int u = 0; u < t; u++)
			{
				string s = Console.ReadLine();
				int index = -1;
				for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--)
				{
					char a = s[i];
					char b = s[j];
					if (s[i] != s[j])
					{
						if (index != -1) //already removed one char, not possible
						{
							index = -1;
							break;
						}
						else {
							char c = s[i + 1];
							if (s[i + 1] == s[j] && s[i] != s[j - 1])
							{
								index = i; //char to remove
								j++; //move j back one since we're removing a char
							}
							else if (s[i] == s[j- 1]){
								index = j;
								i--;
							}

						}
					}
				}
				Console.WriteLine(index);
			}
		}

		//https://www.hackerrank.com/challenges/two-strings
		public static void TwoString()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/two-strings");
			int t = Convert.ToInt32(Console.ReadLine());
			for (int u = 0; u < t; u++)
			{
				string a = Console.ReadLine();
				string b = Console.ReadLine();

				if (TwoStringHelper(a, b))
				{
					Console.WriteLine("YES");
				}
				else {
					Console.WriteLine("NO");	
				}

			}
		}

		private static bool TwoStringHelper(string a, string b)
		{
			var chars = new HashSet<char>();
			foreach (char c in a)
			{
				chars.Add(c);
			}

			foreach (char c in b)
			{
				if (chars.Contains(c))
				{
					return true;
				}
			}
			return false;
		}

		//https://www.hackerrank.com/challenges/caesar-cipher-1
		public static void CaesarCipher()
		{
			//int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("https://www.hackerrank.com/challenges/caesar-cipher-1");
			string s = Console.ReadLine();
			int k = Convert.ToInt32(Console.ReadLine());
			foreach (char c in s){
				//upper case are 65-90
				if ((int)c > 64 && (int)c < 91)
				{
					int newOffset = ((int)c - 65 + k) % 26;
					Console.Write((char)(newOffset + 65));
				}
				//lower case are 97-122
				else if ((int)c > 96 && (int)c < 123)
				{
					int newOffset = ((int)c - 97 + k) % 26;
					Console.Write((char)(newOffset + 97));
				}
				else {
					Console.Write(c);
				}
					
			}
		}

		//https://www.hackerrank.com/challenges/sherlock-and-anagrams
		public static void SherlockAnagrams()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/sherlock-and-anagrams");
			int t = Convert.ToInt32(Console.ReadLine());
			for (int u = 0; u < t; u++)
			{
				string s = Console.ReadLine();
				int count = 0;

				for (int i = 0; i < s.Length; i++)
				{
					for (int j = 1; j < s.Length; j++)
					{
						for (int k = i + 1; k + j <= s.Length; k++)
						{
							string a = s.Substring(i, j);
							string b = s.Substring(k, j);
							if (isAnagram2(a, b))
							{
								count++;
							}
						}
					}
				}

				Console.WriteLine(count);
			}

		}

		//dictionary performance of searching if key exists is too slow!! 
		//fails tests
		private static bool isAnagram(string a, string b)
		{
			var chars = new Dictionary<char, int>();
			foreach (char c in a)
			{
				if (!chars.ContainsKey(c)) { chars.Add(c, 1); }
				else { chars[c]++; }
			}
			foreach (char c in b)
			{
				if (!chars.ContainsKey(c)) { chars.Add(c, -1); }
				else { chars[c]--; }
			}

			foreach (char c in chars.Keys)
			{
				if (chars[c] != 0) { return false; }
			}
			return true;
		}

		//much faster uses simple char[256] array
		private static bool isAnagram2(string a, string b)
		{
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
					return false;
				}
			}
			return true;
		}

		//https://www.hackerrank.com/challenges/sherlock-and-valid-string
		public static void SherlockValidString()
		{
			Console.WriteLine("https://www.hackerrank.com/challenges/sherlock-and-valid-string");
			string s = Console.ReadLine();
			//Lower case letters are [97-122]
			int[] chars = new int[26];
			foreach (char c in s)
			{
				chars[((int)c) - 97]++;
			}

			//key is frequency, value is count
			var freq = new Dictionary<int, int>();
			foreach (int i in chars)
			{
				if (i != 0)
				{
					if (freq.ContainsKey(i))
					{
						freq[i]++;
					}
					else {
						freq.Add(i, 1);
					}
				}
			}

			//array of sorted counts
			int[] counts = new int[freq.Count];
			freq.Values.CopyTo(counts, 0);
			Array.Sort(counts);

			if (counts.Length == 1 || //if only one frequency
			    (counts.Length == 2 && counts[0] == 1)) //or 2 frequencies and smallest is 1
			{
				Console.WriteLine("YES");
			}
			else { 
				Console.WriteLine("NO");
			}
				
		}
	}
}
