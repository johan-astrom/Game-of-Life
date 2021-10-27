using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GenerationData
    {
        public IImmutableList<Node> LivingNodes { get; set; }
        public List<Node> NextGeneration { get; set; }
        public Position Coordinates { get; set; }
        public ImmutableDictionary<String, Position> Neighbours { get; }

        public GenerationData(IImmutableList<Node> livingNodes, List<Node> nextGeneration, Position coordinates)
        {
            LivingNodes = livingNodes;
            NextGeneration = nextGeneration;
            Coordinates = coordinates;
            Neighbours = new Dictionary<string, Position>()
            {
                {"UpperLeft", new Position(Coordinates.XCoordinate - 1, Coordinates.YCoordinate + 1) },
                {"UpperCenter", new Position(Coordinates.XCoordinate, Coordinates.YCoordinate + 1) },
                {"UpperRight", new Position(Coordinates.XCoordinate + 1, Coordinates.YCoordinate + 1) },
                {"Left", new Position(Coordinates.XCoordinate - 1, Coordinates.YCoordinate) },
                {"Right", new Position(Coordinates.XCoordinate + 1, Coordinates.YCoordinate) },
                {"LowerLeft", new Position(Coordinates.XCoordinate - 1, Coordinates.YCoordinate - 1) },
                {"LowerCenter", new Position(Coordinates.XCoordinate, Coordinates.YCoordinate - 1) },
                {"LowerRight", new Position(Coordinates.XCoordinate + 1, Coordinates.YCoordinate - 1) }
            }.ToImmutableDictionary();
    }


    }
}
    