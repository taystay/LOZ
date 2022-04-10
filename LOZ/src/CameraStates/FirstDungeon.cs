using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.GameStateReference;
using LOZ.ControllerClasses;
using LOZ.Hud;
using LOZ.Room;
using LOZ.SpriteClasses;
using LOZ.ItemsClasses;
using LOZ.Factories;

namespace LOZ.src.CameraStates
{
    public class FirstDungeon : ICameraState
    {
        private IController keyboard;
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite GameOverDisplay; //probably just make a state
        private HudElement _topHud;

        public FirstDungeon(Game1 gameObject, HudElement topHud)
        {
            _gameObject = gameObject;
            _topHud = topHud;
            keyboard = new KeyBindings(gameObject).GetKeyboardController();
            GameOverDisplay = DisplaySpriteFactory.Instance.CreateDeadDisplay();
        }
        public void UpdateController(GameTime gameTime)
        {
            if (RoomReference.GetChangeRoom()) return;

           

            if (RoomReference.GetInventory().HasItem(typeof(Triforce)))
                _gameObject.CameraState = new Victory(_gameObject);

            keyboard.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameObject.CameraState = new Pausing(_gameObject, _topHud);
        }
        public void Update(GameTime gameTime)
        {
            CurrentRoom.Instance.Update(gameTime);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentRoom.Instance.Draw(spriteBatch);
            _topHud.Draw(spriteBatch);
            if (RoomReference.GetLink().Health <= 0)
                GameOverDisplay.Draw(spriteBatch, new Point(500, 500));
        }
    }
}
