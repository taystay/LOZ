using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LOZ.Collision;

namespace LOZ.SpriteClasses
{
    abstract class AbstractItemBlockClass : ISprite
    {
		private protected double scale = 1.4;
		private protected Rectangle frame;
		private protected Texture2D _texture;
		public abstract void Update(GameTime timer);

		public void ChangeScale(double scaleSet)
        {
			scale = scaleSet;
        }

		public void Draw(SpriteBatch spriteBatch, Point location) {
			Draw(spriteBatch, location, Color.White);
		}

		public virtual void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * frame.Width);
			int height = (int)(scale * frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);		

			//for SpriteBatch.Begin(...)
			//the paramater idea was from:
			//https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
			//https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			if (_texture == null) System.Diagnostics.Debug.WriteLine("" + this.GetType().ToString());
			if(_texture != null) spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}

	}
}
