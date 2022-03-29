using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class SolidBlueTileSprite : AbstractBlock
	{

		//-----Constructor-----
		public SolidBlueTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.solidBlueSprite;
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }

	}
}
