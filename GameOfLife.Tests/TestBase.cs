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
        public Node DeadNode = new Node 
        { 
            Coordinates = new Position(6, 4), IsAlive = false
        };
        
        public Node LivingNode = new Node
        {
            Coordinates = new Position(5, 4),
            IsAlive = true
        };
    }
}
