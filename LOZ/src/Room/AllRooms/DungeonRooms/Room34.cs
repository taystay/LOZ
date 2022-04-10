using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room34 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room34(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "3_4.csv");
            roomObj.Add(new Skeleton(GetCoorPoint(8, 1)));
            roomObj.Add(new Skeleton(GetCoorPoint(5, 3)));
            roomObj.Add(new Skeleton(GetCoorPoint(7, 3)));
            roomObj.Add(new Skeleton(GetCoorPoint(4, 6)));
            roomObj.Add(new Skeleton(GetCoorPoint(12, 4)));
        }
    }
}
