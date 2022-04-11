using LOZ.MapIO;
using LOZ.Collision;
using LOZ.EnemyClass;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room24 : RoomAbstract
    {
       
        private bool hasEnemies = true;
        public Room24(string pathFile)
        {
            
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_4.csv");
            gameObjects.Add(new Bat(GetCoorPoint(9, 1)));
            gameObjects.Add(new Bat(GetCoorPoint(1, 4)));
            gameObjects.Add(new Bat(GetCoorPoint(2, 6)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 3)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 5)));
            gameObjects.Add(new Bat(GetCoorPoint(9, 7)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.CrackedDoor, DoorType.Wall, DoorType.Wall, gameObjects);

            colliders = new CollisionIterator(gameObjects);
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
