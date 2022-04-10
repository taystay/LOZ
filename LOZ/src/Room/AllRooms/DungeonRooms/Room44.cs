using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room44 : RoomAbstract
    {
        
        public Room44(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "4_4.csv");
            gameObjects.Add(new Bat(GetCoorPoint(4, 1)));
            gameObjects.Add(new Bat(GetCoorPoint(7, 3)));
            gameObjects.Add(new Bat(GetCoorPoint(7, 5)));
            gameObjects.Add(new Bat(GetCoorPoint(9, 3)));
            gameObjects.Add(new Bat(GetCoorPoint(9, 5)));
            gameObjects.Add(new Bat(GetCoorPoint(9, 2)));
            gameObjects.Add(new Bat(GetCoorPoint(11, 6)));
            gameObjects.Add(new Bat(GetCoorPoint(11, 4)));
            gameObjects.Add(new Compass(GetCoorPoint(11, 4)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
