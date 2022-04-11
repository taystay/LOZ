using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        public StartRoom(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_6.csv");
            gameObjects.Add(new Sword(GetCoorPoint(6, 3)));
            exterior = new ExteriorObject(DoorType.Door, DoorType.Door, DoorType.Wall, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
