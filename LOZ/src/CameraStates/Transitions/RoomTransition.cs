using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Hud;
using LOZ.Room;
using LOZ.GameStateReference;
using LOZ.DungeonClasses;
using System;
using LOZ.SpriteClasses;

namespace LOZ.src.CameraStates
{
    public class RoomTransition : ICameraState
    {
        private Game1 _gameObject;

        #region next_room_logic
        private Point3D change;
        int offsetDist, updatesLeft, updates = 0;
        private Point delta;
        private int deltaAmount = 8;      
        private bool hasUpdated = false;
        #endregion

        #region sprites
        private ISprite sides, top;
        private HudElement topHud;
        #endregion

        public RoomTransition(Game1 gameObject, int dx, int dy, int dz)
        {
            _gameObject = gameObject;
            change = new Point3D(dx, dy, dz);
            topHud = new InventoryHud(RoomReference.GetInventory());
            topHud.Offset(new Point(0, -630));
            sides = Factories.DisplaySpriteFactory.Instance.GetMapWalk(Info.Map.Location.X,Info.screenHeight);
            top = Factories.DisplaySpriteFactory.Instance.GetMapWalk(Info.screenWidth, Info.Map.Location.Y);

            if(dx != 0)
            {
                offsetDist = Info.DungeonWidth;
                delta = new Point(-deltaAmount * (dx / Math.Abs(dx)), 0);
            } else if(dy != 0)
            {
                offsetDist = Info.DungeonHeight;
                delta = new Point(0, - deltaAmount * (dy / Math.Abs(dy)));
            } else
            {
                offsetDist = Info.DungeonHeight;
                delta = new Point(0, -deltaAmount * (dz / Math.Abs(dz)));
            }
            updatesLeft = offsetDist / deltaAmount;
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            /* temporary fix*/
            //if(!hasUpdated)
            //{
            //    IRoom r = RoomReference.GetChangeRoom(change.X, change.Y, change.Z);
            //    if(r != null)
            //        r.Update(gameTime);
            //    hasUpdated = true;
            //}
            updatesLeft--;
            updates++;
            if (updatesLeft > 0) return;              
            HudElement inv = new InventoryHud(RoomReference.GetInventory());
            inv.Offset(new Point(0, -630));
            RoomReference.SetLinkPosition(change.X, change.Y, change.Z);
            RoomReference.GetLink().Update(gameTime);
            RoomReference.SetRoomLocation(change.X, change.Y, change.Z);
            _gameObject.CameraState = new FirstDungeon(_gameObject, inv);                                        
        }
        public void Reset() { }
        #region room_and_window
        private void DrawBlackWindow(SpriteBatch spriteBatch)
        {
            int x = Info.Map.X;
            int y = Info.Map.Y;
            int w = Info.Map.Width;
            int h = Info.Map.Height;
            sides.Draw(spriteBatch, new Point(3 * x / 2 + w, y + h / 2), Color.Black);
            sides.Draw(spriteBatch, new Point(x / 2, y + h / 2), Color.Black);
            top.Draw(spriteBatch, new Point(x + w / 2, y / 2), Color.Black);
            top.Draw(spriteBatch, new Point(x + w / 2, 3 * y / 2 + h), Color.Black);
        }
        private void DrawNextRoom(SpriteBatch spriteBatch)
        {
            Point changeRoomOffset = new Point(-delta.X * updatesLeft, -delta.Y * updatesLeft);
            IRoom nextRoom = RoomReference.GetChangeRoom(change.X, change.Y, change.Z);
            if (nextRoom != null)
                nextRoom.DrawWithoutLink(spriteBatch, new Point() + changeRoomOffset);
        }
        private void DrawCurrentRoom(SpriteBatch spriteBatch)
        {
            Point oldRoomOffset = new Point(delta.X * updates, delta.Y * updates);
            RoomReference.GetCurrRoom().DrawWithoutLink(spriteBatch, new Point() + oldRoomOffset);
        }
        #endregion
        public void Draw(SpriteBatch spriteBatch)
        {                  
            DrawNextRoom(spriteBatch);
            DrawCurrentRoom(spriteBatch);
            DrawBlackWindow(spriteBatch);          
            topHud.Draw(spriteBatch);
        }
    }
}
