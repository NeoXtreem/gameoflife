using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GameOfLife.Models
{
    public class Grid
    {
        public Grid(Coordinates size, IEnumerable<Cell> cells)
        {
            Size = size;
            Cells = cells.ToList().AsReadOnly();
        }

        public Coordinates Size { get; }

        public ReadOnlyCollection<Cell> Cells { get; set; }

        public static IEnumerable<Coordinates> GetAllCoordinatesByRow(Coordinates size, Coordinates offset = default)
        {
            return Enumerable.Range(0, size.Y).SelectMany(y => Enumerable.Range(0, size.X).Select(x => new Coordinates(x + offset.X, y + offset.Y)));
        }
    }
}
