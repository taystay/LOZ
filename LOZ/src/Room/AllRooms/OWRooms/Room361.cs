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

namespace LOZ.Room
{
    class Room361 : RoomAbstract
    {
       
        public Room361(string pathFile)
        {
            posZ = GetCoorPoint(5, 5);
            gameObjects = IO.Instance.ParseOW(pathFile + "entrance.csv");
            gameObjects.Add(new ThinTree(GetCoorPoint(7, 3)));
            gameObjects.Add(new ThinTree(GetCoorPoint(3,3)));
            gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(4.5, 3), new Point(48,48)), new LeaveBasement(GetReference.GetRef()), typeof(ILink)));
            colliders = new CollisionIterator(gameObjects);
                      
        }
    }
}
