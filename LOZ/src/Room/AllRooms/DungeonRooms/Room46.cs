using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room46 : RoomAbstract
    {
       
        public Room46(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "4_6.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(7, 2)));
            gameObjects.Add(new Skeleton(GetCoorPoint(6, 5)));
            gameObjects.Add(new Skeleton(GetCoorPoint(4, 6)));
            gameObjects.Add(new Skeleton(GetCoorPoint(11, 2)));
            gameObjects.Add(new Skeleton(GetCoorPoint(12, 6)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
