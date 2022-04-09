using Microsoft.Xna.Framework;
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
        private HudElement _pasuedHud;
        private bool buttonPressed = false;

        public Paused(Game1 gameObject, HudElement pausedHud)
        {
            _gameObject = gameObject;
            _pasuedHud = pausedHud;
        }
        public void UpdateController(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                _gameObject.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameObject.CameraState = new Unpausing(_gameObject, _pasuedHud);
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && !buttonPressed)
            {
                buttonPressed = true;
                Room.RoomInventory.NextItem();
            }
            if(Keyboard.GetState().IsKeyDown(Keys.OemPipe) && !buttonPressed)
            {
                buttonPressed = true;
                Room.DebugMode = !Room.DebugMode;
            }

            if (Keyboard.GetState().GetPressedKeyCount() == 0)
                buttonPressed = false;
        }
        public void Update(GameTime gameTime)
        {
            _pasuedHud.Update();

        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _pasuedHud.Draw(spriteBatch);                      
        }
    }
}
