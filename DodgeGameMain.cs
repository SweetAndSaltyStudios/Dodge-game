using System;

namespace DodgeGame
{
    class DodgeGameMain
    {
        static void Main()
        {
            Console.CursorVisible = false;

            Game newGame = new Game();

            newGame.Run();

            #region GAME_END

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            #endregion GAME_END
        }
    }
}
