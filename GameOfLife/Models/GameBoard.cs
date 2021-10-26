using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GameBoard
    {
        public List<Node> LivingNodes { get; set; }
        public int Size { get; set; }
        public int MaxXCoordinate { get; set; }
        public int MaxYCoordinate { get; set; }
        public GameBoard()
        {
            LivingNodes = new List<Node>();
        }

        public bool GetStateByCoordinates(Position coordinates)
        {
            return LivingNodes.SingleOrDefault(n => n.Coordinates.Equals(coordinates)) is not null;
        }

        public void Parse(string[] coordinates)
        {
            foreach (string coordinate in coordinates)
            {
                int[] splitCoordinates = Array.ConvertAll(coordinate.Split(','), int.Parse);
                LivingNodes.Add(new Node
                {
                    Coordinates = new Position(splitCoordinates[0], splitCoordinates[1]),
                });
            }
            FindMaxYCoordinate();
            FindMaxXCoordinate();
        }

        private void FindMaxXCoordinate()
        {
            MaxXCoordinate = LivingNodes.Select(n => n.Coordinates.XCoordinate).Max();
        }

        private void FindMaxYCoordinate()
        {
            MaxYCoordinate = LivingNodes.Select(n => n.Coordinates.YCoordinate).Max();
        }

        public void ComputeGeneration()
        {
            for (int x = 1; x <= MaxXCoordinate; x++)
            {
                for (int y = 1; y < MaxYCoordinate; y++)
                {
                    ComputeSurvival(new Position(x, y));
                }
            } 
        }

        private void ComputeSurvival(Position pos)
        {
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

            if (GetStateByCoordinates(pos) && (livingNeighbours > 3 || livingNeighbours < 2))
            {
                RemoveAtCoordinates(pos);
            }
            else if (!GetStateByCoordinates(pos) && livingNeighbours == 3)
            {
                LivingNodes.Add(new Node { Coordinates = pos });
            }
        }

        public bool RemoveAtCoordinates(Position pos)
        {
            var node = LivingNodes.SingleOrDefault(n => n.Coordinates.Equals(pos));
            return LivingNodes.Remove(node);
        }
    }
}
