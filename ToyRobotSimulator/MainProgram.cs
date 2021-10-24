using System;
using ToySimulator.ConsoleChecker;
using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;
using ToySimulator.Toy.Interface;
using ToySimulator.ToyBoard.Interface;

namespace ToySimulator
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            const string description =
@"  **************************************
  **************************************
  **                                  **
  **        TOY SIMULATOR v1.0        **
  **                                  **
  **************************************
  **************************************

     Welcome!

  1: Place the toy on a 6 x 6 square tabletop
     using the following command:

     PLACE X,Y,DIRECTION (Where X and Y are integers and DIRECTION 
     must be either NORTH, SOUTH, EAST or WEST)

  2: When the toy is placed, have at go at using
     the following commands.
                
     REPORT – Shows the current status of the toy. 
     LEFT   – turns the toy 90 degrees left.
     RIGHT  – turns the toy 90 degrees right.
     MOVE   – Moves the toy 1 unit in the facing direction.
     EXIT   – Closes the toy Simulator.
";

            IToyBoard squareBoard = new ToyBoard.ToyBoard(6, 6);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            var stopApplication = false;
            Console.WriteLine(description);
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
