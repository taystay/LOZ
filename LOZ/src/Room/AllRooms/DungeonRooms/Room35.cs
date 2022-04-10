using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room35 : RoomAbstract
    {
        
        public Room35(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_5.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(5, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(10, 5)));
            gameObjects.Add(new Skeleton(GetCoorPoint(3, 7)));
            exterior = new ExteriorObject(DoorType.Door, DoorType.Wall, DoorType.KeyDoor, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
