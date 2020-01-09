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
        public void Initialisation_StandardSetup_CoordinatesCorrect()
        {
            // Arrange
            var size = _fixture.Create<Coordinates>();
            var cells = _fixture.Create<Cell[]>();

            // Act
            var sut = new Grid(size, cells);
            var result = sut.GetAllCoordinatesByRow().ToArray();

            // Assert
            for (var x = 0; x < size.X; x++)
            {
                for (var y = 0; y < size.Y; y++)
                {
                    result.Should().Contain(new Coordinates(x, y));
                }
            }
        }
    }
}
