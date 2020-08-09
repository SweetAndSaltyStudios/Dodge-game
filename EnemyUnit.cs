using System;

namespace DodgeGame
{
    class EnemyUnit : BaseUnit
    {
        private int timeBetweenMoves = 100;
        private int timeSinceLastMove = 0;
        private int sleepTime = 0;

        public EnemyUnit(string unitGraphic, int x, int y) : base("X", x, y)
        {
            sleepTime = Game.Random.Next(0, 2000);
        }

        public override void Update(int deltaTime)
        {
       
            sleepTime -= deltaTime;
            if (sleepTime > 0)
            {
                return;
            }

            timeSinceLastMove += deltaTime;

            if (timeSinceLastMove < timeBetweenMoves)
            {
                return;
            }

            timeSinceLastMove -= timeBetweenMoves;

            EnemyAI();

            base.Update(deltaTime);
        }

        private void EnemyAI()
        {
            if (X > 0)
            {
                X--;
            }
            else
            {
                X = Console.WindowWidth - 1;
                Y = Game.Random.Next(0, Console.WindowHeight - 1);
                sleepTime = Game.Random.Next(0, 1000);
            }
        }

        public override void DrawUnit()
        {
            if (sleepTime > 0)
            {
                return;
            }

            base.DrawUnit();
        }
    }
}
