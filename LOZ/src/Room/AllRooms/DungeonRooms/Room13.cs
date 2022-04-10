using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room13 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room13(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "1_3.csv");
            roomObj.Add(new NPC(new Point(6, 3)));
            roomObj.Add(new FireItem(new Point(4, 3)));
            roomObj.Add(new FireItem(new Point(8, 3)));
        }
    }
}
