using System.Collections.Generic;

namespace Model
{
    public class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }

        public List<int> Path { get; set; }
    }
}
