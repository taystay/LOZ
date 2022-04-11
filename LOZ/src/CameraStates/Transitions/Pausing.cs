using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Hud;
using LOZ.SpriteClasses;
using LOZ.GameStateReference;

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
           
            RoomReference.DrawOffset(spriteBatch, new Point(0, 630 - numberOfUpdates * dy));
          
        }
    }
}
