using System.Collections.Generic;
using LOZ.Collision;
using LOZ.LinkClasses;
using Microsoft.Xna.Framework;

namespace LOZ.GameState
{
    public class DungeonRoom : Room
    {
        public DungeonRoom(List<IGameObjects> list)
        {
            gameObjects = list;
            colliders = new CollisionIterator(gameObjects);
            Link = new Link(new Point(1000, 500));
            gameObjects.Add(Link);
        }

        public override void LoadContent() {
            colliders = new CollisionIterator(gameObjects);

        }
    }
}
