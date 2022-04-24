using LOZ.MapIO;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.CommandClasses;
using LOZ.EnvironmentalClasses;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room62 : RoomAbstract
    {
        
        public Room62(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "6_2.csv");
            gameObjects.Add(new StairsBlock(GetCoorPoint(2, 2)));
            gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(1.6, 1.6), new Point(52, 52)), new EnterBossFight(), typeof(ILink)));
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Wall, DoorType.Wall, DoorType.Door, gameObjects);

            gameObjects.Add(new Heart(GetCoorPoint(4, 2)));
            gameObjects.Add(new Heart(GetCoorPoint(5, 2)));
            gameObjects.Add(new Heart(GetCoorPoint(6, 2)));

            colliders = new CollisionIterator(gameObjects);
        }
    }
}
