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
        private int dy = -10;
        private const int offsetDist = 630;
        private int numberOfUpdates;

        public Unpausing(Game1 gameObject, HudElement hud)
        {
            numberOfUpdates = 630 / -dy;
            _gameObject = gameObject;
            _hud = hud;
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            numberOfUpdates--;
            _hud.Offset(new Point(0, dy));
            if (numberOfUpdates <= 0)
                _gameObject.CameraState = new FirstDungeon(_gameObject, _hud);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _hud.Draw(spriteBatch);
        }
    }
}
