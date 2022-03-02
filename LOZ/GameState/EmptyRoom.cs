using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.Collision;
using LOZ.MapIO;
namespace LOZ.GameState
{
    public class EmptyRoom : Room
    {
        public EmptyRoom()
        {
            
        }

        public override void LoadContent()
        {
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            Link = new Link(new Point(1000, 500));
            gameObjects.Add(Link);

            gameObjects.Add(StringToBlock.Convert("BlackTileBlock", 200, 500));
        }
    }
}
