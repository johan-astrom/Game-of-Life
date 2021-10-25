using NUnit.Framework;

namespace GameOfLife.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetStateByCoordinatesShouldReturnFalseForDeadNode()
        {
            var node = new Node
            {
                Coordinates = new Position(4, 2),
                IsAlive = false;
            }
        }
    }
}