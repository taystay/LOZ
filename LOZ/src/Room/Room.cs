using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.EnemyClass;
using LOZ.EnemyClass.Projectiles;
using LOZ.Hud;

namespace LOZ.GameState
{
    public abstract class Room
    {

        public static HudElement hudele { get; set; }


        public List<IGameObjects> GameObjects { get; set; }
        private protected CollisionIterator colliders;

        public static ILink Link { get; set; } // only one link so we dont accidently break the game with the decorator.
        public static bool DebugMode { get; set; } = false;
        public bool Damaged { get; set; } = false;
        
        public abstract void LoadContent();       
        public void Update(GameTime gameTime)
        {
            Link.Update(gameTime);
            for (int i = 0; i < GameObjects.Count; i++)
            { // for loop because state of list may change. (items added)
                IGameObjects item = GameObjects[i];
                item.Update(gameTime);
            }    

            RemoveDeadItems();
            colliders.Iterate();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            hudele.Draw(spriteBatch);
            foreach (IGameObjects item in GameObjects)
            {
                item.Draw(spriteBatch);
            }
            Link.Draw(spriteBatch);

            if (!DebugMode) return; //Debug hitboxes for easy of testing numbers
            foreach (IGameObjects item in GameObjects)
            {
                item.GetHitBox().Draw(spriteBatch);
            }
            Link.GetHitBox().Draw(spriteBatch);
        }
        private void RemoveDeadItems()
        {
            List<IGameObjects> toRemove = new List<IGameObjects>();
            foreach (IGameObjects item in GameObjects)
            {
                if (TypeC.Check(item, typeof(IItem)))
                { //allow us to take items out of the game without them doing it themselves.
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) toRemove.Add(item);
                }
                if (TypeC.Check(item, typeof(AbstractEnemy)))
                {
                    AbstractEnemy itemObject = (AbstractEnemy)item;
                    if (!itemObject.IsActive()) toRemove.Add(item);
                }
                if(TypeC.Check(item, typeof(DragonBreathe)))
                {
                    DragonBreathe itemObject = (DragonBreathe)item;
                    if (!itemObject.IsActive()) toRemove.Add(item);
                }
            }
            foreach (IGameObjects item in toRemove)
            {
                GameObjects.Remove(item);
            }
        }
    }
}
