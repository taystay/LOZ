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
            roomObj.Add(new Bat(new Point(2, 2)));
            roomObj.Add(new Bat(new Point(2, 6)));
            roomObj.Add(new Bat(new Point(4, 3)));
            roomObj.Add(new Key(new Point(8, 7)));
        }
    }
}
