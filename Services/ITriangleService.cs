using Model;
using System.Collections.Generic;

namespace Services
{
    public interface ITriangleService
    {
        IEnumerable<Cell> CalculateCellData();
    }
}
