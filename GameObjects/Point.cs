using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int leftX , int topY)
        {
            LeftX = leftX;
            TopY = topY;

        }
        public int LeftX { get; set; }
        public int TopY { get; set; }

        public void Draw(char sumbol)
        {
            //Console.SetCursorPosition(LeftX, TopY);
            //Console.Write(sumbol);
            this.Draw(this.LeftX, this.TopY , sumbol);

            
        }

        public void Draw(int leftX,int topY ,char sumbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(sumbol);


        }
    }
}
