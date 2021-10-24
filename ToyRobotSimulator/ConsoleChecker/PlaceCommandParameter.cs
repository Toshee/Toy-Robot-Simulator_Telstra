using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;

namespace ToySimulator.ConsoleChecker
{
    // This is a class to store the parameters for the "PLACE" command.
    public class PlaceCommandParameter
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(Position position,Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
