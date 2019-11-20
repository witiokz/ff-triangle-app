using System.Collections.Generic;

namespace Data
{
    public interface ITriangleRepository
    {
        IReadOnlyList<string> GetAll();
    }
}
