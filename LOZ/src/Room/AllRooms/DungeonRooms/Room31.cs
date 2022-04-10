using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room31 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room31(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "3_1.csv");
            roomObj.Add(new Key(GetCoorPoint(7, 2)));
        }
    }
}
