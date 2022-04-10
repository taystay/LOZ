using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room46 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room46(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "4_6.csv");
            roomObj.Add(new Skeleton(GetCoorPoint(7, 2)));
            roomObj.Add(new Skeleton(GetCoorPoint(6, 5)));
            roomObj.Add(new Skeleton(GetCoorPoint(4, 6)));
            roomObj.Add(new Skeleton(GetCoorPoint(11, 2)));
            roomObj.Add(new Skeleton(GetCoorPoint(12, 6)));
        }
    }
}
