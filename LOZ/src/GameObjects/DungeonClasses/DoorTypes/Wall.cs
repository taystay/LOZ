using Microsoft.Xna.Framework;

namespace LOZ.DungeonClasses
{
    internal class Wall : DoorTypeAbstract
    {
        public Wall(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateWall(n);
            itemLocation = location;
        }
    }
}
