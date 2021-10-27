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
        public void ParseShouldReturnListOfNodes()
        {
            TestContext.Write("Asserting that Parse method returns an immutable Node list when passing in array of coordinate strings.");

            var nodes = testBase.GameBoard.Parse(testBase.Coordinates);

            CollectionAssert.IsNotEmpty(nodes);
        }

        [Test]
        public void MaxXCoordinate_ShouldReturnBiggestValueOfXAxis_AfterParseIsCalled()
        {
            var nodes = testBase.GameBoard.Parse(testBase.Coordinates); 
            Assert.AreEqual(3, testBase.GameBoard.FindMaxXCoordinate(nodes));
        }

        [Test]
        public void MaxYCoordinate_ShouldReturnBiggestValueOfYAxis_AfterParseIsCalled()
        {
            var nodes = testBase.GameBoard.Parse(testBase.Coordinates);
            Assert.AreEqual(4, testBase.GameBoard.FindMaxYCoordinate(nodes));
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnTrueForLivingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns true for a living node.");

            var nodes = testBase.GameBoard.Parse(testBase.Coordinates);
            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.LivingNodePosition, nodes);
            
            Assert.IsTrue(nodeState);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnFalseForNonexistingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns false if no value is specified for a node at the given position.");

            var nodes = testBase.GameBoard.Parse(testBase.Coordinates);
            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.DeadNodePosition, nodes);

            Assert.IsFalse(nodeState);
        }

        [TestCase(1, 4)]
        [TestCase(3, 4)]
        [TestCase(2, 2)]
        public void ComputeSurvivalShouldRemoveNodesWith_Zero_One_Or_Four_LivingNeighbours(int x, int y)
        {
            TestContext.WriteLine($"Testing with coordinates ({x}, {y})");
            var pos = new Position(x, y);
            var nodes = testBase.GameBoard.Parse(testBase.Coordinates);

            if (!testBase.GameBoard.GetStateByCoordinates(pos, nodes))
            {
                Assert.Fail();
            }

            var nextGeneration = testBase.GameBoard.ComputeGeneration(nodes);

            var nodeState = testBase.GameBoard.GetStateByCoordinates(pos, nextGeneration);

            Assert.IsFalse(nodeState);
        }

        [TestCase(3, 1)]
        [TestCase(3, 3)]
        public void ComputeSurvivalShouldAddNodesWithThreeNeighbours(int x, int y)
        {
            var pos = new Position(x, y);
            var nodes = testBase.GameBoard.Parse(testBase.Coordinates);

            if (testBase.GameBoard.GetStateByCoordinates(pos, nodes))
            {
                Assert.Fail();
            }

            var nextGeneration = testBase.GameBoard.ComputeGeneration(nodes);

            var nodeState = testBase.GameBoard.GetStateByCoordinates(pos, nextGeneration);

            Assert.IsTrue(nodeState);
        }

    }
}
