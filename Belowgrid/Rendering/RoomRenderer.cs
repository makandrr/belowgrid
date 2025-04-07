using Belowgrid.Map.Room;
using Belowgrid.Utils;

namespace Belowgrid.Rendering
{
    public class RoomRenderer
    {
        public void Render(BaseRoom room)
        {
            int width = room.roomGrid.GetLength(0);
            int height = room.roomGrid.GetLength(1);

            for (int x = 0; x < width + 2; x++) Printer.Print("#");
            Printer.PrintLine("");

            for (int x = 0; x < width; x++)
            {
                Printer.Print("#");
                for (int y = 0; y < height; y++)
                {
                    var entity = room.GetEntity(x, y);
                    if (entity != null)
                    {
                        Printer.Print(entity.GetSymbol().ToString());
                    }
                    else
                    {
                        Printer.Print(" ");
                    }
                }
                Printer.Print("#");
                Printer.PrintLine("");
            }

            for (int x = 0; x < width + 2; x++) Printer.Print("#");
            Printer.PrintLine("");
        }
    }
}
