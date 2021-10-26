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

            if(emptyBoard.Nodes.Count > 0)
            {
                Assert.Fail();
            }

            emptyBoard.Parse(testBase.Coordinates);

            CollectionAssert.IsNotEmpty(emptyBoard.Nodes);

        }

        [Test]
        public void GetStateByCoordinatesShouldReturnFalseForDeadNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns false for a dead node.");

            var nodeState = testBase.GameBoard.GetStateByCoordinates(new Position(6, 4));

            Assert.IsFalse(nodeState);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnTrueForLivingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns true for a living node.");

            var nodeState = testBase.GameBoard.GetStateByCoordinates(new Position(5, 4));

            Assert.IsTrue(nodeState);
        }

        [Test]
        public void ComputeSurvivalShouldSetIsAliveToFalseForNodeWithOneLivingNeighbour()
        {
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            populatedBoard.ComputeSurvival();

            if(!populatedBoard.GetStateByCoordinates(new Position(1, 3)))
            {
                Assert.Fail();
            }

            var nodeState = populatedBoard.GetStateByCoordinates(new Position(1,3));

            Assert.IsFalse(nodeState);
        }

    }
}
