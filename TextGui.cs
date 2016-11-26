using System;
using System.Reflection;
using System.Collections.Generic;

namespace TextGui
{
	public class TextGui
	{
		public static void Main(string[] args)
		{
			//Print list of chapters
			List<Type> chapters = GetChapters();
			for (int i = 0; i < chapters.Count; i++)
			{
				Console.WriteLine("{0}: {1}", i, chapters[i].Name);
			}


			//Select a chapter
			Console.Write("Select a chapter number from 0 to {0}: ", chapters.Count - 1);
			int chapter = 0;
			//validate integer input and bounds
			while (!int.TryParse(Console.ReadLine(), out chapter) || 
			       chapter >= chapters.Count || chapter < 0) 
			{
				Console.WriteLine("Invalid selection.");
				Console.Write("Select a chapter number from 0 to {0}: ", chapters.Count - 1);
			}


			//Print list of exercises
			Console.Clear();
			Console.WriteLine("*** {0} Exercises ***", chapters[chapter].Name);
			MethodInfo[] methods = chapters[chapter].GetMethods();
			int methodCount = 0;
			for (int i = 0; i < methods.Length; i++)
			{
				//don't print out private or virtual methods
				if (methods[i].IsStatic && methods[i].IsPublic) 
				{
					Console.WriteLine("{0}: {1}", methodCount, methods[i].Name);
					methodCount++;
				}
			}


			//Select an exercise
			Console.Write("Select an exercise number from 0 to {0}: ",  methodCount - 1);
			int method = 0;
			while (!int.TryParse(Console.ReadLine(), out method) ||
				   method >= chapters.Count || method < 0)
			{
				Console.WriteLine("Invalid selection.");
				Console.Write("Select an exercise number from 0 to {0}: ", methodCount - 1);
			}


			//Execute an exercise
			Console.Clear();
			// assume all exercises are static with no parameters
			methods[method].Invoke(null, null); 

		}

		private static List<Type> GetChapters()
		{
			var assembly = typeof(TextGui).Assembly;
			var types = assembly.GetTypes();
			List<Type> chapters = new List<Type>();

			foreach (var type in types)
			{
				if (type.Namespace == "CrackingTheCodingInterview")
				{
					chapters.Add(type);
				}
			}

			return chapters;
		}
	}
}
