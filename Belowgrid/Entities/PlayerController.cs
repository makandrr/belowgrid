using Belowgrid.Map;

namespace Belowgrid.Entities
{
    public class PlayerController : IBehavior
    {
        private ConsoleKey? _lastKey = null;

        public void SetKey(ConsoleKey key)
        {
            _lastKey = key;
        }

        private void TryInteract(Entity self, GameMap map)
        {
            var room = map.GetCurrentRoom();
            if (room == null) return;

            int x = self.X;
            int y = self.Y;

            (int dx, int dy)[] directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

            foreach (var (dx, dy) in directions)
            {
                int nx = x + dx;
                int ny = y + dy;
                var target = room.GetEntity(nx, ny);
                if (target != null)
                {
                    target.Interact(self, map);
                    return;
                }
            }
        }

        public void Act(Entity self, GameMap map)
        {
            if (_lastKey == null) return;

            int dx = 0;
            int dy = 0;

            switch (_lastKey) {
                case ConsoleKey.W: dx = -1; break;
                case ConsoleKey.S: dx = 1; break;
                case ConsoleKey.A: dy = -1; break;
                case ConsoleKey.D: dy = 1; break;
                case ConsoleKey.E:
                    TryInteract(self, map);
                    _lastKey = null;
                    return;
            }

            _lastKey = null;

            var room = map.GetCurrentRoom();
            if (room == null) return;

            int newX = self.X + dx;
            int newY = self.Y + dy;

            if (room.CanMoveTo(newX, newY))
            {
                room.MoveEntity(self.X, self.Y, newX, newY);
                self.Move(newX, newY);
            }
        }
    }
}
