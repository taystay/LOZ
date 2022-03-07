using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.EnemyClass;

namespace LOZ.GameState
{
    public abstract class Room
    {
        public List<IGameObjects> gameObjects { get; set; }
        public ILink Link { get; set; }
        public bool Damaged { get; set; } = false;
        public bool DEBUGMODE { get; set; } = false;
        private protected CollisionIterator colliders;
        public abstract void LoadContent();       
        public void Update(GameTime gameTime)
        {         
            for(int i = 0; i < gameObjects.Count; i++)
            {
                IGameObjects item = gameObjects[i];
                if (!TypeC.Check(item, typeof(ILink)))
                {
                    item.Update(gameTime);
                }
            }
            Link.Update(gameTime);
            RemoveDeadItems();
            colliders.Iterate();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch);

                
            }
            if (DEBUGMODE)
            {
                foreach (IGameObjects item in gameObjects)
                {
                    item.GetHitBox().Draw(spriteBatch);
                }
            }
            Link.Draw(spriteBatch);
        }
        private void RemoveDeadItems()
        {
            List<IGameObjects> toRemove = new List<IGameObjects>();
            foreach (IGameObjects item in gameObjects)
            {
                if (TypeC.Check(item, typeof(IItem)))
                {
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) toRemove.Add(item);
                }
                if (TypeC.Check(item, typeof(AbstractEnemy)))
                {
                    AbstractEnemy itemObject = (AbstractEnemy)item;
                    if (!itemObject.IsActive()) toRemove.Add(item);
                }
            }
            foreach (IGameObjects item in toRemove)
            {
                gameObjects.Remove(item);
            }
        }
    }
}
