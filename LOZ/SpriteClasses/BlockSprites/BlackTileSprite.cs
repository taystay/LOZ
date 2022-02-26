using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class BlackTileSprite : AbstractItemBlockClass
    {
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
