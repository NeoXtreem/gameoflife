using System.Linq;
using AutoFixture;
using FluentAssertions;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test
{
    [TestClass]
    public class GridTests
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void Coordinates_SizeProvided_ReturnedCoordinatesCorrect()
        {
            // Arrange
            var size = _fixture.Create<Coordinates>();

            // Act
            var result = Grid.GetAllCoordinatesByRow(size).ToArray();

            // Assert
            for (var x = 0; x < size.X; x++)
            {
                for (var y = 0; y < size.Y; y++)
                {
                    result.Should().Contain(new Coordinates(x, y));
                }
            }
        }

        [TestMethod]
        public void Coordinates_SizeAndOffsetProvided_ReturnedCoordinatesCorrect()
        {
            // Arrange
            var size = _fixture.Create<Coordinates>();
            var offset = new Coordinates(_fixture.Create<int>(), _fixture.Create<int>());

            // Act
            var result = Grid.GetAllCoordinatesByRow(size, offset).ToArray();

            // Assert
            for (var x = 0; x < size.X; x++)
            {
                for (var y = 0; y < size.Y; y++)
                {
                    result.Should().Contain(new Coordinates(x + offset.X, y + offset.Y));
                }
            }
        }
    }
}
