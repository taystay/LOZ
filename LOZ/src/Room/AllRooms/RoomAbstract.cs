using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.EnemyClass;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;
using LOZ.EnemyClass.Projectiles;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    abstract class RoomAbstract : IRoom
    {
        #region objects
        private protected List<IGameObjects> gameObjects;
        //public static ILink Link { get; set; }
        #endregion

        public ExteriorObject exterior { get; set; }
        private protected List<IGameObjects> RemovedInDetection { get; set; } = new List<IGameObjects>();
        private protected CollisionIterator colliders;
        public static bool DebugMode { get; set; }

        public virtual void Update(GameTime gameTime)
        {
            if (exterior != null) exterior.Update(gameTime);
            colliders.Iterate();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                IGameObjects item = gameObjects[i];
                item.Update(gameTime);
            }
            CurrentRoom.link.Update(gameTime);
            RemoveItems();
        }

        //public virtual void Draw(SpriteBatch spriteBatch)
        //{
        //    Draw(spriteBatch, new Point(0, 0));
        //}

        public virtual void Draw(SpriteBatch spriteBatch, Point offset)
        {
            foreach (IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch, offset);
            }
            CurrentRoom.link.Draw(spriteBatch, offset);

            if (!DebugMode) return; //Debug hitboxes for easy of testing numbers
            foreach (IGameObjects item in gameObjects)
            {
                item.GetHitBox().Draw(spriteBatch, offset);
            }
            CurrentRoom.link.GetHitBox().Draw(spriteBatch, offset);

        }

        public virtual void RemoveItems()
        {
            foreach (IGameObjects item in RemovedInDetection)
            {
                gameObjects.Remove(item);
            }
            for (int i = gameObjects.Count - 1; i >= 0; i--)
            {
                IGameObjects item = gameObjects[i];
                if (TypeC.Check(item, typeof(IItem)))
                { 
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) gameObjects.RemoveAt(i);
                }
                if (TypeC.Check(item, typeof(AbstractEnemy)))
                {
                    AbstractEnemy itemObject = (AbstractEnemy)item;
                    if (!itemObject.IsActive()) gameObjects.RemoveAt(i);
                }
                if (TypeC.Check(item, typeof(DragonBreathe)))
                {
                    DragonBreathe itemObject = (DragonBreathe)item;
                    if (!itemObject.IsActive()) gameObjects.RemoveAt(i);
                }
            }
        }
    }
}
