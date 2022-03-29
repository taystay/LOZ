using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class BlackTileSprite : AbstractBlock
	{
		public BlackTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.blackTileSprite;
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
