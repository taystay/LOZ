using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room43 : RoomAbstract
    {
       
        public Room43(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "4_3.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(7, 0)));
            gameObjects.Add(new Skeleton(GetCoorPoint(10, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(6, 5)));
            gameObjects.Add(new Skeleton(GetCoorPoint(3, 6)));
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Door, DoorType.Breakable, DoorType.KeyDoor, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
