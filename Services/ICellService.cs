using Model;
using System.Collections.Generic;

namespace Services
{
    public interface ICellService
    {
        IReadOnlyList<Cell> MapLinesToCells(IReadOnlyList<string> lines);
        Cell GetValidChild(Cell currentNode, Cell leftChild, Cell rightChild);

        Cell FillNodePathIFEmpty(Cell node);
    }
}
