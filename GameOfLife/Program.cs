using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var initSetGlider = new HashSet<Point>
			{
				new Point(0, 0), 
				new Point(2, 0), 
				new Point(1, 1), 
				new Point(2, 1), 
				new Point(1, 2)
			};

			var game = new Game(initSetGlider);

			Console.CursorVisible = false;
			
			while (true)
			{
				Console.SetCursorPosition(0, 0);

				var liveCellsForConsole = GetLiveCellsForConsole(game);
				
				UpdateScreen(liveCellsForConsole);

				game.Update();
			}
			
		}

		private static HashSet<Point> GetLiveCellsForConsole(Game game)
		{
			return game
				.LiveCells.Select(cell => new Point(cell.X % Console.WindowHeight, cell.Y % Console.WindowWidth))
				.ToHashSet();
		}

		private static void UpdateScreen(HashSet<Point> liveCells)
		{
			for (int i = 0; i < Console.WindowHeight; i++)
			{
				for (int j = 0; j < Console.WindowWidth; j++)
				{
					Console.Write(IsLiveCell(liveCells, i, j) ? '#' : ' ');
				}
			}
		}

		private static bool IsLiveCell(HashSet<Point> liveCells, int i, int j)
		{
			var curPoint = new Point(i, j);

			return liveCells.Contains(curPoint);
		}
	}
}