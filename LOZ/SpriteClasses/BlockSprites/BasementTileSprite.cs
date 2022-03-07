using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class BasementTileSprite : AbstractBlock
	{
		public BasementTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(17, 0, 16, 16);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
