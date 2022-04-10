using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room26 : RoomAbstract
    {
       
        public Room26(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_6.csv");
            gameObjects.Add(new Bat(GetCoorPoint(2, 2)));
            gameObjects.Add(new Bat(GetCoorPoint(2, 6)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 3)));
            gameObjects.Add(new Key(GetCoorPoint(8, 7)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
