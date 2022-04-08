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
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.Factories;
namespace LOZ.src.CameraStates
{
    public class Pausing : ICameraState
    {
        private FadeOutSprite fade;
        private Game1 _gameObject;
        public Pausing(Game1 gameObject)
        {
            _gameObject = gameObject;
            fade = new FadeOutSprite();
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            fade.Update(gameTime);
            if (fade.FadeDone())
                _gameObject.stateOfGame = new Paused(_gameObject);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentRoom.Instance.Room.Draw(spriteBatch);
            fade.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2));
        }
    }
}
