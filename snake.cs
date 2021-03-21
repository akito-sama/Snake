using System;
using System.Collections.Generic;

namespace snake_game
{
    public class snake
    {
        public string name{get;}
        public int lenght{get; set;}
        public List<(int, int)> body;
        private Game game;
        public (int, int) direction = (0, 1);
        public snake(string name, Game game){
            this.name = name;
            this.lenght = 3;
            List<(int, int)> body = new List<(int, int)>{(4, 2), (4, 3), (4, 4)};
            this.body = body;
            this.game = game;
        }
        public (int, int) getHead(){
            return body[body.Count - 1];
        }
        public void move(){
            (int, int) head = getHead();
            int x = head.Item1 + direction.Item1;
            int y = head.Item2 + direction.Item2;
            body.Add((x, y));
            eat();
        }
        public bool isDead(){
            (int, int) head = getHead();
            int x = head.Item1;
            int y = head.Item2;
            bool selfCollide = false;
            for (int i = 0; i < body.Count - 1; i++)
            {
                if (body[i] == (x, y)){
                    selfCollide = true;
                }
            }
            return selfCollide || x > game.screenHeight || x < 0 || y > game.screenWidth || y < 0;
        }
        public void eat(){
            if (getHead() == game.apple.coordinate){
                game.apple.randomize_pos();
                game.update();
            }
            else{
                body.Remove(body[0]);
            }
        }
    }
}