namespace CarGame
{
    public class Car
    {
        public Position _currentPosition { get; private set; }
        public Direction _currentDirection { get; private set; }

        public Car(Position currentPosition, Direction currentDirection)
        {
            _currentPosition = currentPosition;
            _currentDirection = currentDirection;
        }
        public void Drive(Position newPosition,Direction newDirection)
        {
            _currentPosition = newPosition;
            _currentDirection = newDirection;
        }
        public Position Forward(Car car, string keyLetter)
        {
            Position currentPosition = car._currentPosition;
            Direction currentDirection = car._currentDirection;

            var command = Definitions.commands.Find(f => f.KeyLetter.ToLower() == keyLetter.ToLower());

            if (command.Rotation == false)
            {
                var directionName = currentDirection.EffectDirection.Direction;
                var effect = currentDirection.EffectDirection.Effect;

                Position newPosition = new();
                newPosition.X = car._currentPosition.X;
                newPosition.Y = car._currentPosition.Y;
                if (directionName.ToLower() == "x")
                {
                    newPosition.X += effect;

                }
                else
                {
                    newPosition.Y += effect;
                }


                return newPosition;
            }

            return currentPosition;
        }
        public Direction UseSteeringWhell(Car car,string keyLetter)
        {
            Direction direction = car._currentDirection;

            var command = Definitions.commands.Find(f => f.KeyLetter.ToLower() == keyLetter.ToLower());
            if (command.Rotation == true)
            {
                var deg = direction.Degree + command.EffectOnDegree;


                if (deg == 360)
                {
                    deg = 0;
                }
                if (deg == -90)
                {
                    deg = 270;
                }
                return Definitions.directions.Find(f => f.Degree == deg);
            }

            return direction;
        }
    }
}
