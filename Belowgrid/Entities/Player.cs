using Belowgrid.Map;

namespace Belowgrid.Entities
{
    class Player : Entity
    {
        public override char GetSymbol()
        {
            return '▀';
        }

        public Player(int x, int y): base(x, y) { }
    }
}
