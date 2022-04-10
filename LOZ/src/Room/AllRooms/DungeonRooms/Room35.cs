using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room35 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room35(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_5.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(5, 1)));
            gameObjects.Add(new Skeleton(GetCoorPoint(11, 5)));
            gameObjects.Add(new Skeleton(GetCoorPoint(3, 7)));
        }
    }
}
