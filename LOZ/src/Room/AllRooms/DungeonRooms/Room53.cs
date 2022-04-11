using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room53 : RoomAbstract
    {
       
        public Room53(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "5_3.csv");
            gameObjects.Add(new Key(GetCoorPoint(8, 6)));
            gameObjects.Add(new Skeleton(GetCoorPoint(2, 0)));
            gameObjects.Add(new Skeleton(GetCoorPoint(3, 0)));
            gameObjects.Add(new Bat(GetCoorPoint(9, 0)));
            gameObjects.Add(new Bat(GetCoorPoint(10, 0)));
            gameObjects.Add(new Jelly(GetCoorPoint(11, 4)));
            gameObjects.Add(new Jelly(GetCoorPoint(11, 5)));
            gameObjects.Add(new Jelly(GetCoorPoint(11, 6)));
            gameObjects.Add(new Jelly(GetCoorPoint(11, 3)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.Wall, DoorType.Wall, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
