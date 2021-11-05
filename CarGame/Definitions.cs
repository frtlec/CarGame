using System;
using System.Collections.Generic;

namespace CarGame
{
    public static class Definitions
    {
        public static List<Direction> directions = new()
        {
            new()
            {
                DirectionSymbol = "N",
                Degree = 0,
                BackgroundColor = ConsoleColor.Blue,
                EffectDirection = new EffectDirection() { Direction = "y", Effect = -1 }
            },
            new()
            {
                DirectionSymbol = "S",
                Degree = 180,
                BackgroundColor = ConsoleColor.Yellow,
                EffectDirection = new EffectDirection() { Direction = "y", Effect = 1 }
            },
            new()
            {
                DirectionSymbol = "E",
                Degree = 90,
                BackgroundColor = ConsoleColor.Red,
                EffectDirection = new EffectDirection() { Direction = "x", Effect = 1 }
            },
            new()
            {
                DirectionSymbol = "W",
                Degree = 270,
                BackgroundColor = ConsoleColor.Green,
                EffectDirection = new EffectDirection() { Direction = "x", Effect = -1 }
            }
        };
        public static List<Command> commands = new()
        {
            new() { KeyLetter = "L", EffectOnDegree = -90, Rotation = true },
            new() { KeyLetter = "R", EffectOnDegree = 90, Rotation = true },
            new() { KeyLetter = "F", Rotation = false }
        };

    }
}
