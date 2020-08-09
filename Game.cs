using System;
using System.Threading;
using System.Diagnostics;

namespace DodgeGame
{
    class Game
    {
        public static Random Random { get; set; }

        private BaseUnit playerUnit;
        private EnemyUnit[] enemyUnits;
        private Stopwatch stopwatch;
        private readonly int timeoutInMilliseconds = 5;
        private readonly int numberOfEnemies = 10;

        public Game()
        {
            stopwatch = new Stopwatch();

            playerUnit = new PlayerUnit("@", 10, 10);

            enemyUnits = new EnemyUnit[numberOfEnemies];

            Random = new Random();

            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemyUnits[i] = new EnemyUnit("X", Console.WindowWidth - 1, Random.Next(0, Console.WindowHeight - 1));
            }
        }

        public void Run()
        {
            stopwatch.Start();

            long timeAtPreviousFrame = stopwatch.ElapsedMilliseconds;

            while (true)
            {
                int deltaTime = (int)(stopwatch.ElapsedMilliseconds - timeAtPreviousFrame);
                timeAtPreviousFrame = stopwatch.ElapsedMilliseconds;

                playerUnit.Update(deltaTime);

                for (int i = 0; i < enemyUnits.Length; i++)
                {
                    enemyUnits[i].Update(deltaTime);

                    if (playerUnit.IsColliding(enemyUnits[i]))
                    {
                        GameOver();
                        return;
                    }
                }

                playerUnit.DrawUnit();

                foreach (var enemyUnit in enemyUnits)
                {
                    enemyUnit.DrawUnit();
                }

                Thread.Sleep(timeoutInMilliseconds);
            }         
        }       
        
        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER !");
            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            Console.ReadKey();
        }
    }
}
