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
using LOZ.DungeonClasses;

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
            //prepare shadow
            RenderTarget2D darkness = new RenderTarget2D(_gameObject.GraphicsDevice, Info.screenWidth / 2, Info.screenHeight / 2);
            Texture2D alphaMask = DisplaySpriteFactory.Instance.GetAlphaMask();
            _gameObject.GraphicsDevice.SetRenderTarget(darkness);
            _gameObject.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
            var blend = new BlendState
            {
                AlphaBlendFunction = BlendFunction.Subtract,
                AlphaSourceBlend = Blend.One,
                AlphaDestinationBlend = Blend.One,
            };
            spriteBatch.Begin(blendState: blend);
            spriteBatch.Draw(alphaMask, darkness.Bounds, Color.White);
            spriteBatch.End();
            _gameObject.GraphicsDevice.SetRenderTarget(null);
            _gameObject.GraphicsDevice.Clear(Color.Black);

            

            CurrentRoom.Instance.Draw(spriteBatch);

            //draw shadow
            spriteBatch.Begin();
            spriteBatch.Draw(darkness, RoomReference.GetLink().Position.ToVector2() - new Vector2(darkness.Width/ 2, darkness.Height/2), Color.White);
            spriteBatch.End();

            _topHud.Draw(spriteBatch);
            if (RoomReference.GetLink().Health <= 0)
                GameOverDisplay.Draw(spriteBatch, new Point(500, 500));
        }
    }
}
