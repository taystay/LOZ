using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;
using LOZ.SpriteClasses;
using LOZ.Factories;
using LOZ.Room;

namespace LOZ.src.CameraStates
{
    public class Victory : ICameraState
    {
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite EndScreenAnimation;

        public Victory(Game1 gameObject)
        {
            _gameObject = gameObject;
            EndScreenAnimation = DisplaySpriteFactory.Instance.CreateEndScreen();
        }
        public void UpdateController(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.R))
            {
                ICommand c = new Reset();
                c.execute();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                _gameObject.Exit();
        }
        public void Update(GameTime gameTime)
        {
            EndScreenAnimation.Update(gameTime);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentRoom.Instance.Draw(spriteBatch);
            EndScreenAnimation.Draw(spriteBatch, new Point());
            CurrentRoom.link.Draw(spriteBatch);
        }
    }
}
