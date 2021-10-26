﻿using System;
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
        [TestCase(1,4)]
        [TestCase(3,4)]
        [TestCase(2,2)]
        public void ComputeSurvivalShouldSetIsAliveToFalseForNodeWith_Zero_One_Or_Four_LivingNeighbours(int x, int y)
        {
            TestContext.WriteLine($"Testing with coordinates ({x}, {y})");
            var pos = new Position(x, y);
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            if (!populatedBoard.GetStateByCoordinates(pos))
            {
                Assert.Fail();
            }

            populatedBoard.ComputeGeneration();

            var nodeState = populatedBoard.GetStateByCoordinates(pos);

            Assert.IsFalse(nodeState);
        }
        
        [Test]
        public void ComputeSurvivalShouldSetIsAliveToFalseForNodeWithZeroLivingNeighbours()
        {
            var positionWithZeroNeighbours = new Position(3, 4);
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            if (!populatedBoard.GetStateByCoordinates(positionWithZeroNeighbours))
            {
                Assert.Fail();
            }

            populatedBoard.ComputeGeneration();

            var nodeState = populatedBoard.GetStateByCoordinates(positionWithZeroNeighbours);

            Assert.IsFalse(nodeState);
        }
        [Test]
        public void ComputeSurvivalShouldSetIsAliveToFalseForNodeWithFourLivingNeighbours()
        {
            var positionWithFourNeighbours = new Position(2, 2);
            var populatedBoard = new GameBoard();
            populatedBoard.Parse(testBase.Coordinates);

            if (!populatedBoard.GetStateByCoordinates(positionWithFourNeighbours))
            {
                Assert.Fail();
            }

            populatedBoard.ComputeGeneration();

            var nodeState = populatedBoard.GetStateByCoordinates(positionWithFourNeighbours);

            Assert.IsFalse(nodeState);
        }
    }
}
