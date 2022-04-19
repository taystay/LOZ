using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.Hud;
using LOZ.GameStateReference;
using LOZ.SpriteClasses;
using LOZ.DungeonClasses;

namespace LOZ.src.CameraStates
{
    public class PauseScreen : ICameraState
    {
        private Game1 _gameObject; // so camera state can change if needed
        private HudElement _pasuedHud;
        private ISprite _pauseScreen;

        public PauseScreen(Game1 gameObject, ISprite pauseScreen, HudElement pauseHud)
        {
            _gameObject = gameObject;
            _pauseScreen = pauseScreen;
            _pasuedHud = pauseHud;
        }
        public void UpdateController(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                _gameObject.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                _gameObject.CameraState = new Unpausing(_gameObject, _pasuedHud);
        }
        public void Update(GameTime gameTime)
        {
            _pauseScreen.Update(gameTime);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        { 
            _pauseScreen.Draw(spriteBatch, new Point(Info.screenWidth / 2, Info.screenHeight / 2));
        }
    }
}
