using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.Room
{
    class Room43 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room43(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "4_3.csv");
        }
    }
}
