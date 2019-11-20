using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    public class TriangleRepository: ITriangleRepository
    {
        private readonly string FilePath;
        public TriangleRepository(string filePath)
        {
            FilePath = filePath;
        }
        public IReadOnlyList<string> GetAll()
        {
            if(!File.Exists(FilePath))
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllLines(FilePath);
        }
    }
}
