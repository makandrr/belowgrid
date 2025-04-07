using Belowgrid.GameState;
using Belowgrid.Input;

namespace Belowgrid
{
    class Game
    {
        private GameStateManager _stateManager = new GameStateManager();
        private InputManager _input = new InputManager();

        public void Run()
        {
            _stateManager.ChangeState(new InGameState(_stateManager));

            while (true)
            {
                _input.PollInput();

                _stateManager.Update(_input);
                _stateManager.Render();

                Thread.Sleep(66);
            }
        }
    }
}

