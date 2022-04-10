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
            roomObj.Add(new Skeleton(new Point(8, 1)));
            roomObj.Add(new Skeleton(new Point(5, 3)));
            roomObj.Add(new Skeleton(new Point(7, 3)));
            roomObj.Add(new Skeleton(new Point(4, 6)));
            roomObj.Add(new Skeleton(new Point(12, 4)));
        }
    }
}
