using LOZ.MapIO;
using LOZ.Collision;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.CommandClasses;
using LOZ.EnemyClass;

namespace LOZ.Room
{
    class Room461 : RoomAbstract
    {
       
        public Room461(string pathFile)
        {
            posX = GetCoorPoint(0, 3);
            gameObjects = IO.Instance.ParseOW(pathFile + "OWTileMaps.csv",13,23);
            gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(-2, 2.5), new Point(48,48)), new RoomnX(GetReference.GetRef()), typeof(ILink)));
            gameObjects.Add(new Skeletron(GetCoorPoint(6, 2)));
            colliders = new CollisionIterator(gameObjects);
                      
        }
    }
}
