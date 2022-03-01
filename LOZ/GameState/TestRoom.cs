using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using System;
namespace LOZ.GameState
{
    public class RandomRoomOfNothingness : Room
    {
        public RandomRoomOfNothingness()
        {
            
        }

        public override void LoadContent()
        {
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            Link = new Link(new Point(1000, 500));
            gameObjects.Add(Link);
        }


    }
}
