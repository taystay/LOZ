using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;
using LOZ.SpriteClasses;
using LOZ.Factories;
using LOZ.GameStateReference;
using LOZ.Hud;


namespace LOZ.src.CameraStates
{
    public class Victory : ICameraState
    {
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite EndScreenAnimation;

        public Victory(Game1 gameObject)
        {
            _gameObject = gameObject;
            EndScreenAnimation = DisplaySpriteFactory.Instance.GetVicScreen();
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
            HudElement inv = new InventoryHud(RoomReference.GetInventory());
            inv.Offset(new Point(0, -630));
            _gameObject.CameraState = new FirstDungeon(_gameObject, inv);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            RoomReference.Draw(spriteBatch);
            EndScreenAnimation.Draw(spriteBatch, new Point());
            RoomReference.GetLink().Draw(spriteBatch);
        }
    }
}
