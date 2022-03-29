using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class StairsBlockSprite : AbstractBlock
	{

		//-----Constructor-----
		public StairsBlockSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.stairsSprite;
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }

		}
}
