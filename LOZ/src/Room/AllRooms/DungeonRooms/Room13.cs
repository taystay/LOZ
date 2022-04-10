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
            roomObj.Add(new NPC(GetCoorPoint(6, 3)));
            roomObj.Add(new FireItem(GetCoorPoint(4, 3)));
            roomObj.Add(new FireItem(GetCoorPoint(8, 3)));
        }
    }
}
