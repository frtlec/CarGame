using System;

namespace CarGame
{
    public class Engine
    {
        private Map Map { get; set; }
        private Car Car { get; set; }
        public Engine(int columnLength, int rowLength)
        {
            this.Map = CreateMap(10, 10);
        }
        public void CarRefresh(Car newCar)
        {
            //the position of the car changes
            CarClear();
            this.Car = newCar;
            PlaceCar(this.Car, this.Map);
            Draw(this.Map);
        }
        private void CarClear()
        {
            //all cars on the map are deleted
            this.Map._rows.ForEach(r =>
            {
                r._cells.ForEach(c =>
                {
                    c.CarClear();
                });
            });
        }
        private Map CreateMap(int columnLength, int rowLength)
        {
            //creating map
            Map map = new();
            for (int r = 1; r <= rowLength; r++)
            {
                //row
                Row row = new();
                for (int c = 1; c <= columnLength; c++)
                {  
                    //cells
                    row.SetCell(new Cell(c, r));

                }
                map.SetRow(row);
            }
            return map;
        }
        private void Draw(Map map)
        {
            //the map is drawn on the screen
            var rowId = 1;
            foreach (var row in map._rows)
            {

                foreach (var cell in row._cells)
                {
                    Console.BackgroundColor = cell.ConsoleColor;
                    Console.Write("__");
                    Console.Write("|");
                    Console.ResetColor();
                }
                Console.WriteLine(rowId);
                rowId++;


            }
            Console.WriteLine("");
            Console.WriteLine("__________________________________________");
        }
        private Map PlaceCar(Car car, Map map)
        {
            foreach (var row in map._rows)
            {
                foreach (var cell in row._cells)
                {
                    if (cell._x == car._currentPosition.X
                     && cell._y == car._currentPosition.Y)
                    {
                        cell.SetCar(car);
                    }
                }
            }

            return map;
        }
    }
}
