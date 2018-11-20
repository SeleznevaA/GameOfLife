using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void OneLiveCell_OneUpdate()
		{
			var initSet = new HashSet<Point>{new Point(0, 0)};
			var game = new Game(initSet);
			
			game.Update();

			var expected = new HashSet<Point>();
			Assert.AreEqual(expected, game.LiveCells);
		}
		[Test]
		public void VerticalStickOf3_OneUpdate()
		{
			var initSet = new HashSet<Point>{new Point(0, 0), new Point(0, 1), new Point(0, 2)};
			var game = new Game(initSet);
			
			game.Update();

			var expected = new HashSet<Point> {new Point(-1, 1), new Point(0, 1), new Point(1, 1)};
			CollectionAssert.AreEquivalent(expected, game.LiveCells);
		}
		
		[Test]
		public void RightAngleOf3_OneUpdate()
		{
			var initSet = new HashSet<Point>{new Point(0, 0), new Point(1, 0), new Point(0, 1)};
			var game = new Game(initSet);
			
			game.Update();

			var expected = new HashSet<Point>{new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1)};
			CollectionAssert.AreEquivalent(expected, game.LiveCells);
		}
		
		[Test]
		public void CrossOf4_OneUpdate()
		{
			var initSet = new HashSet<Point>
			{
				new Point(0, 1), 
				new Point(1, 0), 
				new Point(1, 1), 
				new Point(1, 2), 
				new Point(2, 1)
			};
			var game = new Game(initSet);
			
			game.Update();

			var expected = new HashSet<Point>
			{
				new Point(0, 0), 
				new Point(1, 0), 
				new Point(2, 0), 
				new Point(0, 1),
				new Point(2, 1),
				new Point(0, 2),
				new Point(1, 2),
				new Point(2, 2)
			};
			CollectionAssert.AreEquivalent(expected, game.LiveCells);
		}
		
		[Test]
		public void Glider_OneUpdate()
		{
			var initSet = new HashSet<Point>
			{
				new Point(0, 0), 
				new Point(2, 0), 
				new Point(1, 1), 
				new Point(2, 1), 
				new Point(1, 2)
			};
			var game = new Game(initSet);
			
			game.Update();

			var expected = new HashSet<Point>
			{
				new Point(2, 0), 
				new Point(0, 1), 
				new Point(2, 1), 
				new Point(1, 2),
				new Point(2, 2)
			};
			CollectionAssert.AreEquivalent(expected, game.LiveCells);
		}
		
		[Test]
		public void Glider_TwoUpdate()
		{
			var initSet = new HashSet<Point>
			{
				new Point(0, 0), 
				new Point(2, 0), 
				new Point(1, 1), 
				new Point(2, 1), 
				new Point(1, 2)
			};
			var game = new Game(initSet);
			
			game.Update();
			game.Update();

			var expected = new HashSet<Point>
			{
				new Point(1, 0), 
				new Point(2, 1), 
				new Point(3, 1), 
				new Point(1, 2),
				new Point(2, 2)
			};
			CollectionAssert.AreEquivalent(expected, game.LiveCells);
		}
		
		[Test]
		public void CrossOf4_TwoUpdate()
		{
			var initSet = new HashSet<Point>
			{
				new Point(0, 1), 
				new Point(1, 0), 
				new Point(1, 1), 
				new Point(1, 2), 
				new Point(2, 1)
			};
			var game = new Game(initSet);
			
			game.Update();
			game.Update();

			var expected = new HashSet<Point>
			{
				new Point(1, -1), 
				new Point(0, 0), 
				new Point(2, 0), 
				new Point(-1, 1),
				new Point(3, 1),
				new Point(0, 2),
				new Point(2, 2),
				new Point(1, 3)
			};
			CollectionAssert.AreEquivalent(expected, game.LiveCells);
		}
		
		
	}
	
}