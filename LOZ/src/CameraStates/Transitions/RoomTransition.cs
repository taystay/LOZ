﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Hud;
using LOZ.SpriteClasses;
using LOZ.Room;
using LOZ.GameStateReference;
using LOZ.DungeonClasses;
using LOZ.Inventory;
using LOZ.GameStateReference;

namespace LOZ.src.CameraStates
{
    public class RoomTransition : ICameraState
    {
        private int _dx;
        private int _dy;
        private int _dz;
        private int offsetDist = Info.screenWidth;
        private int updatesLeft;
        private int updates;
        private Point delta;
        private int deltaAmount = 4;
        private Game1 _gameObject;
        public RoomTransition(Game1 gameObject, int dx, int dy, int dz)
        {
            _gameObject = gameObject;
            updatesLeft = offsetDist / deltaAmount;
            _dx = dx;
            _dy = dy;
            _dz = dz;
            if (dx < 0)
                delta = new Point(-deltaAmount, 0);
            else
                delta = new Point(deltaAmount, 0);

            if (dy < 0)
                delta = new Point(0, -deltaAmount);
            else
                delta = new Point(0, deltaAmount);

        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            updatesLeft--;
            updates++;
            if (updatesLeft <= 0)
            {
                RoomReference.SetRoomLocation(_dx, _dy, _dz);
                HudElement inv = new InventoryHud(RoomReference.GetInventory());
                inv.Offset(new Point(0, -630));
                _gameObject.CameraState = new FirstDungeon(_gameObject, inv);
            }

                
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Point changeRoomOffset = new Point(delta.X * updatesLeft, delta.Y * updatesLeft);
            Point oldRoomOffset = new Point(delta.X * updates, delta.Y * updates);
            RoomReference.GetChangeRoom(_dx, _dy, _dz).Draw(spriteBatch, new Point() + changeRoomOffset);
            RoomReference.GetCurrRoom().Draw(spriteBatch, new Point()+ oldRoomOffset);
        }
    }
}
