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

            foreach (var coordinates in Grid.GetAllCoordinatesByRow(Grid.Size))
            {
                var count = 0;
                var alive = false;

                foreach (var neighbour in Grid.GetAllCoordinatesByRow(new Coordinates(3, 3), new Coordinates(coordinates.X - 1, coordinates.Y - 1)))
                {
                    if (!cells.Contains(new Cell(neighbour))) continue;

                    if (neighbour.X == coordinates.X && neighbour.Y == coordinates.Y)
                    {
                        alive = true;
                    }
                    else
                    {
                        count++;
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

            foreach (var coordinates in Grid.GetAllCoordinatesByRow(Grid.Size))
            {
                sb.Append((cells.Contains(new Cell(coordinates)) ? "X" : " ") + (coordinates.X == Grid.Size.X - 1 ? Environment.NewLine : string.Empty));
            }

            return sb.ToString();
        }
    }
}
