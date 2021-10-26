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
        public int Size { get; set; }
        public GameBoard()
        {
            Nodes = new List<Node>();
        }

        public bool GetStateByCoordinates(Position coordinates)
        {
            var node = Nodes.SingleOrDefault(n => n.Coordinates.Equals(coordinates));
            if (node is null) return false;
            return node.IsAlive;
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

        public void ComputeGeneration()
        {
            Nodes.ForEach(ComputeSurvival);
        }

        private void ComputeSurvival(Node node)
        {
            var pos = node.Coordinates;
            List<Position> neighbours = new()
            {
                new Position(pos.XCoordinate-1, pos.YCoordinate+1),
                new Position(pos.XCoordinate, pos.YCoordinate+1),
                new Position(pos.XCoordinate+1, pos.YCoordinate+1),
                new Position(pos.XCoordinate-1, pos.YCoordinate),
                new Position(pos.XCoordinate+1, pos.YCoordinate),
                new Position(pos.XCoordinate-1, pos.YCoordinate-1),
                new Position(pos.XCoordinate, pos.YCoordinate-1),
                new Position(pos.XCoordinate+1, pos.YCoordinate-1),
            };
            int livingNeighbours = 0;
            foreach (Position neighbour in neighbours)
            {
                if (GetStateByCoordinates(neighbour)) { 
                    livingNeighbours++;
                }
            }

            if (livingNeighbours > 4 || livingNeighbours < 2)
            {
                node.IsAlive = false;
            }
            else if (!node.IsAlive && livingNeighbours == 3)
            {
                node.IsAlive = true;
            }
        }
    }
}
