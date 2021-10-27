using GameOfLife.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    public class TestBase
    {
        public TestContext context;

        public Position LivingNodePosition;

        public Position DeadNodePosition;

        public GameBoard GameBoard;

        public string[] Coordinates;

        public TestBase()
        {
            GameBoard = new GameBoard();
            LivingNodePosition = new Position(1, 1);
            DeadNodePosition = new Position(3, 1);
            
            Coordinates = new[]
            {
                "1, 1",
                "2, 1",
                "1, 2",
                "2, 2",
                "3, 2",
                "1, 3",
                "1, 4",
                "3, 4",
            };
        }

    }
}
