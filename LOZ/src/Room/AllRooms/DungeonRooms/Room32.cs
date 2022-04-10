using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room32 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room32(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_2.csv");
            gameObjects.Add(new Skeleton(GetCoorPoint(2, 2)));
            gameObjects.Add(new Skeleton(GetCoorPoint(4, 4)));
            gameObjects.Add(new Skeleton(GetCoorPoint(11, 2)));
        }
    }
}
