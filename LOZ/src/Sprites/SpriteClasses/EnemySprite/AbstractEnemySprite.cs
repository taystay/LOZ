using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    abstract class AbstractEnemySprite : ISprite
    {
        private protected Texture2D _texture;
        private protected int frame = 0;
        private protected int row;
        private protected int column;
        private protected int width;
        private protected int height;
        private protected double scale = 1;
        public abstract void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
        public void ChangeScale(double scale) { }
        public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X - scaledWidth / 2, location.Y - scaledHeight / 2, scaledWidth, scaledHeight);        
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, c);
            spriteBatch.End();
        }
    }
}
