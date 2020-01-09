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
            Grid = new Grid(size, aliveCells.Select(c => new Cell(new Coordinates(c.X, c.Y))));
        }

        public void NextGeneration()
        {
            var cells = Grid.Cells.ToHashSet();
            var newCells = new List<Cell>();

            for (var x = 0; x < Grid.Size.X; x++)
            {
                for (var y = 0; y < Grid.Size.Y; y++)
                {
                    var count = 0;
                    var alive = false;
                    var coordinates = new Coordinates(x, y);

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
            }

            Grid.Cells = newCells.AsReadOnly();
        }

        public string Render()
        {
            var sb = new StringBuilder();
            var cells = Grid.Cells.ToHashSet();

            for (var x = 0; x < Grid.Size.X; x++)
            {
                for (var y = 0; y < Grid.Size.Y; y++)
                {
                    sb.Append(cells.Contains(new Cell(new Coordinates(x, y)) ) ? "X" : " ");
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
