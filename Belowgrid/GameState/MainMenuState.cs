using Belowgrid.Input;
using Belowgrid.Utils;

namespace Belowgrid.GameState
{
    public class MainMenuState : IGameState
    {
        private readonly GameStateManager _manager;

        public MainMenuState(GameStateManager manager)
        {
            _manager = manager;
        }

        public void Enter()
        {
            Printer.Clear();
            Printer.PrintLine("--- BelowGrid ---");
        }

        public void Render() { }

        public void Update(InputManager input) { }

        public void Exit() { }
    }
}
