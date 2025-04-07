using Belowgrid.Input;

namespace Belowgrid.GameState
{
    public interface IGameState
    {
        public void Enter();
        public void Update(InputManager input);
        public void Render();
        public void Exit();
    }
}
