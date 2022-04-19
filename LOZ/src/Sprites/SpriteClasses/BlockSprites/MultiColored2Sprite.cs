using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{ 
	class MultiColored2Sprite : AbstractBlock
	{
		public MultiColored2Sprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.multicolored2Sprite;
		}
		public override void Update(GameTime gameTime) { }
	}
}
