using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        private protected CollisionIterator coll;
        
        
        public abstract void LoadContent(ContentManager Content);

        private bool HasInterface(object o, System.Type t)
        {
            bool r = false;
            System.Type[] interfaces = o.GetType().GetInterfaces();
            foreach (System.Type type in interfaces)
            {
                if (type == t) r = true;
            }
            return r;
        }

        private bool IsType(object object_o, System.Type comparisonType)
        {
            System.Type actualType = object_o.GetType();
            if (actualType.IsAssignableFrom(comparisonType)) return true;
            if (actualType.IsSubclassOf(comparisonType)) return true;

            System.Type[] interfaces = actualType.GetInterfaces();
            foreach (System.Type type in interfaces)
            {
                if (type == comparisonType) return true;
            }
            return false;
        }

        public void Update(GameTime gameTime)
        {
            

            
            Link.Update(gameTime);
            int i = 0;
            int count = gameObjects.Count;
            while(i < count)
            {
                IGameObjects item = gameObjects[i++];
                if (!IsType(item, typeof(ILink)))
                {
                    item.Update(gameTime);
                }
            }

            List<IGameObjects> toRemove = new List<IGameObjects>();
            foreach(IGameObjects item in gameObjects)
            {
                if(HasInterface(item, typeof(IItem)))
                {
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) toRemove.Add(item);
                }
                if(IsType(item, typeof(AbstractEnemy)))
                {
                    AbstractEnemy itemObject = (AbstractEnemy)item;
                    if (!itemObject.IsActive()) toRemove.Add(item);
                }
            }

            foreach(IGameObjects item in toRemove)
            {
                gameObjects.Remove(item);
            }

            coll.Iterate();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch);
                item.GetHitBox().Draw(spriteBatch);
            }
            Link.Draw(spriteBatch);
        }
    }
}
