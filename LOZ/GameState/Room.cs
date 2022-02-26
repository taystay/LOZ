using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.LinkClasses;
using Sprint2.ItemsClasses;
using LOZ.Collision.Iterator;

namespace LOZ.GameState
{
    abstract class Room
    {
        private List<IGameObjects> gameObjects;
        public abstract void Initialize();

        public void Update(GameTime gameTime)
        {
            foreach(IGameObjects item in gameObjects)
            {
                item.Update(gameTime);
            }

            List<IGameObjects> temp = new List<IGameObjects>();
            foreach(IGameObjects item in gameObjects)
            {
                if(item.GetType().IsAssignableFrom(typeof(IItem)))
                {
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) temp.Add(item);
                }
            }

            foreach(IGameObjects item in temp)
            {
                gameObjects.Remove(item);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
