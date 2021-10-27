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

        public Node LivingNode;

        public GameBoard GameBoard;

        public string[] Coordinates;

        public TestBase()
        {
            LivingNodePosition = new Position(5, 4);
            DeadNodePosition = new Position(1, 1);
            LivingNode = new()
            {
                Coordinates = LivingNodePosition,
            };
            GameBoard = new()
            {
                LivingNodes = new List<Node>
            {
                LivingNode
            }
            };
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
