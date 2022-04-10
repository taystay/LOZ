using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room34 : RoomAbstract
    {
        
        public Room34(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_4.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(8, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(5, 3)));
            gameObjects.Add(new Skeleton(GetCoorPoint(7, 3)));
            gameObjects.Add(new Skeleton(GetCoorPoint(4, 6)));
            gameObjects.Add(new Skeleton(GetCoorPoint(11, 4)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
