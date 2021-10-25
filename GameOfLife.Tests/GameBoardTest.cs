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
        [SetUp]
        public void Instantiate()
        {
            var testBase = new TestBase();
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnFalseForDeadNode()
        {
            var gameBoard = new GameBoard();
            var nodeState = gameBoard.GetStateByCoordinates(new Position(6, 4));
        }
    }
}
