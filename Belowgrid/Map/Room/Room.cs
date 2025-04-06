using Belowgrid.Entities;
using Belowgrid.Utils;

namespace Belowgrid.Map.Room
{   
    public class BaseRoom
    {
        public Entity?[,] roomGrid = new Entity?[10, 10];

        public BaseRoom(int x = 10, int y = 10)
        {
            roomGrid = new Entity?[x, y];
        }

        public void SetEntity(Entity entity, int x, int y)
        {
            roomGrid[x, y] = entity;
        }

        public void MoveEntity(int xFrom, int yFrom, int xTo, int yTo)
        {
            Entity? entityToMove = roomGrid[xFrom, yFrom];
            Entity? targetCellEntity = roomGrid[xTo, yTo];
            if (entityToMove != null && targetCellEntity == null)
            {
                roomGrid[xFrom, yFrom] = null;
                roomGrid[xTo, yTo] = entityToMove;
                entityToMove.Move(xTo, yTo);
            }
        }

        public Entity? GetEntity(int x, int y)
        {
            return roomGrid[x, y];
        }

        public bool CanMoveTo(int x, int y)
        {
            return x >= 0 && y >= 0 && x < roomGrid.GetLength(0) && y < roomGrid.GetLength(1) && roomGrid[x, y] == null;
        }

        public void Display()
        {
            for(int x = 0; x < roomGrid.GetLength(0) + 2; x++)
            {
                Printer.Print("#");
            }
            Printer.PrintLine("");
            for (int x = 0; x < roomGrid.GetLength(0); x++)
            {
                Printer.Print("#");
                for(int y = 0; y < roomGrid.GetLength(1); y++)
                {
                    Entity? entity = GetEntity(x, y);
                    if(entity != null)
                    {
                        Printer.Print(Convert.ToString(entity.GetSymbol()));
                    } else
                    {
                        Printer.Print(" ");
                    }
                }
                Printer.Print("#");
                Printer.PrintLine("");
            }
            for (int x = 0; x < roomGrid.GetLength(0) + 2; x++)
            {
                Printer.Print("#");
            }
        }
    }
}
