using System;
using GameOfLife.Models;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameOfLife = new GameOfLife(new Coordinates(5, 5), new[]
            {
                new Coordinates(2, 1),
                new Coordinates(2, 2),
                new Coordinates(2, 3)
            });

            do
            {
                Console.Clear();
                Console.WriteLine(gameOfLife.Render());
                Console.WriteLine("Press Enter to go to next generation...");

                gameOfLife.NextGeneration();
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}
