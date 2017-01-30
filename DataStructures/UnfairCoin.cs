using System;
namespace DataStructures
{
	public class UnfairCoin
	{
		Random _rand { get; set; }
		double _winRatio { get; set; }

		public UnfairCoin(double winRatio)
		{
			_rand = new Random();
			if (winRatio < 0 || winRatio > 1)
			{
				throw new ArgumentOutOfRangeException(nameof(winRatio), "must be between 0 and 1");
			}
			_winRatio = winRatio;

		}

		/// <summary>
		/// Unfair flips
		/// </summary>
		public bool Flip()
		{
			var flip = _rand.NextDouble(); //return (0-1)
			if (flip >= _winRatio)
			{
				return true;
			}
			return false;
		}
	}
}
