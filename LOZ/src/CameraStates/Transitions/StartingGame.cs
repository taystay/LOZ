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
    public class StartingGame : ICameraState
    {
        private FadeOutSprite fade;
        private Game1 _gameObject;
        private ISprite _menu;
        public StartingGame(Game1 gameObject, ISprite menu)
        {
            _gameObject = gameObject;
            _menu = menu;
            fade = new FadeOutSprite();
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            _menu.Update(gameTime);
            fade.Update(gameTime);
            if (fade.FadeDone())
                _gameObject.stateOfGame = new FirstDungeon(_gameObject);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _menu.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2));
            fade.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2));
        }
    }
}
