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

        public IEnumerable<Coordinates> GetAllCoordinatesByRow()
        {
            return Enumerable.Range(0, Size.Y).SelectMany(y => Enumerable.Range(0, Size.X).Select(x => new Coordinates(x, y)));
        }
    }
}
