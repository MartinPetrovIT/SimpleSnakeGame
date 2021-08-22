using System.Collections.Generic;

namespace SimpleSnake.GameObjects
{
    public  class PoisonFlower : ToxicFood
    {
        private const char FoodSymbol = '!';
        private int points;
        public PoisonFlower(Wall wall , int count) : base(wall, FoodSymbol)
        {
            this.points = -(count / 2);

        }
    }
}
