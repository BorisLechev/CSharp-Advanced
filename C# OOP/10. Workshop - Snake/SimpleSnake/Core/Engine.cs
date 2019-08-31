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
        private Direction direction;

        private Point[] pointsOfDirections;

        private Snake snake;

        private Wall wall;

        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.pointsOfDirections = new Point[4];
            this.sleepTime = 100;
        }

        public void Run()
        {
            while (true)
            {
                this.CreativeDirections();

                if (Console.KeyAvailable) // когато е натиснато
                {
                     this.GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.pointsOfDirections[(int)this.direction]); // enum посоки

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime); // изкуствено забавям играта 
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n: ");
            Console.SetCursorPosition(leftX, topY + 1);

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }

            else if (input == "n")
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

        private void CreativeDirections()
        {
            this.pointsOfDirections[0] = new Point(1, 0);
            this.pointsOfDirections[1] = new Point(-1, 0);
            this.pointsOfDirections[2] = new Point(0, 1);
            this.pointsOfDirections[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                // ако си натиснал да премине наляво, а се движи надясно, ще се самоизяде.
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }

            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }

            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }

            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            else if (userInput.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.CursorVisible = false;
        }
    }
}
