using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class OverworldTile : ISprite
    {
		private protected Rectangle frame;
		private protected Texture2D _texture;
		private const int width = 48;
		private const int height = 48;
		public OverworldTile(Texture2D texture, int select)
        {
			_texture = texture;
            switch (select)
            {
				case 0://bottom of wall
					frame = new Rectangle(36 - 1, 172 - 1, 16, 16);
					break;
				case 1: //top of wall
					frame = new Rectangle(36 - 1, 155 - 1, 16, 16);
					break;		
				case 2: //sand no coloration
					frame = new Rectangle(2 - 1, 155 - 1, 16, 16);
					break;
				case 3: //top left of tree
					frame = new Rectangle(2 - 1, 206 - 1, 16, 16);
					break;
				case 4: //bottom left tree
					frame = new Rectangle(2 - 1, 223 - 1, 16, 16);
					break;
				case 5: //top right tree
					frame = new Rectangle(36 - 1, 206 - 1, 16, 16);
					break;
				case 6: //bottm right tree
					frame = new Rectangle(36 - 1, 223 - 1, 16, 16);
					break;
				case 7: //center tree
					frame = new Rectangle(19 - 1, 206 - 1, 16, 16);
					break;
				case 8: //bridge
					frame = new Rectangle(18, 222, 16, 16);
					break;
				case 9: //water with dots
					frame = new Rectangle(87 - 1, 172 - 1, 16, 16);
					break;
				default: //water with dots
					frame = new Rectangle(87 - 1, 172 - 1, 16, 16);
					break;
            }
        }
		public void ChangeScale(double scale) { }
		public void Update(GameTime timer) { }
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			destinationRectangle = new Rectangle(location.X - width / 2 , location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}
	}
}
