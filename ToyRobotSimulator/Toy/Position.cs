namespace ToySimulator.Toy
{
    /// <summary>
    /// This class represents the position of the toy on the board.
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
