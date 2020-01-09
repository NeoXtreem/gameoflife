using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GameOfLife.Models
{
    public class Grid
    {
        public Coordinates Size { get; }

        public ReadOnlyCollection<Cell> Cells { get; set; }

        public Grid(Coordinates size, IEnumerable<Cell> cells)
        {
            Size = size;
            Cells = cells.ToList().AsReadOnly();
        }
    }
}
