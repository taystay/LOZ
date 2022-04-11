using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        public StartRoom(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_6.csv");
            exterior = new ExteriorObject(DoorType.Door, DoorType.Door, DoorType.Wall, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
