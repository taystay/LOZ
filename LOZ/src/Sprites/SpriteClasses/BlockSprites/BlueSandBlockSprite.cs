using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class BlueSandBlockSprite : AbstractBlock
	{
		//-----Constructor-----
		public BlueSandBlockSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.blueSandBlock;
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
