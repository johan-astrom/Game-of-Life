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
        public GameBoard()
        {
            Nodes = new List<Node>();
        }

        public bool GetStateByCoordinates(Position coordinates)
        {
            return Nodes.SingleOrDefault(n => n.Coordinates.Equals(coordinates)).IsAlive;
        }

        public void Parse(string[] coordinates)
        {
            foreach (string coordinate in coordinates)
            {
                int[] splitCoordinates = Array.ConvertAll(coordinate.Split(','), int.Parse);
                Nodes.Add(new Node
                {
                    Coordinates = new Position(splitCoordinates[0], splitCoordinates[1]),
                    IsAlive = true
                });
            }
        }
    }
}
