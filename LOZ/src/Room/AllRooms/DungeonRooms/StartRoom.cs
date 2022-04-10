using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        //private List<IGameObjects> roomObj;
        public StartRoom(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_6.csv");
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.Door, DoorType.Wall, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
