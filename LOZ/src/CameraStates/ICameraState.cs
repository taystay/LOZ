using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace LOZ.src.CameraStates
{
    public interface ICameraState
    {
        public void UpdateController(GameTime gameTime);
        public void Update(GameTime gameTime);
        public void Reset();
        public void Draw(SpriteBatch spriteBatch);
    }
}
