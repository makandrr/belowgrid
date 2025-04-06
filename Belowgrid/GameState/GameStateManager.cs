﻿namespace Belowgrid.GameState
{
    public class GameStateManager
    {
        private IGameState? _currentState;

        public void ChangeState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void Render()
        {
            _currentState?.Render();
        }
    }
}
