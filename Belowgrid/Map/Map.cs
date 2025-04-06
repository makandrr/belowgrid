using Belowgrid.Entities;
using Belowgrid.Map.Room;

namespace Belowgrid.Map
{
    public class GameMap
    {
        private BaseRoom?[,] rooms = new BaseRoom?[10, 10];

        private (int, int) currentRoomCoord = (0, 0);

        public BaseRoom? GetCurrentRoom()
        {
            return rooms[currentRoomCoord.Item1, currentRoomCoord.Item2];
        }

        public void Spawn(Entity entity, int x, int y) 
        {
            BaseRoom? currentRoom = GetCurrentRoom();
            if (currentRoom != null)
            {
                entity.Move(x, y);
                currentRoom.SetEntity(entity, x, y);
            }
        }

        public void MoveWithinCurrentRoom(int fromX, int fromY, int toX, int toY)
        {
            BaseRoom? currentRoom = GetCurrentRoom();
            Entity? entity = currentRoom?.GetEntity(fromX, fromY);
            if(currentRoom != null && entity != null)
            {
                currentRoom.MoveEntity(fromX, fromY, toX, toY);
                entity.Move(toX, toY);
            }
        }

        public void TickAllEntities()
        {
            var room = GetCurrentRoom();
            if (room == null) return;

            for(int x = 0; x < room.roomGrid.GetLength(0); x++)
            {
                for(int y = 0; y < room.roomGrid.GetLength(1); y++)
                {
                    Entity? entity = room.GetEntity(x, y);
                    entity?.OnTick(this);
                }
            }
        }

        public GameMap() {
            for (int x = 0; x < rooms.GetLength(0); x++)
            {
                for (int y = 0; y < rooms.GetLength(1); y++)
                {
                    BaseRoom room = new BaseRoom();

                    rooms[x, y] = room;
                }
            }
        }
    }
}
