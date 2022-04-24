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
        public Room52(string pathFile)
        {             
            gameObjects = IO.Instance.ParseRoom(pathFile + "5_2.csv");
            gameObjects.Add(new Dragon(GetCoorPoint(5.5, 0)));
            gameObjects.Add(new HeartContainer(GetCoorPoint(5, 3)));
            gameObjects.Add(new HeartContainer(GetCoorPoint(6, 3)));
            gameObjects.Add(new Heart(GetCoorPoint(0, 3)));
            gameObjects.Add(new Heart(GetCoorPoint(11, 3)));

            exterior = new ExteriorObject(DoorType.Wall, DoorType.CrackedDoor, DoorType.KeyDoor, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateNormally(gameTime);
            foreach(IGameObjects item in gameObjects)
            {
                if (TypeC.Check(item, typeof(Dragon)))
                    return;
            }
            exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
        }
    }
}
