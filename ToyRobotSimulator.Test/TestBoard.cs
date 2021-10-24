using NUnit.Framework;
using ToySimulator.Toy;
using ToySimulator.ToyBoard;

namespace ToySimulator.Test
{
    [TestFixture]
    public class TestBoard
    {

        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Test]
        public void TestInvalidBoardPosition()
        {
            // arrange
            ToyBoard.ToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);            
            Position position = new Position(6, 6);
          
            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }
        
        /// <summary>
        /// Test valid positon 
        /// </summary>
        [Test]
        public void TestValidBoardPosition()
        {
            // arrange
            ToyBoard.ToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            Position position = new Position(1, 4);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsTrue(result);            
        }   

    }
}
