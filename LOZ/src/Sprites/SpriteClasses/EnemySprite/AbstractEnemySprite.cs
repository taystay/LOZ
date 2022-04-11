using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using System;

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

		public void Draw(SpriteBatch spriteBatch, Point location) {
			Draw(spriteBatch, location, Color.White);
		}

        public void ChangeScale(double scale) { }
        public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
            //The code below was taken for the sprite atalas tutorial
            // URL http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X - scaledWidth / 2, location.Y - scaledHeight / 2, scaledWidth, scaledHeight);
            

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, c);
            spriteBatch.End();
        }
    }
}
