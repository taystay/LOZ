using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.EnemyClass;
using LOZ.EnemyClass.Projectiles;
using LOZ.Inventory;
using LOZ.DungeonClasses;
using LOZ.Factories;

namespace LOZ.GameState
{
    public abstract class OldRoom
    { 
        public static LinkInventory RoomInventory { get; set;}
        public List<IGameObjects> GameObjects { get; set; }
        public List<IGameObjects> RemovedInDetection { get; set; } = new List<IGameObjects>();
        public ExteriorObject exterior { get; set; }
        private protected CollisionIterator colliders;
        //public static ILink link { get; set; } // only one link so we dont accidently break the game with the decorator.
        public static bool DebugMode { get; set; } = false;
        public static bool Damaged { get; set; } = false;
        public abstract void LoadContent();
        
        public void Update(GameTime gameTime, ILink link)
        {
            if (exterior != null) exterior.Update(gameTime);
            link.Update(gameTime);
            colliders.Iterate();
            for (int i = 0; i < GameObjects.Count; i++)
            { // for loop because state of list may change. (items added)            
                IGameObjects item = GameObjects[i];
                item.Update(gameTime);
            }
            RemoveDeadItems();             
            
        }
        public void Draw(SpriteBatch spriteBatch, ILink link)
        {
            Draw(spriteBatch, link, new Point(0, 0));
        }
        public void Draw(SpriteBatch spriteBatch, ILink link, Point offset)
        {
            if (exterior != null) exterior.Draw(spriteBatch, offset);
            foreach (IGameObjects item in GameObjects)
            {
                item.Draw(spriteBatch, offset);
            }
            link.Draw(spriteBatch, offset);

            if (!DebugMode) return; //Debug hitboxes for easy of testing numbers
            foreach (IGameObjects item in GameObjects)
            {
                item.GetHitBox().Draw(spriteBatch);
            }
            link.GetHitBox().Draw(spriteBatch);
        }
        private void RemoveDeadItems()
        {
            /* 
                I might go ahead and add this as a function that all IGameObjects have.
                that way we can just do this through all IGameObjects. Some can just always return true;
             */
            foreach (IGameObjects item in RemovedInDetection)
            {
                GameObjects.Remove(item);
            }
            for(int i = GameObjects.Count - 1; i >= 0; i--)
            {
                IGameObjects item = GameObjects[i];
                if (TypeC.Check(item, typeof(IItem)))
                { //allow us to take items out of the game without them doing it themselves.
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) GameObjects.RemoveAt(i);
                }
                if (TypeC.Check(item, typeof(AbstractEnemy)))
                {
                    AbstractEnemy itemObject = (AbstractEnemy)item;
                    if (!itemObject.IsActive()) GameObjects.RemoveAt(i);
                }
                if (TypeC.Check(item, typeof(DragonBreathe)))
                {
                    DragonBreathe itemObject = (DragonBreathe)item;
                    if (!itemObject.IsActive()) GameObjects.RemoveAt(i);
                }
            }
        }
    }
}
