namespace DataStructures
{
	public class Keypad
	{
		private char[][] _letters { get; set; }
		public Keypad()
		{
			_letters = new char[8][];
			_letters[0] = new char[] { 'a', 'b', 'c' };
			_letters[1] = new char[] { 'd', 'e', 'f' };
			_letters[2] = new char[] { 'g', 'h', 'i' };
			_letters[3] = new char[] { 'j', 'k', 'l' };
			_letters[4] = new char[] { 'm', 'n', 'o' };
			_letters[5] = new char[] { 'p', 'q', 'r', 's' };
			_letters[6] = new char[] { 't', 'u', 'v' };
			_letters[7] = new char[] { 'w', 'x', 'y', 'z' };
		}

		public char[] GetLetters(int num)
		{
			//bounds check
			if (num < 2 || num > 9)
			{
				return new char[0]; //return empty array
			}
			return _letters[num - 2];
		}

		public char[] GetLetters(char c)
		{
			return GetLetters((int)char.GetNumericValue(c));
		}
	}
}
