using System;

namespace CarGame
{
    public class Cell
    {
        public int _x { get; private set; }
        public int _y { get; private set; }
        public Car Car { get; private set; }
        private const ConsoleColor DefaultCellBackgroundColor= ConsoleColor.Black;
        public ConsoleColor ConsoleColor { get; private set; } = DefaultCellBackgroundColor;

        public Cell(int x,int y)
        {
            _x = x;
            _y = y;
        }

        public void SetCar(Car car)
        {
            if (car==null)
            {
                throw new System.Exception("Opps! car cannot be null");
            }
            this.Car = car;

            if (car._currentDirection!=null)
            {
                this.ConsoleColor = car._currentDirection.BackgroundColor;
            }
        }
        public void CarClear()
        {
            this.Car = null;
            this.ConsoleColor = DefaultCellBackgroundColor;
        }

    }

}
