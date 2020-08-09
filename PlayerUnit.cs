using System;

namespace DodgeGame
{
    class PlayerUnit : BaseUnit
    {
        public PlayerUnit(string unitGraphic, int x, int y) : base("@", x, y)
        {

        }

        public override void Update(int deltaTime)
        {
            if(Console.KeyAvailable)
            {
                PlayerInputs(Console.ReadKey(true));
            }

            base.Update(deltaTime);
        }
   
        private void PlayerInputs(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if(Y > 0)
                    {
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if(Y< Console.WindowHeight - 1)
                    {
                        Y++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (X > 0)
                    {
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (X < Console.WindowWidth - 1)
                    {
                        X++;
                    }
                    break;           
            }
        }
    }
}
