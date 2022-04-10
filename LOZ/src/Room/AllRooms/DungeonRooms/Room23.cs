﻿using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class Room23 : RoomAbstract
    {
       
        private IEnvironment pushBlock;
        public Room23(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_3.csv");
            pushBlock = new SolidBlueBlock(GetCoorPoint(6, 4));
            pushBlock.Pushable = true;
            gameObjects.Add(new Bat(GetCoorPoint(6, 2)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 4)));
            gameObjects.Add(new Bat(GetCoorPoint(6, 6)));
            gameObjects.Add(pushBlock);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
