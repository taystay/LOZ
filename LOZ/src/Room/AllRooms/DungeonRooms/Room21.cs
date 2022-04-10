using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room21 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room21(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_1.csv");
            roomObj.Add(new SpikeTrap(GetCoorPoint(1, 1)));
            roomObj.Add(new SpikeTrap(GetCoorPoint(12, 1)));
            roomObj.Add(new SpikeTrap(GetCoorPoint(1, 7)));
            roomObj.Add(new SpikeTrap(GetCoorPoint(12, 7)));
        }
    }
}
