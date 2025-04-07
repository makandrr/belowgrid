using Belowgrid.Map;
using Belowgrid.Utils;

namespace Belowgrid.Entities
{

    class Chest : Entity
    {
        private bool _opened = false;

        public override char GetSymbol()
        {
            return _opened ? 'O' : 'C';
        }

        public override void Interact(Entity source, GameMap map)
        {
            base.Interact(source, map);
            if (_opened)
            {
                return;
            }

            _opened = true;
        }

        public Chest(int x, int y): base(x, y) { }
    }
}
