using ToySimulator.Toy;

namespace ToySimulator.ToyBoard.Interface
{
    public interface IToyBoard
    {
        // this interface enables access to a boolean method that returns
        // true or false if the position of the robot is within the board
        bool IsValidPosition(Position position);
    }
}
