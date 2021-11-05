using System.Collections.Generic;

namespace CarGame
{
    public class Row
    {
        public List<Cell> _cells { get; private set; } = new();


        public void SetCell(Cell column)
        {
            _cells.Add(column);
        }

    }

}
