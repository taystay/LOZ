using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.ItemsClasses;
using LOZ.EnvironmentalClasses;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using LOZ.CommandClasses.RoomCommands;
using LOZ.LinkClasses;
namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        public StartRoom(string pathFile)
        {
            negZ = GetCoorPoint(5.5, 6.3);
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_6.csv");
            gameObjects.Add(new Sword(GetCoorPoint(6, 3)));
            gameObjects.Add(new PortalGun(GetCoorPoint(0, 0)));
            gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(5, 7), new Point(50,50)), new RoompZ(GetReference.GetRef()), typeof(ILink)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.Door, DoorType.Door, DoorType.Door, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
