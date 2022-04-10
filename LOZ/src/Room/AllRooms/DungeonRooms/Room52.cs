using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room52 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room52(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "5_2.csv");
            roomObj.Add(new Dragon(GetCoorPoint(10, 4)));
            roomObj.Add(new HeartContainer(GetCoorPoint(11, 4)));
        }
    }
}
