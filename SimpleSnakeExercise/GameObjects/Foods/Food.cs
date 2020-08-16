using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food:Point
    {
        public int FoodPoints { get; private set; }
        private char foodSymbol;
        
        private Random random;

        
        protected Food(char foodSymbol,int points)
            

        {
       
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
           
        }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, Console.WindowWidth- 2);
            this.TopY = this.random.Next(2, Console.WindowHeight - 2);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, Console.WindowHeight - 2);
                this.TopY = this.random.Next(2, Console.WindowHeight - 2);
                isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }


        public bool isFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
