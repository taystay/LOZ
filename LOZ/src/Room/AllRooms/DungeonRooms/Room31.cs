using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room31 : RoomAbstract
    {
       
        public Room31(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_1.csv");
            gameObjects.Add(new Key(GetCoorPoint(7, 2)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
