using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.EnemyClass.Projectiles;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    abstract class RoomAbstract : IRoom
    {
        private protected List<IGameObjects> gameObjects;

        public ExteriorObject exterior { get; set; }
        public List<IGameObjects> RemovedInDetection { get; set; } = new List<IGameObjects>();
        private protected CollisionIterator colliders;
        
        public virtual void Update(GameTime gameTime)
        {
            UpdateNormally(gameTime);
        }
        public void UpdateNormally(GameTime gameTime)
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

        public virtual void Draw(SpriteBatch spriteBatch, Point offset)
        {
            DrawNormally(spriteBatch, offset);
        }

        public void DrawWithoutLink(SpriteBatch spriteBatch, Point offset)
        {
            if (exterior != null) exterior.Draw(spriteBatch, offset);
            foreach (IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch, offset);
            }
            if (!CurrentRoom.DebugMode) return; //Debug hitboxes for easy of testing numbers
            foreach (IGameObjects item in gameObjects)
            {
                item.GetHitBox().Draw(spriteBatch, offset);
            }
            CurrentRoom.link.GetHitBox().Draw(spriteBatch, offset);
        }

        public void DrawNormally(SpriteBatch spriteBatch, Point offset)
        {
            DrawWithoutLink(spriteBatch, offset);
            CurrentRoom.link.Draw(spriteBatch, offset);    
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
        protected Point GetCoorPoint(double x, double y)
        {
            Point start = Info.Inside.Location;
            start.X += Info.BlockWidth / 2;
            start.Y += Info.BlockWidth / 2;

            start.X += (int)((double)Info.BlockWidth * x);
            start.Y += (int)((double)Info.BlockWidth * y);

            return start;
        }
        public ExteriorObject GetExtObj()
        {
            return exterior;
        }
        public void AddItem(IGameObjects item)
        {
            gameObjects.Add(item);
        }
        public List<IGameObjects> GetObjectsList()
        {
            return gameObjects;
        }
    }
}
