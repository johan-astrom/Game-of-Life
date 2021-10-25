using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    public class TestBase
    {
        public static readonly Node DeadNode = new() 
        { 
            Coordinates = new Position(6, 4), IsAlive = false
        };
        
        public static readonly Node LivingNode = new()
        {
            Coordinates = new Position(5, 4),
            IsAlive = true
        };

        public readonly GameBoard GameBoard = new()
        {
            Nodes = new List<Node>
            {
                DeadNode,
                LivingNode
            }
        };
    }
}
