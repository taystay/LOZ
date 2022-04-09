using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.DungeonClasses
{
    internal class DoorObject : DoorTypeAbstract
    {
        public DoorObject(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateDoorWay(n);
            itemLocation = location;

        }
    }
}
