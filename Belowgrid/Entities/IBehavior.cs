using Belowgrid.Map;

namespace Belowgrid.Entities
{
    public interface IBehavior
    {
        void Act(Entity self, GameMap map);
    }
}
