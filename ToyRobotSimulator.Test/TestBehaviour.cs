using NUnit.Framework;
using ToySimulator.ConsoleChecker;
using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;
using ToySimulator.Toy.Interface;
using ToySimulator.ToyBoard.Interface;
using ToySimulator.ToyBoard;

namespace ToySimulator.Test
{
    [TestFixture]
    public class TestBehaviour
    {
        /// <summary>
        /// Test a valid place command
        /// </summary>
        [Test]
        public void TestValidBehaviourPlace()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(4, robot.Position.Y);
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourPlace()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(robot.Position);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Test]
        public void TestValidBehaviourMove()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", simulator.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourMove()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessCommand("MOVE".Split(' '));
            
            // assert
            Assert.AreEqual("Output: 2,4,NORTH", simulator.GetReport());
        }

        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidBehaviourReport()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);
            
            // act
            simulator.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
