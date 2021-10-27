using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class SurvivalItem
    {
        public ImmutableList<Node> LivingNodes { get; set; }
        public List<Node> NextGeneration { get; set; }
        public Position Coordinates { get; set; }
        public List<Position> Neighbours { get; set; }
        public SurvivalItem(ImmutableList<Node> livingNodes, List<Node> nextGeneration, Position coordinates)
        {
            LivingNodes = livingNodes;
            NextGeneration = nextGeneration;
            Coordinates = coordinates;
            Neighbours = new()
            {
                new Position(Coordinates.XCoordinate - 1, Coordinates.YCoordinate + 1),
                new Position(Coordinates.XCoordinate, Coordinates.YCoordinate + 1),
                new Position(Coordinates.XCoordinate + 1, Coordinates.YCoordinate + 1),
                new Position(Coordinates.XCoordinate - 1, Coordinates.YCoordinate),
                new Position(Coordinates.XCoordinate + 1, Coordinates.YCoordinate),
                new Position(Coordinates.XCoordinate - 1, Coordinates.YCoordinate - 1),
                new Position(Coordinates.XCoordinate, Coordinates.YCoordinate - 1),
                new Position(Coordinates.XCoordinate + 1, Coordinates.YCoordinate - 1),
            };
        }
    }
}
