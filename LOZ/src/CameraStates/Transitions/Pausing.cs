using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Hud;
using LOZ.GameStateReference;
using LOZ.SpriteClasses;

namespace LOZ.src.CameraStates
{
    public class Pausing : ICameraState
    {
        private Game1 _gameObject;
        private int dy = 12;
        private const int offsetDist = 630;
        private int numberOfUpdates;
        private ISprite _menuScreen;

        
        private HudElement _topHud;
        public Pausing(Game1 gameObject, HudElement topHud)
        {
            numberOfUpdates = offsetDist / dy;
            _gameObject = gameObject;
            _topHud = topHud;
        }
        public Pausing(Game1 gameObject, ISprite menuScreen, HudElement topHud)
        {
            numberOfUpdates = offsetDist / dy;
            _gameObject = gameObject;
            _menuScreen = menuScreen;
            _topHud = topHud;
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            if(_menuScreen == null)
            {
                numberOfUpdates--;
                _topHud.Offset(new Point(0, dy));
                if (numberOfUpdates <= 0)
                    _gameObject.CameraState = new Paused(_gameObject, _topHud);
            } 
            else
            {
                numberOfUpdates--;
                _topHud.Offset(new Point(0, dy));
                if (numberOfUpdates <= 0)
                    _gameObject.CameraState = new PauseScreen(_gameObject, _menuScreen, _topHud);
            }

        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(_menuScreen == null)
                _topHud.Draw(spriteBatch);
            RoomReference.DrawOffset(spriteBatch, new Point(0, 630 - numberOfUpdates * dy));
        }
    }
}
