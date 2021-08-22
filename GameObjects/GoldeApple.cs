using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class GoldenApple : Food
    {
        private const char FoodSymbol = 'X';
        private const int Points = 30;
        public GoldenApple(Wall wall) : base(wall, FoodSymbol, Points)
        {
        }
        public override void DrawFood()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;


            this.Draw(this.foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
