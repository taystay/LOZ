using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{

    class DarkBlueSolidBlockSprite : AbstractBlock
	{
		//-----Constructor-----
		public DarkBlueSolidBlockSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.darkBlueSolidSprite;
		}
		public override void Update(GameTime gameTime)
		{

		}
	}
}
