using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class Position
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }

        public Position(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   XCoordinate == position.XCoordinate &&
                   YCoordinate == position.YCoordinate;
        }
    }
}
