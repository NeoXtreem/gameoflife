namespace GameOfLife.Models
{
    public struct Cell
    {
        public Cell(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; }
    }
}
