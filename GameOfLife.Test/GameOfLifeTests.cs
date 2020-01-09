using System.Linq;
using FluentAssertions;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void Iteration_PopulatedGrid_NextStateCorrect()
        {
            // Arrange
            var sut = new GameOfLife(new Coordinates(5, 5), new []
            {
                new Coordinates(2, 1),
                new Coordinates(2, 2),
                new Coordinates(2, 3)
            });

            // Act
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
