using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room43 : RoomAbstract
    {
       
        public Room43(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "4_3.csv");
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Door, DoorType.Breakable, DoorType.KeyDoor, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
