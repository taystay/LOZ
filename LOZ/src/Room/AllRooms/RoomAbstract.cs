using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    abstract class RoomAbstract : IRoom
    {
        private protected List<IGameObjects> gameObjects;
        public ExteriorObject exterior { get; set; }
        public List<IGameObjects> RemovedInDetection { get; set; } = new List<IGameObjects>();
        private protected CollisionIterator colliders;

        #region lamba functions
        public ExteriorObject GetExtObj() => exterior;
        public void AddItem(IGameObjects item) => gameObjects.Add(item);
        public List<IGameObjects> GetObjectsList() => gameObjects;
        public virtual void Update(GameTime gameTime) => UpdateNormally(gameTime);
        public virtual void Draw(SpriteBatch spriteBatch, Point offset) => DrawNormally(spriteBatch, offset);
        #endregion

        #region room moving points
        /* 
         * points where link would be placed if he moved on the map in this way.
         * certain rooms might want to change these, so they are in room abstract.
         */
        private protected Point posX = Info.posX;
        private protected Point negX = Info.negX;
        private protected Point posY = Info.posY;
        private protected Point negY = Info.negY;
        private protected Point? posZ = null;
        private protected Point? negZ = null;

        public void PlaceLinkX(int dx)
        {
            if (dx > 0)
                CurrentRoom.link.Position = posX;
            else if (dx < 0)
                CurrentRoom.link.Position = negX;
        }
        public void PlaceLinkY(int dy)
        {
            if (dy > 0)
                CurrentRoom.link.Position = posY;
            else if (dy < 0)
                CurrentRoom.link.Position = negY;
        }
        public void PlaceLinkZ(int dz)
        {
            if (dz > 0 && posZ.HasValue)
                CurrentRoom.link.Position = posZ.GetValueOrDefault();
            else if (dz < 0 && negZ.HasValue)
                CurrentRoom.link.Position = negZ.GetValueOrDefault();
        }
        #endregion

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
                if (!item.IsActive()) gameObjects.RemoveAt(i);
            }
        }
        protected Point GetCoorPoint(double x, double y)
        {
            Point start = Info.Inside.Location;
            start.X += Info.BlockWidth / 2;
            start.Y += Info.BlockWidth / 2;
            start.X += (int)(Info.BlockWidth * x);
            start.Y += (int)(Info.BlockWidth * y);
            return start;
        }       
        public void UpdateExterior(DoorType t, DoorLocation l)
        {
            if (exterior == null) return;
            exterior.ChangeDoorOnUpdate(l, t);
        }
    }
}
