using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.BlockSprites
{
    class BlackTileSprite : AbstractItemBlockClass
    {

		//-----Constructor-----
		public BlackTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(7, 63, 32, 32);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
