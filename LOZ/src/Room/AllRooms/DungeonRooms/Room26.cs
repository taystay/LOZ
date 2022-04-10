using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room26 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room26(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_6.csv");
            roomObj.Add(new Bat(GetCoorPoint(2, 2)));
            roomObj.Add(new Bat(GetCoorPoint(2, 6)));
            roomObj.Add(new Bat(GetCoorPoint(4, 3)));
            roomObj.Add(new Key(GetCoorPoint(8, 7)));
        }
    }
}
