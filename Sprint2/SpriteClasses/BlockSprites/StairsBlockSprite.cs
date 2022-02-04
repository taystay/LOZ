using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class StairsBlockSprite : ISprite
    {
			//-----Private Variables-----
			private Rectangle Frame;
			private Texture2D Texture;
			private double Scale;


			//-----Constructor-----
			public StairsBlockSprite(Texture2D texture, double scale)
			{
				Scale = scale;
				Texture = texture;
				Frame = new Rectangle(109, 63, 32, 32);
			}

			public void SetSize(double size)
			{
				Scale = size;
			}

			//-----Update frame-----
			public void Update(GameTime gameTime)
			{

			}

			public void Draw(SpriteBatch spriteBatch, Point location)
			{
				Rectangle destinationRectangle;

				int width = (int)(Scale * (int)Frame.Width);
				int height = (int)(Scale * (int)Frame.Height);
				destinationRectangle = new Rectangle(location.X, location.Y, width, height);

				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
				spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
				spriteBatch.End();
			}
		}
}
