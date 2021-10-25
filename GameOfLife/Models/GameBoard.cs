using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GameBoard
    {
        public List<Node> Nodes { get; set; }

        public bool GetStateByCoordinates(Position coordinates)
        {
            return Nodes.SingleOrDefault(n => n.Coordinates.Equals(coordinates)).IsAlive;
        }

        public void Parse(string[] coordinates)
        {

        }
    }
}
