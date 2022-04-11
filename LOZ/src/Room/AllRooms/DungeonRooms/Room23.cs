using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Room
{
    class Room23 : RoomAbstract
    {
       
        private IEnvironment pushBlock;
        private Point blockEventSpot;
        private bool hasUpdated = false;
        public Room23(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_3.csv");
            blockEventSpot = GetCoorPoint(6, 3);
            pushBlock = new BlueTriangleBlock(blockEventSpot);
            pushBlock.Pushable = true;
            gameObjects.Add(new Bat(GetCoorPoint(6, 2)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 4)));
            gameObjects.Add(new Bat(GetCoorPoint(6, 6)));
            gameObjects.Add(pushBlock);

            exterior = new ExteriorObject(DoorType.Wall, DoorType.Door, DoorType.KeyDoor, DoorType.CrackedDoor, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateNormally(gameTime);
            if (hasUpdated) return;
            if(pushBlock.GetPosition() != blockEventSpot)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Door);
                hasUpdated = true;
            }
        }

    }
}
