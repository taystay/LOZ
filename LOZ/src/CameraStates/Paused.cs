using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.Hud;
using LOZ.Room;
using LOZ.LinkClasses;

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
                CurrentRoom.link.inventory.NextItem();
            }
            if(Keyboard.GetState().IsKeyDown(Keys.OemPipe) && !buttonPressed)
            {
                buttonPressed = true;
                CurrentRoom.DebugMode = !CurrentRoom.DebugMode;
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
