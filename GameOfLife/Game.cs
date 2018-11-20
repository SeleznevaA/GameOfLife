using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
	public class Game
	{
		public Game(HashSet<Point> liveCells)
		{
			LiveCells = liveCells;
		}

		public HashSet<Point> LiveCells { get; private set; }

		public void Update()
		{
			LiveCells = GetNewLiveCells();
		}
		
		public HashSet<Point> GetNewLiveCells()
		{
			var newLiveCells = new HashSet<Point>();
			
			newLiveCells.UnionWith(GetLiveCellsFromLive());
			newLiveCells.UnionWith(GetLiveCellsFromDead(GetDeadNeighbors()));

			return newLiveCells;
		}

		public IEnumerable<Point> GetLiveCellsFromLive()
		{
			return LiveCells.Where(LiveCellCanLive);
		}

		public IEnumerable<Point> GetLiveCellsFromDead(IEnumerable<Point> deadCells)
		{
			return deadCells.Where(DeadCellCanLive);
		}

		private bool DeadCellCanLive(Point deadCell)
		{
			return GetLiveNeighborsCountForCell(deadCell) == 3;
		}

		public IEnumerable<Point> GetDeadNeighbors()
		{
			return LiveCells.SelectMany(GetNeighbors).Where(cell => !LiveCells.Contains(cell));
		}

		public int GetLiveNeighborsCountForCell(Point cell)
		{
			return GetNeighbors(cell).Count(p => LiveCells.Contains(p));
		}

		public bool LiveCellCanLive(Point cell)
		{
			var liveCount = GetLiveNeighborsCountForCell(cell);
			return liveCount == 3 || liveCount == 2;
		}

		public IEnumerable<Point> GetNeighbors(Point cell)
		{
			int[] d = {-1, 0, 1};

			return d
				.SelectMany(i => d.Select(j => new Point(cell.X + i, cell.Y + j)))
				.Where(point => !point.Equals(cell));
		}
	}
}