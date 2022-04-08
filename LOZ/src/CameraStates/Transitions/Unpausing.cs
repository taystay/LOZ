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
    public class Unpausing : ICameraState
    {
        private FadeOutSprite fade;
        private Game1 _gameObject;
        private HudElement _hud;

        public Unpausing(Game1 gameObject, HudElement hud)
        {
            _gameObject = gameObject;
            _hud = hud;
            fade = new FadeOutSprite();

        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            fade.Update(gameTime);
            if (fade.FadeDone())
                _gameObject.CameraState = new FirstDungeon(_gameObject);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _hud.Draw(spriteBatch);
            fade.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2));
        }
    }
}
