using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly Dictionary<Direction , Point> directions;
        private Direction direction;
        private readonly Snake snake;
        private readonly Wall wall;
        private double sleepHorizontal;
        private double sleepVertical;
       

        public Engine(Wall wall , Snake snake)
        {
            direction = Direction.Right;
            directions = new Dictionary<Direction, Point>();
            SeedDirectionpoints();
            this.snake = snake;
            this.wall = wall;
            sleepHorizontal = 75;
            sleepVertical = 150;
        }


        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }
                Point currentPointDirection = directions[direction];
               bool IsMoved = snake.IsMoving(currentPointDirection);

                if (direction == Direction.Left || direction == Direction.Right)
                {
                    sleepHorizontal -= 0.01;
                   

                    Thread.Sleep((int)sleepHorizontal);
                }
                else
                {
                    sleepVertical -= 0.01;

                    Thread.Sleep((int)sleepVertical);
                }
               
             
                if (!IsMoved)
                {
                    AskForRestart();
                    break;
                }
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.Up)
                    {
                        direction = Direction.Down;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.Down)
                    {
                        direction = Direction.Up;
                    }
                    break;
            }


        }

    
     
        private void AskForRestart()
        {
            //int Leftx = wall.LeftX + 1;
            //int topY = 3;
            int Leftx = 20;
            int topY = 5;
            Console.SetCursorPosition(Leftx, topY);
            Console.Write("Would you like to continue?");
            Console.SetCursorPosition(Leftx, topY + 1);
            Console.Write("Yes/ Enter || No / Any word + Enter");
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }
        private void SeedDirectionpoints()
        {
            directions.Add(Direction.Right, new Point(1, 0));
            directions.Add(Direction.Left, new Point(- 1, 0));
            directions.Add(Direction.Down, new Point(0, 1));
            directions.Add(Direction.Up, new Point(0, -1));
            
        }


    }
}
