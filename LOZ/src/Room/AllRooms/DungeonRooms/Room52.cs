using LOZ.MapIO;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.EnemyClass;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room52 : RoomAbstract
    {
       
        private bool hasEnemies = true;
        public Room52(string pathFile)
        {
            colliders = new CollisionIterator(gameObjects);
            gameObjects = IO.Instance.ParseRoom(pathFile + "5_2.csv");
            gameObjects.Add(new Dragon(GetCoorPoint(10, 4)));
            gameObjects.Add(new HeartContainer(GetCoorPoint(11, 4)));
            if (!hasEnemies)
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
