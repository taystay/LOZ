using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room24 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room24(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_4.csv");
            roomObj.Add(new Bat(GetCoorPoint(9, 1)));
            roomObj.Add(new Bat(GetCoorPoint(1, 4)));
            roomObj.Add(new Bat(GetCoorPoint(2, 6)));
            roomObj.Add(new Bat(GetCoorPoint(4, 3)));
            roomObj.Add(new Bat(GetCoorPoint(4, 5)));
            roomObj.Add(new Bat(GetCoorPoint(9, 7)));
        }
    }
}
