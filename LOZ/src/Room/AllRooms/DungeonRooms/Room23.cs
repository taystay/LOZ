using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room23 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room23(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_3.csv");
            roomObj.Add(new Bat(new Point(6, 2)));
            roomObj.Add(new Bat(new Point(4, 4)));
            roomObj.Add(new Bat(new Point(6, 6)));
        }
    }
}
