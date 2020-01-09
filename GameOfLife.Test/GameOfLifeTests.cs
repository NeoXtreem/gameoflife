using System.Linq;
using AutoFixture;
using FluentAssertions;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test
{
    [TestClass]
    public class GameOfLifeTests
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void Initialisation_StandardSetup_ValidState()
        {
            // Arrange
            var size = _fixture.Create<Coordinates>();
            var coordinatesList = _fixture.Create<Coordinates[]>();

            // Act
            var sut = new GameOfLife(size, coordinatesList);

            // Assert
            sut.Grid.Size.X.Should().Be(size.X);
            sut.Grid.Size.Y.Should().Be(size.Y);
            sut.Grid.Cells.Should().HaveCount(coordinatesList.Length);
            sut.Grid.Cells.Select(c => c.Coordinates).Should().Contain(coordinatesList);
        }

        [TestMethod]
        public void Iteration_PopulatedGrid_NextStateCorrect()
        {
            // Arrange
            var size = new Coordinates(5, 5);
            var coordinatesList = new[]
            {
                new Coordinates(2, 1),
                new Coordinates(2, 2),
                new Coordinates(2, 3)
            };

            // Act
            var sut = new GameOfLife(size, coordinatesList);
            sut.NextGeneration();

            // Assert
            var expectedAliveCells = new[]
            {
                new Coordinates(1, 2),
                new Coordinates(2, 2),
                new Coordinates(3, 2)
            }.ToHashSet();

            sut.Grid.Cells.Should().HaveCount(3);
            foreach (var cell in sut.Grid.Cells)
            {
                expectedAliveCells.Should().Contain(cell.Coordinates);
            }
        }
    }
}
