using Microsoft.Xna.Framework;

namespace LOZ.DungeonClasses
{
    internal class CrackDoor : DoorTypeAbstract
    {
	
        public CrackDoor(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateCrackDoor(n);
            itemLocation = location;
        }
	
    }
}
