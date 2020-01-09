using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLife.Models;

namespace GameOfLife
{
    public class GameOfLife
    {
        public Grid Grid { get; }

        public GameOfLife(Coordinates size, IEnumerable<Coordinates> aliveCells)
        {
            Grid = new Grid(size, aliveCells.Select(c => new Cell(c)));
        }

        public void NextGeneration()
        {
            var cells = Grid.Cells.ToHashSet();
            var newCells = new List<Cell>();

            foreach (var coordinates in Grid.GetAllCoordinatesByRow())
            {
                var count = 0;
                var alive = false;

                for (var i = Math.Max(coordinates.X - 1, 0); i <= Math.Min(coordinates.X + 1, Grid.Size.X - 1); i++)
                {
                    for (var j = Math.Max(coordinates.Y - 1, 0); j <= Math.Min(coordinates.Y + 1, Grid.Size.Y - 1); j++)
                    {
                        if (cells.Contains(new Cell(new Coordinates(i, j))))
                        {
                            if (i == coordinates.X && j == coordinates.Y)
                            {
                                alive = true;
                            }
                            else
                            {
                                count++;
                            }
                        }
                    }
                }

                if (alive ? count != 1 && (count == 2 || count == 3) : count == 3)
                {
                    newCells.Add(new Cell(coordinates));
                }
            }

            Grid.Cells = newCells.AsReadOnly();
        }

        public string Render()
        {
            var sb = new StringBuilder();
            var cells = Grid.Cells.ToHashSet();

            foreach (var coordinates in Grid.GetAllCoordinatesByRow())
            {
                sb.Append((cells.Contains(new Cell(coordinates)) ? "X" : " ") + (coordinates.X == Grid.Size.X - 1 ? Environment.NewLine : string.Empty));
            }

            return sb.ToString();
        }
    }
}
