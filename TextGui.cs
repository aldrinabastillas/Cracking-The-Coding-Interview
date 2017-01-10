using System;
using System.Reflection;
using System.Collections.Generic;

namespace TextMethods
{
	public class TextGui
	{
		#region Text Prompt Methods
		private static List<Type> chapters { get; set; }

		public static void Main(string[] args)
		{
			//Get list of chapters
			GetChapters();

			//Print and select a chapter
			ChapterSelect();
		}

		private static void GetChapters()
		{
			var assembly = typeof(TextGui).Assembly;
			var types = assembly.GetTypes();
			chapters = new List<Type>();

			foreach (var type in types)
			{
				if (type.Namespace == "CrackingTheCodingInterview")
				{
					chapters.Add(type);
				}
			}
		}

		/// <summary>
		/// Prints chapters, prompts for a chapter, then calls ExerciseSelect() 
		/// </summary>
		private static void ChapterSelect()
		{
			//check chapter list
			if (chapters == null)
			{
				GetChapters();
			}

			//Print Chapters
			Console.Clear();
			for (int i = 0; i < chapters.Count; i++)
			{
				Console.WriteLine("{0}: {1}", i, chapters[i].Name);
			}

			//Select a Chapter
			string prompt = "Select a chapter number from 0 to " + 
				            (chapters.Count - 1).ToString() + " or 'q' to quit: ";
			Console.Write(prompt);
			int chapter = 0;
			string line = Console.ReadLine().Trim();
			//validate integer input and bounds
			while (line == "q" || !int.TryParse(line, out chapter) ||
				   chapter >= chapters.Count || chapter < 0)
			{
				if (line == "q")
				{
					return;
				}
				else {
					Console.WriteLine("Invalid selection.");
					Console.Write(prompt);
					line = Console.ReadLine();
				}
			}

			//Select a chapter exercise
			ExerciseSelect(chapter);
		}

		/// <summary>
		/// Given a chapter, prints exercises, prompts for an exercise, then calls ExecuteExercise()
		/// </summary>
		/// <param name="chapter">Chapter.</param>
		private static void ExerciseSelect(int chapter)
		{
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
			string prompt = "Select an exercise number from 0 to " +
				            (methodCount - 1).ToString() + " or 'b' to go back: "; 
			Console.Write(prompt);
			int method = 0;
			string line = Console.ReadLine().Trim();
			while (line == "b" || !int.TryParse(line, out method) ||
				   method >= methods.Length || method < 0)
			{
				if (line == "b")
				{
					ChapterSelect();
					return;
				}
				else {
					Console.WriteLine("Invalid selection.");
					Console.Write(prompt);
					line = Console.ReadLine();	
				}
			}

			//Execute the exercise
			ExecuteExercise(methods[method]);
		}

		private static void ExecuteExercise(MethodInfo method)
		{
			Console.Clear();
			// assume all exercises are static with no parameters
			method.Invoke(null, null);

			Console.Write("\nPress any key to select another exercise or 'q' to quit: ");
			if (Console.ReadLine().Trim() != "q")
			{
				ChapterSelect();
			}
		}
		#endregion

		#region Other Helper Methods
		public static int IntegerPrompt(string prompt)
		{
			int num = 0;
			Console.Write(prompt);
			while (!int.TryParse(Console.ReadLine(), out num))
			{
				Console.Write("Invalid number, try again: ");
			}
			return num;
		}
		#endregion
	} //end class
} // end namespace
