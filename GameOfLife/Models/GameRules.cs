using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GameRules
    {
        public bool GetStateByCoordinates(Position coordinates, IImmutableList<Node> nodes)
        {
            return nodes.SingleOrDefault(n => n.Coordinates.Equals(coordinates)) is not null;
        }

        public IImmutableList<Node> Parse(string[] coordinates)
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

        public int FindMaxXCoordinate(IImmutableList<Node> nodes)
        {
            return nodes.Select(n => n.Coordinates.XCoordinate).Max();
        }

        public int FindMaxYCoordinate(IImmutableList<Node> nodes)
        {
            return nodes.Select(n => n.Coordinates.YCoordinate).Max();
        }

        public IImmutableList<Node> ComputeGeneration(IImmutableList<Node> nodes)
        {
            var nextGeneration = new List<Node>(nodes);
            for (int x = 1; x <= FindMaxXCoordinate(nodes); x++)
            {
                for (int y = 1; y <= FindMaxYCoordinate(nodes); y++)
                {
                    ComputeSurvival(new GenerationData(nodes, nextGeneration, new Position(x, y)));
                }
            }
            return nextGeneration.ToImmutableList<Node>();
        }

        private void ComputeSurvival(GenerationData generationData)
        {
            int livingNeighbours = CountLivingNeighbours(generationData);

            if (GetStateByCoordinates(generationData.Coordinates, generationData.LivingNodes) && (livingNeighbours > 3 || livingNeighbours < 2))
            {
                RemoveAtCoordinates(generationData);
            }
            else if (!GetStateByCoordinates(generationData.Coordinates, generationData.LivingNodes) && livingNeighbours == 3)
            {
                generationData.NextGeneration.Add(new Node { Coordinates = generationData.Coordinates });
            }
        }

        private int CountLivingNeighbours(GenerationData generationData)
        {
            int livingNeighbours = 0;
            generationData.Neighbours.Values.ToList().ForEach(neighbour =>
                livingNeighbours += GetStateByCoordinates(neighbour, generationData.LivingNodes) ? 1 : 0);

            return livingNeighbours;
        }

        private static bool RemoveAtCoordinates(GenerationData generationData)
        {
            var node = generationData.LivingNodes.SingleOrDefault(n => n.Coordinates.Equals(generationData.Coordinates));
            return generationData.NextGeneration.Remove(node);
        }
    }
}
