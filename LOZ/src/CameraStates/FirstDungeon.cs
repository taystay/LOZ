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
        private IController mouse;
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite GameOverDisplay; //probably just make a state
        private HudElement _topHud;
        private ISprite _pauseScreen;

        public FirstDungeon(Game1 gameObject, HudElement topHud)
        {
            _gameObject = gameObject;
            _topHud = topHud;
            keyboard = new KeyBindings(gameObject).GetKeyboardController();
            mouse = new KeyBindings(gameObject).GetMouseController();
            GameOverDisplay = DisplaySpriteFactory.Instance.CreateDeadDisplay();
            _pauseScreen = DisplaySpriteFactory.Instance.GetMainMenu();
        }

        public void UpdateController(GameTime gameTime)
        {
            if (RoomReference.GetInventory().HasItem(typeof(Triforce)))
                _gameObject.CameraState = new Victory(_gameObject);
            keyboard.Update(gameTime);
            mouse.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameObject.CameraState = new Pausing(_gameObject, _topHud);
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                _gameObject.CameraState = new Pausing(_gameObject, _pauseScreen, _topHud);
        }

        public void Update(GameTime gameTime) =>
            CurrentRoom.Instance.Update(gameTime);

        public void Reset()
        {
            _topHud = new InventoryHud(RoomReference.GetLink().Inventory);
            _topHud.Offset(new Point(0, -630));
        }      

        public void Draw(SpriteBatch spriteBatch)
        {
            RoomReference.Draw(spriteBatch);

            if (!RoomReference.GetDebug() && RoomReference.GetCurrLocation().Z == 0)
                FOWFactory.Instance.DrawShadow(spriteBatch);

            _topHud.Draw(spriteBatch);
            if (RoomReference.GetLink().Health <= 0)
                GameOverDisplay.Draw(spriteBatch, new Point(500, 500));
        }
    }
}
