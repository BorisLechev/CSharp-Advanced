namespace SimpleSnake
{
    using System;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);

            string copyRightText = "Snake game by Boris Lechev | C# OOP";

            Console.SetCursorPosition(wall.LeftX - copyRightText.Length, wall.TopY + 1);
            Console.Write(copyRightText);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
