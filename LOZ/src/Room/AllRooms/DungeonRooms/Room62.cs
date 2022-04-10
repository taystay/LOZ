using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room62 : RoomAbstract
    {
        
        public Room62(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "6_2.csv");
            gameObjects.Add(new Triforce(GetCoorPoint(5, 3)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
