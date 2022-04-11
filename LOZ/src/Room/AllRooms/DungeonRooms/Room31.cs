using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room31 : RoomAbstract
    {
       
        public Room31(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_1.csv");
            gameObjects.Add(new Key(GetCoorPoint(6, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(7, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(5, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(6, 0)));
            gameObjects.Add(new Skeleton(GetCoorPoint(6, 2)));
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Wall, DoorType.KeyDoor, DoorType.KeyDoor, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
