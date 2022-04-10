using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room33 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        public Room33(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_3.csv");
            gameObjects.Add(new Jelly(GetCoorPoint(3, 1)));
            gameObjects.Add(new Jelly(GetCoorPoint(7, 1)));
            gameObjects.Add(new Jelly(GetCoorPoint(4, 3)));
            gameObjects.Add(new Jelly(GetCoorPoint(8, 3)));
            gameObjects.Add(new Jelly(GetCoorPoint(4, 6)));
            gameObjects.Add(new Map(GetCoorPoint(11, 4)));
        }
    }
}
