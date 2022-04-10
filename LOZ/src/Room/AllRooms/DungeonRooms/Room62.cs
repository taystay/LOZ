﻿using LOZ.MapIO;
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
            gameObjects = IO.Instance.ParseRoom(pathFile + "6_2.csv");
            gameObjects.Add(new Triforce(GetCoorPoint(6, 4)));
        }
    }
}
