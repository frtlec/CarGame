using System;

namespace CarGame
{
    public class Direction
    {
        public string DirectionSymbol { get; set; }
        public int Degree { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public EffectDirection EffectDirection { get; internal set; }
    }
}
