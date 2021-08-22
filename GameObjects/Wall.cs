using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u2580';


        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.CreateBorders();
        }

        public bool IsPointOfWall(Point snake)
        {

            return snake.TopY == 0 || snake.LeftX == 0 || snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;

        }
        private void CreateBorders()
        {

            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);
            this.SetVerticalLine(this.LeftX -1);
            this.SetVerticalLine(0);

        }

        private void SetHorizontalLine(int topY)
        {
            for (int currentleftX = 0; currentleftX < this.LeftX; currentleftX++)
            {
                this.Draw(currentleftX, topY, WallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int currentTopY = 0; currentTopY < this.TopY; currentTopY++)
            {
                this.Draw(leftX, currentTopY, WallSymbol);
            }
        }
    }
}
