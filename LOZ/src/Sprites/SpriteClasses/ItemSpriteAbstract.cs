using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LOZ.Collision;

namespace LOZ.SpriteClasses
{
    abstract class ItemSpriteAbstract : ISprite
    {
		private protected double scale = 1.4;
		private protected Rectangle frame;
		private protected Texture2D _texture;

		public abstract void Update(GameTime timer);
		public void ChangeScale(double scaleSet) => scale = scaleSet;
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);

		public virtual void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			int width = (int)(scale * frame.Width);
			int height = (int)(scale * frame.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);		

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}

	}
}
