using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room44 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room44(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "4_4.csv");
            roomObj.Add(new Bat(new Point(4, 1)));
            roomObj.Add(new Bat(new Point(7, 3)));
            roomObj.Add(new Bat(new Point(7, 5)));
            roomObj.Add(new Bat(new Point(9, 3)));
            roomObj.Add(new Bat(new Point(9, 5)));
            roomObj.Add(new Bat(new Point(11, 2)));
            roomObj.Add(new Bat(new Point(11, 6)));
            roomObj.Add(new Bat(new Point(12, 4)));
            roomObj.Add(new Compass(new Point(11, 4)));
        }
    }
}
