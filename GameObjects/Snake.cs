using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char WhiteSpace = ' ';
        private const char SnakeSymbol = '\u25CF';
        private readonly Queue<Point> snakeElements;

        private readonly Food[] foods;
        //private readonly ToxicFood[] toxicFoods;
        private readonly Random random;
        private readonly Wall wall;
        private int nextTopY;
        private int nextLeftX;
        private int foodindex;
       // private int toxicFoodindex;
        public int SnakeLengthCount => snakeElements.Count;
        private int score;
        private int level;
         
        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            random = new Random();
            this.foods = new Food[4];
           // toxicFoods = new ToxicFood[1];
            this.CreateSanke();
            
            score = 0;
            level = 0;
            
            LevelAndPoints();

            SpawnFood();
        }


        public bool IsMoving(Point direction)
        {

            Point currentSnakeHead = this.snakeElements.Last();
            this.GetNextPoint(direction, currentSnakeHead);
            bool isInSnake = snakeElements.Any(p => p.LeftX == nextLeftX && p.TopY == nextTopY);
            if (isInSnake)
            {
                return false;
            }
            Point nextSnakeHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(nextSnakeHead))
            {
                return false;
            }
            if (this.foods[foodindex].IsPointSnake(nextSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }
            //if (this.toxicFoods[toxicFoodindex].IsPointSnake(nextSnakeHead))
            //{
            //    EatToxic(direction, currentSnakeHead);
            //}



            nextSnakeHead.Draw(SnakeSymbol);
            snakeElements.Enqueue(nextSnakeHead);
            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(WhiteSpace);
            return true;
        }

        private void LevelAndPoints()
        {
            int Leftxs = wall.LeftX + 1;
            int topYs = 5;
            Console.SetCursorPosition(Leftxs, topYs);
            Console.Write($"Points: {score}");
            Console.SetCursorPosition(Leftxs, topYs + 1);
            Console.Write($"Level: {level}");
        }
        private void Eat(Point direction, Point currentSnakeHead)
        {
            int foodPoints = foods[foodindex].FoodPoints;
            score += foodPoints;
            this.level = score / 10 + 1;
            
                for (int i = 0; i < foodPoints; i++)
                {
                    snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                    GetNextPoint(direction, currentSnakeHead);
                }
        
         

            LevelAndPoints();
            //if (level > 0)
            //{
            //    SpawnToxicFood();
            //}

            SpawnFood();
          
        }

        //private void EatToxic(Point direction, Point currentSnakeHead)
        //{
        //    int foodPoints = toxicFoods[toxicFoodindex].FoodPoints;
        //    score += foodPoints;
        //    this.level = score / 10 + 1;

        //    for (int i = Math.Abs(foodPoints); i >= 0; i--)
        //    {
        //        snakeElements.Dequeue();
        //        GetNextPoint(direction, currentSnakeHead);
        //    }


        //    LevelAndPoints();
          

        //}

        public void SpawnFood()
        {
            foodindex = random.Next(0, foods.Length);
            SeedFoods();
            this.foods[foodindex].SetRandomposition(snakeElements);

        }

        //public void SpawnToxicFood()
        //{
        //    toxicFoodindex = random.Next(0, toxicFoods.Length);
        //    TosxicSeedFoods();
        //    this.toxicFoods[toxicFoodindex].SetRandomposition(snakeElements);

        //}


        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextTopY = snakeHead.TopY + direction.TopY;
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
        }
        private void CreateSanke()
        {
            for (int y = 1; y <= 6; y++)
            {
                this.snakeElements.Enqueue(new Point(2, y));
            }

           

        }

        private void SeedFoods()
        {
            this.foods[0] = new FoodAsterisk(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
            this.foods[3] = new GoldenApple(this.wall);
            
        }

        //private void TosxicSeedFoods()
        //{
        //    int num = snakeElements.Count;
        //    this.toxicFoods[0] = new PoisonFlower(this.wall , num);
            

        //}
    }
}
