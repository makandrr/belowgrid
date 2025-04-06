using Belowgrid.Entities;
using Belowgrid.Utils;
using Belowgrid.Map;
using Belowgrid.Map.Room;
using Belowgrid.GameState;

namespace Belowgrid
{
    class Game
    {
        private GameStateManager _stateManager = new GameStateManager();

        public void Run()
        {
            _stateManager.ChangeState(new InGameState(_stateManager));

            while (true)
            {
                _stateManager.Update();
                _stateManager.Render();
            }
        }
    }
}

