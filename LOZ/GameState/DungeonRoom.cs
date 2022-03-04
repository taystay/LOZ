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
            
        }

        public override void LoadContent() {
            colliders = new CollisionIterator(gameObjects);

        }
    }
}
