using System.Collections.Generic;

namespace CarGame
{
    public class Column
    {
        public List<Cell> _cells { get; private set; } = new();

        public void SetCell(Cell cell)
        {
            _cells.Add(cell);
        }
    }

}
