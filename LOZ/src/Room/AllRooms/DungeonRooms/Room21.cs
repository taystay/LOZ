﻿using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room21 : RoomAbstract
    {
        public Room21(string pathFile)
        {
            negZ = Info.Leave211;
            posZ = Info.Leave211;
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_1.csv");
            gameObjects.Add(new BlueTriangleBlock(GetCoorPoint(4, 3), true));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(0, 0)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(11, 0)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(0, 6)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(11, 6)));


            exterior = new ExteriorObject(DoorType.Wall, DoorType.KeyDoor, DoorType.Wall, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
