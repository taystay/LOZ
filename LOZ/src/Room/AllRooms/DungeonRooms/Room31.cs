using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room31 : RoomAbstract
    {
       
        public Room31(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_1.csv");
            gameObjects.Add(new Key(GetCoorPoint(7, 2)));
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Wall, DoorType.KeyDoor, DoorType.KeyDoor, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
