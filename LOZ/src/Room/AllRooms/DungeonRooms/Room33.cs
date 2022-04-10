using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room33 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room33(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "3_3.csv");
            roomObj.Add(new Jelly(new Point(3, 1)));
            roomObj.Add(new Jelly(new Point(7, 1)));
            roomObj.Add(new Jelly(new Point(4, 3)));
            roomObj.Add(new Jelly(new Point(8, 3)));
            roomObj.Add(new Jelly(new Point(4, 6)));
            roomObj.Add(new Map(new Point(11, 4)));
        }
    }
}
