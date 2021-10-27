using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GameBoard
    {
        public bool GetStateByCoordinates(Position coordinates, ImmutableList<Node> nodes)
        {
            return nodes.SingleOrDefault(n => n.Coordinates.Equals(coordinates)) is not null;
        }

        public ImmutableList<Node> Parse(string[] coordinates)
        {
            var nodes = new List<Node>();
            Array.ForEach(coordinates, 
                c => AddNode(nodes, 
                Array.ConvertAll(c.Split(','), int.Parse)));
            return nodes.ToImmutableList();
        }

        private static void AddNode(List<Node> nodes, int[] splitCoordinates)
        {
            nodes.Add(new Node
            {
                Coordinates = new Position(splitCoordinates[0], splitCoordinates[1]),
            });
        }

        public int FindMaxXCoordinate(ImmutableList<Node> nodes)
        {
            return nodes.Select(n => n.Coordinates.XCoordinate).Max();
        }

        public int FindMaxYCoordinate(ImmutableList<Node> nodes)
        {
            return nodes.Select(n => n.Coordinates.YCoordinate).Max();
        }

        public ImmutableList<Node> ComputeGeneration(ImmutableList<Node> nodes)
        {
            var nextGeneration = new List<Node>(nodes);
            for (int x = 1; x <= FindMaxXCoordinate(nodes); x++)
            {
                for (int y = 1; y <= FindMaxYCoordinate(nodes); y++)
                {
                    ComputeSurvival(new SurvivalItem
                    {
                        Coordinates = new Position(x, y),
                        LivingNodes = nodes,
                        NextGeneration = nextGeneration
                    });
                }
            }
            return nextGeneration.ToImmutableList<Node>();
        }

        private void ComputeSurvival(SurvivalItem survivalItem)
        {
            int livingNeighbours = 0;
            foreach (Position neighbour in survivalItem.Neighbours)
            {
                if (GetStateByCoordinates(neighbour, survivalItem.LivingNodes)) { 
                    livingNeighbours++;
                }
            }

            if (GetStateByCoordinates(survivalItem.Coordinates, survivalItem.LivingNodes) && (livingNeighbours > 3 || livingNeighbours < 2))
            {
                RemoveAtCoordinates(survivalItem);
            }
            else if (!GetStateByCoordinates(survivalItem.Coordinates, survivalItem.LivingNodes) && livingNeighbours == 3)
            {
                survivalItem.NextGeneration.Add(new Node { Coordinates = survivalItem.Coordinates });
            }
        }

        public bool RemoveAtCoordinates(SurvivalItem survivalItem)
        {
            var node = survivalItem.LivingNodes.SingleOrDefault(n => n.Coordinates.Equals(survivalItem.Coordinates));
            return survivalItem.NextGeneration.Remove(node);
        }
    }
}
