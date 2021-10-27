using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Models;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class GameBoardTest
    {
        private TestBase testBase;

        [SetUp]
        public void Instantiate()
        {
            testBase = new TestBase();
        }

        [Test]
        public void ParseShouldFillListOfNodes()
        {
            TestContext.Write("Asserting that Parse method populates the Nodes property when passing in array of coordinate strings.");

            var emptyBoard = new GameBoard();

            if(emptyBoard.LivingNodes.Count > 0)
            {
                Assert.Fail();
            }

            emptyBoard.Parse(testBase.Coordinates);

            CollectionAssert.IsNotEmpty(emptyBoard.LivingNodes);

        }

        [Test]
        public void ParseShouldSetMaxXCoordinate()
        {
            var gameBoard = new GameBoard();
            gameBoard.Parse(testBase.Coordinates);
            Assert.AreEqual(3, gameBoard.MaxXCoordinate);
        }
        
        [Test]
        public void ParseShouldSetMaxYCoordinate()
        {
            var gameBoard = new GameBoard();
            gameBoard.Parse(testBase.Coordinates);
            Assert.AreEqual(4, gameBoard.MaxYCoordinate);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnTrueForLivingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns true for a living node.");

            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.LivingNodePosition, testBase.GameBoard.LivingNodes);

            Assert.IsTrue(nodeState);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnFalseForNonexistingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns false if no value is specified for a node at the given position.");

            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.DeadNodePosition, testBase.GameBoard.LivingNodes);

            Assert.IsFalse(nodeState);
        }

        [Test]
        public void Calling_RemoveAtCoordinates_ShouldMake_GetStateByCoordinates_ReturnFalse()
        {
            if (!testBase.GameBoard.GetStateByCoordinates(testBase.LivingNodePosition, testBase.GameBoard.LivingNodes))
            {
                Assert.Fail();
            }

            testBase.GameBoard.RemoveAtCoordinates(testBase.LivingNodePosition);

            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.LivingNodePosition, testBase.GameBoard.LivingNodes);

            Assert.IsFalse(nodeState);
        }

        [TestCase(1,4)]
        [TestCase(3,4)]
        [TestCase(2,2)]
        public void ComputeSurvivalShouldRemoveNodesWith_Zero_One_Or_Four_LivingNeighbours(int x, int y)
        {
            TestContext.WriteLine($"Testing with coordinates ({x}, {y})");
            var pos = new Position(x, y);
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            if (!populatedBoard.GetStateByCoordinates(pos, populatedBoard.LivingNodes))
            {
                Assert.Fail();
            }

            populatedBoard.ComputeGeneration();

            var nodeState = populatedBoard.GetStateByCoordinates(pos, populatedBoard.LivingNodes);

            Assert.IsFalse(nodeState);
        }

        [TestCase(3,1)]
        [TestCase(3,3)]
        public void ComputeSurvivalShouldAddNodesWithThreeNeighbours(int x, int y)
        {
           var pos = new Position(x, y);
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            if (populatedBoard.GetStateByCoordinates(pos, populatedBoard.LivingNodes))
            {
                Assert.Fail();
            }

            populatedBoard.ComputeGeneration();

            var nodeState = populatedBoard.GetStateByCoordinates(pos, populatedBoard.LivingNodes);

            Assert.IsTrue(nodeState);
        }
        
    }
}
