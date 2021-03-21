using System;
using System.Collections.Generic;
using System.Threading;

namespace snake_game
{
    public class Game
    {
        public int screenWidth = 60;
        public int screenHeight = 22;
        public snake mySnake;
        Dictionary<string, (int, int)> mouvements = new Dictionary<string, (int, int)>{
                {"q", (0, -1)},
                {"d", (0, 1)},
                {"s", (1, 0)},
                {"z", (-1, 0)}
            };
        public int score = -1;
        Dictionary<char, char> opposite = new Dictionary<char, char>()
            {
                {'z', 's'},
                {'s', 'z'},
                {'d', 'q'},
                {'q', 'd'}
            };
        char directChar = Convert.ToChar('d');
        public Apple apple;
        public char[][] table;
        bool error = false;
        
        public Game(){
            this.mySnake = new snake("otomodatchi", this);
            this.apple = new Apple(this);
            this.update();
            this.table = new char[screenHeight][];
            for (int i = 0; i < screenHeight; i++)
            {
                this.table[i] = new char[screenWidth];
                for (int j = 0; j < screenWidth; j++)
                {
                    this.table[i][j] = ' ';
                }
            }
            this.draw();
        }
        public void draw(){
            foreach ((int, int) item in mySnake.body)
            {
                table[item.Item1][item.Item2] = 'o';
            }
            int x = mySnake.getHead().Item1;
            int y = mySnake.getHead().Item2;
            table[x][y] = 'O';
            table[apple.x_coordinate][apple.y_coordinate] = 'A';
            foreach (var item in table)
            {
                System.Console.Write('|');
                System.Console.Write(item);
                System.Console.WriteLine('|');

            }
        }
        void change(){
            if (Console.KeyAvailable){
                char key = Console.ReadKey(true).KeyChar;
                if ("zsdq".Contains(key) && verify(key)){
                    mySnake.direction =  mouvements[key.ToString()];
                    directChar = key;
                }
            }
        }
        bool verify(char lettre){
            return opposite[lettre] != directChar;
        }
        public void start(){
            while (true){
                Console.Clear();
                change();
                mySnake.move();
                try{
                    draw();
                }
                catch (IndexOutOfRangeException){
                    error = true;
                    foreach (var item in table)
                    {
                        System.Console.Write('|');
                        System.Console.Write(item);
                        System.Console.WriteLine('|');

                    }
                }
                if ((200 - score * 3 >= 50))
                    Thread.Sleep(200 - score * 4);
                else
                    Thread.Sleep(50);
                if (error == true || mySnake.isDead())
                    break;
            }
        }
        public void update(){
            score += 1;
            Console.Title = $"score : {score}";
        }
    }
}