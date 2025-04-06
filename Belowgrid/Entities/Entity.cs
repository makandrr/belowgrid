using Belowgrid.Map;

namespace Belowgrid.Entities
{
    public class Entity
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public IBehavior? Behavior { get; set; }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual char GetSymbol()
        {
            return ' ';
        }

        public virtual void OnTick(GameMap gameMap) {
            Behavior?.Act(this, gameMap);
        }

        public Entity(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
