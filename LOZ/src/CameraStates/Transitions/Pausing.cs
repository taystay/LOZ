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
        private int dy = 10;
        private const int offsetDist = 630;
        private int numberOfUpdates;
        
        private HudElement _topHud;
        public Pausing(Game1 gameObject, HudElement topHud)
        {
            numberOfUpdates = offsetDist / dy;
            _gameObject = gameObject;
            fade = new FadeOutSprite();
            _topHud = topHud;
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            //fade.Update(gameTime);
            numberOfUpdates--;
            _topHud.Offset(new Point(0, dy));
            if (numberOfUpdates <= 0)
                _gameObject.CameraState = new Paused(_gameObject, _topHud);
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _topHud.Draw(spriteBatch);
            CurrentRoom.Instance.Room.Draw(spriteBatch);
            //fade.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2));
        }
    }
}
