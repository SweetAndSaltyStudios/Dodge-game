using System;

namespace DodgeGame
{
    public abstract class BaseUnit
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0 || value >= Console.WindowWidth)
                {
                    throw new Exception("Invalid x coordinate!");
                }

                UndrawUnit();
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0 || value >= Console.WindowHeight)
                {
                    throw new Exception("Invalid y coordinate!");
                }

                UndrawUnit();
                y = value;
            }
        }
        public string UnitGraphic
        {
            get;
            private set;
        }

        public bool IsColliding(BaseUnit otherUnit)
        {
            return x == otherUnit.x && y == otherUnit.y ? true : false;
        }

        public BaseUnit(string unitGraphic = "@", int x = 0, int y = 0)
        {
            X = x;
            Y = y;
            UnitGraphic = unitGraphic;
        }      

        public virtual void Update(int deltaTime)
        {

        }

        public virtual void DrawUnit()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(UnitGraphic);
        }

        public void UndrawUnit()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
