using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
   public class Wall:Point
    {
        
        private int playerPoints;

        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            this.InitializeWallBorder();
            this.PlayerInfo();
        }

        private void InitializeWallBorder()
        {
            SetHoriontalLine(0);
            SetHoriontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        private const char wallSymbol = '\u25A0';
        private void SetHoriontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }


        private void SetVerticalLine(int leftX)
        {

            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }

        }
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 || snake.LeftX == this.LeftX - 1
                || snake.TopY == this.TopY;
        }
        public void AddPoints(int points)
        {
            this.playerPoints += points;
        }
        public void PlayerInfo()
        {
            Console.SetCursorPosition(this.LeftX + 3, 0);
            Console.WriteLine($"Player points: {this.playerPoints}");
            Console.SetCursorPosition(this.LeftX + 3, 1);
            Console.WriteLine("Player level: ");
        }
    }
}
