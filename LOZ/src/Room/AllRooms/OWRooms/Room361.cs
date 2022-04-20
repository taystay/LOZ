using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.Collision;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using LOZ.CommandClasses.RoomCommands;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;
using LOZ.ItemsClasses;
using LOZ.EnvironmentalClasses;
using LOZ.CommandClasses;

namespace LOZ.Room
{
    class Room361 : RoomAbstract
    {
       
        public Room361(string pathFile)
        {
            posZ = GetCoorPoint(5, 5);
            gameObjects = IO.Instance.ParseOW(pathFile + "OWTileMaps.csv",1,11);
            gameObjects.Add(new ThinTree(GetCoorPoint(8, 3)));
            gameObjects.Add(new ThinTree(GetCoorPoint(2,3)));
            gameObjects.Add(new StumpDoor(GetCoorPoint(5, 3)));
            gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(4.5, 3.1), new Point(48,48)), new RoomnZ(GetReference.GetRef()), typeof(ILink)));
            //gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(12, 2.5), new Point(48, 48)), new RoompX(GetReference.GetRef()), typeof(ILink)));
            colliders = new CollisionIterator(gameObjects);                   
        }
    }
}
