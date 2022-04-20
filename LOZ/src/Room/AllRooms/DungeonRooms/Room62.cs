using LOZ.MapIO;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.LinkClasses;
using LOZ.CommandClasses;
using LOZ.EnemyClass;
using LOZ.SpriteClasses;
using LOZ.Factories;
using LOZ.EnvironmentalClasses;

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
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
