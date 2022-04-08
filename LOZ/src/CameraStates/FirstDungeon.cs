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
using LOZ.ItemsClasses;
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.Factories;
namespace LOZ.src.CameraStates
{
    public class FirstDungeon : ICameraState
    {
        private IController keyboard;
        private Game1 _gameObject; // so camera state can change if needed
        private ISprite GameOverDisplay; //probably just make a state

        public FirstDungeon(Game1 gameObject)
        {
            _gameObject = gameObject;
            keyboard = new KeyBindings(gameObject).GetKeyboardController();
            GameOverDisplay = DisplaySpriteFactory.Instance.CreateDeadDisplay();
        }
        public void UpdateController(GameTime gameTime)
        {
            if (CurrentRoom.Instance.transition) return;

            if (Room.RoomInventory.HasItem(typeof(Triforce)))
                _gameObject.CameraState = new Victory(_gameObject);

            keyboard.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameObject.CameraState = new Pausing(_gameObject);
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
            if (Room.Link.Health <= 0)
                GameOverDisplay.Draw(spriteBatch, new Point(500, 500));
        }
    }
}
