using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Room
{
    class Room62 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room62(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "6_2.csv");
            roomObj.Add(new Triforce(new Point(6, 4)));
        }
    }
}
