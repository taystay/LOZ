using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        //private List<IGameObjects> roomObj;
        public StartRoom(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_6.csv");
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
