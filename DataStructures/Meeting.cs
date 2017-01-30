using System.Collections.Generic;
namespace DataStructures
{
	public class Meeting
	{
		public int start { get; set; }
		public int end { get; set; }
		public Meeting(int s, int e)
		{
			start = s;
			end = e;
		}
	}

	public class MeetingComparer : IComparer<Meeting>
	{
		public int Compare(Meeting x, Meeting y)
		{
			return x.end.CompareTo(y.end);
		}

	}
}
