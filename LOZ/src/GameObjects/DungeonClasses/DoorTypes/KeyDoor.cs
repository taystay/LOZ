using Microsoft.Xna.Framework;

namespace LOZ.DungeonClasses
{
    internal class KeyDoor : DoorTypeAbstract
    {

        public KeyDoor(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateKeyDoor(n);
            itemLocation = location;
        }
    }
}
