using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room32 : RoomAbstract
    {
        
        public Room32(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_2.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(2, 2)));
            gameObjects.Add(new Skeleton(GetCoorPoint(4, 4)));
            gameObjects.Add(new Skeleton(GetCoorPoint(11, 2)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.Wall, DoorType.Door, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
