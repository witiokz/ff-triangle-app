using Data;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class TriangleService : ITriangleService
    {
        private readonly ITriangleRepository _triangleItemRepository;
        private readonly ICellService _cellService;
        public TriangleService(ITriangleRepository triangleItemRepository, ICellService cellService)
        {
            _triangleItemRepository = triangleItemRepository;
            _cellService = cellService;
        }

        public IEnumerable<Cell> CalculateCellData()
        {
            var items = _triangleItemRepository.GetAll();

            var cells = _cellService.MapLinesToCells(items);

            return Process(items.Count, cells);
        }

        private IEnumerable<Cell> Process(int linesCount, IEnumerable<Cell> cells)
        {
            for (var y = linesCount - 2; y >= 0; y--)
            {
                for (int x = 0; x < cells.Count(i => i.Y == y); x++)
                {
                    var currentNode = cells.FirstOrDefault(i => i.X == x && i.Y == y);
                    var leftChild = cells.FirstOrDefault(i => i.X == x && i.Y == y + 1);
                    var rightChild = cells.FirstOrDefault(i => i.X == x + 1 && i.Y == y + 1);

                    var chosenPathNode = _cellService.GetValidChild(currentNode, leftChild, rightChild);

                    if (chosenPathNode != null)
                    {
                        _cellService.FillNodePathIFEmpty(currentNode);
                        _cellService.FillNodePathIFEmpty(chosenPathNode);

                        currentNode.Path.AddRange(chosenPathNode.Path);
                    }
                }
            }

            return cells;
        }
    }
}
