using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {

        private Queue<Point> snakeELements;
        private Food[] foods;
     
        private int nextLeftX;
        private const char snakeSymbol = '\u25FC';
        private int nextTopY;
        private int foodIndex;
        public int RandomFoodNumber => 
            new Random().Next(0, this.foods.Length);




        public Snake()
        {
            
            
            this.snakeELements = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
            
        }

    

        private void CreateSnake()
        {
            for (int i = 1; i <= 6; i++) 
            {
                this.snakeELements.Enqueue(new Point(2, i));
            }
            this.foods[this.foodIndex].SetRandomPosition(this.snakeELements);

        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeELements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeELements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if(isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (snakeNewHead.LeftX == -1)
            {
                snakeNewHead.LeftX = Console.WindowWidth - 1;
            }
            else if (snakeNewHead.LeftX == Console.WindowWidth) 
            {
                snakeNewHead.LeftX = 0;
            }

            if (snakeNewHead.TopY == -1)
            {
                snakeNewHead.TopY = Console.WindowHeight - 1;
            }
            else if (snakeNewHead.TopY == Console.WindowHeight) 
            {
                snakeNewHead.TopY = 0;
          
            }
            /*
            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }*/
            this.snakeELements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if(foods[foodIndex].isFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }
            Point snakeTail = this.snakeELements.Dequeue();
            snakeTail.Draw(' ');


            return true;
        }



        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeELements
                    .Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

          
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeELements);

           
                    
        }



        private void GetFoods()
        {
            this.foods[0] = new FoodHash();
            this.foods[1] = new FoodDollar();
            this.foods[2] = new FoodAsterisk();

        }


        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
           
            

                   
    }
}
