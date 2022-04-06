using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.BlockSprites
{
    class PortalSprite : ISprite
	{
		private protected Rectangle frame;
		private protected Texture2D _texture;
		private protected int width;
		private protected int height;
		public PortalSprite(Texture2D texture, int direction, int color)
		{
			_texture = texture;
			switch (direction)
			{
				case 0: // up
					if (color == 0) //blue
						frame = new Rectangle(1038, 98, 1068 - 1037, 110 - 97); 
					else
						frame = new Rectangle(1041, 156, 1071 - 1040, 169 - 155);
					width = 48;
					height = (int)(48.0 * ((double)frame.Height / (double)frame.Width));
					break;
				case 1: //right
					if (color == 0)//blue
						frame = new Rectangle(1024, 74, 1036 - 1023, 103 - 73); 
					else
						frame = new Rectangle(1073, 130, 1085 - 1072, 159 - 129);
					height = 48;
					width = (int)(48.0 * ((double)frame.Width / (double)frame.Height));
					break;
				case 2: //down
					if (color == 0)//blue
						frame = new Rectangle(1038, 71, 1067 - 1037, 83 - 70); 
					else
						frame = new Rectangle(1038, 125, 1069 - 1037, 138 - 124);
					width = 48;
					height = (int)(48.0 * ((double)frame.Height / (double)frame.Width));
					break;
				default: //left
					if (color == 0)//blue
						frame = new Rectangle(1070, 77, 1082 - 1070, 106 - 77); 
					else
						frame = new Rectangle(1024, 130, 1036 - 1023, 159 - 129);
					height = 48;
					width = (int)(48.0 * ((double)frame.Width / (double)frame.Height));
					break;
			}

		}
		public void ChangeScale(double d)
        {

        }

		//-----Update frame-----
		public void Update(GameTime gameTime) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.White);

		}
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;
			
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			

			//for SpriteBatch.Begin(...)
			//the paramater idea was from:
			//https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
			//https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();

		}

	}
}
