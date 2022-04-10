using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.EnemyClass;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room24 : RoomAbstract
    {
        private List<IGameObjects> roomObj;
        private bool hasEnemies = true;
        public Room24(string pathFile)
        {
            roomObj = IO.Instance.ParseRoom(pathFile + "2_4.csv");
            roomObj.Add(new Bat(GetCoorPoint(9, 1)));
            roomObj.Add(new Bat(GetCoorPoint(1, 4)));
            roomObj.Add(new Bat(GetCoorPoint(2, 6)));
            roomObj.Add(new Bat(GetCoorPoint(4, 3)));
            roomObj.Add(new Bat(GetCoorPoint(4, 5)));
            roomObj.Add(new Bat(GetCoorPoint(9, 7)));
            if(!hasEnemies)
                exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
        }

        public override void Update(GameTime gameTime)
        {
            if (exterior != null) exterior.Update(gameTime);
            colliders.Iterate();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                IGameObjects item = gameObjects[i];
                if (TypeC.Check(item, typeof(IEnemy)))
                    hasEnemies = true;
                item.Update(gameTime);
            }
            CurrentRoom.link.Update(gameTime);
            RemoveItems();
        }
    }
}
