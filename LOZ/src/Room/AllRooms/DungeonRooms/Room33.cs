using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room33 : RoomAbstract
    {
        
        public Room33(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_3.csv");
            gameObjects.Add(new Jelly(GetCoorPoint(3, 1)));
            gameObjects.Add(new Jelly(GetCoorPoint(7, 1)));
            gameObjects.Add(new Jelly(GetCoorPoint(4, 3)));
            gameObjects.Add(new Jelly(GetCoorPoint(8, 3)));
            gameObjects.Add(new Jelly(GetCoorPoint(4, 6)));
            gameObjects.Add(new Map(GetCoorPoint(10, 3)));
            exterior = new ExteriorObject(DoorType.Door, DoorType.KeyDoor, DoorType.Breakable, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
