using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses;
using LOZ.Factories;

namespace LOZ.src.CameraStates
{
    public class MainMenuState : ICameraState
    {
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite menu; //probably just make a state

        public MainMenuState(Game1 gameObject)
        {
            _gameObject = gameObject;
            menu = DisplaySpriteFactory.Instance.GetMainMenu();
        }
        public void UpdateController(GameTime gameTime)
        {
            if (Keyboard.GetState().GetPressedKeyCount() > 0)
                _gameObject.CameraState = new StartingGame(_gameObject, menu);
        }
        public void Update(GameTime gameTime) =>
            menu.Update(gameTime);
        public void Reset() { }
        public void Draw(SpriteBatch spriteBatch) =>
            menu.Draw(spriteBatch, new Point(Info.screenWidth / 2, Info.screenHeight / 2));
    }
}
