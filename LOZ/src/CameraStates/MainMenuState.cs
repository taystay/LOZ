using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses;
using LOZ.Factories;
using LOZ.GameStateReference;

namespace LOZ.src.CameraStates
{
    public class MainMenuState : ICameraState
    {
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite menu; //probably just make a state
        private Keys pressed = Keys.None;
        public MainMenuState(Game1 gameObject)
        {
            _gameObject = gameObject;
            menu = DisplaySpriteFactory.Instance.GetMainMenu();
        }
        public void UpdateController(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _gameObject.CameraState = new StartingGame(_gameObject, menu);
            else if (Keyboard.GetState().IsKeyDown(Keys.H) && pressed == Keys.None)
            {
                pressed = Keys.H;
                RoomReference.ToggleHardMode();
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.H) && pressed == Keys.H)
                pressed = Keys.None;
        }
        public void Update(GameTime gameTime) =>
            menu.Update(gameTime);
        public void Reset() { }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!RoomReference.GetHardMode())
                menu = DisplaySpriteFactory.Instance.GetMainMenu();
            else
                menu = DisplaySpriteFactory.Instance.GetHardMenu();
            menu.Draw(spriteBatch, new Point(Info.screenWidth / 2, Info.screenHeight / 2));
        }
    }
}
