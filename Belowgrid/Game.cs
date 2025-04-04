using Belowgrid.Entities;
using Belowgrid.Utils;
using Belowgrid.UI;

namespace Belowgrid
{
    class Game
    {
        private GameState _state = GameState.MainMenu;
        private Player _player;


        private void InitializeState(GameState state)
        {
            _state = state;
            if (state == GameState.MainMenu)
            {
                Printer.PrintLine("--- BelowGrid ---");
            }
            else if (state == GameState.Game)
            {
                Printer.PrintLine("Game", ThemeColor.Success);
            }
        }
        public void Run()
        {
            InitializeState(GameState.Game);
        }
    }

    enum GameState
    {
        MainMenu,
        Game
    }
}