using System.Collections.Generic;

namespace CarGame
{
    public class Map
    {
        public List<Row> _rows { get; private set; } = new();
        public void SetRow(Row row)
        {
            _rows.Add(row);
        }

    }

}
