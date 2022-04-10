using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room32 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room32(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "3_2.csv");
            roomObj.Add(new Skeleton(GetCoorPoint(2, 2)));
            roomObj.Add(new Skeleton(GetCoorPoint(4, 4)));
            roomObj.Add(new Skeleton(GetCoorPoint(11, 2)));
        }
    }
}
