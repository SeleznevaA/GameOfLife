namespace GameOfLife
{
	public class Point
	{
		protected bool Equals(Point other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}

			return Equals((Point) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}

		public int X { get; }
		public int Y { get; }
		
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
		
		
		
	}
}