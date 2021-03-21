using System;
using System.Collections.Generic;
using System.Threading;

namespace snake_game
{
    public class Game
    {
        public int screenWidth = 50;
        public int screenHeight = 22;
        public snake mySnake;
        Dictionary<string, (int, int)> mouvements;
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
        public Game(){
            snake mySnake = new snake("otomodatchi", this);
            this.mySnake = mySnake;
            Apple apple = new Apple(this);
            this.apple = apple;
            this.draw();
            Dictionary<string, (int, int)> dico = new Dictionary<string, (int, int)>{
                {"q", (0, -1)},
                {"d", (0, 1)},
                {"s", (1, 0)},
                {"z", (-1, 0)}
            };
            this.mouvements = dico;
            this.update();
        }
        public void draw(){
            for (int i = 0; i < screenHeight + 1; i++)
            {
                string str = "|";
                for (int j = 0; j < screenWidth + 1; j++)
                {
                    if ((i, j) == apple.coordinate){
                        str += "A";
                    }
                    else if (mySnake.body.Contains((i, j)))
                    {
                        if (mySnake.getHead() == (i, j))
                        {
                            str += "O";
                        }
                        else
                        {
                            str += "o";
                        }
                    }
                    else{
                        str += " ";
                    }
                }
                str += "|";
                System.Console.WriteLine(str);
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
                draw();
                Thread.Sleep(200);
                if (mySnake.isDead())
                    break;
            }
        }
        public void update(){
            score += 1;
            Console.Title = $"score : {score}";
        }
    }
}