using Belowgrid.Entities;
using Belowgrid.Input;
using Belowgrid.Map;
using Belowgrid.Rendering;
using Belowgrid.Utils;

namespace Belowgrid.GameState
{
    public class InGameState : IGameState
    {
        private GameMap _map;
        private RoomRenderer _roomRenderer = new RoomRenderer();
        private PlayerController _controller;
        private Player _player;
        private GameStateManager _gameStateManager;

        public InGameState(GameStateManager manager)
        {
            _map = new GameMap();
            _controller = new PlayerController();
            _player = new Player(0, 0) { Behavior = _controller };
            _map.Spawn(_player, 0, 0);
            _gameStateManager = manager;
        }

        public void Enter() {
            var chest = new Chest(3, 3);
            _map.Spawn(chest, 3, 3);
            var chest2 = new Chest(6, 6);
            _map.Spawn(chest2, 6, 6);
            var chest3 = new Chest(8, 2);
            _map.Spawn(chest3, 8, 2);
            Render();
        }

        public void Update(InputManager input)
        {
            var key = input.GetKey();
            if (key == null)
            {
                return;
            }

            if(key == ConsoleKey.Escape)
            {
                _gameStateManager.ChangeState(new MainMenuState(_gameStateManager));
                return;
            }

            _controller.SetKey(key.Value);

            _map.TickAllEntities();
        }

        public void Render()
        {
            Printer.Clear();
            var room = _map.GetCurrentRoom();
            if(room != null)
            {
                _roomRenderer.Render(room);
            }
        }

        public void Exit() { }
    }
}
