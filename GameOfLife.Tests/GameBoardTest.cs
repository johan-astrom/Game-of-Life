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

            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.DeadNodePosition);

            Assert.IsFalse(nodeState);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnTrueForLivingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns true for a living node.");

            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.LivingNodePosition);

            Assert.IsTrue(nodeState);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnFalseForNonexistingNode()
        {
            TestContext.Write("Asserting that GetStateByCoordinates returns false if no value is specified for a node at the given position.");

            var nodeState = testBase.GameBoard.GetStateByCoordinates(testBase.NonExistentNodePosition);

            Assert.IsFalse(nodeState);
        }
        [Test]
        public void ComputeSurvivalShouldSetIsAliveToFalseForNodeWithOneLivingNeighbour()
        {
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            if(!populatedBoard.GetStateByCoordinates(new Position(1, 3)))
            {
                Assert.Fail();
            }

            populatedBoard.ComputeSurvival();

            var nodeState = populatedBoard.GetStateByCoordinates(new Position(1,3));

            Assert.IsFalse(nodeState);
        }
    }
}
