using LOZ.MapIO;
using LOZ.EnemyClass;
using LOZ.Collision;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using LOZ.CommandClasses.RoomCommands;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room21n1 : RoomAbstract
    {
        
        public Room21n1(string pathFile)
        {
            posZ = Info.Enter211;
            negZ = Info.Enter211;
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_1_1.csv");
            gameObjects.Add(new Bat(GetCoorPoint(9, 2)));
            gameObjects.Add(new Bat(GetCoorPoint(2, 4)));
            gameObjects.Add(new Bat(GetCoorPoint(1, 5)));
            gameObjects.Add(new Bat(GetCoorPoint(5, 3)));
            gameObjects.Add(new Bow(GetCoorPoint(6, 3)));
            gameObjects.Add(new DoorCollider(new Rectangle(Info.Inside.Location + new Point(48, -48 * 2), new Point(48,48)), new RoompZ(GetReference.GetRef()), typeof(ILink) ));
            colliders = new CollisionIterator(gameObjects);
        }
    }
}
