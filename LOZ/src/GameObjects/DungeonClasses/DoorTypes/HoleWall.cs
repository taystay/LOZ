using Microsoft.Xna.Framework;

namespace LOZ.DungeonClasses
{
    internal class HoleWall : DoorTypeAbstract
    {
		
        public HoleWall(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateHoleWall(n);
            itemLocation = location;
        }
		
    }
}
