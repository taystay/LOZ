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
			frame = SpriteStandardizeClass.basementTileSprite;
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
