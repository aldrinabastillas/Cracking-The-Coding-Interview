using System;
namespace DataStructures
{
	public class Mastermind{
		public enum Color { Red, Green, Blue, Yellow };
		public static Color CharToColor(char c)
		{
			switch (c)
			{
				case 'R': return Color.Red;
				case 'G': return Color.Green;
				case 'B': return Color.Blue;
				case 'Y': return Color.Yellow;
				default: throw new ArgumentException();
			}
		}
	}
}
