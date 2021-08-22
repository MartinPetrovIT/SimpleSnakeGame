using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class ToxicFood : Point
    {
       
        private readonly Random random;
        protected readonly char toxicFoodSymbol;
        private readonly Wall wall;


        protected ToxicFood(Wall wall, char symbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.random = new Random();
            toxicFoodSymbol = symbol;
            this.FoodPoints = points;
            this.wall = wall;
        }
        protected ToxicFood(Wall wall, char symbol)
           : base(wall.LeftX, wall.TopY)
        {
            this.random = new Random();
            toxicFoodSymbol = symbol;
         
            this.wall = wall;
        }
        public int FoodPoints { get; set; }


        public void SetRandomposition(Queue<Point> snakeElements)
        {


            bool foodSnake = true;

            while (foodSnake)
            {
                this.LeftX = this.random.Next(2, wall.LeftX - 2);
                this.TopY = this.random.Next(2, wall.TopY - 2);

                foodSnake = snakeElements.Any(
                    p => p.TopY == this.TopY &&
                   p.LeftX == this.LeftX);
            }

            DrawFood();
        }

        public virtual void DrawFood()
        {
            Console.BackgroundColor = ConsoleColor.Red;


            this.Draw(this.toxicFoodSymbol);
            Console.BackgroundColor = ConsoleColor.White;

        }


        public bool IsPointSnake(Point snake)
        {

            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;

        }
    }
}
