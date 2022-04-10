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
        public bool HasEnemies { get; set; } = true;
        public List<IGameObjects> GameObjects { get; set; }
        public List<IGameObjects> RemovedInDetection { get; set; } = new List<IGameObjects>();
        public ExteriorObject exterior { get; set; }
        private protected CollisionIterator colliders;
        //public static ILink Link { get; set; } // only one link so we dont accidently break the game with the decorator.
        public static bool DebugMode { get; set; } = false;
        public static bool Damaged { get; set; } = false;
        public abstract void LoadContent();
        
        public void Update(GameTime gameTime, link)
        {
            HasEnemies = false;
            if (exterior != null) exterior.Update(gameTime);
            Link.Update(gameTime);
            if (!CurrentRoom.Instance.transition) {
                colliders.Iterate();
                for (int i = 0; i < GameObjects.Count; i++)
                { // for loop because state of list may change. (items added)            
                    IGameObjects item = GameObjects[i];
                    if (TypeC.Check(item, typeof(IEnemy)))
                        HasEnemies = true;
                    item.Update(gameTime);
                }
                RemoveDeadItems();             
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, new Point(0, 0));
        }
        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            if (exterior != null) exterior.Draw(spriteBatch, offset);
            foreach (IGameObjects item in GameObjects)
            {
                item.Draw(spriteBatch, offset);
            }
            if (CurrentRoom.Instance.linkCoor.X == 1 && CurrentRoom.Instance.linkCoor.Y == 3)
                GameFont.Instance.Write(spriteBatch, "Some walls may be bombable", 265 + offset.X, 450 + offset.Y);
            Link.Draw(spriteBatch, offset);

            if (!DebugMode) return; //Debug hitboxes for easy of testing numbers
            foreach (IGameObjects item in GameObjects)
            {
                item.GetHitBox().Draw(spriteBatch);
            }
            Link.GetHitBox().Draw(spriteBatch);
        }
        private void RemoveDeadItems()
        {
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
