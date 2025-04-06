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
