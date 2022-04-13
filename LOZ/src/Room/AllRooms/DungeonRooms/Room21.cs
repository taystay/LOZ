using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using LOZ.CommandClasses.RoomCommands;
using LOZ.LinkClasses;

namespace LOZ.Room
{
    class Room21 : RoomAbstract
    {
        public Room21(string pathFile)
        {
            negZ = Info.Leave211;
            posZ = Info.Leave211;
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_1.csv");
            gameObjects.Add(new BlueTriangleBlock(GetCoorPoint(4, 3), true));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(0, 0)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(11, 0)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(0, 6)));
            gameObjects.Add(new SpikeTrap(GetCoorPoint(11, 6)));
            gameObjects.Add(new DoorCollider(new Rectangle(Info.Leave211 + new Point(23, -23), new Point(50, 50)), new RoomnZ(GetReference.GetRef()), typeof(ILink)));

            exterior = new ExteriorObject(DoorType.Wall, DoorType.KeyDoor, DoorType.Wall, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
