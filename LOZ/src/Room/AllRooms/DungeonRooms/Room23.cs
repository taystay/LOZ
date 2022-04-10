﻿using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;

namespace LOZ.Room
{
    class Room23 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        private IEnvironment pushBlock;
        public Room23(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_3.csv");
            pushBlock = new SolidBlueBlock(GetCoorPoint(6, 4));
            pushBlock.Pushable = true;
            roomObj.Add(new Bat(GetCoorPoint(6, 2)));
            roomObj.Add(new Bat(GetCoorPoint(4, 4)));
            roomObj.Add(new Bat(GetCoorPoint(6, 6)));
            roomObj.Add(pushBlock);
        }
    }
}
