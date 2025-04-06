namespace Belowgrid.GameState
{
    public interface IGameState
    {
        public void Enter();
        public void Update();
        public void Render();
        public void Exit();
    }
}
