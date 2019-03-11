using System;
using System.Collections.Generic;
using System.IO;

namespace Snake
{
    public class Wall : GameObject
    {
        enum GameLevel
        {
            FIRST,
            SECOND,
            THIRD
        }

        GameLevel gameLevel = GameLevel.FIRST;

        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();
        }

        public void LoadLevel()
        {
            body = new List<Point>();
            string fileName = "level1.txt";
            if (gameLevel == GameLevel.SECOND)
                fileName = "level2.txt";
            if (gameLevel == GameLevel.THIRD)
                fileName = "level3.txt";

            StreamReader sr = new StreamReader(fileName);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '*')
                        body.Add(new Point(j, i));
        }

        public void NextLevel()
        {
            if (gameLevel == GameLevel.FIRST)
                gameLevel = GameLevel.SECOND;
            else if (gameLevel == GameLevel.SECOND)
                gameLevel = GameLevel.THIRD;
            LoadLevel();
        }
    }




    public class Food : GameObject
    {
        public Food(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {
        }

        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(1, 100);
            int y = random.Next(1, 30);
            body[0].x = x;
            body[0].y = y;
        }
    }





    public class Game
    {
        List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;

        public Game()
        {
            g_objects = new List<GameObject>();
            snake = new Snake(10, 10, '*', ConsoleColor.White);
            food = new Food(50, 10, 'o', ConsoleColor.Cyan);
            wall = new Wall('#', ConsoleColor.Green);
            wall.LoadLevel();
            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();

            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);
                    
            isAlive = true;
        }

        public void Start()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while (isAlive && keyInfo.Key != ConsoleKey.Escape)
            {
                Draw();
                keyInfo = Console.ReadKey();
                if (snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();

                    if (snake.body.Count % 3 == 0)
                        wall.NextLevel();
                }
                if (snake.IsCollisionWithObject(wall))
                {
                    isAlive = false;
                }
                snake.Move(keyInfo);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("GAME OVER!!!");
            Console.ReadKey();
        }
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
                g.Draw();
        }
    }





    public class Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class GameObject
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public GameObject(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point>();
            Point p = new Point(x, y);
            body.Add(p);
            this.sign = sign;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public bool IsCollisionWithObject(GameObject obj)
        {
            // Check obj is instance of Snake 
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
    }

    public class Snake : GameObject
    {
        enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }
        Direction direction = Direction.None;
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {
        }

        public void Move(ConsoleKeyInfo consoleKey)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            if (consoleKey.Key == ConsoleKey.UpArrow)
                body[0].y--;
            if (consoleKey.Key == ConsoleKey.DownArrow)
                body[0].y++;
            if (consoleKey.Key == ConsoleKey.LeftArrow)
                body[0].x--;
            if (consoleKey.Key == ConsoleKey.RightArrow)
                body[0].x++;
        }
    }

       
    class Program
    {
        public static int cursor;

        public static void Color(string s, int i, int cursor)
        {
            if (i == cursor)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(s);
        }

        public static void Start()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                ShowMenu();
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (cursor > 0) { cursor--; } else cursor = 2;
                }
                else
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (cursor < 2) { cursor++; } else cursor = 0;
                }
            }
            if (cursor == 2) { return; } else { Game game = new Game(); game.Start(); }
        }

        public static void ShowMenu()
        {
            string[] Menu = new string[3];
            Menu[0] = "New Game";
            Menu[1] = "Continue";
            Menu[2] = "Exit";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Color(Menu[i], i, cursor);
            }
        }

        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            cursor = 0;
            Console.WriteLine("Write your username");
            string s = Console.ReadLine();
            Start();
            Console.Clear();
            Console.WriteLine(s);
            Console.Write("Your score:");
            Console.ReadKey();
        }
    }
}