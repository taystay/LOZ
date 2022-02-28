using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.EnemyClass.Projectiles;

namespace LOZ.GameState
{
    public abstract class Room
    {
        public List<IGameObjects> gameObjects { get; set; }
        public ILink Link { get; set; }
        public bool Damaged { get; set; } = false;

        private protected CollisionIterator coll;
        private protected List<IProjectile> projectiles;
        
        
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

        public void Update(GameTime gameTime)
        {
            coll.Iterate();

            
            gameObjects.Add((IGameObjects)Link);

            
            //Link.Update(gameTime);
            foreach(IGameObjects item in gameObjects)
            {
                item.Update(gameTime);
            }
            foreach (IProjectile p in projectiles)
            {
                p.Update(gameTime);
                //gameObjects.Add((IGameObjects)p);
            }

            List<IGameObjects> toRemove = new List<IGameObjects>();
            foreach(IGameObjects item in gameObjects)
            {
                if(HasInterface(item, typeof(IItem)))
                {
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) toRemove.Add(item);
                }
            }

            foreach(IGameObjects item in toRemove)
            {
                gameObjects.Remove(item);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Link.Draw(spriteBatch);
            foreach(IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch);
            }
            foreach (IProjectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }
        }
    }
}
