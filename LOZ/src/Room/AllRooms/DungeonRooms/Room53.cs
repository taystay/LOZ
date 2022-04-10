using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room53 : RoomAbstract
    {
       
        public Room53(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "5_3.csv");
            gameObjects.Add(new Key(GetCoorPoint(8, 6)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.Wall, DoorType.Wall, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
