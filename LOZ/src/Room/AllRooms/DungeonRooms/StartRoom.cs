using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.ItemsClasses;
using LOZ.EnvironmentalClasses;

namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        public StartRoom(string pathFile)
        {
            negZ = GetCoorPoint(1, 6);
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_6.csv");
            gameObjects.Add(new Sword(GetCoorPoint(6, 3)));
            gameObjects.Add(new PortalGun(GetCoorPoint(0, 0)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.Door, DoorType.Wall, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
