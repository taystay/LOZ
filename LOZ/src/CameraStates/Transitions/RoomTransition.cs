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
        private Point3D dCoor;
        private readonly int offsetAmount;
        private int updatesLeft, updates = 0;
        private Point delta;
        private readonly int changePerUpdate = 10;      
        #endregion

        #region sprites
        private readonly ISprite sides, top;
        private readonly HudElement topHud;
        #endregion

        public RoomTransition(Game1 gameObject, int dx, int dy, int dz)
        {
            _gameObject = gameObject;
            dCoor = new Point3D(dx, dy, dz);

            ExteriorObject o = RoomReference.GetChangeRoom(dCoor.X, dCoor.Y, dCoor.Z).GetExtObj();
            if (o != null) o.Update(null);

            /* need hud to draw and pass to next state*/
            topHud = new InventoryHud(RoomReference.GetInventory());
            topHud.Offset(new Point(0, -630));

            sides = Factories.DisplaySpriteFactory.Instance.GetMapWalk(Info.Map.Location.X,Info.screenHeight);
            top = Factories.DisplaySpriteFactory.Instance.GetMapWalk(Info.screenWidth, Info.Map.Location.Y);

            delta = new Point(Math.Sign(dx) * -changePerUpdate, Math.Sign(dy + dz) * -changePerUpdate);
            offsetAmount = Math.Abs(dx) * Info.DungeonWidth + Math.Abs(dy + dz) * Info.DungeonHeight;
            updatesLeft = offsetAmount / changePerUpdate;
        }
        public void UpdateController(GameTime gameTime){ }
        public void Update(GameTime gameTime)
        {
            updatesLeft--;
            updates++;
            
            if (updatesLeft > 0) return;

            RoomReference.SetLinkPosition(dCoor.X, dCoor.Y, dCoor.Z);
            RoomReference.GetLink().Update(gameTime); //properly updates position
            RoomReference.SetRoomLocation(dCoor.X, dCoor.Y, dCoor.Z);

            _gameObject.CameraState = new FirstDungeon(_gameObject, topHud);                                        
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
            IRoom nextRoom = RoomReference.GetChangeRoom(dCoor.X, dCoor.Y, dCoor.Z);
            if (nextRoom != null)
                nextRoom.DrawWithoutLink(spriteBatch, new Point() + changeRoomOffset);
        }
        private void DrawCurrentRoom(SpriteBatch spriteBatch)
        {
            Point oldRoomOffset = new Point(delta.X * updates, delta.Y * updates);
            RoomReference.GetCurrRoom().DrawWithoutLink(spriteBatch, new Point() + oldRoomOffset);
            Factories.FOWFactory.Instance.DrawShadow(spriteBatch, new Point() + oldRoomOffset);
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
