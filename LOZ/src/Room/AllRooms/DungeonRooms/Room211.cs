using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room211 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room211(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_1_1.csv");
            roomObj.Add(new Bat(GetCoorPoint(9, 2)));
            roomObj.Add(new Bat(GetCoorPoint(2, 4)));
            roomObj.Add(new Bat(GetCoorPoint(1, 5)));
            roomObj.Add(new Bat(GetCoorPoint(5, 3)));
        }
    }
}
