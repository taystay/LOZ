using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class IdleSprite : ISprite
	{
		//-----Private Variables-----
		private int Scale;
		private Rectangle Frame;
		private Texture2D Texture;


		//-----Constructor-----
		public IdleSprite(Texture2D texture)
		{
			Texture = texture;
			Scale = 5;
			Frame = new Rectangle(2, 20, 22, 25);
		}


		public void Update()
        {
		}
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Scale * Frame.Width, Scale * Frame.Height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
			spriteBatch.End();
		}
    }
}
