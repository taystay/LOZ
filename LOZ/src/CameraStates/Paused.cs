﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.ControllerClasses;
using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.MapIO;
using System.IO;
using System.Reflection;
using LOZ.Sound;
using LOZ.Hud;
using LOZ.SpriteClasses;
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.Factories;
namespace LOZ.src.CameraStates
{
    public class Paused : ICameraState
    {
        private Game1 _gameObject; // so camera state can change if needed
        private HudElement pausedHud;

        public Paused(Game1 gameObject)
        {
            _gameObject = gameObject;
            pausedHud = new InventoryHud(Room.RoomInventory);
        }
        public void UpdateController(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                _gameObject.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameObject.CameraState = new Unpausing(_gameObject, pausedHud);
            
        }
        public void Update(GameTime gameTime)
        {
            pausedHud.Update();

        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            pausedHud.Draw(spriteBatch);                      
        }
    }
}
