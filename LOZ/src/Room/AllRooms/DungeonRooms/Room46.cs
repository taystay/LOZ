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
            roomObj.Add(new Skeleton(new Point(7, 2)));
            roomObj.Add(new Skeleton(new Point(6, 5)));
            roomObj.Add(new Skeleton(new Point(4, 6)));
            roomObj.Add(new Skeleton(new Point(11, 2)));
            roomObj.Add(new Skeleton(new Point(12, 6)));
        }
    }
}
