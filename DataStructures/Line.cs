using System;
namespace DataStructures
{
	public class Line
	{
		public double slope { get; set; }
		public double yintercept { get; set; }
		public Line(Point start, Point end)
		{
			slope = (end.y - start.y) / (end.x - start.x);
			yintercept = start.y - (slope * start.x);
		}

		public static Point Intersection(Line line1, Line line2)
		{
			double x = (line2.yintercept - line1.yintercept) / (line1.slope - line2.slope);
			double y = x * line1.slope + line1.yintercept;
			return new Point(x, y);
		}
	}

	public class Point
	{
		public double x { get; set; }
		public double y { get; set; }
		public Point(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
