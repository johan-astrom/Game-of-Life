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

        public Position DeadNodePosition;

        public Position LivingNodePosition;

        public Position NonExistentNodePosition;

        public Node DeadNode;

        public Node LivingNode;

        public GameBoard GameBoard;

        public string[] Coordinates;

        public TestBase()
        {
            DeadNodePosition = new Position(6, 4);
            LivingNodePosition = new Position(5, 4);
            NonExistentNodePosition = new Position(0, 0);
            LivingNode = new()
            {
                Coordinates = LivingNodePosition,
            };
            GameBoard = new()
            {
                Nodes = new List<Node>
            {
                DeadNode,
                LivingNode
            }
            };
            Coordinates = new[]
            {
                "1, 1",
                "2, 1",
                "1, 2",
                "2, 2",
                "1, 3",
                "1, 4",
                "3, 4",
            };
        }

    }
}
