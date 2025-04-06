using Belowgrid.Entities;
using Belowgrid.Map;
using Belowgrid.Utils;

namespace Belowgrid.GameState
{
    public class InGameState : IGameState
    {
        private GameMap _map;
        private PlayerController _controller;
        private Player _player;

        public InGameState(GameStateManager manager)
        {
            _map = new GameMap();
            _controller = new PlayerController();
            _player = new Player(0, 0) { Behavior = _controller };
            _map.Spawn(_player, 0, 0);
        }

        public void Enter() { }

        public void Update()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            _controller.SetKey(key);

            _map.TickAllEntities();
        }

        public void Render()
        {
            Printer.Clear();
            _map.GetCurrentRoom()?.Display();
        }

        public void Exit() { }
    }
}
