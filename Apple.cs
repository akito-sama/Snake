using System;

namespace snake_game
{
    public class Apple
    {
        public int x_coordinate;
        public int y_coordinate;
        public (int, int) coordinate{get => (x_coordinate, y_coordinate);}
        public Random random = new Random();
        private Game game;
        public Apple(Game game){
            this.game = game;
            randomize_pos();
        }
        public void randomize_pos(){
            do {
            x_coordinate = random.Next(game.screenHeight);
            y_coordinate = random.Next(game.screenWidth);
            }
            while (game.mySnake.body.Contains((x_coordinate, y_coordinate)));
        }
    }
}