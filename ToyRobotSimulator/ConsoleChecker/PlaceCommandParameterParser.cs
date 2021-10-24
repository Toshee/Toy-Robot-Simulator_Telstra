using System;
using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;

namespace ToySimulator.ConsoleChecker
{

    // This class checks the parameters for the "PLACE" command.
    public class PlaceCommandParameterParser
    {
        // Number of parameters provided for "PLACE" Command. (X,Y,DIRECTION)
        private const int ParameterCount = 3;
        
        // Number of raw input items expected from user.
        private const int CommandInputCount = 2;

        // Checks the toy's initial position and the direction it is going to be facing.
        public PlaceCommandParameter ParseParameters(string[] input)
        {
            Direction direction;
            Position position = null;

            // Checks that Place command is followed by valid command parameters (X,Y and DIRECTION toy's face direction).
            if (input.Length != CommandInputCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,DIRECTION");

            // Checks that three command parameters are provided for the PLACE command.   
            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,DIRECTION");

            // Checks the direction which the toy is going to be facing.
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");
            
            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            position = new Position(x, y);

            return new PlaceCommandParameter(position, direction);
        }
    }
}
