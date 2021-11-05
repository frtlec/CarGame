using System;
using System.Linq;
using System.Text;

namespace CarGame
{
    class Program
    {
        const int MapXLength = 10;
        const int MapYLength = 10;
        const string OverMaxLengthError = "Haritanın dışına çıkamazsın";

        static int GetXCordinatInput()
        {
            int numberX;
            do
            {
                Console.WriteLine("----------------");
                Console.Write("X:");
            } while (!int.TryParse(Console.ReadLine(), out numberX) || numberX > MapXLength);

            return numberX;
        }
        static int GetYCordinatInput()
        {
            int numberY;
            do
            {
                Console.WriteLine("----------------");
                Console.Write("Y:");
            } while (!int.TryParse(Console.ReadLine(), out numberY) || numberY > MapYLength);

            return numberY;
        }
        static string GetDirectionInput()
        {
            Console.Write("Yönü:");
            string inputRotate = Console.ReadLine();
            inputRotate = InputRotateToFill(inputRotate);

            return inputRotate;
        }
        static void Main(string[] args)
        {
            //L sol
            //R Sağ
            //F İleri


            var engine = new Engine(MapXLength, MapYLength);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Başlangıç noktanı belirle:");
            Console.WriteLine("           X<=10,Y<=10           ");
            Console.WriteLine("(N)KUZEY,(S)GÜNEY,(E)DOĞU,(W)BATI:");
            Console.ResetColor();
            int numberX= GetXCordinatInput();
            int numberY= GetYCordinatInput();
            string inputRotate = GetDirectionInput();
            var direction = Definitions.directions.Find(f => f.DirectionSymbol.ToLower()
            == inputRotate.ToString().ToLower());
            var position = new Position { X = numberX, Y = numberY };
            var car = new Car(position, direction);
            engine.CarRefresh(car);
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("(F)İLERİ,(L)SOLA,(R)SAĞA:");
                var INPUT_2 = Console.ReadLine();
                char[] input2Array = INPUT_2.ToCharArray();
                var historyChar = "";
                foreach (var character in input2Array)
                {
                    var str = character.ToString();
                    historyChar += str;
                    Direction newDirection = car.UseSteeringWhell(car, str);
                    Position newPosition = car.Forward(car, str);

                    if (!PositionValidator(newPosition))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine(OverMaxLengthError);
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("---------------------------");
                        Console.ResetColor();
                        continue;
                    }
                    car.Drive(newPosition, newDirection);
                    engine.CarRefresh(car);
                    Console.WriteLine(historyChar);
                }
            }
            Console.ReadLine();


        }
        static bool PositionValidator(Position position)
        {
            return MapXLength >= position.X
                && MapYLength >= position.Y
                && position.X > 0
                && position.Y > 0;
        }
        static string InputRotateToFill(string input)
        {
            string InputRotate = "N";//default
            if (Definitions.directions.Any(f => f.DirectionSymbol == input))
            {
                InputRotate = input;
            }
            return InputRotate;
        }

    }
}
