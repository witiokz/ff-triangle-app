using Services;
using System;
using System.Linq;

namespace FFTriangleApp
{
    public class ConsoleApplication
    {
        private readonly ITriangleService _triangleItemService;

        public ConsoleApplication(ITriangleService triangleItemService)
        {
            _triangleItemService = triangleItemService;
        }

        public void Run()
        {
            var cellData = _triangleItemService.CalculateCellData();

            var firstNode = cellData.FirstOrDefault(i => i.X == 0 && i.Y == 0);

            Console.WriteLine("Output:");
            Console.WriteLine($"Max sum: {firstNode?.Path?.Sum()}");
            Console.WriteLine($"Path: {string.Join(", ", firstNode.Path)}");
            Console.ReadLine();
        }
    }
}
