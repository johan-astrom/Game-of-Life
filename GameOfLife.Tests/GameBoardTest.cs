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
        public void GetStateByCoordinatesShouldReturnFalseForDeadNode()
        {
            
            var nodeState = testBase.GameBoard.GetStateByCoordinates(new Position(6, 4));

            Assert.IsFalse(nodeState);
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnTrueForLivingNode()
        {

        }
    }
}
