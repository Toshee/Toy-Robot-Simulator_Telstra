using System;
using NUnit.Framework;
using ToySimulator.ConsoleChecker;
using ToySimulator.Toy;

namespace ToySimulator.Test
{
    [TestFixture]
    public class TestConsoleChecker
    {
        /// <summary>
        /// Test valid place command
        /// </summary>
        [Test]
        public void TestValidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = inputParser.ParseCommand(rawInput);

            // assert
            Assert.AreEqual(Command.Place, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACETOY".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { inputParser.ParseCommand(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT"));
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [Test]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            var placeCommandParameter = inputParser.ParseCommandParameter(rawInput);

            // assert
            Assert.AreEqual(4, placeCommandParameter.Position.X);
            Assert.AreEqual(3, placeCommandParameter.Position.Y);
            Assert.AreEqual(Direction.West, placeCommandParameter.Direction);
        }

        /// <summary>
        /// Test a place command with an incomplete parameter
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {  var placeCommandParameter = inputParser.ParseCommandParameter(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F"));
        }

        /// <summary>
        /// Test a place command with an invalid direction
        /// </summary>
        [Test]
        public void TestInvalidPlaceDirection()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 2,4,OneDirection".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST"));
        }

        /// <summary>
        /// Test a place command with an invalid parameter format
        /// </summary>
        [Test]
        public void TestInvalidPlaceParamsFormat()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 3,3,SOUTH,2".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F"));
        }

    }
}
