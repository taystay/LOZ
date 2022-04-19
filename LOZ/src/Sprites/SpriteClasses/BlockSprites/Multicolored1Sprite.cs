using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace LOZ.SpriteClasses.BlockSprites
{
	class Multicolored1Sprite : AbstractBlock
	{
		public Multicolored1Sprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.multicolored1Sprite;
		}
		public override void Update(GameTime gameTime) { }


	}
}
