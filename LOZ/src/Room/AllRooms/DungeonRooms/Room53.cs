using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Room
{
    class Room53 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room53(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "5_3.csv");
            roomObj.Add(new Key(GetCoorPoint(8, 7)));
        }
    }
}
