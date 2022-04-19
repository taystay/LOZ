using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class StairsBlockSprite : AbstractBlock
	{
		public StairsBlockSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.stairsSprite;
		}
		public override void Update(GameTime gameTime) { }
		}
}
