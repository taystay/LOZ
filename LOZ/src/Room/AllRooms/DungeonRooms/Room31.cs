using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.Room
{
    class Room31 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room31(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "3_1.csv");
        }
    }
}
