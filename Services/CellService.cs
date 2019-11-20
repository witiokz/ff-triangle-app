using Model;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CellService: ICellService
    {
        public IReadOnlyList<Cell> MapLinesToCells(IReadOnlyList<string> lines)
        {
            var cells = new List<Cell>(0);

            for (var i = 0; i < lines.Count(); i++)
            {
                var lineParts = lines.ElementAt(i).Split(' ');

                for (var j = 0; j < lineParts.Length; j++)
                {
                    int.TryParse(lineParts[j], out int value);
                    cells.Add(new Cell { X = j, Y = i, Value = value });
                }
            }

            return cells;
        }

        public Cell GetValidChild(Cell currentNode, Cell leftChild, Cell rightChild)
        {
            var validLeftChild = ValidateChild(currentNode, leftChild);
            var validRightChild = ValidateChild(currentNode, rightChild);

            if (validLeftChild != null && validRightChild != null)
            {
                return leftChild.Path?.Sum() > rightChild.Path?.Sum() ? leftChild : rightChild;
            }

            return validLeftChild ?? validRightChild;
        }

        private static Cell ValidateChild(Cell currentNode, Cell child)
        {
            if(currentNode?.Value % 2 != child?.Value % 2)
            {
                return child;
            }

            return null;
        }
    }
}
