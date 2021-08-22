namespace SimpleSnake

{
    using Utilities;
    using SimpleSnake.GameObjects;
    using System.Collections.Generic;
    using SimpleSnake.Core;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            
            Wall wall = new Wall(80, 20);
            Snake snake = new Snake(wall);
            
          
            Engine engine = new Engine(wall, snake);
            engine.Run();
            
        }
    }
}
