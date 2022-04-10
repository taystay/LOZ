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
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_1_1.csv");
            gameObjects.Add(new Bat(GetCoorPoint(9, 2)));
            gameObjects.Add(new Bat(GetCoorPoint(2, 4)));
            gameObjects.Add(new Bat(GetCoorPoint(1, 5)));
            gameObjects.Add(new Bat(GetCoorPoint(5, 3)));
        }
    }
}
