using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room62 : RoomAbstract
    {
        
        public Room62(string pathFile)
        {
            System.Diagnostics.Debug.WriteLine("");
            gameObjects = IO.Instance.ParseRoom(pathFile + "6_2.csv");
            gameObjects.Add(new Triforce(GetCoorPoint(6, 4)));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
