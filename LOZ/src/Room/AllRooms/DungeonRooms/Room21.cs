using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;

namespace LOZ.Room
{
    class Room21 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        private IEnvironment pushBlock;
        public Room21(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_1.csv");
            pushBlock = new SolidBlueBlock(GetCoorPoint(5, 4));
            pushBlock.Pushable = true;
            gameObjects.Add(new SpikeTrap(GetCoorPoint(1, 1)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(12, 1)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(1, 7)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(12, 7)));
            gameObjects.Add(pushBlock);
        }
    }
}
