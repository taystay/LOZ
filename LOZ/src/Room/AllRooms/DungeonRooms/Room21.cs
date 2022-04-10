using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room21 : RoomAbstract
    {
       
        private IEnvironment pushBlock;
        public Room21(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_1.csv");
            pushBlock = new SolidBlueBlock(GetCoorPoint(5, 4));
            pushBlock.Pushable = true;
            gameObjects.Add(new SpikeTrap(GetCoorPoint(0, 0)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(11, 0)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(0, 6)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(11, 6)));
            gameObjects.Add(pushBlock);
            exterior = new ExteriorObject(DoorType.Wall, DoorType.KeyDoor, DoorType.Wall, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
