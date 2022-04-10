using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room35 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room35(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "3_5.csv");
            roomObj.Add(new Skeleton(new Point(5, 1)));
            roomObj.Add(new Skeleton(new Point(11, 5)));
            roomObj.Add(new Skeleton(new Point(3, 7)));
        }
    }
}
